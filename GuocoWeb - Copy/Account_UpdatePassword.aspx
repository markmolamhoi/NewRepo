<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account_UpdatePassword.aspx.cs" Inherits="Account_UpdatePassword" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="UserControlLibrary" Namespace="UserControlLibrary.Lamsoon"
    TagPrefix="cc2" %>
<%@ Register Assembly="LSLIBWebBased" Namespace="LSLIBWebBased.LSWebControl" TagPrefix="cc3" %>
<%@ Register Src="ucPageHeader.ascx" TagName="ucPageHeader" TagPrefix="uc5" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change/Reset Password</title>
    <link href="CSS/bootstrap.min.css" type="text/css" rel="stylesheet" />
    <link href="CSS/bootstrap-theme.min.css" type="text/css" rel="stylesheet" />
    <link href="CSS/bootstrap-select.min.css" type="text/css" rel="stylesheet" />

    <script src="js/jquery-1.12.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/bootstrap-select.min.js"></script>


    <link href="CSS/Stylebootstrap.css" type="text/css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container">
            <asp:UpdatePanel ID="upHeader" runat="server">
                <ContentTemplate>
                    <div>
                        <uc5:ucPageHeader ID="ucPageHeader1" runat="server" />

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <asp:Label ID="Label4" runat="server" Text="Change Password" Font-Bold="True"></asp:Label>

                </div>
                <table class="table table-condensed table-hover">
                    <tr>
                        <th class="width20">
                            <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartTextbox ID="txtUsername" runat="server" class="form-control">
                            </cc2:SmartTextbox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Label2" runat="server" Text="Existing Password"></asp:Label>
                        </th>
                        <td colspan="3">
                            <cc2:SmartTextbox ID="txtPassword" runat="server" class="form-control" TextMode="Password">
                            </cc2:SmartTextbox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Label5" runat="server" Text="New Password"></asp:Label>
                        </th>
                        <td colspan="3">
                            <cc2:SmartTextbox ID="txtNewPassword" runat="server" class="form-control" TextMode="Password">
                            </cc2:SmartTextbox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Label8" runat="server" Text="Comfirm New Password"></asp:Label>
                        </th>
                        <td colspan="3">
                            <cc2:SmartTextbox ID="txtNewPassword_Confirm" runat="server" class="form-control" TextMode="Password">
                            </cc2:SmartTextbox>
                        </td>
                    </tr>
                    <tr>
                        <th></th>
                        <td>
                            <asp:Button ID="btnUpdatePassword" runat="server" Text="Change Password" OnClick="btnUpdatePassword_Click" class="btn btn-info" />
                        </td>
                    </tr>
                </table>

            </div>
            <div class="panel panel-primary">

                <div class="panel-heading">
                    <asp:Label ID="lblResetPassword" runat="server" Text="Reset Password" Font-Bold="True"></asp:Label>

                </div>
                <table class="table table-condensed table-hover">
                    <tr>
                        <th class="width20">
                            <asp:Label ID="Label3" runat="server" Text="User Name"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartTextbox ID="txtUsername_Reset" runat="server" class="form-control">
                            </cc2:SmartTextbox>
                        </td>
                    </tr>
                     <tr>
                        <th>
                            <asp:Label ID="Label6" runat="server" Text="Send Verification Code to Email"></asp:Label>
                         </th>
                        <td>
                            <asp:Button ID="btnSend" runat="server" Text="Send verification code" OnClick="btnsend_Click" class="btn btn-info" />
                        </td>
                    </tr>
                     <tr>
                        <th class="width20">
                            <asp:Label ID="Label9" runat="server" Text="Verification Code"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartTextbox ID="txtVerificationCode" runat="server" class="form-control">
                            </cc2:SmartTextbox>
                        </td>
                    </tr>
                    <tr>
                        <th></th>
                        <td>
                            <asp:Button ID="btnResetPassword" runat="server" Text="Get Initial Password" OnClick="btnResetPassword_Click" class="btn btn-info" />
                        </td>
                    </tr>
                    <tr>
                        <th class="width20">
                            <asp:Label ID="Label7" runat="server" Text="Initial Password"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartTextbox ID="txtOrignalPassword" runat="server" class="form-control" ></cc2:SmartTextbox>
                        </td>
                    </tr>
                </table>
            </div>

        </div>
    </form>
</body>
</html>
