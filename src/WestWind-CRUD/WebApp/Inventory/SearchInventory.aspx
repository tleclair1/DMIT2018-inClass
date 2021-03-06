﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchInventory.aspx.cs" Inherits="WebApp.Inventory.SearchInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="page-header">Search Inventory</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:DropDownList ID="SupplierDropDown" runat="server" AppendDataBoundItems="True" DataSourceID="SupplierDataSource" DataTextField="CompanyName" DataValueField="SupplierID">
                <asp:ListItem Value="0" Text="[Select a supplier...]" />
            </asp:DropDownList>
            <asp:LinkButton ID="SearchBySupplier" Text="Search by Supplier" runat="server" CssClass="btn btn-default"/>
            <asp:ObjectDataSource ID="SupplierDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllSuppliers" TypeName="WestWindSystem.BLL.InventoryController" />
        </div>
        <div class="col-md-4">

        </div>
        <div class="col-md-4">

        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <h2>Inventory</h2>
            <asp:GridView ID="ProductsGridView" runat="server" AutoGenerateColumns="False" DataSourceID="ProductsDataSource" CssClass="table table-hover table-condensed">
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="Product"></asp:BoundField>
                    <asp:BoundField DataField="Supplier" HeaderText="Supplier" SortExpression="Supplier"></asp:BoundField>
                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category"></asp:BoundField>
                    <asp:BoundField DataField="SellingPrice" DataFormatString="{0:C}" HeaderText="Selling Price" SortExpression="SellingPrice"></asp:BoundField>
                    <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="Qty/Unit"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ProductsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListProductsBySupplier" TypeName="WestWindSystem.BLL.InventoryController">
                <SelectParameters>
                    <asp:ControlParameter ControlID="SupplierDropDown" PropertyName="SelectedValue" DefaultValue="" Name="supplierid" Type="Int32"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
