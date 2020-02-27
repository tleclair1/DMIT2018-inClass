<%@ Page Title="Selecetion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductSelection.aspx.cs" Inherits="WebApp.SandBox.ProductSelection" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="page-haeder">Product Selecetion</h1>
            <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <asp:Label id="label1" Text="Average Price:" runat="server" />
            <asp:Label id="AveragePrice" Text="" runat="server" /><br />
            <asp:GridView ID="SourceProductsGridView" runat="server" CssClass="table table-hover table-condensed" AutoGenerateColumns="false" ItemType="WestWindSystem.DataModels.ProductInfo" OnRowCommand="SourceProductsGridView_RowCommand" OnSelectedIndexChanged="SourceProductsGridView_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Name" >
                        <ItemTemplate>
                            <asp:Label id="ProductName" Text="<%# Item.Name %>" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty/Unit" >
                        <ItemTemplate>
                            <asp:Label id="Qty" Text="<%# Item.QuantityPerUnit %>" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit Price" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label id="Price" Text='<%# Item.Price.ToString("C") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" HeaderText="Action"/>
                </Columns>    
            </asp:GridView>
        </div>
        <div class="col-md-6">
            <asp:Label id="label2" Text="Average Price:" runat="server" />
            <asp:Label id="OtherAveragePrice" Text="" runat="server" /><br />
            <asp:GridView ID="DestinationGridView" runat="server" CssClass="table table-hover table-condensed" AutoGenerateColumns="false" ItemType="WestWindSystem.DataModels.ProductInfo" OnRowCommand="SourceProductsGridView_RowCommand" OnSelectedIndexChanged="DestinationGridView_SelectedIndexChanged">
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Remove" HeaderText="Action"/>
                    <asp:TemplateField HeaderText="Name" >
                        <ItemTemplate>
                            <asp:Label id="ProductName" Text="<%# Item.Name %>" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty/Unit" >
                        <ItemTemplate>
                            <asp:Label id="Qty" Text="<%# Item.QuantityPerUnit %>" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit Price" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label id="Price" Text='<%# Item.Price.ToString("C") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>    
            </asp:GridView>
        </div>
    </div>
</asp:Content>
