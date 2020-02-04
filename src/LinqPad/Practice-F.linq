<Query Kind="Expression">
  <Connection>
    <ID>9f795fec-6525-43c5-bbd0-2819df27768a</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//F) List all the region and territory names as an "object graph" - use a nested query
from data in Regions
select new
{
   Region = data.RegionDescription,
   Territory =  from item in data.Territories
   				select item.TerritoryDescription
}