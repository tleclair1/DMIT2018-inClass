﻿<%@ Page Title="Selecetion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductSelection.aspx.cs" Inherits="WebApp.SandBox.ProductSelection" %>

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
            <asp:GridView ID="SourceProductsGridView" runat="server" CssClass="table table-hover table-condensed" AutoGenerateColumns="false" ItemType="WestWindSystem.DataModels.ProductInfo" OnRowCommand="SourceProductsGridView_RowCommand" OnSelectedIndexChanged="SourceProductsGridView_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Name" >
                        <ItemTemplate>
                            <%# Item.Name %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty/Unit" >
                        <ItemTemplate>
                            <%# Item.QuantityPerUnit %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit Price" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <%# Item.Price.ToString("C") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" HeaderText="Action"/>
                </Columns>    
            </asp:GridView>
        </div>
        <div class="col-md-6">
            
        </div>
    </div>
</asp:Content>
