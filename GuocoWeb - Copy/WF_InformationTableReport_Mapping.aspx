<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WF_InformationTableReport_Mapping.aspx.cs" Inherits="WF_InformationTableReport_Mapping" %>

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
            <asp:UpdatePanel>
                <ContentTemplate>
                <div class="panel panel-primary">

                    <table class="table table-condensed table-hover">                                                           
                        
                        <tr>
                            <th  class="width20">
                                <asp:Label ID="Label2" runat="server" Text="SearchKey"></asp:Label>
                            </th>
                            <td >
                                <cc2:SmartTextbox ID="txtSearchKey" runat="server" class="form-control"></cc2:SmartTextbox>
                                <asp:Label ID="lblSearch" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                </td>                          
                            
                            <td><asp:Button ID="btnSearch" runat="server" Text="搜尋" OnClick="btnSearch_Click" class="btn btn-info"/>
                            </td>
                        </tr>
                    </table>
                </div>
                </ContentTemplate>
        </asp:UpdatePanel>
</div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblPrintSql" runat="server" Text="" Visible="false"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
         <asp:Button ID="btnInsert" runat="server" Text="新增"  OnClick="btnInsert_Click"  class="btn btn-info" />               
         <br/>
                                 
        <asp:UpdatePanel ID="upDetail" runat="server">
            <ContentTemplate>                
                <div id="divCoverLayer" runat="server">
                </div>

                <div id="divGridView" runat="server">
                    <asp:Label ID="lblCountLabel1" runat="server" Visible="false"></asp:Label>

                    <div runat="server" class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label12" runat="server" Text="Search Result:" Font-Bold="True"></asp:Label>

                        </div>
                        <asp:Label ID="lblSortLabel1" runat="server" Visible="False"></asp:Label>

                        <asp:GridView ID="GridView1" CssClass="table table-condensed table-hover table-bordered" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" AllowPaging="True" RowStyle-Wrap="true" PageSize="50" OnRowCommand="GridView1_RowCommand">
                            <Columns>

                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblKey_Header" runat="server" Text='<%# Eval("ReportID")%>' Visible="false"> </asp:Label>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblURL_Header" runat="server" Text='<%# Eval("URL")%>' Visible="false"> </asp:Label>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReportType_Header" runat="server" Text='<%# Eval("FolderCode")%>' Visible="false"> </asp:Label>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEidtHeader" runat="server" Text="更新" class="btn btn-info" CommandName="Edit1" CommandArgument='<%# Container.DataItemIndex %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Button ID="btnCopy" runat="server" Text="複製" class="btn btn-info" CommandName="Copy1" CommandArgument='<%# Container.DataItemIndex %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--  <asp:TemplateField ItemStyle-Width="50px">
                                            <ItemTemplate >
                                                 <asp:Button ID="btnEidtLink" runat="server" Text="更新Link"  class="btn btn-info" CommandName="Edit2" CommandArgument='<%# Container.DataItemIndex %>'/>  
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Redirect" SortExpression="ReportID">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink4" runat="server"
                                            NavigateUrl='<%# LIBLocal.sLoadPostURL(Eval("URL").ToString(), Eval("ReportID").ToString(), Eval("FolderCode").ToString())%>'
                                            Target="_blank" Text='<%# Eval("ReportID")%>'></asp:HyperLink>

                                        <%--<asp:HyperLink ID="HyperLink4a" runat="server" Text='Link' Target="_blank" NavigateUrl=  '<%#  Eval("URL") + "?&FolderCode=" + Eval("FolderCode") + "&ReportID=" + Eval("ReportID")%>'></asp:HyperLink>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ReportID" HeaderText="ReportID" SortExpression="ReportID"
                                    HtmlEncode="false" />
                                <%--<asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL" Visible="false"
                                            HtmlEncode="false" />--%>
                                <asp:BoundField DataField="Report_Name" HeaderText="Report_Name" SortExpression="Report_Name"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="DropDown_Key" HeaderText="DropDown_Key" SortExpression="DropDown_Key"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="MasterReportID" HeaderText="MasterReportID" SortExpression="MasterReportID"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="SubReportID" HeaderText="SubReportID" SortExpression="SubReportID"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="Gird_stp_Name" HeaderText="Gird_stp_Name" SortExpression="Gird_stp_Name"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="DDLDivisionCode" HeaderText="DDLDivisionCode" SortExpression="DDLDivisionCode"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="DDLCompanyCode" HeaderText="DDLCompanyCode" SortExpression="DDLCompanyCode"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="DDLRegion" HeaderText="DDLRegion" SortExpression="DDLRegion"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="NoOfDDL_Display" HeaderText="NoOfDDL_Display" SortExpression="NoOfDDL_Display"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="EnableDDLYear" HeaderText="EnableDDLYear" SortExpression="EnableDDLYear"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="EnableDDLMonth" HeaderText="EnableDDLMonth" SortExpression="EnableDDLMonth"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="EnableDDLContentType" HeaderText="EnableDDLContentType" SortExpression="EnableDDLContentType"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="EnableSearchKey" HeaderText="EnableSearchKey" SortExpression="EnableSearchKey"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="EnableButtonExportToExcel" HeaderText="EnableButtonExportToExcel" SortExpression="EnableButtonExportToExcel"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="EnableButtonUpdate" HeaderText="EnableButtonUpdate" SortExpression="EnableButtonUpdate"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="Chart_ContentType1" HeaderText="Chart_ContentType1" SortExpression="Chart_ContentType1"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="Chart_ContentType2" HeaderText="Chart_ContentType2" SortExpression="Chart_ContentType2"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="Chart_ContentType3" HeaderText="Chart_ContentType3" SortExpression="Chart_ContentType3"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="Chart_ConnectOracle" HeaderText="Chart_ConnectOracle" SortExpression="Chart_ConnectOracle"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="SearchKeyName" HeaderText="SearchKeyName" SortExpression="SearchKeyName"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="defaultValue_SearchKeyName" HeaderText="defaultValue_SearchKeyName" SortExpression="defaultValue_SearchKeyName"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="Chart_EnableDefinition" HeaderText="Chart_EnableDefinition" SortExpression="Chart_EnableDefinition"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="Chart_type" HeaderText="Chart_type" SortExpression="Chart_type"
                                    HtmlEncode="false" />

                                <%-- <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnEidt" runat="server" CausesValidation="false" CommandName="Edit1" ToolTip="Edit" CommandArgument='<%# Container.DataItemIndex %>' 
                                                    ImageUrl="img/edit.gif" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                        </asp:TemplateField>                    --%>
                            </Columns>
                            <RowStyle Wrap="False" />
                        </asp:GridView>
                    </div>

                </div>

                 <div id="divPopUpPanel2" runat="server" >
                       <%-- <div class="panel panel-info">--%>
                        <div  class="panel panel-primary">  
                                                  
                            <div class="panel-heading">
                                <asp:Label ID="Label9" runat="server" Text="更新-tbl_wf_all_InformationTableReport_Mapping" Font-Bold="True"></asp:Label>
                               
                            </div>      

                            <table class="table table-condensed table-hover" >
                                <tr>
                                    <td >
                                        <asp:Label ID="Label10" runat="server" Text="ReportID" ></asp:Label>
                                    </td>
                                    <td>
                                        <cc2:SmartTextbox ID="txtReportID" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                    <td>
                                         <asp:Label ID="Label11" runat="server" Text="Report_Name"></asp:Label>
                                    </td>
                                    <td>
                                        <cc2:SmartTextbox ID="txtReport_Name" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                </tr>                                 
                               
                                <tr>                                    
                                    <td >
                                        <asp:Label ID="Label1" runat="server" Text="Gird_stp_Name" ></asp:Label>
                                     </td>
                                    <td>
                                        <cc2:SmartTextbox ID="txtGird_stp_Name" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label18" runat="server" Text="DropDown_Key(ReportRowOption)" ></asp:Label>
                                     </td>
                                    <td>
                                        <cc2:SmartTextbox ID="txtDropDown_Key" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                </tr>                                
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="Label27" runat="server" Text="If 'Showing DDL' no value, using 'No. Of DDL Display' setting. If 'Showing DDL' have value, using 'Showing DDL' setting."></asp:Label>
                                    </td>
                                </tr> 
                                <tr>
                                     <td>
                                        <asp:Label ID="Label7" runat="server" Text="No. Of DDL Display(0,1,2,3,4,5 or 6) " ></asp:Label>
                                         <br />
                                          <asp:Label ID="Label45" runat="server" Text="(e.g. Input:2) - Display (1)DDLDivisionCode, (2)DDLCompanyCode" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtNoOfDDL_Display" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                     <td>
                                        <asp:Label ID="Label43" runat="server" Text="Showing DDL( ,1,2,3,4,5,6) " ></asp:Label>
                                         <br />
                                          <asp:Label ID="Label46" runat="server" Text="(e.g. Input: 2, 6) - Display - (2)DDLCompanyCode, (6)DDLOUCode" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtShowing_DDL" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>     
                                </tr> 
                                 <tr>
                                    <td colspan="4">
                                        <asp:Label ID="Label44" runat="server" Text="Replacing DDL (e.g. DDL-stp:stp_wf_ebs_rss_RSSDIS040_DDLCity, Input: RSSDIS040_DDLCity)"></asp:Label>
                                    </td>
                                </tr> 
                                <tr>     
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="(1)DDLDivisionCode" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtDDLDivisionCode" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>                             
                                     <td>
                                        <asp:Label ID="Label5" runat="server" Text="(2)DDLCompanyCode" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtDDLCompanyCode" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>                
                                </tr> 
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="(3)DDLRegion"></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtDDLRegion" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>    
                                    <td>
                                        <asp:Label ID="Label40" runat="server" Text="(4)DDLProductCode"></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtDDLProductCode_4" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>                                                                      
                                </tr> 
                                <tr>
                                    <td>
                                        <asp:Label ID="Label41" runat="server" Text="(5)DDLSalesmanCode" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtDDLSalesmanCode_5" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td> 
                                    <td>
                                        <asp:Label ID="Label42" runat="server" Text="(6)DDLOUCode"></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtDDLOUCode_6" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>                                
                                </tr> 
                                 
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="EnableDDLYear(Y,N)" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtEnableDDLYear" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Text="EnableDDLMonth(Y,N)" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtEnableDDLMonth" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                </tr> 
                                 <tr>
                                    <td>
                                        <asp:Label ID="Label39" runat="server" Text="EnableDDLWeek(Y,N) (Set Y required EnableDDLYear = Y)" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtEnableDDLWeek" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label38" runat="server" Text="EnableDateRange(Y,N)(Not for BI)" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtEnableDateRange" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>                                    
                                </tr>   
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="EnableDDLContentType(Y,N)" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtEnableDDLContentType" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Text="EnableSearchKey(Y,N)"></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtEnableSearchKey" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                </tr>     
                                <tr>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" Text="EnableButtonExportToExcel(Y,N)" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtEnableButtonExportToExcel" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label17" runat="server" Text="EnableButtonUpdate(Y,N)" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtEnableButtonUpdate" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                </tr>   
                              
                                <tr>
                                    <td>
                                        <asp:Label ID="Label23" runat="server" Text="SearchKeyName(rename 關鍵字)" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtSearchKeyName" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label24" runat="server" Text="defaultValue_SearchKeyName" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtdefaultValue_SearchKeyName" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                </tr>   
                                <tr>
                                    <td>
                                        <asp:Label ID="Label19" runat="server" Text="Chart_ContentType1(ByDivisionCode)" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtChart_ContentType1" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label20" runat="server" Text="Chart_ContentType2(ByOU)" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtChart_ContentType2" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                </tr> 
                                <tr>
                                    <td>
                                        <asp:Label ID="Label21" runat="server" Text="Chart_ContentType3" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtChart_ContentType3" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label22" runat="server" Text="Chart_ConnectOracle(Y,N)"></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtChart_ConnectOracle" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                </tr>     
                                
                                 <tr>
                                    <td colspan="4">
                                        <asp:Label ID="Label28" runat="server" Text="Chart_type: (default)Line, Column, Bar, StackedColumn100, StackedBar100, StackedArea100"></asp:Label>
                                    </td>
                                </tr> 
                                <tr>
                                    <td>
                                        <asp:Label ID="Label25" runat="server" Text="Chart_EnableDefinition(Y,N)"></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtChart_EnableDefinition" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label26" runat="server" Text="Chart_type" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtChart_type" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                </tr> 
                                 <tr>
                                    <td>
                                        <asp:Label ID="Label47" runat="server" Text="EnableGrid(Y,N) (BI only)"></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtEnableGrid" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label48" runat="server" Text="EnableComment(Y,N)"></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtEnableComment" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                </tr> 

                                 <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Remark"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <cc2:SmartTextbox ID="txtRemark" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                </tr> 
                                
                                           
                                <tr>    
                                    <td > 
                                        <asp:Button ID="btnUpdateEditHeader" runat="server" Text="更新"
                                            class="btn btn-info btn-block" OnClick="btnUpdateEditHeader_Click" Width="80px" />
                                        <asp:Label ID="lblAlert1" runat="server" Text="沒有這個ID" ForeColor="Red" Visible="false"></asp:Label> 
                                    </td>
                                    <td >
                                        <asp:Button ID="btnCloseEditHeader" runat="server" Text="關閉"
                                            class="btn btn-info btn-block" OnClick="btnCloseEditHeader_Click" Width="80px" />
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>
                              
                            </table>                            
                        </div>

                    </div>
                    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender2" runat="server"
                        TargetControlID="divPopUpPanel2" VerticalSide="Middle" HorizontalSide="Center" ScrollEffectDuration=".1" />


                    <div id="divPopUpPanel" runat="server">
                       <%-- <div class="panel panel-info">--%>
                        <div  class="panel panel-primary">  
                                                  
                            <div class="panel-heading">
                                <asp:Label ID="Label29" runat="server" Text="更新Link-tbl_wf_rss_ReportMaster" Font-Bold="True"></asp:Label>
                               
                            </div>      

                            <table class="table table-condensed table-hover" >
                                <tr>
                                    <th class="width20">
                                        <asp:Label ID="Label30" runat="server" Text="ReportID"></asp:Label>
                                    </th>
                                    <td>
                                       <%-- <asp:Label ID="lblEditKey" runat="server" Text=""></asp:Label>--%>
                                        <cc2:SmartTextbox ID="txtReportIDLink" runat="server" class="form-control" Enabled="false"></cc2:SmartTextbox>
                                    </td>
                                </tr>                                 
                                <tr>
                                    <td>
                                        <asp:Label ID="Label31" runat="server" Text="ReportType"></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtReportType" runat="server" class="form-control"></cc2:SmartTextbox>
                                    </td>
                                </tr>     
                                <tr>
                                    <td>
                                        <asp:Label ID="Label32" runat="server" Text="ReportName" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtReportName" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                </tr> 
                                <tr>
                                    <td>
                                        <asp:Label ID="Label33" runat="server" Text="ReportSorting" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtReportSorting" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                </tr>  
                                 <tr>
                                    <td>
                                        <asp:Label ID="Label35" runat="server" Text="URL" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtURL" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                </tr>    
                                 <tr>
                                    <td>
                                        <asp:Label ID="Label36" runat="server" Text="URLTarget(_self,_blank)" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtURLTarget" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                </tr> 
                                <tr>     
                                   <td>
                                        <asp:Label ID="Label37" runat="server" Text="status(A,E)" ></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtstatus" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                </tr>                    
                                <tr>    
                                    <td > 
                                        <asp:Button ID="btnUpdateEditHeaderLink" runat="server" Text="更新"
                                            class="btn btn-info btn-block" OnClick="btnUpdateEditHeaderLink_Click" Width="80px" />
                                        <asp:Label ID="Label34" runat="server" Text="沒有這個ID" ForeColor="Red" Visible="false"></asp:Label> 
                                    </td>
                                    <td >
                                        <asp:Button ID="btnCloseEditHeaderLink" runat="server" Text="關閉"
                                            class="btn btn-info btn-block" OnClick="btnCloseEditHeaderLink_Click" Width="80px" />
                                    </td>
                                </tr>
                              
                            </table>                            
                        </div>

                    </div>
                    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
                        TargetControlID="divPopUpPanel" VerticalSide="Middle" HorizontalSide="Center" ScrollEffectDuration=".1" />

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>




