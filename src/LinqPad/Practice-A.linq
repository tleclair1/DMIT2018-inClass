<Query Kind="Expression">
  <Connection>
    <ID>9f795fec-6525-43c5-bbd0-2819df27768a</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//A) List all the customer company names for those with more than 5 orders.
	from data in Customers
	where data.Orders.Count() > 5
	select data.CompanyName
