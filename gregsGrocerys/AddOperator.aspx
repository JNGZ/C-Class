<%@ Page Title="Add Operator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddOperator.aspx.cs" Inherits="gregsGrocerys.AddOperator" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server"> <ContentTemplate>
    <h2><%: Title %></h2>
        Access Level: <asp:Label ID="lblInfo" runat="server"></asp:Label>
    <div id="topControls">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </div>
    <br />
    <asp:Label ID="lblUserAddPrompt" runat="server" BackColor="GreenYellow"></asp:Label>
    <div id="dataEntry1">
        <asp:Label ID="lblOpSales" runat="server" Text="Sales Permissions"></asp:Label>
        <asp:CheckBox ID="CheckBoxOpSales" runat="server"  />
        <br />
        <asp:Label ID="lblOpAdmin" runat="server" Text="Admin Permissions"></asp:Label>
        <asp:CheckBox ID="CheckBoxOpAdmin" runat="server" />

        <br />
        <asp:Label ID="labelOpID" runat="server" Text="Operator ID"></asp:Label>
        <asp:Label ID="lblOpID" runat="server"></asp:Label>

        <asp:Label ID="lblOperatorName" runat="server" Text="Operator Name:"></asp:Label>
        <asp:TextBox ID="txtOperatorName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblOperatorPin" runat="server" Text="Operator Pin:"></asp:Label>
        <asp:TextBox ID="txtOperatorPin" runat="server"></asp:TextBox>


    </div>
    <br />
    <div id="lineItemList">
        <asp:GridView ID="GridViewNewProduct" runat="server"></asp:GridView>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
