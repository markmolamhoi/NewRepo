<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View_IncidentLog.aspx.cs" Inherits="View_IncidentLog" %>

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

            <div runat="server" id="divPost">
                <asp:UpdatePanel ID="upDetail" runat="server">
                    <ContentTemplate>
                        <div runat="server" class="panel panel-primary" id="divPostdetail">

                            <%--                        <div class="panel-heading">
                                <asp:Label ID="Label6" runat="server" Text="Edit Folder" Font-Bold="True"></asp:Label>
                            </div>--%>

                            <table class="table table-condensed table-hover">
                                 <tr>
                                    <td>
                                        <asp:Button ID="btnEdit_Info" runat="server" Text="Edit log"
                                             class="btn btn-info btn-block" OnClick="btnEdit_Info_Click" Width="80px" />
                                    </td>
                                    <td>    
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label23" runat="server" Text="System"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<asp:Label ID="lbl_UserCode" runat="server" ></asp:Label>--%>
                                       <%-- <cc2:SmartTextbox ID="txtSystem" runat="server" class="form-control"  Enabled="false"></cc2:SmartTextbox>--%>
                                        <asp:Label ID="lblSystem" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label7" runat="server" Text="Log ID"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<asp:Label ID="lbl_UserCode" runat="server" ></asp:Label>--%>
                                        <%--<cc2:SmartTextbox ID="txtLogID" runat="server" class="form-control"  Enabled="false"></cc2:SmartTextbox>--%>
                                        <asp:Label ID="lblLogID" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label2" runat="server" Text="Log No."></asp:Label>
                                    </th>
                                    <td>
                                        <%--<asp:Label ID="lbl_UserCode" runat="server" ></asp:Label>--%>
                                        <%--<cc2:SmartTextbox ID="txtLogNo" runat="server" class="form-control"  Enabled="false"></cc2:SmartTextbox>--%>
                                        <asp:Label ID="lblLogNo" runat="server" ></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label14" runat="server" Text="Subject"></asp:Label>
                                    </th>
                                    <td >
                                        <cc2:SmartTextbox ID="txtSubject_edit" runat="server" class="form-control" ValidationGroup="NewRecord" MaxLength="300"></cc2:SmartTextbox>
                                         <asp:Label ID="lblSubject_view" runat="server" Text="" Visible="false" 
                                             style="word-break:break-all;word-wrap:normal" ></asp:Label>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSubject_edit" 
                                            Display="Dynamic" ErrorMessage="Please input." ForeColor="Red" ValidationGroup="NewRecord"></asp:RequiredFieldValidator>
                                        
                                    </td>
                                </tr>
                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label42" runat="server" Text="Folder "></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblFolderCode_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlFolderCode_edit" runat="server" class="form-control" AutoPostBack="true">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>
                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label8" runat="server" Text="Critical Level"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblCriticalLevel_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlCriticalLevel_edit" runat="server" class="form-control" AutoPostBack="true">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label15" runat="server" Text="Incident Type"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblIncidentType_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlIncidentType_edit" runat="server" class="form-control" AutoPostBack="true">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>

                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label16" runat="server" Text="Incident Discovered by"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblIncidentDiscoveredby_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlIncidentDiscoveredby_edit" runat="server" class="form-control" AutoPostBack="true">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label17" runat="server" Text="Status"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblStatus_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlStatus_edit" runat="server" class="form-control" AutoPostBack="true">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>

                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label18" runat="server" Text="Cross Ref."></asp:Label>
                                    </th>
                                    <td>
                                        <cc2:SmartTextbox ID="txtCrossRef_edit" runat="server" class="form-control" Width="250px"  MaxLength="10"></cc2:SmartTextbox>
                                         <asp:Label ID="lblCrossRef_view" runat="server" Text="" Visible="false"></asp:Label>
                                    </td>
                                </tr>

                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label20" runat="server" Text="Version No."></asp:Label>
                                    </th>
                                    <td> 
                                        <cc2:SmartTextbox ID="txtVersionNo_edit" runat="server" class="form-control" Width="500px"  MaxLength="30"></cc2:SmartTextbox>
                                         <asp:Label ID="lblVersionNo_view" runat="server" Text="" Visible="false"
                                             style="word-break:break-all;word-wrap:normal" ></asp:Label>
                                    </td>
                                </tr>
                                                                
                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label19" runat="server" Text="Incident Report by"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblIncidentReportby_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlIncidentReportby_edit" runat="server" class="form-control" AutoPostBack="true">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label21" runat="server" Text="Report Date"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<cc2:SmartTextbox ID="txtReportDate" runat="server" class="form-control"  Enabled="false"></cc2:SmartTextbox>--%>
                                        <asp:Label ID="lblReportDate" runat="server" style="word-break:break-all;word-wrap:normal" ></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label3" runat="server" Text="Start Date"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<cc2:DatePicker ID="DPDate" runat="server" AutoPostBack="true" />--%>
                                        <asp:Label ID="lblDPStartDate_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartTextbox ID="DPStartDate_edit" runat="server" MaxLength="10" onkeypress="return isNumber(event)"></cc2:SmartTextbox>
                                        <asp:ImageButton ID="ImageButton_edit" ImageUrl="img/calendar.png" ImageAlign="Bottom" runat="server" />
                                        <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="ImageButton_edit" runat="server" TargetControlID="DPStartDate_edit"
                                            Format="yyyy-MM-dd"></cc1:CalendarExtender>


                                         <asp:Label ID="lblStartTime_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartTextbox ID="txtStartTime_edit" runat="server" 
                                            meta:resourcekey="txtTimeFromResource1" ></cc2:SmartTextbox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="txtStartTime_edit"
                                                                Mask="99:99"
                                                                MaskType="Time"
                                                                CultureName="en-us"
                                                                MessageValidatorTip="true"
                                                                runat="server">
                                        </cc1:MaskedEditExtender>
                                    </td>
                                </tr>

                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label22" runat="server" Text="End Date"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<cc2:DatePicker ID="DPDate" runat="server" AutoPostBack="true" />--%>
                                        <asp:Label ID="lblDPEndDate_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartTextbox ID="DPEndDate_edit" runat="server" MaxLength="10" onkeypress="return isNumber(event)"></cc2:SmartTextbox>
                                        <asp:ImageButton ID="ImageButton_edit2" ImageUrl="img/calendar.png" ImageAlign="Bottom" runat="server" />
                                        <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="ImageButton_edit2" runat="server" TargetControlID="DPEndDate_edit"
                                            Format="yyyy-MM-dd"></cc1:CalendarExtender>

                                        <asp:Label ID="lblEndTime_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartTextbox ID="txtEndTime_edit" runat="server" 
                                            meta:resourcekey="txtTimeFromResource1" ValidationGroup="vgrpUpdateTask"  ></cc2:SmartTextbox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" TargetControlID="txtEndTime_edit"
                                                                Mask="99:99"
                                                                MaskType="Time"
                                                                CultureName="en-us"
                                                                MessageValidatorTip="true"
                                                                runat="server">
                                        </cc1:MaskedEditExtender>
                                    </td>
                                </tr>

                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label10" runat="server" Text="Division"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<asp:Label ID="lbl_UserCode" runat="server" ></asp:Label>--%>
                                        <asp:Label ID="lblDivision_view" runat="server" Text="" Visible="false" 
                                            style="word-break:break-all;word-wrap:normal" ></asp:Label>
                                        <cc2:SmartTextbox ID="txtDivision_edit" runat="server" class="form-control"  MaxLength="50"></cc2:SmartTextbox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label11" runat="server" Text="Related Systems"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblRelatedSystems_view" runat="server" Text="" Visible="false"
                                            style="word-break:break-all;word-wrap:normal" ></asp:Label>
                                        <cc2:SmartTextbox ID="txtRelatedSystems_edit" runat="server" class="form-control"  MaxLength="200"></cc2:SmartTextbox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label4" runat="server" Text="System/Server Name"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblSystemServerName_view" runat="server" Text="" Visible="false"
                                            style="word-break:break-all;word-wrap:normal" ></asp:Label>
                                        <cc2:SmartTextbox ID="txtSystemServerName_edit" runat="server" class="form-control"  MaxLength="200"></cc2:SmartTextbox>
                                      
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label1" runat="server" Text="Function"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblFunction_view" runat="server" Text="" Visible="false"
                                            style="word-break:break-all;word-wrap:normal" ></asp:Label>
                                        <cc2:SmartTextbox ID="txtFunction_edit" runat="server" class="form-control"  MaxLength="200"></cc2:SmartTextbox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label12" runat="server" Text="Related Internal Parties"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblRelatedInternalParties_view" runat="server" Text="" Visible="false"
                                            style="word-break:break-all;word-wrap:normal" ></asp:Label>
                                        <cc2:SmartTextbox ID="txtRelatedInternalParties_edit" runat="server" class="form-control"  MaxLength="300"></cc2:SmartTextbox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label13" runat="server" Text="Related External Parties"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblRelatedExternalParties_view" runat="server" Text="" Visible="false"
                                            style="word-break:break-all;word-wrap:normal" ></asp:Label>
                                        <cc2:SmartTextbox ID="txtRelatedExternalParties_edit" runat="server" class="form-control"  MaxLength="300"></cc2:SmartTextbox>
                                    </td>
                                </tr>
                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label26" runat="server" Text="Error Description"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblErrorDescription_view" runat="server" Text="" Visible="false"
                                            style="word-break:break-all;word-wrap:normal" ></asp:Label>
                                        <cc2:SmartTextbox ID="txtErrorDescription_edit" runat="server" class="form-control"  TextMode="MultiLine" Rows="3" MaxLength="500"></cc2:SmartTextbox>
                                    </td>
                                </tr>

                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label27" runat="server" Text="Retest by"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblRetestby_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlRetestby_edit" runat="server" class="form-control" AutoPostBack="true">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>

                                   <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label28" runat="server" Text="Retest date"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<cc2:DatePicker ID="DPDate" runat="server" AutoPostBack="true" />--%>
                                        <asp:Label ID="lblRetestDate_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartTextbox ID="DPRetestDate_edit" runat="server" MaxLength="10" onkeypress="return isNumber(event)"></cc2:SmartTextbox>
                                        <asp:ImageButton ID="ImageButton_edit3" ImageUrl="img/calendar.png" ImageAlign="Bottom" runat="server" />
                                        <cc1:CalendarExtender ID="CalendarExtender3" PopupButtonID="ImageButton_edit3" runat="server" TargetControlID="DPRetestDate_edit"
                                            Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                    </td>
                                </tr>
                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label31" runat="server" Text="Remark 1 by IT"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblRemark1byIT_view" runat="server" Text="" Visible="false"
                                            style="word-break:break-all;word-wrap:normal"  ></asp:Label>
                                        <cc2:SmartTextbox ID="txtRemark1byIT_edit" runat="server" class="form-control"  TextMode="MultiLine" Rows="2" MaxLength="300"
                                           ></cc2:SmartTextbox>
                                    </td>
                                </tr>

                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label33" runat="server" Text="Remark 2 by IT"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblRemark2byIT_view" runat="server" Text="" Visible="false"
                                            style="word-break:break-all;word-wrap:normal"></asp:Label>
                                        <cc2:SmartTextbox ID="txtRemark2byIT_edit" runat="server" class="form-control"  TextMode="MultiLine" Rows="2" MaxLength="300"></cc2:SmartTextbox>
                                    </td>
                                </tr>

                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label35" runat="server" Text="Remark 3 by IT"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblRemark3byIT_view" runat="server" Text="" Visible="false"
                                             style="word-break:break-all;word-wrap:normal"  ></asp:Label>
                                        <cc2:SmartTextbox ID="txtRemark3byIT_edit" runat="server" class="form-control"  TextMode="MultiLine" Rows="2"  MaxLength="300"></cc2:SmartTextbox>
                                    </td>
                                </tr>

                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label34" runat="server" Text="Target Version"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblTargetVersion_view" runat="server" Text="" Visible="false"
                                            style="word-break:break-all;word-wrap:normal" ></asp:Label>
                                        <cc2:SmartTextbox ID="txtTargetVersion_edit" runat="server" class="form-control"  Width="500px"   MaxLength="30"></cc2:SmartTextbox>
                                    </td>
                                </tr>

                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label32" runat="server" Text="Target Completion Date"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<cc2:DatePicker ID="DPDate" runat="server" AutoPostBack="true" />--%>
                                        <asp:Label ID="lblTargetCompletionDate_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartTextbox ID="DPTargetCompletionDate_edit" runat="server" MaxLength="10" onkeypress="return isNumber(event)"></cc2:SmartTextbox>
                                        <asp:ImageButton ID="ImageButton_edit4" ImageUrl="img/calendar.png" ImageAlign="Bottom" runat="server" />
                                        <cc1:CalendarExtender ID="CalendarExtender4" PopupButtonID="ImageButton_edit4" runat="server" TargetControlID="DPTargetCompletionDate_edit"
                                            Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                    </td>
                                </tr>

                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label29" runat="server" Text="Assigned to"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblAssignedto_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlAssignedto_edit" runat="server" class="form-control" AutoPostBack="true">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        <asp:Label ID="lblURL" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblURLTarget" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblRemark" runat="server" Text="" Visible="false"></asp:Label>
                                         <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>

                                        <asp:Button ID="btnUpdate_Info" runat="server" Text="Update"
                                            class="btn btn-info btn-block" OnClick="btnUpdate_Info_Click" Width="80px" ValidationGroup="NewRecord" OnClientClick="return confirm('Confirm to update?');"/>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject_edit" 
                                            Display="Dynamic"  ForeColor="Red" ValidationGroup="NewRecord"></asp:RequiredFieldValidator>

                                        <asp:Label ID="lblAlert3" runat="server" Text="沒有這個ID" ForeColor="Red" Visible="false"></asp:Label>

                                        <%--<asp:Button ID="btnEdit_Info" runat="server" Text="Edit log"
                                             class="btn btn-info btn-block" OnClick="btnEdit_Info_Click" Width="80px" />--%>
                                    </td>
                                    <td>
                                        <%-- <asp:Button ID="btnClose_Info" runat="server" Text="Close"
                                            class="btn btn-info btn-block" OnClick="btnClose_Info_Click" Width="80px" />--%>
                                    
                                    </td>
                                </tr>

                            </table>
                        </div>

                    
                    </ContentTemplate>
                </asp:UpdatePanel>

               <div id="div_ProjectManager" runat="server">
              
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                 
                        <div runat="server" class="panel panel-primary">
                            <div class="panel-heading">
                                <asp:Label ID="Label24a" runat="server" Text="List of Project Managers:" Font-Bold="True"></asp:Label>
                            </div>

                  <%--          <asp:Panel ID="Panel1" runat="server">--%>
                            <div id="div_EditProjectManager" runat="server">
                                <table class="table table-condensed table-hover">
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label25" runat="server" Text="Project Manager"></asp:Label>
                                        </th>
                                        <td>
                                            <cc2:SmartDropDownList ID="ddlProjectManager_edit" runat="server" class="form-control" AutoPostBack="true">
                                            </cc2:SmartDropDownList>
                                            <asp:Button ID="btnAddProjectManager" runat="server" Text="Add"
                                                 class="btn btn-info btn-block" OnClick="btnAddProjectManager_Click" Width="80px" />
                                        </th>
                                        <td>                                            
                                        </td>
                                    </tr>
                                </table>
                                </div>
                         <%--   </asp:Panel>--%>

                          
                            <asp:GridView ID="GridViewPM" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-hover table-bordered"

                                OnRowCommand="grdPM_RowCommand" OnRowDataBound="grdPM_RowDataBound">
                                <Columns>
                                     <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblKeyUserCode" runat="server" Text='<%# Eval("UserCode")%>' Visible="false"> </asp:Label>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                   
                                    <asp:BoundField DataField="UserShortName" HeaderText="Short Name" SortExpression="UserShortName" HeaderStyle-Width="40%"/>                                   
                                    <asp:BoundField DataField="UserFullName" HeaderText="Full Name" SortExpression="UserFullName" />

                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButtonPM" runat="server" CausesValidation="false" CommandName="Delete1"
                                                ImageUrl="img/ico_Cross.ico" CommandArgument='<%# Container.DataItemIndex %>'/>
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

                <div id="div_RelatedStaff" runat="server">
              
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                 
                        <div runat="server" class="panel panel-primary">
                            <div class="panel-heading">
                                <asp:Label ID="Label24b" runat="server" Text="List of Related Staff:" Font-Bold="True"></asp:Label>
                            </div>

                  <%--          <asp:Panel ID="Panel1" runat="server">--%>
                            <div id="div_EditRelatedStaff" runat="server">
                                <table class="table table-condensed table-hover">
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label24" runat="server" Text="Related Staff"></asp:Label>
                                        </th>
                                        <td>
                                            <cc2:SmartDropDownList ID="ddlRelatedStaff_edit" runat="server" class="form-control" AutoPostBack="true">
                                            </cc2:SmartDropDownList>
                                            <asp:Button ID="btnAddRelatedStaff" runat="server" Text="Add"
                                                 class="btn btn-info btn-block" OnClick="btnAddRelatedStaff_Click" Width="80px" />
                                        </th>
                                        <td>                                            
                                        </td>
                                    </tr>
                                </table>
                                </div>
                         <%--   </asp:Panel>--%>

                          
                            <asp:GridView ID="GridViewRS" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-hover table-bordered"

                                OnRowCommand="grdRS_RowCommand" OnRowDataBound="grdRS_RowDataBound">
                                <Columns>
                                     <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblKeyUserCode" runat="server" Text='<%# Eval("UserCode")%>' Visible="false"> </asp:Label>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                   
                                    <asp:BoundField DataField="UserShortName" HeaderText="Short Name" SortExpression="UserShortName" HeaderStyle-Width="40%"/>                                   
                                    <asp:BoundField DataField="UserFullName" HeaderText="Full Name" SortExpression="UserFullName" />

                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButtonRS" runat="server" CausesValidation="false" CommandName="Delete1"
                                                ImageUrl="img/ico_Cross.ico" CommandArgument='<%# Container.DataItemIndex %>'/>
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

                <div id="divAttachment" runat="server">
              
                <asp:UpdatePanel ID="upAttachment" runat="server">
                    <ContentTemplate>
                 
                        <div runat="server" class="panel panel-primary">
                            <div class="panel-heading">
                                <asp:Label ID="Label9" runat="server" Text="Error Description:" Font-Bold="True"></asp:Label>
                            </div>

                        <%--    <asp:Panel ID="pnlAttachmentDetail" runat="server">--%>
                            <div id="div_ErrorAtt" runat="server">
                                <table class="table table-condensed table-hover">
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label37" runat="server"  Text="Item"></asp:Label>
                                        </th>
                                        <td>
                                            <asp:Panel ID="Panel3" runat="server">
                                                <cc2:SmartTextbox ID="txtItem" runat="server" class="form-control"  Width="300px"  MaxLength="30"></cc2:SmartTextbox>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label30" runat="server"  Text="Description"></asp:Label>
                                        </th>
                                        <td>
                                            <asp:Panel ID="Panel1" runat="server">
                                                <cc2:SmartTextbox ID="txtErrDescription" runat="server" class="form-control"   TextMode="MultiLine" Rows="2"  MaxLength="500"></cc2:SmartTextbox>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label5" runat="server" Text="Attachment"></asp:Label>
                                        </th>
                                        <td >
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                           <%-- <asp:RequiredFieldValidator ID="rfvFileUpload1" runat="server" ControlToValidate="FileUpload1"
                                                Display="Dynamic" ErrorMessage="不能為空" ValidationGroup="Attachment"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label6" runat="server"  Text="Attachment Description"></asp:Label>
                                        </th>
                                        <td>
                                             <cc2:SmartTextbox ID="txtFileDesc" runat="server" ValidationGroup="Attachment" class="form-control" 
                                                     TextMode="MultiLine" Rows="2"  MaxLength="200"></cc2:SmartTextbox>
                                        </td>
                                    </tr>
                                      <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label36" runat="server"  Text="Remark"></asp:Label>
                                        </th>
                                        <td>
                                            <asp:Panel ID="Panel2" runat="server">
                                                <cc2:SmartTextbox ID="txtRemarkAtt" runat="server" class="form-control"   TextMode="MultiLine" Rows="2" MaxLength="200"></cc2:SmartTextbox>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                      <tr>
                                        <th class="width30">
                                             <asp:Button ID="btnAttachmentAdd" runat="server" Text="Add" ValidationGroup="Attachment" class="btn btn-info btn-block" Width="80px"
                                                    PostBackUrl="#divAttachment" OnClick="btnAttachmentAdd_Click" />
                                             <asp:Label ID="lblAlert5" runat="server" Text="沒有這個ID" ForeColor="Red" Visible="false"></asp:Label>
                                        </th>
                                        <td>                                           
                                        </td>
                                    </tr>
                                </table>
                                </div>
                            <%--</asp:Panel>--%>

                          
                            <asp:GridView ID="grdAttachment" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-hover table-bordered"

                                OnRowCommand="grdAttachment_RowCommand" OnRowDataBound="grdAttachment_RowDataBound" style="word-wrap:normal">
                                <Columns>
                                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />

                                     <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSeq_No" runat="server" Text='<%# Eval("Seq_No")%>' Visible="false"> </asp:Label>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                    <%--<asp:BoundField DataField="Error_Desc" HeaderText="Error Description" SortExpression="Error_Desc" />--%>
                                    <asp:TemplateField HeaderText="File_Path" Visible="false" >
                                         <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("File_Path", "~{0}") %>'
                                                Target="_blank" Text='<%# Eval("File_Path")%>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Attachment"  HeaderStyle-Wrap="false">
                                         <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("File_Path", "~{0}") %>'
                                                Target="_blank" Text='<%# bindGetText(Eval("File_Path"))%>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="File_Desc" HeaderText="Attachment Description" SortExpression="File_Desc" />--%>
                                    <%--<asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark" />--%>
                                  <%--  <asp:BoundField DataField="Upload_By" HeaderText="Upload By" SortExpression="Upload_By" />--%>
                                    <asp:BoundField DataField="Upload_Date" HeaderText="Update Date" SortExpression="Upload_Date" HeaderStyle-Wrap="false"/>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandName="Delete1"
                                                ImageUrl="img/ico_Cross.ico" />
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>


                 <div id="divActiontaken" runat="server">
              
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                 
                        <div runat="server" class="panel panel-primary">
                            <div class="panel-heading">
                                <asp:Label ID="Label38" runat="server" Text="Action Taken:" Font-Bold="True"></asp:Label>
                            </div>

                        <%--    <asp:Panel ID="pnlAttachmentDetail" runat="server">--%>
                            <div id="div_Actiontaken" runat="server">
                                <table class="table table-condensed table-hover">
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label39" runat="server"  Text="Item"></asp:Label>
                                        </th>
                                        <td>
                                            <asp:Panel ID="Panel4" runat="server">
                                                <cc2:SmartTextbox ID="txtActionitem" runat="server" class="form-control"  Width="300px" MaxLength="30"></cc2:SmartTextbox>
                                            </asp:Panel>
                                        </td>
                                    </tr>                                   
                                     <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label41" runat="server" Text="Date"></asp:Label>
                                    </th>
                                        <td>
                                            <%--<cc2:DatePicker ID="DPDate" runat="server" AutoPostBack="true" />--%>
                                            <cc2:SmartTextbox ID="DPActiontakeDate" runat="server" MaxLength="10" onkeypress="return isNumber(event)"></cc2:SmartTextbox>
                                            <asp:ImageButton ID="ImageButton_edit5" ImageUrl="img/calendar.png" ImageAlign="Bottom" runat="server" />
                                            <cc1:CalendarExtender ID="CalendarExtender5" PopupButtonID="ImageButton_edit5" runat="server" TargetControlID="DPActiontakeDate"
                                                Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                        

                                             <cc2:SmartTextbox ID="txtActiontakeTime" runat="server" 
                                                meta:resourcekey="txtTimeFromResource1" ValidationGroup="vgrpUpdateTask"  ></cc2:SmartTextbox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" TargetControlID="txtActiontakeTime"
                                                                    Mask="99:99"
                                                                    MaskType="Time"
                                                                    CultureName="en-us"
                                                                    MessageValidatorTip="true"
                                                                    runat="server">
                                            </cc1:MaskedEditExtender>
                                         </td>
                                    </tr>
                                     <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label40" runat="server"  Text="Description"></asp:Label>
                                        </th>
                                        <td>
                                            <asp:Panel ID="Panel5" runat="server">
                                                <cc2:SmartTextbox ID="txtActiontaken" runat="server" class="form-control"  TextMode="MultiLine" Rows="2" MaxLength="500"></cc2:SmartTextbox>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                   
                                      <tr>
                                        <th class="width30">
                                             <asp:Button ID="btnActiontakenAdd" runat="server" Text="Add" ValidationGroup="Attachment" class="btn btn-info btn-block" Width="80px"
                                                    PostBackUrl="#divActiontaken" OnClick="btnActiontakenAdd_Click" />
                                            <asp:Label ID="lblAlert4" runat="server" Text="沒有這個ID" ForeColor="Red" Visible="false"></asp:Label>
                                        </th>
                                        <td>                                           
                                        </td>
                                    </tr>
                                </table>
                                </div>
                            <%--</asp:Panel>--%>

                          
                            <asp:GridView ID="grdActiontaken" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-hover table-bordered"

                                OnRowCommand="grdActiontaken_RowCommand" OnRowDataBound="grdActiontaken_RowDataBound" style="word-wrap:normal">
                                <Columns>
                                    <asp:BoundField DataField="Description" HeaderText="Action" SortExpression="Description" />

                                     <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSeq_No" runat="server" Text='<%# Eval("Seq_No")%>' Visible="false"> </asp:Label>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                    <asp:BoundField DataField="ActionDate" HeaderText="Action Date" SortExpression="ActionDate" HeaderStyle-Wrap="false" HeaderStyle-Width="15%"/>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandName="Delete1"
                                                ImageUrl="img/ico_Cross.ico" />
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            </div>

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
        </div>
        
    </form>
</body>
</html>



