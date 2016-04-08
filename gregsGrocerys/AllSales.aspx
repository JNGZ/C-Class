<%@ Page Title="All Sales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllSales.aspx.cs" Inherits="gregsGrocerys.AllSales" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
     Access Level: <asp:Label ID="lblInfo" runat="server"></asp:Label>
    <div id="topControls">

    </div>
    <br />
    <div id="gridViewAllSales">
        <asp:GridView ID="GridViewAllSales" runat="server" OnSelectedIndexChanged="GridViewAllSales_SelectedIndexChanged" CellPadding="5">
             <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        </asp:GridView>
    </div>
</asp:Content>
