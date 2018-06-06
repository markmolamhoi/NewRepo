<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View_System.aspx.cs" Inherits="View_System" %>

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
                    <tr runat="server" id="trSystemType">
                        <th>
                            <asp:Label ID="Label1" runat="server" Text="System Type"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartDropDownList ID="ddlSystemTypeCode" runat="server" CssClass="selectpicker selectwidthauto" AutoPostBack="true" OnSelectedIndexChanged="ddlSystemTypeCode_SelectedIndexChanged">
                            </cc2:SmartDropDownList>
                        </td>
                    </tr>
                    <tr runat="server" id="trSystem">
                        <th>
                            <asp:Label ID="Label5" runat="server" Text="System"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartDropDownList ID="ddlSystemCode" runat="server" CssClass="selectpicker selectwidthauto" AutoPostBack="true" OnSelectedIndexChanged="ddlSystemCode_SelectedIndexChanged">
                            </cc2:SmartDropDownList>
                        </td>
                    </tr>
                    <tr runat="server" id="trFolder">
                        <th>
                            <asp:Label ID="Label2" runat="server" Text="Folder"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartDropDownList ID="ddlFolderCode" runat="server" CssClass="selectpicker selectwidthauto" AutoPostBack="true" OnSelectedIndexChanged="ddlFolderCode_SelectedIndexChanged">
                            </cc2:SmartDropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="width30">
                            <asp:Label ID="Label19" runat="server" Text="Status"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartDropDownList ID="ddlStatus" runat="server" class="form-control" CssClass="selectpicker selectwidthauto">
                            </cc2:SmartDropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="width20">
                            <asp:Label ID="lblSearchKey" runat="server" Text="SearchKey"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartTextbox ID="txtSearchKey" runat="server" class="form-control"></cc2:SmartTextbox>
                            <asp:Label ID="lblSearch" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th></th>
                        <td >
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" class="btn btn-info" Width="140px" />
                            <asp:Button ID="btn_Browse" runat="server" Text="Browse Mode" class="btn btn-info" Width="140px" />
                            <asp:Button ID="btn_AddPost" runat="server" Text="Create New" class="btn btn-info" Width="140px" />
                            <asp:Button ID="btn_GoToConfig_Privilege_UserSystemRights" runat="server" Text="User Rights" class="btn btn-info" Width="140px" />
                            <asp:Button ID="btn_GoToConfig_Folder" runat="server" Text="Folder Settings" class="btn btn-info" Width="140px" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>

        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblPrintSql" runat="server" Text="" Visible="false"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="upDetail" runat="server">
            <ContentTemplate>

                <div id="divGridView" runat="server">
                    <asp:Label ID="lblCountLabel1" runat="server"></asp:Label>
                    <div runat="server" class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="lblReportName" runat="server" Text="ReportName" Font-Bold="True"></asp:Label>

                        </div>
                        <asp:Label ID="lblSortLabel1" runat="server" Visible="False"></asp:Label>

                    </div>

                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-condensed table-hover table-bordered" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="true" PageSize="50" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>


                            <asp:TemplateField HeaderText="Link">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server"
                                        NavigateUrl='<%# LIBLocal.sLoadPostFullURL(Eval("URL").ToString(), Eval("SystemCode").ToString(), Eval("ID").ToString(), Eval("FolderCode").ToString())%>'
                                        Target="_blank" Text="Visit"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblKey_Header" runat="server" Text='<%# Eval("ID")%>' Visible="false"> </asp:Label>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>



