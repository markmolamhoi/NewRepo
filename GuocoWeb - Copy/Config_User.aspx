﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Config_User.aspx.cs" Inherits="Config_User" %>

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
    <title></title>
    <link href="CSS/bootstrap.min.css" type="text/css" rel="stylesheet" />
    <link href="CSS/bootstrap-theme.min.css" type="text/css" rel="stylesheet" />
    <link href="CSS/bootstrap-select.min.css" type="text/css" rel="stylesheet" />

    <script src="js/jquery-1.12.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/bootstrap-select.min.js"></script>
    <script src="js/LIBLocal.js"></script>


    <link href="CSS/Stylebootstrap.css" type="text/css" rel="stylesheet" />
    <link href="CSS/LIBLocal.css" type="text/css" rel="stylesheet" />
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
            <div class="panel panel-primary">

                <table class="table table-condensed table-hover">

                    <tr>
                        <th class="width20">
                            <asp:Label ID="Label8" runat="server" Text="Company Code:"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartDropDownList ID="DDLCompanyCode" runat="server" CssClass="selectpicker selectwidthauto" AutoPostBack="true" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged">
                            </cc2:SmartDropDownList>
                            <asp:Label ID="lblCompanyCode" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Label2" runat="server" Text="Division Code:"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartDropDownList ID="ddlDivisionCode" runat="server" CssClass="selectpicker selectwidthauto">
                            </cc2:SmartDropDownList>
                            <asp:Label ID="lblDivisionCode" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Label2a" runat="server" Text="SearchKey"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartTextbox ID="txtSearchKey" runat="server" class="form-control"></cc2:SmartTextbox>
                            <asp:Label ID="lblSearch" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th></th>

                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" class="btn btn-info" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblPrintSql" runat="server" Text="" visible ="false"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="upDetail" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnInsert" runat="server" Text="Add User Profile" OnClick="btnInsert_AddUserProfile_Click" class="btn btn-info" />

               <%-- <br />--%>
                <div id="divCoverLayer" runat="server">
                </div>

                <div id="divGridView" runat="server">
                    <asp:Label ID="lblCountLabel1" runat="server"></asp:Label>
                     <asp:Label ID="lblSortLabel1" runat="server" Visible="False"></asp:Label>

                    <div runat="server" class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label12" runat="server" Text="Result:" Font-Bold="True"></asp:Label>

                        </div>
                       
                    </div>

                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-condensed table-hover table-bordered" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="true" PageSize="50" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <%--  <asp:TemplateField ItemStyle-Width="50px" headerText="Edit Profile">--%>
                                <asp:TemplateField ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEidtInfo" runat="server" Text="Edit Profile" class="btn btn-info" CommandName="Edit1" CommandArgument='<%# Container.DataItemIndex %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField ItemStyle-Width="50px" headerText="Mark Close Profile">--%>
                                <%--   <asp:TemplateField ItemStyle-Width="50px">
                                    <ItemTemplate >
                                        <asp:Button ID="btnMarkCloseInfo" runat="server" Text="Mark Close"  class="btn btn-info" CommandName="MarkClose1" CommandArgument='<%# Container.DataItemIndex %>'/>  
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <%--<asp:TemplateField ItemStyle-Width="50px" headerText="Reset Password">--%>
                                <asp:TemplateField ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" class="btn btn-info" CommandName="ResetPassword1" CommandArgument='<%# Container.DataItemIndex %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField ItemStyle-Width="50px" headerText="Send Password">--%>
                                <%--  <asp:TemplateField ItemStyle-Width="50px">
                                    <ItemTemplate >
                                        <asp:Button ID="btnSendPassword" runat="server" Text="Send Password"  class="btn btn-info" CommandName="SendPassword1" CommandArgument='<%# Container.DataItemIndex %>'/>  
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblKey_Header" runat="server" Text='<%# Eval("UserCode")%>' Visible="false"> </asp:Label>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                </div>
                <div id="divPopUpPanel" runat="server" class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label6" runat="server" Text="Edit User Profile" Font-Bold="True"></asp:Label>
                        </div>
                        <table class="table table-condensed table-hover">
                            <tr>
                                <th class="width30">
                                    <asp:Label ID="Label7" runat="server" Text="User Code"></asp:Label>
                                </th>
                                <td>
                                    <cc2:SmartTextbox ID="txtUserCode" runat="server" class="form-control" Width="350px"></cc2:SmartTextbox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserCode" 
                                            Display="Dynamic" ErrorMessage="Please fill." ForeColor="Red" ValidationGroup="NewRecord"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <th class="width30">
                                    <asp:Label ID="Label14" runat="server" Text="User Short Name"></asp:Label>
                                </th>
                                <td>
                                    <cc2:SmartTextbox ID="txtUserShortName" runat="server" class="form-control" Width="350px"></cc2:SmartTextbox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserShortName" 
                                            Display="Dynamic" ErrorMessage="Please fill." ForeColor="Red" ValidationGroup="NewRecord"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <th class="width30">
                                    <asp:Label ID="Label3" runat="server" Text="User Full Name"></asp:Label>
                                </th>
                                <td>
                                    <cc2:SmartTextbox ID="txtUserFullName" runat="server" class="form-control" Width="350px"></cc2:SmartTextbox>
                                </td>
                            </tr>
                            <tr>
                                <th class="width30">
                                    <asp:Label ID="Label4" runat="server" Text="Company Code"></asp:Label>
                                </th>
                                <td>
                                    <cc2:SmartDropDownList ID="ddlCompanyCode_edit" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCompanyCode_edit_SelectedIndexChanged">
                                    </cc2:SmartDropDownList>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCompanyCode_edit" 
                                            Display="Dynamic" ErrorMessage="Please select." ForeColor="Red" ValidationGroup="NewRecord"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="Label10" runat="server" Text="Division Code"></asp:Label>
                                </th>
                                <td>
                                    <cc2:SmartDropDownList ID="ddlDivisionCode_edit" runat="server" class="form-control">
                                    </cc2:SmartDropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th class="width30">
                                    <asp:Label ID="Label9" runat="server" Text="Email"></asp:Label>
                                </th>
                                <td>
                                    <cc2:SmartTextbox ID="txtEmail" runat="server" class="form-control" Width="350px"></cc2:SmartTextbox>
                                </td>
                            </tr>
                            <tr>
                                <th class="width30">
                                    <asp:Label ID="Label13" runat="server" Text="Telephone Ext."></asp:Label>
                                </th>
                                <td>
                                    <cc2:SmartTextbox ID="txtTelephoneExtension" runat="server" class="form-control" Width="350px"></cc2:SmartTextbox>
                                </td>
                            </tr>
                            <tr>
                                <th class="width30">
                                    <asp:Label ID="Label15" runat="server" Text="Post Default Owner"></asp:Label>
                                </th>
                                <td>
                                    <cc2:SmartTextbox ID="txtPostDefaultOwner" runat="server" class="form-control" Width="350px"></cc2:SmartTextbox>

                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPostDefaultOwner" 
                                            Display="Dynamic" ErrorMessage="Please fill." ForeColor="Red" ValidationGroup="NewRecord"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <th class="width30">
                                    <asp:Label ID="Label16" runat="server" Text="Account Lock"></asp:Label>
                                </th>
                                <td>
                                    <cc2:SmartTextbox ID="txtAccountLock" runat="server" class="form-control" Width="350px"></cc2:SmartTextbox>
                                </td>
                            </tr>
                            <tr>
                                <th class="width30">
                                    <asp:Label ID="Label17" runat="server" Text="Remark"></asp:Label>
                                </th>
                                <td>
                                    <cc2:SmartTextbox ID="txtRemark" runat="server" class="form-control" Width="350px" TextMode="MultiLine" Rows="3"></cc2:SmartTextbox>
                                </td>
                            </tr>
                            <div id="div_ProfileStatus_edit" runat="server">
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label19" runat="server" Text="Status"></asp:Label>
                                    </th>
                                    <td>
                                        <cc2:SmartDropDownList ID="ddlProfileStatus_edit" runat="server" class="form-control">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>
                            </div>
                            <tr>
                                <td>
                                    <asp:Button ID="btnUpdate_UserProfile" runat="server" Text="Edit"
                                        class="btn btn-info btn-block" OnClick="btnUpdate_UserProfile_Click" Width="80px" ValidationGroup="NewRecord"  OnClientClick="return confirm('Confirm?');"/>
                                     <asp:Label ID="lblAlert3" runat="server" Text="沒有這個ID" ForeColor="Red" Visible="false"></asp:Label>

                                </td>
                                <td>
                                    <asp:Button ID="btnClose_UserProfile" runat="server" Text="Close"
                                        class="btn btn-info btn-block" OnClick="btnClose_UserProfile_Click" Width="80px" />
                                   
                                </td>
                            </tr>

                        </table>
                </div>
                <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender3" runat="server"
                    TargetControlID="divPopUpPanel" VerticalSide="Middle" HorizontalSide="Center" ScrollEffectDuration=".1" />
                              
            </ContentTemplate>
        </asp:UpdatePanel>

         <asp:UpdateProgress ID="upLoading" runat="server" DisplayAfter="1">
            <ProgressTemplate>
                <asp:Panel ID="pLoading" runat="server" BackColor="White">
                    <div class="LoadingModal">
                        <div class="LoadingCenter">
                            <asp:Image ID="imgLoading" runat="server" ImageUrl="img/wait.gif" />
                        </div>
                    </div>
                </asp:Panel>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
            TargetControlID="upLoading" VerticalSide="Top" VerticalOffset="10" HorizontalSide="Left"
             ScrollEffectDuration=".1" />

    </form>
</body>
</html>



