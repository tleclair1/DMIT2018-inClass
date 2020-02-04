<Query Kind="Expression">
  <Connection>
    <ID>9f795fec-6525-43c5-bbd0-2819df27768a</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//E) List all the region and territory names in a "flat" list
from data in Territories
select new
{
   Territory = data.TerritoryDescription,
   Region = data.Region.RegionDescription
}