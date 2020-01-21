using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.DataModels;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    [DataObject] // Allows this class to be a "source" for databound controls
    public class InventoryController
    {
        #region Supplier CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Supplier> ListAllSuppliers()
        {
            using (var context = new WestWindContext())
            {
                return context.Suppliers.ToList();
            }
        }
        #endregion

        #region Category CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Category> ListAllCategories()
        {
            using (var context = new WestWindContext())
            {
                return context.Categories.ToList();
            }
        }
        #endregion

        #region Products - Queries
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ProductSummary> ListProductsBySupplier(int supplierid)
        {
            using (var context = new WestWindContext())
            {
                // Using a LINQ query to get the products by supplier
                var result = from item in context.Products
                             where item.SupplierID == supplierid
                             select new ProductSummary
                             {
                                 ProductName = item.ProductName,
                                 Supplier = item.Supplier.CompanyName,
                                 Category = item.Category.CategoryName,
                                 SellingPrice = item.UnitPrice,
                                 QuantityPerUnit = item.QuantityPerUnit
                             };
                return result.ToList();
            }
        }
        #endregion

        #region Products CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Product> ListAllProducts()
        {
            using (var context = new WestWindContext())
            {
                // Get the Product information along with the supplier and category information for each Product
                return context.Products.Include(nameof(Product.Supplier)).Include(nameof(Product.Category)).ToList();
            }// Exiting the using block will "dispose" of the context object
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void InsertProduct(Product info)
        {
            using (var context = new WestWindContext())
            {
                context.Products.Add(info);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateProduct(Product info)
        {
            using (var context = new WestWindContext())
            {
                var existing = context.Entry(info);
                existing.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteProduct(Product info)
        {
            using (var context = new WestWindContext())
            {
                var found = context.Products.Find(info.ProductID);
                context.Products.Remove(found);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
