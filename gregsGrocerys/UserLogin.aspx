<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="gregsGrocerys.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:ScriptManager ID="SciptManager" runat="server" />

                <asp:UpdatePanel runat="server">

                    <ContentTemplate>
                        <asp:Label ID="lblInfo" runat="server" Text="Enter login details"></asp:Label>


                        <table>
                            <tr>
                                <td>Username:</td>
                                <td>
                                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Password:</td>
                                <td>
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /></td>
                            </tr>
                        </table>
                                                  
                            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" Width="127px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </form>
    </body>
</html>
