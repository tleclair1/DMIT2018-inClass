using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WestWindSystem.BLL;
using WestWindSystem.DataModels;

namespace WebApp.SandBox
{
    public partial class ProductSelection2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var controller = new InventoryController();
            var data = controller.ListActiveProducts();
            AvailableProductsListView.DataSource = data;
            AvailableProductsListView.DataBind();
        }

        protected void AvailableProductsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewDataItem thing in AvailableProductsListView.Items)
            {

            }

            string message = $"The item at index {AvailableProductsListView.SelectedIndex} was selected";
            ListViewItem item = AvailableProductsListView.Items[AvailableProductsListView.SelectedIndex];
            Label name = item.FindControl("ProductName") as Label;
            Label quantity = item.FindControl("Qty") as Label;
            Label price = item.FindControl("Price") as Label;
            if (name != null && quantity != null && price != null)
            {
                message += $"<br>The product name is {name.Text} and sells at {price.Text} for {quantity.Text}.";
            }
            else
            {
                message += "<b>Error: </b> Problem parsing the contents of row";
            }

            MessageUserControl.ShowInfo(message);

            var info = new ProductInfo
            {
                Name = name.Text,
                QuantityPerUnit = quantity.Text,
                Price = decimal.Parse(price.Text, System.Globalization.NumberStyles.Currency)
            };
            ; // just for breakpoint
            var products = GetExistingProducts(DestinationProductsListView);
            products.Add(info);

            DestinationProductsListView.DataSource = products;
            DestinationProductsListView.DataBind();

            // remove the item from the source gridview
            var existing = GetExistingProducts(AvailableProductsListView);
            existing.RemoveAt(AvailableProductsListView.SelectedIndex);
            AvailableProductsListView.DataSource = existing;
            AvailableProductsListView.DataBind();
        }

        private List<ProductInfo> GetExistingProducts(ListView aProductGridView)
        {
            List<ProductInfo> result = new List<ProductInfo>();

            foreach (ListViewDataItem row in aProductGridView.Items)
            {
                result.Add(ExtractProduct(row));
            }

            return result;
        }

        private ProductInfo ExtractProduct(ListViewDataItem row)
        {
            Label name = row.FindControl("ProductName") as Label;
            Label quantity = row.FindControl("Qty") as Label;
            Label price = row.FindControl("Price") as Label;

            var info = new ProductInfo
            {
                Name = name.Text,
                QuantityPerUnit = quantity.Text,
                Price = decimal.Parse(price.Text, System.Globalization.NumberStyles.Currency)
            };

            return info;
        }

        protected void DestinationProductsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = DestinationProductsListView.Items[DestinationProductsListView.SelectedIndex];
            Label name = item.FindControl("ProductName") as Label;
            Label quantity = item.FindControl("Qty") as Label;
            Label price = item.FindControl("Price") as Label;

            var info = new ProductInfo
            {
                Name = name.Text,
                QuantityPerUnit = quantity.Text,
                Price = decimal.Parse(price.Text, System.Globalization.NumberStyles.Currency)
            };
            ; // just for breakpoint
            var products = GetExistingProducts(AvailableProductsListView);
            products.Add(info);

            AvailableProductsListView.DataSource = products;
            AvailableProductsListView.DataBind();

            // remove the item from the source gridview
            var existing = GetExistingProducts(DestinationProductsListView);
            existing.RemoveAt(DestinationProductsListView.SelectedIndex);
            DestinationProductsListView.DataSource = existing;
            DestinationProductsListView.DataBind();
        }
    }
}