<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View_Form_USBDriveLoan.aspx.cs" Inherits="View_Form_USBDriveLoan" %>

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
                                        <asp:Button ID="btnEdit_Info" runat="server" Text="Edit Form"
                                             class="btn btn-info btn-block" OnClick="btnEdit_Info_Click" Width="80px" />

                                    </td>
                                    <td>    
                                    </td>
                                </tr>
                             <%--   <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label23" runat="server" Text="System"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblSystem" runat="server"></asp:Label>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label7" runat="server" Text="Form ID"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<asp:Label ID="lbl_UserCode" runat="server" ></asp:Label>--%>
                                        <%--<cc2:SmartTextbox ID="txtLogID" runat="server" class="form-control"  Enabled="false"></cc2:SmartTextbox>--%>
                                        <asp:Label ID="lblFormID" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                               
                               <%-- <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label14" runat="server" Text="Subject"></asp:Label>
                                    </th>
                                    <td >
                                        <cc2:SmartTextbox ID="txtSubject_edit" runat="server" class="form-control" ValidationGroup="SendApproval" MaxLength="300"></cc2:SmartTextbox>
                                         <asp:Label ID="lblSubject_view" runat="server" Text="" Visible="false" 
                                             style="word-break:break-all;word-wrap:normal" ></asp:Label>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1a" runat="server" ControlToValidate="txtSubject_edit" 
                                            Display="Dynamic" ErrorMessage="Please input." ForeColor="Red" ValidationGroup="SendApproval"></asp:RequiredFieldValidator>
                                        
                                    </td>
                                </tr>--%>
                                <%-- <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label42" runat="server" Text="Folder"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblFolderCode_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlFolderCode_edit" runat="server" class="form-control" AutoPostBack="true">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>--%>

                               <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label8" runat="server" Text="Company"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblCompany_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlCompany_edit" runat="server" class="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlCompanyCode_edit_SelectedIndexChanged">
                                        </cc2:SmartDropDownList>

                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCompany_edit" 
                                            Display="Dynamic" ErrorMessage="Please select." ForeColor="Red" ValidationGroup="NewRecord"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label15" runat="server" Text="Division"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblDivision_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlDivision_edit" runat="server" class="form-control" >
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>

                                  <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label16" runat="server" Text="Requester"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblRequester_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlRequester_edit" runat="server" class="form-control" >
                                        </cc2:SmartDropDownList>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlRequester_edit" 
                                            Display="Dynamic" ErrorMessage="Please select." ForeColor="Red" ValidationGroup="NewRecord"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label14" runat="server" Text="Telephone Extension"></asp:Label>
                                    </th>
                                    <td >
                                        <cc2:SmartTextbox ID="txtTelephoneExt_edit" runat="server" class="form-control" MaxLength="20" onkeypress="return isNumber(event)"></cc2:SmartTextbox>
                                         <asp:Label ID="lblTelephoneExt_view" runat="server" Text="" Visible="false" ></asp:Label>
                                    </td>
                                </tr>

                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label18" runat="server" Text="Reason for Request"></asp:Label>
                                    </th>
                                    <td>
                                        <cc2:SmartTextbox ID="txtReasonRequest_edit" runat="server" class="form-control"  TextMode="MultiLine" Rows="2"  MaxLength="500"></cc2:SmartTextbox>
                                         <asp:Label ID="lblReasonRequest_view" runat="server" Text="" Visible="false"
                                             style="word-break:break-all;word-wrap:normal"></asp:Label>
                                    </td>
                                </tr>
                                
                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label3" runat="server" Text="Loan Period - Start Date"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<cc2:DatePicker ID="DPDate" runat="server" AutoPostBack="true" />--%>
                                        <asp:Label ID="lblDPLoanStartDate_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartTextbox ID="DPLoanStartDate_edit" runat="server" MaxLength="10" onkeypress="return isNumber(event)"></cc2:SmartTextbox>
                                        <asp:ImageButton ID="ImageButton_edit" ImageUrl="img/calendar.png" ImageAlign="Bottom" runat="server" />
                                        <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="ImageButton_edit" runat="server" TargetControlID="DPLoanStartDate_edit"
                                            Format="yyyy-MM-dd"></cc1:CalendarExtender>

                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DPLoanStartDate_edit" 
                                            Display="Dynamic" ErrorMessage="Please select." ForeColor="Red" ValidationGroup="SendApproval"></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>

                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label11" runat="server" Text="Loan Period - Return Date"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<cc2:DatePicker ID="DPDate" runat="server" AutoPostBack="true" />--%>
                                        <asp:Label ID="lblDPLoanReturnDate_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartTextbox ID="DPLoanReturnDate_edit" runat="server" MaxLength="10" onkeypress="return isNumber(event)"></cc2:SmartTextbox>
                                        <asp:ImageButton ID="ImageButton2_edit" ImageUrl="img/calendar.png" ImageAlign="Bottom" runat="server" />
                                        <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="ImageButton2_edit" runat="server" TargetControlID="DPLoanReturnDate_edit"
                                            Format="yyyy-MM-dd"></cc1:CalendarExtender>

                                    <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DPLoanReturnDate_edit" 
                                            Display="Dynamic" ErrorMessage="Please select." ForeColor="Red" ValidationGroup="SendApproval"></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label12" runat="server" Text="Copy Data detail"></asp:Label>
                                    </th>
                                    <td>
                                        <cc2:SmartTextbox ID="txtCopyDataDetail_edit" runat="server" class="form-control"  TextMode="MultiLine" Rows="2"  MaxLength="500"></cc2:SmartTextbox>
                                         <asp:Label ID="lblCopyDataDetail_view" runat="server" Text="" Visible="false"
                                             style="word-break:break-all;word-wrap:normal"></asp:Label>
                                    </td>
                                </tr>

                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label20" runat="server" Text="1'st Approver"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblFirstApprover_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlFirstApprover_edit" runat="server" class="form-control">
                                        </cc2:SmartDropDownList>

                                  <%--      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlFirstApprover_edit" 
                                            Display="Dynamic" ErrorMessage="Please select." ForeColor="Red" ValidationGroup="SendApproval"></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
                                                          
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label17" runat="server" Text="Status"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                                                
                                <tr>
                                    <td>
                                        <asp:Label ID="lblURL" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblURLTarget" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblRemark" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblFolderCode" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblSystem" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
                                        
                                        <asp:Button ID="btnUpdate_Info" runat="server" Text="Save"
                                            class="btn btn-info btn-block" OnClick="btnUpdate_Info_Click" Width="80px" ValidationGroup="NewRecord" OnClientClick="return confirm('Confirm to update?');" />

                                     <%--   <asp:Button ID="btnApprove" runat="server" Text="Approve"
                                            class="btn btn-info btn-block" OnClick="btnApprove_Click" Width="100px"/>    --%>
                                    <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject_edit" 
                                            Display="Dynamic" ErrorMessage="Please input Subject." ForeColor="Red" ValidationGroup="NewRecord"></asp:RequiredFieldValidator>--%>

                                        <asp:Label ID="lblAlert3" runat="server" Text="沒有這個ID" ForeColor="Red" Visible="false"></asp:Label>

                                        <%--<asp:Button ID="btnEdit_Info" runat="server" Text="Edit log"
                                             class="btn btn-info btn-block" OnClick="btnEdit_Info_Click" Width="80px" />--%>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSendApproval" runat="server" Text="Submit for Approval"
                                            class="btn btn-info btn-block" OnClick="btnSendApproval_Click" ValidationGroup="SendApproval" Width="200px" OnClientClick="return confirm('Confirm to submit?');"/>
                                                                        
                                    </td>
                                </tr>

                            </table>
                        </div>

                    
                    </ContentTemplate>
                </asp:UpdatePanel>


                 <div id="div_RelatedStaff" runat="server">
              
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                 
                        <div runat="server" class="panel panel-primary">
                            <div class="panel-heading">
                                <asp:Label ID="Label24b" runat="server" Text="Approver:" Font-Bold="True"></asp:Label>
                            </div>

                  <%--          <asp:Panel ID="Panel1" runat="server">--%>
                            <div id="div_EditRelatedStaff" runat="server">
                                <table class="table table-condensed table-hover">
                                    <tr>                                        
                                        <th class="width30">
                                             <asp:Button ID="btnApproverAccept" runat="server" Text="Approve"
                                                 class="btn btn-info btn-block" OnClick="btnApproverAccept_Click" Width="80px" />
                                        </th>
                                        <td>
                                           <asp:Button ID="btnApproverDeny" runat="server" Text="Deny"
                                                 class="btn btn-info btn-block" OnClick="btnApproverDeny_Click" Width="80px" />
                                        </th>
                                    </tr>
                                </table>
                                </div>
                         <%--   </asp:Panel>--%>

                          
                            <asp:GridView ID="GridViewRS" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-hover table-bordered" >
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblKeyApproverRole" runat="server" Text='<%# Eval("ApproverRole")%>' Visible="false"> </asp:Label>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblKeyApprover" runat="server" Text='<%# Eval("Approver")%>' Visible="false"> </asp:Label>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:BoundField DataField="ApproverRole" HeaderText="Approver Role" SortExpression="ApproverRole" HeaderStyle-Wrap="false"/>                                   
                                    <asp:BoundField DataField="UserShortName" HeaderText="Approver" SortExpression="UserShortName" HeaderStyle-Wrap="false"/>
                                    <asp:BoundField DataField="ApprovalStatus" HeaderText="Status" SortExpression="ApprovalStatus" HeaderStyle-Wrap="false"/>
                                    <asp:BoundField DataField="ApprovedDateTime" HeaderText="Approved Date" SortExpression="ApprovedDateTime" HeaderStyle-Wrap="false"/>

                                   <%-- <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButtonRS" runat="server" CausesValidation="false" CommandName="Delete1"
                                                ImageUrl="img/ico_Cross.ico" CommandArgument='<%# Container.DataItemIndex %>'/>
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
                
                
               <div id="div_ITUse" runat="server">
              
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                 
                        <div runat="server" class="panel panel-primary">
                            <div class="panel-heading">
                                <asp:Label ID="Label24a" runat="server" Text="IT Use section:" Font-Bold="True"></asp:Label>
                            </div>

                  <%--          <asp:Panel ID="Panel1" runat="server">--%>
                                <table class="table table-condensed table-hover">
                                    <tr>
                                        <th class="width30">                                            
                                             <asp:Button ID="btnITEdit" runat="server" Text="Edit"
                                             class="btn btn-info btn-block" OnClick="btnITEdit_Click" Width="80px" />
                                        </th>
                                        <td>                                                                                  
                                        </td>
                                    </tr>
                                    
                                     <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label4" runat="server" Text="Loan#"></asp:Label>
                                        </th>
                                        <td>
                                            <cc2:SmartTextbox ID="txtLoan_edit" runat="server" class="form-control"  MaxLength="30"></cc2:SmartTextbox>
                                             <asp:Label ID="lblLoan_view" runat="server" Text="" Visible="false"
                                                 style="word-break:break-all;word-wrap:normal"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label5" runat="server" Text="Loan to (User)"></asp:Label>
                                        </th>
                                        <td>
                                             <asp:Label ID="lblLoanToUser_view" runat="server" Text="" Visible="false"></asp:Label>
                                            <cc2:SmartDropDownList ID="ddlLoanToUser_edit" runat="server" class="form-control" >
                                            </cc2:SmartDropDownList>
                                        </td>
                                    </tr>

                                     <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label6" runat="server" Text="IT Staff Handle Loan"></asp:Label>
                                        </th>
                                        <td>
                                             <asp:Label ID="lblITStaffHandleLoan_view" runat="server" Text="" Visible="false"></asp:Label>
                                            <cc2:SmartDropDownList ID="ddlITStaffHandleLoan_edit" runat="server" class="form-control" >
                                            </cc2:SmartDropDownList>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label10" runat="server" Text="Actual Loan Date"></asp:Label>
                                        </th>
                                        <td>
                                            <%--<cc2:DatePicker ID="DPDate" runat="server" AutoPostBack="true" />--%>
                                            <asp:Label ID="lblActualUSBLoanDate_view" runat="server" Text="" Visible="false"></asp:Label>
                                            <cc2:SmartTextbox ID="DPActualUSBLoanDate_edit" runat="server" MaxLength="10" onkeypress="return isNumber(event)"></cc2:SmartTextbox>
                                            <asp:ImageButton ID="ImageButton3_edit" ImageUrl="img/calendar.png" ImageAlign="Bottom" runat="server" />
                                            <cc1:CalendarExtender ID="CalendarExtender3" PopupButtonID="ImageButton3_edit" runat="server" TargetControlID="DPActualUSBLoanDate_edit"
                                                Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label9" runat="server" Text="IT Staff Handle Return"></asp:Label>
                                        </th>
                                        <td>
                                             <asp:Label ID="lblITStaffHandleReturn_view" runat="server" Text="" Visible="false"></asp:Label>
                                            <cc2:SmartDropDownList ID="ddlITStaffHandleReturn_edit" runat="server" class="form-control">
                                            </cc2:SmartDropDownList>
                                        </td>
                                    </tr>
                                           

                                     <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label13" runat="server" Text="Actual Return Date"></asp:Label>
                                        </th>
                                        <td>
                                            <%--<cc2:DatePicker ID="DPDate" runat="server" AutoPostBack="true" />--%>
                                            <asp:Label ID="lblActualUSBReturnDate_view" runat="server" Text="" Visible="false"></asp:Label>
                                            <cc2:SmartTextbox ID="DPActualUSBReturnDate_edit" runat="server" MaxLength="10" onkeypress="return isNumber(event)"></cc2:SmartTextbox>
                                            <asp:ImageButton ID="ImageButton4_edit" ImageUrl="img/calendar.png" ImageAlign="Bottom" runat="server" />
                                            <cc1:CalendarExtender ID="CalendarExtender4" PopupButtonID="ImageButton4_edit" runat="server" TargetControlID="DPActualUSBReturnDate_edit"
                                                Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                        </td>
                                    </tr>


                                    <tr>
                                        <th class="width30">
                                            <asp:Button ID="btnITSave" runat="server" Text="Save"
                                                 class="btn btn-info btn-block" OnClick="btnITSave_Click" Width="80px"  OnClientClick="return confirm('Confirm to update?');" />

                                             <%-- <asp:Button ID="btnITEdit" runat="server" Text="Edit"
                                             class="btn btn-info btn-block" OnClick="btnITEdit_Click" Width="80px" />--%>

                                              <asp:Label ID="lblAlert4" runat="server" Text="沒有這個ID" ForeColor="Red" Visible="false"></asp:Label>
                                        </th>
                                        <td>
                                                                                  
                                        </td>
                                    </tr>
                                </table>
                         <%--   </asp:Panel>--%>

                          
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

                 <div id="div_ITVeri" runat="server">
              
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                 
                        <div runat="server" class="panel panel-primary">
                            <div class="panel-heading">
                                <asp:Label ID="Label21" runat="server" Text="IT Verification section:" Font-Bold="True"></asp:Label>
                            </div>

                  <%--          <asp:Panel ID="Panel1" runat="server">--%>
                                <table class="table table-condensed table-hover">
                                    <tr>
                                        <th class="width30">                                            
                                             <asp:Button ID="btnITVeriEdit" runat="server" Text="Edit"
                                             class="btn btn-info btn-block" OnClick="btnITVeriEdit_Click" Width="80px" />
                                        </th>
                                        <td>                                                                                  
                                        </td>
                                    </tr>

                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label22" runat="server" Text="Remarks"></asp:Label>
                                        </th>
                                        <td>
                                            <cc2:SmartTextbox ID="txtITVeriRemarks_edit" runat="server" class="form-control"  TextMode="MultiLine" Rows="3"  MaxLength="2000"></cc2:SmartTextbox>
                                             <asp:Label ID="lblITVeriRemarks_view" runat="server" Text="" Visible="false"
                                                 style="word-break:break-all;word-wrap:normal"></asp:Label>
                                        </td>
                                    </tr>

                                     <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label23" runat="server" Text="Verification"></asp:Label>
                                        </th>
                                        <td>
                                            <cc2:SmartTextbox ID="txtITVerification_edit" runat="server" class="form-control"  TextMode="MultiLine" Rows="3"  MaxLength="2000"></cc2:SmartTextbox>
                                             <asp:Label ID="lblITVerification_view" runat="server" Text="" Visible="false"
                                                 style="word-break:break-all;word-wrap:normal"></asp:Label>
                                        </td>
                                    </tr>
                                    
                                      <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label25" runat="server" Text="Request Date"></asp:Label>
                                        </th>
                                        <td>
                                            <asp:Label ID="lbl_ITRequestDate" runat="server" Text="" ></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th class="width30">
                                            <asp:Button ID="btnITVeriSave" runat="server" Text="Save"
                                                 class="btn btn-info btn-block" OnClick="btnITVeriSave_Click" Width="80px"  OnClientClick="return confirm('Confirm to update?');" />

                                             <%-- <asp:Button ID="btnITEdit" runat="server" Text="Edit"
                                             class="btn btn-info btn-block" OnClick="btnITEdit_Click" Width="80px" />--%>

                                              <asp:Label ID="lblAlert5" runat="server" Text="沒有這個ID" ForeColor="Red" Visible="false"></asp:Label>
                                        </th>
                                        <td>
                                                                                  
                                        </td>
                                    </tr>
                                </table>
                         <%--   </asp:Panel>--%>

                          
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



