<Query Kind="Expression">
  <Connection>
    <ID>9f795fec-6525-43c5-bbd0-2819df27768a</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Display all the company names and contact names for our customers, grouped by country
from row in Customers
group  row   by   row.Address.Country into CustomersByCountry
//    \what/      \       how       /
select new
{
   Country = CustomersByCountry.Key, // the key is "how" we have sorted the data
   Customers = from data in CustomersByCountry
               select new
               {
			       Company = data.CompanyName,
				   Contact = data.ContactName
               }
}

//from row in Customers
//where row.Address.City.StartsWith("M")
//group  row   by   row.Address.City into CustomersByCountry
////    \what/      \       how       /
//where CustomersByCountry.Count() > 2
//select new
//{
//   Country = CustomersByCountry.Key, // the key is "how" we have sorted the data
//   Customers = from data in CustomersByCountry
//               select new
//               {
//			       Company = data.CompanyName,
//				   Contact = data.ContactName
//               }
//}
//
//from row in Customers
//group  row   by  new { country = row.Address.Country, region = row.Address.Region } into CustomersByCountry
////    \what/      \       how       /
//select new
//{
//   Country = CustomersByCountry.Key, // the key is "how" we have sorted the data
//   Customers = from data in CustomersByCountry
//               select new
//               {
//			       Company = data.CompanyName,
//				   Contact = data.ContactName
//               }
//}
