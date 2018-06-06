<%@ Page Language="C#" AutoEventWireup="true" CodeFile="All_InformationTableReportList.aspx.cs" Inherits="All_InformationTableReportList" %>

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
    <form id="form2" runat="server">
        <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container">
            <asp:UpdatePanel ID="upHeader" runat="server">
                <ContentTemplate>
                    <div>
                        <cc3:LSPageHeader ID="LSPageHeader1" runat="server" />

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="panel panel-primary">
                <table class="table table-condensed table-hover">
                    <div id="divLabelList">
                        <asp:Label ID="lblDropDown_Key" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblGird_stp_Name" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblDDLDivisionCode" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblDDLCompanyCode" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblDDLRegion" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblNoOfDDL_Display" runat="server" Text="" Visible="false"></asp:Label>

                        <asp:Label ID="lblEnableDDLYear" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblEnableDDLMonth" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblEnableDDLContentType" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblEnableSearchKey" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblEnableButtonExportToExcel" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblEnableButtonUpdate" runat="server" Text="" Visible="false"></asp:Label>

                        <asp:Label ID="lblSearchKeyName" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lbldefaultValue_SearchKeyName" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblEnableDefinition" runat="server" Text="" Visible="false"></asp:Label>

                        <asp:Label ID="lblChart_ContentType1" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblChart_ContentType2" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblChart_ContentType3" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblChart_ConnectOracle" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblChart_ChartType" runat="server" Text="" Visible="false"></asp:Label>

                        <asp:Label ID="lblEnableDateRange" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblEnableDDLWeek" runat="server" Text="" Visible="false"></asp:Label>

                        <asp:Label ID="lblDDLProductCode_4" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblDDLSalesmanCode_5" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblDDLOUCode_6" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblShowing_DDL" runat="server" Text="" Visible="false"></asp:Label>

                        <asp:Label ID="lblEnableGrid" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblEnableComment" runat="server" Text="" Visible="false"></asp:Label>

                    </div>
                    <tr id="divDivision" runat="server">
                        <th class="width20">
                            <asp:Label ID="lblDivision" runat="server" Text="分部"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartDropDownList ID="ddlDivision" runat="server" class="form-control" CssClass="selectpicker selectwidthauto">
                            </cc2:SmartDropDownList>
                        </td>
                    </tr>
                    <tr id="divCompany" runat="server">
                        <th class="width20">
                            <asp:Label ID="lblCompany" runat="server" Text="公司"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartDropDownList ID="ddlCompany" runat="server" CssClass="selectpicker selectwidthauto">
                            </cc2:SmartDropDownList>
                        </td>
                    </tr>
                    <tr id="divRegion" runat="server">
                        <th class="width20">
                            <asp:Label ID="lblRegion" runat="server" Text="区域"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartDropDownList ID="ddlRegion" runat="server" CssClass="selectpicker selectwidthauto">
                            </cc2:SmartDropDownList>
                        </td>
                    </tr>
                    <tr id="divProductCode_4" runat="server">
                        <th class="width20">
                            <asp:Label ID="lblProductCode_4" runat="server" Text="ddl4"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartDropDownList ID="DDLProductCode_4" runat="server" CssClass="selectpicker selectwidthauto">
                            </cc2:SmartDropDownList>
                        </td>
                    </tr>
                    <tr id="divSalesmanCode_5" runat="server">
                        <th class="width20">
                            <asp:Label ID="lblSalesmanCode_5" runat="server" Text="ddl5"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartDropDownList ID="DDLSalesmanCode_5" runat="server" CssClass="selectpicker selectwidthauto">
                            </cc2:SmartDropDownList>
                        </td>
                    </tr>
                    <tr id="divOUCode_6" runat="server">
                        <th class="width20">
                            <asp:Label ID="lblOUCode_6" runat="server" Text="ddl6"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartDropDownList ID="DDLOUCode_6" runat="server" CssClass="selectpicker selectwidthauto">
                            </cc2:SmartDropDownList>
                        </td>
                    </tr>
                    <tr id="divYearMonth" runat="server">
                        <th class="width20">
                            <asp:Label ID="Label5" runat="server" Text="年"></asp:Label>
                            <asp:Label ID="Label7" runat="server" Text="月"></asp:Label>
                            <asp:Label ID="lblWeek" runat="server" Text="周" Visible="false"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartDropDownList ID="ddlYear" runat="server" CssClass="selectpicker selectwidthauto" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_Changed">
                            </cc2:SmartDropDownList>
                            <cc2:SmartDropDownList ID="ddlMonth" runat="server" CssClass="selectpicker selectwidthauto">
                            </cc2:SmartDropDownList>
                            <cc2:SmartDropDownList ID="ddlWeek" runat="server" CssClass="selectpicker selectwidthauto" Visible="false">
                            </cc2:SmartDropDownList>
                        </td>
                    </tr>
                    <tr id="divDateRange" runat="server">
                        <th>
                            <asp:Label ID="Label11" runat="server" Text="日期"></asp:Label>
                        </th>
                        <td colspan="3">
                            <cc2:DatePicker ID="DateFrom" runat="server" AutoPostBack="true" />
                            -
                            <cc2:DatePicker ID="DateTo" runat="server" AutoPostBack="true" />

                        </td>
                    </tr>
                    <tr id="divContentType" runat="server">
                        <th class="width20">
                            <asp:Label ID="Label6" runat="server" Text="報表類型"></asp:Label>
                        </th>
                        <td>
                            <cc2:SmartDropDownList ID="ddlReportRowOption" runat="server" class="form-control" CssClass="selectpicker selectwidthauto" AutoPostBack="true" OnSelectedIndexChanged="ddlReportRowOption_Changed">
                                <asp:ListItem>Allahabad</asp:ListItem>
                                <asp:ListItem>Allahabad</asp:ListItem>
                            </cc2:SmartDropDownList>

                            <asp:Button ID="btnExcelUpload" runat="server" Text="Excel上載" OnClick="btnExcelUpload_Click" class="btn btn-info" Visible="false" />
                        </td>
                    </tr>
                    <tr id="divSearchKey" runat="server">
                        <th class="width20">
                            <asp:Label ID="lblSearchKey" runat="server" Text="關鍵字"></asp:Label>
                        </th>
                        <td colspan="3">
                            <cc2:SmartTextbox ID="txtSearchKey" runat="server" class="form-control">
                            </cc2:SmartTextbox>
                        </td>
                    </tr>
                    <tr id="divbtn" runat="server">
                        <th class="width20">
                            <asp:Button ID="btnExporttoExcel" runat="server" Text="Export to Excel" OnClick="btnExporttoExcel_Click" class="btn btn-info" /></th>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnUpdate" runat="server" Text="Apply" OnClick="btnUpdate_Click" class="btn btn-info" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr id="divDefinition" runat="server">
                        <th class="width20">
                            <asp:Label ID="Label1" runat="server" Text="定義"></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="lblDefinition" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

            <div id="divEnableComment" runat="server" Visible="false">
                    <asp:Button ID="btnShowComment" runat="server" Text="Show comment" OnClick="btnShowComment_Click" class="btn btn-info"/>
                     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <div id="divComment" runat="server" Visible="false">

                            <asp:Panel ID="p11" runat="server">
                      
                                <div id="div21" runat="server" class="panel panel-primary" >
                                 <%--   <div class="panel-heading">
                                        <asp:Label ID="Label3" runat="server" Text="Comment:" Font-Bold="True"></asp:Label>
                                    </div>--%>
                                    <table class="table table-condensed table-hover" >
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblgvSort2" runat="server" Visible="false"></asp:Label>
                                                <%-- <asp:Label ID="lblNoOfRecords2" runat="server"></asp:Label>--%>
                                                <div id="divGridComment" runat="server">
                                                    <asp:GridView ID="GridViewComment" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="5">
                                                    </asp:GridView>
                                                </div>  
                                            </td>
                                        </tr>
                                         <tr>
                                            <th  class="width20">
                                                <asp:Label ID="Label4" runat="server" Text="AddComment"></asp:Label>
                                            </th>
                                            <td>
                                                <cc2:SmartTextbox ID="txtComment" runat="server" class="form-control" TextMode="MultiLine" Rows="3">
                                                </cc2:SmartTextbox>
                                            </td>
                                        </tr>
                                        <tr id="Tr1" runat="server">
                                            <th class="width20">
                                                <%--<asp:Button ID="btnUpdateComment" runat="server" Text="Update" OnClick="btnUpdateComment_Click" class="btn btn-info" />--%>
                                            </th>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnAddComment" runat="server" Text="Add" OnClick="btnAddComment_Click" class="btn btn-info" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                 
                                    </table>    
                                </div>                          
    
                            </asp:Panel>

                        </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblPrintSql" runat="server" Text="" Visible="false"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div id="divData" runat="server">
                    <asp:Label ID="lblTestingMessage" runat="server" Text="以下資料全是測試數據, 只作測試用途."></asp:Label>

                    <asp:Label ID="lblNoOfRecords" runat="server"></asp:Label>
                    <asp:Label ID="lblgvSort1" runat="server" Visible="false"></asp:Label>
                    <div id="div1" runat="server">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div2" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView2" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div3" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView3" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div4" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView4" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div5" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView5" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div6" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView6" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div7" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView7" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div8" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView8" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div9" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView9" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div10" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView10" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div11" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView11" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div12" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView12" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div13" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView13" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div14" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView14" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div15" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView15" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div16" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView16" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div17" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView17" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div18" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView18" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div19" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView19" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                    <div id="div20" runat="server" >
                        <%--<br />--%>
                        <asp:GridView ID="GridView20" runat="server" CssClass="table table-condensed table-hover table-bordered gridview" AllowPaging="true" AutoGenerateColumns="True" RowStyle-Wrap="false" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
                        </asp:GridView>
                    </div>
                </div>
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
            HorizontalOffset="10" ScrollEffectDuration=".1" />
    </form>
</body>
</html>
