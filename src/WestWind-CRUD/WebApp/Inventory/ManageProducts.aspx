﻿<%@ Page Title="Product Manager" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="WebApp.Inventory.ManageProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="page-header">Manage Products</h1>
        </div>
        <div class="col-md-12">
            <asp:label ID="MessageLabel" runat="server"></asp:label>
            <asp:GridView runat="server" ID="ProductInventoryGridView" DataSourceID="ProductInventoryDataSource" AutoGenerateColumns="False" CssClass="table table-hover table-condensed" DataKeyNames="ProductID">
                <Columns>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
                    <asp:BoundField DataField="ProductName" HeaderText="Name" SortExpression="ProductName"></asp:BoundField>


                    <asp:TemplateField HeaderText="Supplier">
                        <ItemTemplate>
                            <asp:DropDownList ID="SupplierDropDown" runat="server" DataSourceID="SupplierDataSource" DataTextField="CompanyName" DataValueField="SupplierID" SelectedValue='<%# Eval("SupplierID") %>'></asp:DropDownList>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="SupplierDropDown" runat="server" DataSourceID="SupplierDataSource" DataTextField="CompanyName" DataValueField="SupplierID" SelectedValue='<%# Bind("SupplierID") %>'></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="CategoryID" HeaderText="Category" SortExpression="CategoryID"></asp:BoundField>
                    <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty/Unit" SortExpression="QuantityPerUnit"></asp:BoundField>
                    <asp:BoundField DataField="MinimumOrderQuantity" HeaderText="Min Order" SortExpression="MinimumOrderQuantity"></asp:BoundField>
                    <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" SortExpression="UnitPrice" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                    <asp:BoundField DataField="UnitsOnOrder" HeaderText="Qty On Order" SortExpression="UnitsOnOrder" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                    <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" ItemStyle-HorizontalAlign="Center"></asp:CheckBoxField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource runat="server" ID="ProductInventoryDataSource" OldValuesParameterFormatString="original_{0}" OnDeleted="ProductInventoryDataSource_Deleted" OnDeleting="ProductInventoryDataSource_Deleting" SelectMethod="ListAllProducts" TypeName="WestWindSystem.BLL.InventoryController" DataObjectTypeName="WestWindSystem.Entities.Product" DeleteMethod="DeleteProduct" UpdateMethod="UpdateProducts" />
            <asp:ObjectDataSource ID="SupplierDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllSuppliers" TypeName="WestWindSystem.BLL.InventoryController"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>