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
    public partial class ProductSelection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var controller = new InventoryController();
                var data = controller.ListActiveProducts();
                SourceProductsGridView.DataSource = data;
                SourceProductsGridView.DataBind();

                AveragePrice.Text = SetAveragePrice(SourceProductsGridView);
            }
        }

        protected void SourceProductsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Select")
            {
                //MessageUserControl.ShowInfo("A select button was clicked");
            }
        }

        protected void SourceProductsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string message = $"The item at index {SourceProductsGridView.SelectedIndex} was selected";
            GridViewRow row = SourceProductsGridView.Rows[SourceProductsGridView.SelectedIndex];
            Label name = row.FindControl("ProductName") as Label;
            Label quantity = row.FindControl("Qty") as Label;
            Label price = row.FindControl("Price") as Label;
            if (name != null && quantity != null  && price != null)
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
            var products = GetExistingProducts(DestinationGridView);
            products.Add(info);

            DestinationGridView.DataSource = products;
            DestinationGridView.DataBind();

            // remove the item from the source gridview
            var existing = GetExistingProducts(SourceProductsGridView);
            existing.RemoveAt(SourceProductsGridView.SelectedIndex);
            SourceProductsGridView.DataSource = existing;
            SourceProductsGridView.DataBind();

            AveragePrice.Text = SetAveragePrice(SourceProductsGridView);
            OtherAveragePrice.Text = SetAveragePrice(DestinationGridView);
        }

        private string SetAveragePrice(GridView aTypeOfGridView)
        {
            var row = GetExistingProducts(aTypeOfGridView);
            decimal result = 0;

            foreach (var item in row)
            {
                result += item.Price;
            }

            var average = result / aTypeOfGridView.Rows.Count;

            return average.ToString("C");
        }

        private List<ProductInfo> GetExistingProducts(GridView aProductGridView)
        {
            List<ProductInfo> result = new List<ProductInfo>();

            foreach(GridViewRow row in aProductGridView.Rows)
            {
                result.Add(ExtractProduct(row));
            }

            return result;
        }

        private ProductInfo ExtractProduct(GridViewRow row)
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

        protected void DestinationGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = DestinationGridView.Rows[DestinationGridView.SelectedIndex];
            Label name = row.FindControl("ProductName") as Label;
            Label quantity = row.FindControl("Qty") as Label;
            Label price = row.FindControl("Price") as Label;

            var info = new ProductInfo
            {
                Name = name.Text,
                QuantityPerUnit = quantity.Text,
                Price = decimal.Parse(price.Text, System.Globalization.NumberStyles.Currency)
            };
            ; // just for breakpoint

            var products = GetExistingProducts(SourceProductsGridView);
            products.Add(info);

            SourceProductsGridView.DataSource = products;
            SourceProductsGridView.DataBind();

            // remove the item from the source gridview
            var existing = GetExistingProducts(DestinationGridView);
            existing.RemoveAt(DestinationGridView.SelectedIndex);
            DestinationGridView.DataSource = existing;
            DestinationGridView.DataBind();

            OtherAveragePrice.Text = SetAveragePrice(DestinationGridView);
            AveragePrice.Text = SetAveragePrice(SourceProductsGridView);
        }
    }
}