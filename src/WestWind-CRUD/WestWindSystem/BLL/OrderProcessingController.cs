using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.DataModels.OrderProcessing;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    [DataObject]
    public class OrderProcessingController
    {
        #region Query Methods
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<OutstandingOrder> LoadOrders(int supplierID)
        {
            // TODO: Implement LoadOrders
            using (var context = new WestWindContext())
            {
                var result = from ord in context.Orders
                             where !ord.Shipped //Still items to be shipped
                                && ord.OrderDate.HasValue // The order has been placed and is ready to ship
                             select new
                             {
                                 OrderId = ord.OrderID,
                                 ShipToName = ord.ShipName,
                                 OrderDate = ord.OrderDate.Value,
                                 RequiredBy = ord.RequiredDate.Value,
                                 // Note to self:
                                 // If there is a ShipTo address, use that, otherwise use the customer address
                                 ShipTo = ord.ShipAddressID.HasValue
                                       ? ord.Address
                                       : ord.Customer.Address,
                                 Comments = ord.Comments,
                                 OutstandingItems =
                                    from detail in ord.OrderDetails
                                    where detail.Product.SupplierID == supplierID
                                    select new
                                    {
                                        ProductId = detail.ProductID,
                                        ProductName = detail.Product.ProductName,
                                        Qty = detail.Quantity,
                                        QtyPerUnit = detail.Product.QuantityPerUnit,
                                        ShippedQtys = (from ship in detail.Order.Shipments
                                                       from item in ship.ManifestItems
                                                       where item.ProductID == detail.ProductID
                                                       select item.ShipQuantity)
                                    }
                             };
                var nextResult = from item in result
                                 select new OutstandingOrder // create a new instance of the DTO
                                 {
                                     OrderID = item.OrderId,
                                     ShipToName = item.ShipToName,
                                     OrderedDate = item.OrderDate,
                                     RequiredDate = item.RequiredBy,
                                     FullShippingAddress = item.ShipTo.Address1 + Environment.NewLine +
                                                         item.ShipTo.City + Environment.NewLine +
                                                         item.ShipTo.Region + " " +
                                                         item.ShipTo.Country + ", " +
                                                         item.ShipTo.PostalCode,
                                     Comments = item.Comments,

                                     OutstandingItems = from detail in item.OutstandingItems
                                                        select new ProductSummary
                                                        {
                                                            ProductID = detail.ProductId,
                                                            ProductName = detail.ProductName,
                                                            Quantity = detail.Qty,
                                                            QtyPerUnit = detail.QtyPerUnit,
                                                            OutstandingQty = detail.ShippedQtys.Count() > 0
                                                                    ? detail.Qty - detail.ShippedQtys.Cast<int>().Sum()
                                                                    : detail.Qty
                                                        }
                                 };
                var finalResult = nextResult.Where(x => x.OutstandingItems.Count() > 0);
                return finalResult.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ShipperSelection> ListShippers()
        {
            using (var context = new WestWindContext())
            {
                var results = from company in context.Shippers
                              select new ShipperSelection
                              {
                                  Name = company.CompanyName,
                                  ShipperID = company.ShipperID
                              };
                return results.ToList();
            }
        }

        public SupplierSummary GetSupplier(int supplierID)
        {
            // TODO: Implement GetSupplier
            throw new NotImplementedException();
        }
        #endregion

        #region Command Methods
        public void ShipOrder(int orderID, ShippingDirections directions, List<ProductShipment> items)
        {
            if (directions == null) throw new ArgumentNullException("No shipping directions provided.");

            if (items == null) throw new ArgumentNullException("No shipment items were provided.");

            using (var context = new WestWindContext())
            {
                // TODO: Implement ShipOrder - Validation of input:
                //      OrderID must exist
                var violations = new List<Exception>();

                var existingOrder = context.Orders.Find(orderID);
                if (existingOrder == null)
                    violations.Add(new Exception("Order does not exist"));
                else
                {
                    if (existingOrder.Shipped)
                        violations.Add(new Exception("This order has already been completed."));
                    if (!existingOrder.OrderDate.HasValue)
                        violations.Add(new Exception("This order is not ready to be shipped (no order date has been specified)."));
                }

                //      Shipper must exist
                var shipper = context.Shippers.Find(directions.ShipperID);
                if (shipper == null)
                    violations.Add(new Exception("Invalid shipper ID."));

                //      Freight cahrge is either null or a value greater than 0
                if (directions.FreightCharge.HasValue && directions.FreightCharge <= 0)
                    violations.Add(new Exception("Freight charge must be either a positive value or no charge"));

                //      Must have one or more items to ship
                if (!items.Any())
                    violations.Add(new Exception("No products identified for shipping."));

                foreach (var item in items)
                {
                    if (item == null) 
                        violations.Add(new Exception("Blank item listed in the products to be shipped."));
                    else
                    {
                        //      ProductIDs must exist and be valid
                        if (!existingOrder.OrderDetails.Any(x => x.ProductID == item.ProductID))
                            violations.Add(new Exception($"The product {item.ProductID} does not exist on the order."));
                        //      Quantities must be greater than 0 and less than the number / qty outstanding on the order
                    }
                }

                if (violations.Any())
                {
                    throw new BusinessRuleException(nameof(ShipOrder), violations);
                }

                // TODO: Add a new Shipment to the database
                var ship = new Shipment
                {
                    OrderID = orderID,
                    ShipVia = directions.ShipperID,
                    TrackingCode = directions.TrackingCode,
                    FreightCharge = directions.FreightCharge.HasValue ? directions.FreightCharge.Value : 0,
                    ShippedDate = DateTime.Now
                };

                // TODO: Add new ManifestItem objects to the new shipment
                foreach (var item in items)
                {
                    ship.ManifestItems.Add(new ManifestItem
                    {
                        ProductID = item.ProductID,
                        ShipQuantity = item.Quantity
                    });
                }

                var quantities = from detail in existingOrder.OrderDetails
                                 select new ShipmentItemComparison
                                 {
                                     ProductID = detail.ProductID,
                                     ExpectedQuantity = (int)detail.Quantity,
                                     ShipQuantity = (from sent in detail.Product.ManifestItems
                                                     where sent.Shipment.OrderID == orderID
                                                     select (int)sent.ShipQuantity).Sum()
                                 };

                foreach (var toShip in items)
                {
                    quantities.Single(x => x.ProductID == toShip.ProductID).ShipQuantity += (int)toShip.Quantity;
                }

                if (quantities.All(x => x.ShipQuantity == x.ExpectedQuantity))
                {
                    existingOrder.Shipped = true;
                    context.Entry(existingOrder).Property(x => x.Shipped).IsModified = true;
                }

                // TODO: Check if the order is complete; If so, update Order.Shipped

                // Add
                context.Shipments.Add(ship);

                // Save
                context.SaveChanges();

            }
            
            throw new NotImplementedException();
        }
        #endregion
    }
}
