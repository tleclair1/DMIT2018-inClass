<%@ Page Title="Order Processing" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderShipping.aspx.cs" Inherits="WebApp.SandBox.OrderShipping" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="page-header">Order Processing</h1>
            <asp:Label Id="SupplierName" Text="" runat="server" />
            <asp:Label Id="ContactName" Text="" runat="server" />
            <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

            <asp:ListView ID="ShipmentListView" runat="server">
                <ItemTemplate></ItemTemplate>
            </asp:ListView>

            <asp:HiddenField Id="TempSupplier" runat="server" Value="3"/> 
            <asp:ObjectDataSource id="OutstandingOrderDataSource" runat="server" />
        </div>

    </div>
</asp:Content>
