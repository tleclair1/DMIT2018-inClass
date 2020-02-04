<Query Kind="Expression">
  <Connection>
    <ID>9f795fec-6525-43c5-bbd0-2819df27768a</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//D) List all the regions and the number of territories in each region

from data in Regions
select new 
{
	Region = data.RegionDescription,
	TerritoryCount = data.Territories.Count()
}