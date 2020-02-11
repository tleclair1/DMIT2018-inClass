<Query Kind="Statements">
  <Connection>
    <ID>97af8c69-3651-48ba-b2ef-4102220d2d4c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

/* Aggregate func.
	- Count()
	- Sum()
	- Average()
	- Min()
	- Max()
*/
// 1) Date of the most recent order
var mostRecent = Orders.Max(anOrder => anOrder.OrderDate);
mostRecent.Dump("Date of the most recent order");

// 2) Cheapest selling price of all the products we sell
var cheapestProduct = Products.Min(aProduct => aProduct.UnitPrice);
cheapestProduct.ToString("C").Dump("Cheapest selling price of all the products");

// 3) How much has the company received in payments?
var total = Payments.Sum(aPayment => aPayment.Amount);
total.ToString("C").Dump("How much has the company received in payments");

// 4) For the most recent order, what is the total of all items sold on that order?
var info = 	from order in Orders
			where order.OrderDate == mostRecent
			select order;
var info2 = from details in info
			select details.OrderDetails.Sum(x => x.UnitPrice * (decimal)(1 - x.Discount) * x.Quantity);
info2.Dump("Total of all items sold on most recent orders");
// 5) What is the average of all orders?
var orderAverage = Orders.Average(orderSum => orderSum.OrderDetails.Sum(x => x.UnitPrice * (decimal)(1 - x.Discount) * x.Quantity));
orderAverage.ToString("C").Dump("The average of all orders");
// 6) Who has been working at the company the longest?
var item = Employees.Where(row => (row.HireDate == Employees.Min(x => x.HireDate)) && row.Active == true).Select(y => y.FirstName + " " + y.LastName); 
item.Dump();
