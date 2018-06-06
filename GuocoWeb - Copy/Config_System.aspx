<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Config_System.aspx.cs" Inherits="Config_System" %>


<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="UserControlLibrary" Namespace="UserControlLibrary.Lamsoon"
    TagPrefix="cc2" %>
<%@ Register Assembly="LSLIBWebBased" Namespace="LSLIBWebBased.LSWebControl" TagPrefix="cc3" %>
<%@ Register Src="ucPageHeader.ascx" TagName="ucPageHeader" TagPrefix="uc5" %>
<%@ Register Src="ucPageHeader.ascx" TagName="PageHeader" TagPrefix="uc5" %>
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
            <asp:UpdatePanel ID="upSelection" runat="server">
                <ContentTemplate>
                    <div class="panel panel-primary">

                        <table class="table table-condensed table-hover">
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

                                <td>
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" class="btn btn-info" Width="100px" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>


            </asp:UpdatePanel>
        </div>
        
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblPrintSql" runat="server" Text="" visible ="false"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="upDetail" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnInsert" runat="server" Text="Add System" OnClick="btnInsert_AddSystem_Click" class="btn btn-info" />

                <br />
                <div id="divCoverLayer" runat="server">
                </div>

                <div id="div2" runat="server">
                    <asp:Label ID="lblCountLabel1" runat="server"></asp:Label>
                    <asp:Panel ID="p20" runat="server">

                        <div id="div3" runat="server" class="panel panel-primary">
                            <div class="panel-heading">
                                <asp:Label ID="Label12" runat="server" Text="Result:" Font-Bold="True"></asp:Label>

                            </div>
                            <asp:Label ID="lblSortLabel1" runat="server" Visible="False"></asp:Label>

                        </div>

                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-condensed table-hover table-bordered" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="true" PageSize="50" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <%--  <asp:TemplateField ItemStyle-Width="50px" headerText="Edit Profile">--%>
                                <asp:TemplateField ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEidtInfo" runat="server" Text="Edit System" class="btn btn-info" CommandName="Edit1" CommandArgument='<%# Container.DataItemIndex %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField ItemStyle-Width="50px" headerText="Mark Close Profile">--%>
                                <%--   <asp:TemplateField ItemStyle-Width="50px">
                                    <ItemTemplate >
                                        <asp:Button ID="btnMarkCloseInfo" runat="server" Text="Mark Close"  class="btn btn-info" CommandName="MarkClose1" CommandArgument='<%# Container.DataItemIndex %>'/>  
                                    </ItemTemplate>
                                </asp:TemplateField>--%>


                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblKey_Header" runat="server" Text='<%# Eval("SystemCode")%>' Visible="false"> </asp:Label>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>



                <div id="divPopUpPanel" runat="server" class="divPopUpPanel">
                    <div runat="server" class="panel panel-primary">

                        <div class="panel-heading">
                            <%--<asp:Label ID="lblAction" runat="server" Text="" Font-Bold="True"></asp:Label>--%>
                            <asp:Label ID="Label6" runat="server" Text="Edit System Info" Font-Bold="True"></asp:Label>
                        </div>

                        <table class="table table-condensed table-hover">
                            <tr>
                                <th class="width30">
                                    <asp:Label ID="Label7" runat="server" Text="System Code"></asp:Label>
                                </th>
                                <td>
                                    <%--<asp:Label ID="lbl_UserCode" runat="server" ></asp:Label>--%>
                                    <cc2:SmartTextbox ID="txtSystemCode" runat="server" class="form-control" Width="350px" Enabled ="false"></cc2:SmartTextbox>
                                </td>
                            </tr>
                            <tr>
                                <th class="width30">
                                    <asp:Label ID="Label14" runat="server" Text="System Short Name"></asp:Label>
                                </th>
                                <td>
                                    <cc2:SmartTextbox ID="txtSystemShortName" runat="server" class="form-control" Width="350px"></cc2:SmartTextbox>
                                </td>
                            </tr>
                            <tr>
                                <th class="width30">
                                    <asp:Label ID="Label3" runat="server" Text="System Full Name"></asp:Label>
                                </th>
                                <td>
                                    <cc2:SmartTextbox ID="txtSystemFullName" runat="server" class="form-control" Width="350px"></cc2:SmartTextbox>
                                </td>
                            </tr>

                             <tr>
                                <th>
                                    <asp:Label ID="Label5" runat="server" Text="System Type:"></asp:Label>
                                </th>
                                <td>
                                    <cc2:SmartDropDownList ID="ddlSystemType" runat="server" class="form-control" AutoPostBack="true">
                                    </cc2:SmartDropDownList>
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

                             <%--<tr>
                                <th class="width30">
                                    <asp:Label ID="Label1" runat="server" Text="New item URL"></asp:Label>
                                </th>
                                <td>
                                    <cc2:SmartTextbox ID="txtUrl" runat="server" class="form-control" Width="350px"></cc2:SmartTextbox>
                                </td>
                            </tr>--%>

                           
                           
                            <%--<tr>
                                        <th class="width30">
                                            <asp:Label ID="Label19" runat="server" Text="Status"></asp:Label>
                                        </th>
                                        <td >
                                             <cc2:SmartTextbox ID="txtStatus" runat="server" class="form-control" Width="350px" ></cc2:SmartTextbox>
                                        </td>
                                    </tr>--%>
                            <div id="div_ProfileStatus_edit" runat="server">
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label19" runat="server" Text="Status"></asp:Label>
                                    </th>
                                    <td>
                                        <cc2:SmartDropDownList ID="ddlInfoStatus_edit" runat="server" class="form-control">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>
                            </div>
                            <tr>
                                <td>
                                    <asp:Button ID="btnUpdate_Info" runat="server" Text="Edit"
                                        class="btn btn-info btn-block" OnClick="btnUpdate_Info_Click" Width="80px" />

                                </td>
                                <td>
                                    <asp:Button ID="btnClose_Info" runat="server" Text="Close"
                                        class="btn btn-info btn-block" OnClick="btnClose_Info_Click" Width="80px" />
                                    <asp:Label ID="lblAlert3" runat="server" Text="沒有這個ID" ForeColor="Red" Visible="false"></asp:Label>
                                </td>
                            </tr>

                        </table>
                    </div>
                </div>
                <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender3" runat="server"
                    TargetControlID="divPopUpPanel" VerticalSide="Middle" HorizontalSide="Center" ScrollEffectDuration=".1" />


            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>



