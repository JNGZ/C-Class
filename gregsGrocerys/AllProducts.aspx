<%@ Page Title="All Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllProducts.aspx.cs" Inherits="gregsGrocerys.AllProducts" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
     Access Level: <asp:Label ID="lblInfo" runat="server"></asp:Label>
    <br />



    <div id="gridViewAllProducts">
                <asp:GridView ID="GridViewAllProducts" runat="server" OnSelectedIndexChanged="GridViewAllProducts_SelectedIndexChanged" CellPadding="5">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
               </asp:GridView>
    </div>

</asp:Content>
