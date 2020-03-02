<%@ Page Title="Selecetion (ListView)" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductSelection2.aspx.cs" Inherits="WebApp.SandBox.ProductSelection2" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="page-haeder">Product Selecetion (ListView)</h1>
            <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <asp:ListView ID="AvailableProductsListView" runat="server" OnSelectedIndexChanged="AvailableProductsListView_SelectedIndexChanged" ItemType="WestWindSystem.DataModels.ProductInfo">
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label ID="ProductName" Text="<%# Item.Name %>" runat="server" /></td>
                        <td>
                            <asp:Label ID="Qty" Text="<%# Item.QuantityPerUnit %>" runat="server" /></td>
                        <td>
                            <asp:Label ID="Price" Text='<%# Item.Price.ToString("C") %>' runat="server" /></td>
                        <td>
                            <asp:LinkButton ID="AddProduct" runat="server" CommandName="Select" Text="Add" /></td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" class="table table-hover table-condensed">
                                    <tr runat="server" style="">
                                        <th runat="server">Product</th>
                                        <th runat="server">Qty/Unit</th>
                                        <th runat="server">Unit Price</th>
                                        <th runat="server">Action</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                                <asp:DataPager runat="server" ID="DataPager1">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                        <asp:NumericPagerField></asp:NumericPagerField>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
        <div class="col-md-6">
            <asp:ListView ID="DestinationProductsListView" runat="server" OnSelectedIndexChanged="DestinationProductsListView_SelectedIndexChanged" ItemType="WestWindSystem.DataModels.ProductInfo">
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label ID="ProductName" Text="<%# Item.Name %>" runat="server" /></td>
                        <td>
                            <asp:Label ID="Qty" Text="<%# Item.QuantityPerUnit %>" runat="server" /></td>
                        <td>
                            <asp:Label ID="Price" Text='<%# Item.Price.ToString("C") %>' runat="server" /></td>
                        <td>
                            <asp:LinkButton ID="AddProduct" runat="server" CommandName="Select" Text="Add" /></td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" class="table table-hover table-condensed">
                                    <tr runat="server" style="">
                                        <th runat="server">Product</th>
                                        <th runat="server">Qty/Unit</th>
                                        <th runat="server">Unit Price</th>
                                        <th runat="server">Action</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                                <asp:DataPager runat="server" ID="DataPager1">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                        <asp:NumericPagerField></asp:NumericPagerField>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
