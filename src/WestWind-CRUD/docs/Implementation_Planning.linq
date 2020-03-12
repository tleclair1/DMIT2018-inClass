<Query Kind="Expression">
  <Connection>
    <ID>562b6ed9-44f7-43b9-9947-1140f7e35b08</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Find all the Orders that have quantities of items that have
// not yet been shipped.

//from item in OrderDetails
//where item.Quantity > (from ship in item.Order.Shipments
//					   from sent in ship.ManifestItems
//					   where sent.ProductID == item.ProductID
//					   select (int)sent.ShipQuantity).Sum()
//select item.OrderID

//from item in Orders
//where item.OrderDetails.Any(x => x.Quantity > 0) && !item.Shipments.Any()
//select item.OrderID


// Find all the Suppliers that provide products for Order # 11077

//from item in OrderDetails
//where item.OrderID == 11077
//select new 
//{
//	item.Product.ProductName,
//	item.Product.Supplier.CompanyName,
//	item.Product.SupplierID
//}
// I see that I can use SupplierIDs of 3 and 12. So, find what other
// Orders have items from those suppliers

(
from item in OrderDetails
where item.Product.SupplierID == 3 || item.Product.SupplierID == 12
select new { item.OrderID, item.Product.SupplierID }
).Distinct()
// I found orders 11072 && 11076