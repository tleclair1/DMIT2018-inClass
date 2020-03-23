using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WestWindSystem.BLL;
using WestWindSystem.DataModels.OrderProcessing;

namespace WebApp.SandBox
{
    public partial class OrderShipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShipmentsListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Ship")
            {
                // Gather information from the form to send to the BLL for shipping
                // - ShipOrder(int)\
                int orderId = 0;
                Label orderIdLabel = e.Item.FindControl("OrderIdLabel") as Label;
                if (orderIdLabel != null)
                {
                    orderId = int.Parse(orderIdLabel.Text);

                    ShippingDirections shipInfo = new ShippingDirections();
                    DropDownList shipViaDropDown = e.Item.FindControl("ShipperDropDown") as DropDownList;
                    if (shipViaDropDown != null)
                    {
                        shipInfo.ShipperID = int.Parse(shipViaDropDown.SelectedValue);
                    }

                    TextBox tracking = e.Item.FindControl("TrackingCode") as TextBox;
                    if (tracking != null)
                    {
                        shipInfo.TrackingCode = tracking.Text;
                    }

                    decimal price;
                    TextBox freight = e.Item.FindControl("FreightCharge") as TextBox;
                    if (freight != null && decimal.TryParse(freight.Text, out price))
                    {
                        shipInfo.FreightCharge = price;
                    }

                    List<ProductShipment> goods = new List<ProductShipment>();
                    GridView gv = e.Item.FindControl("ProductsGridView") as GridView;
                    if (gv != null)
                    {
                        foreach (GridViewRow row in gv.Rows)
                        {
                            HiddenField prodId = row.FindControl("ProductId") as HiddenField;
                            TextBox qty = row.FindControl("ShipQuantity") as TextBox;
                            short quantity;
                            if (prodId != null && qty != null && short.TryParse(qty.Text, out quantity))
                            {
                                ProductShipment item = new ProductShipment
                                {
                                    ProductID = int.Parse(prodId.Value),
                                    Quantity = quantity
                                };

                                goods.Add(item);
                            }
                        }
                    }

                    MessageUserControl.TryRun(() =>
                    {
                        var controller = new OrderProcessingController();
                        controller.ShipOrder(orderId, shipInfo, goods);
                    }, "Order shipment recorded", "The products identified as shipped are recorded in the database");
                }
            }
        }
    }
}