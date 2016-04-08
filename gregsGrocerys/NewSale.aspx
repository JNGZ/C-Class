<%@ Page Title="New Sale" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewSale.aspx.cs" Inherits="gregsGrocerys.NewSale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
     Access Level: <asp:Label ID="lblInfo" runat="server"></asp:Label>
    <br />
    Operator ID: <asp:Label ID="lblUserID" runat="server" ></asp:Label>
    <br />
    Sale ID:<asp:Label ID="lblSaleID" runat="server" Text=""></asp:Label>
    <br />
    Line Item ID:<asp:Label ID="lblLineItemID" runat="server" Text=""></asp:Label>

    <div id="topControls">
        <asp:CheckBox ID="completeBox" runat="server" />
        <asp:Button ID="btnAddLineItem" runat="server" Text="Add Line Item" OnClick="btnAddLineItem_Click" />
    </div>
    <br />
    <asp:UpdatePanel ID="fgsfds" runat="server">
        <ContentTemplate>
            <div id="dataEntry1">
                <asp:Label ID="lblProductDescription" runat="server" Text="Product Description"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
              
                <asp:Label ID="lblProductPrice" runat="server" Text="Product Price"></asp:Label>
                <asp:TextBox ID="txtSalePrice" runat="server"></asp:TextBox>
              
                  <asp:Label ID="lblProductQty" runat="server" Text="QTY:"></asp:Label>
                <asp:TextBox ID="txtSaleQty" runat="server"></asp:TextBox>

                <asp:Label ID="lblSubtoal" runat="server" Text="Subtotal:"></asp:Label>
                <asp:TextBox ID="txtSubtotal" runat="server"></asp:TextBox>
            </div>
            <br />
            <div id="lineItemList">
                <asp:GridView ID="LineItemGrid" runat="server"></asp:GridView>

            </div>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
