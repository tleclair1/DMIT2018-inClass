<Query Kind="Program">
  <Connection>
    <ID>49bfd87d-1cde-4668-84c3-21e739a66fae</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

void Main()
{
	//List all the categories and the products per category
	//We need the name, description, and picture of the categories
	//We need the name, quantity/unti, and price of the products
	var result = 	from data in Categories
					select new CategorizedProducts
					{
						Name = data.CategoryName,
						Description = data.Description,
						Picture = data.Picture.ToArray(),
						Products = 	from item in data.Products
									select new ProductInfo
									{
										Name = item.ProductName,
										QuantityPerUnit = item.QuantityPerUnit,
										Price = item.UnitPrice
									}
					};
	result.Dump();
}

// Define other methods and classes here
public class ProductInfo //POCO class (Plain Old CLR Object)
{
	public string Name { get; set; }
	public string QuantityPerUnit { get; set; }
	public decimal Price { get; set; }
}

public class CategorizedProducts //DTO class (Data Transfer Object)
{
	public string Name { get; set; }
	public string Description { get; set; }
	public byte[] Picture { get; set; }
	public IEnumerable<ProductInfo> Products { get; set; }
}