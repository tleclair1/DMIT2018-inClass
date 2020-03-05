using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DataModels.OrderProcessing;

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
            throw new NotImplementedException();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ShipperSelection> ListShippers()
        {
            // TODO: Implement ListShippers
            throw new NotImplementedException();
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
            // TODO: Implement ShipOrder - Validation of input:
            //      OrderID must exist
            //      Shipper must exist
            //      Must have one or more items to ship
            //      ProductIDs must exist and be valid
            //      Quantities must be greater than 0 and less than the number / qty outstanding on the order
            //      Freight cahrge is either null or a value greater than 0
            // TODO: Add a new Shipment to the database
            // TODO: Add new ManifestItem objects to the new shipment
            throw new NotImplementedException();
        }
        #endregion
    }
}
