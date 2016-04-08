<%@ Page Title="Edit Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="gregsGrocerys.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
     Access Level: <asp:Label ID="lblInfo" runat="server"></asp:Label>
    <div id="topControls">
        <asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"/>
    </div>
    <br />
    <div id="dataEntry1">
        <asp:Label ID="labelID" runat="server" Text="Product ID"></asp:Label>
        <asp:Label ID="lblID" runat="server"></asp:Label>

        <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>

        <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
    </div>
    <br />
    <div id="lineItemList">
        <asp:GridView ID="GridViewNewProduct" runat="server"></asp:GridView>
    </div>
</asp:Content>
