<%@ Page Title="New Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewProduct.aspx.cs" Inherits="gregsGrocerys.NewProduct" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
     Access Level: <asp:Label ID="lblInfo" runat="server"></asp:Label>
    <div id="topControls">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </div>
    <br />
    <div id="dataEntry1">
        <asp:Label ID="labelID" runat="server" Text="Product ID"></asp:Label>
        <asp:Label ID="lblID" runat="server"></asp:Label>
        <br/>
        <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
    </div>
    <br />
    <div id="lineItemList">
        <asp:GridView ID="GridViewNewProduct" runat="server"></asp:GridView>
    </div>
</asp:Content>
