<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="gregsGrocerys._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     Access Level: <asp:Label ID="lblInfo" runat="server"></asp:Label>
        <h2><%: Title %></h2>
    <div id="topControls">
        <asp:Button ID="btnFirst" runat="server" Text="|<" />
        <asp:Button ID="btnPrevious" runat="server" Text="<" />
        <asp:Button ID="btnNew" runat="server" Text="New" />
        <asp:Button ID="btnEdit" runat="server" Text="Edit" />
        <asp:Button ID="btnSave" runat="server" Text="Save" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" />
        <asp:Button ID="btnNext" runat="server" Text=">" />
        <asp:Button ID="btnLast" runat="server" Text=">|" />

    </div>
    <br />
    <div id="dataEntry1">
        <asp:Label ID="lblProductName" runat="server" Text="Product Name:"></asp:Label>
        <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
        
        <asp:Label ID="lblProductQty" runat="server" Text="Qty:"></asp:Label>
        <asp:TextBox ID="txtProductQty" runat="server"></asp:TextBox>
      
        <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
      
        <asp:Label ID="lblSubTotal" runat="server" Text="Subtotal:"></asp:Label>
        <asp:TextBox ID="txtSubTotal" runat="server"></asp:TextBox>
    </div>
    <br />
    <div id="controls">
        <asp:Button ID="btnAddLineItem" runat="server" Text="Add Line Item" />
    </div>
    <br />
    <div id="lineItemList">
        <asp:GridView ID="GridViewNewSale" runat="server"></asp:GridView>
    </div>

</asp:Content>
