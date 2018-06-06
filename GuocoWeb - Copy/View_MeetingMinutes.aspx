<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View_MeetingMinutes.aspx.cs" Inherits="View_MeetingMinutes" %>

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
                                        <asp:Button ID="btnEdit_Info" runat="server" Text="Edit Minutes"
                                             class="btn btn-info btn-block" OnClick="btnEdit_Info_Click" Width="120px" />

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
                                        <asp:Label ID="Label7" runat="server" Text="Meeting ID"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<asp:Label ID="lbl_UserCode" runat="server" ></asp:Label>--%>
                                        <%--<cc2:SmartTextbox ID="txtLogID" runat="server" class="form-control"  Enabled="false"></cc2:SmartTextbox>--%>
                                        <asp:Label ID="lblMeetingID" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                               
                                <tr>
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
                                </tr>
                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label42" runat="server" Text="Folder"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblFolderCode_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlFolderCode_edit" runat="server" class="form-control" AutoPostBack="true">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>

                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label3" runat="server" Text="Meeting Date"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<cc2:DatePicker ID="DPDate" runat="server" AutoPostBack="true" />--%>
                                        <asp:Label ID="lblDPMeetingDate_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartTextbox ID="DPMeetingDate_edit" runat="server" MaxLength="10" onkeypress="return isNumber(event)" ValidationGroup="SendApproval"></cc2:SmartTextbox>
                                        <asp:ImageButton ID="ImageButton_edit" ImageUrl="img/calendar.png" ImageAlign="Bottom" runat="server" />
                                        <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="ImageButton_edit" runat="server" TargetControlID="DPMeetingDate_edit"
                                            Format="yyyy-MM-dd"></cc1:CalendarExtender>

                                         


                                         <asp:Label ID="lblMeetingTime_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartTextbox ID="txtMeetingTime_edit" runat="server" 
                                            meta:resourcekey="txtTimeFromResource1" ></cc2:SmartTextbox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="txtMeetingTime_edit"
                                                                Mask="99:99"
                                                                MaskType="Time"
                                                                CultureName="en-us"
                                                                MessageValidatorTip="true"
                                                                runat="server">
                                        </cc1:MaskedEditExtender>

                                        <br />

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DPMeetingDate_edit" 
                                            Display="Dynamic" ErrorMessage="Please input." ForeColor="Red" ValidationGroup="SendApproval"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>

                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label8" runat="server" Text="Company"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblCompany_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlCompany_edit" runat="server" class="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlCompanyCode_edit_SelectedIndexChanged">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label15" runat="server" Text="Division"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblDivision_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlDivision_edit" runat="server" class="form-control" AutoPostBack="true">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>

                                  <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label18" runat="server" Text="Scope"></asp:Label>
                                    </th>
                                    <td>
                                        <cc2:SmartTextbox ID="txtScope_edit" runat="server" class="form-control"  MaxLength="100"></cc2:SmartTextbox>
                                         <asp:Label ID="lblScope_view" runat="server" Text="" Visible="false"
                                             style="word-break:break-all;word-wrap:normal"></asp:Label>
                                    </td>
                                </tr>

                                 <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label16" runat="server" Text="Chairperson"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblChairperson_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlChairperson_edit" runat="server" class="form-control" AutoPostBack="true">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label10" runat="server" Text="Approver"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblApprover_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlApprover_edit" runat="server" class="form-control" AutoPostBack="true">
                                        </cc2:SmartDropDownList>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlApprover_edit" 
                                            Display="Dynamic" ErrorMessage="Please select." ForeColor="Red" ValidationGroup="SendApproval"></asp:RequiredFieldValidator>
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
                                        <asp:Label ID="lblApprover_Email" runat="server" Text="" Visible="false"></asp:Label>
                                         <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
                                        
                                        <asp:Button ID="btnUpdate_Info" runat="server" Text="Save"
                                            class="btn btn-info btn-block" OnClick="btnUpdate_Info_Click" Width="80px" ValidationGroup="NewRecord" OnClientClick="return confirm('Confirm to update?');"/>

                                        <asp:Button ID="btnApprove" runat="server" Text="Approve"
                                            class="btn btn-info btn-block" OnClick="btnApprove_Click" Width="100px" OnClientClick="return confirm('Confirm to approve?');"/>    
                                    <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject_edit" 
                                            Display="Dynamic" ErrorMessage="Please input Subject." ForeColor="Red" ValidationGroup="NewRecord"></asp:RequiredFieldValidator>--%>

                                        <asp:Label ID="lblAlert3" runat="server" Text="沒有這個ID" ForeColor="Red" Visible="false"></asp:Label>

                                        <%--<asp:Button ID="btnEdit_Info" runat="server" Text="Edit log"
                                             class="btn btn-info btn-block" OnClick="btnEdit_Info_Click" Width="80px" />--%>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSendApproval" runat="server" Text="Save and Send for Approval"
                                            class="btn btn-info btn-block" OnClick="btnSendApproval_Click" ValidationGroup="SendApproval" Width="200px" OnClientClick="return confirm('Confirm to submit?');"/>
                                                                        
                                    </td>
                                </tr>

                            </table>
                        </div>

                    
                    </ContentTemplate>
                </asp:UpdatePanel>

                
                <div id="divAttachment" runat="server">
              
                <asp:UpdatePanel ID="upAttachment" runat="server">
                    <ContentTemplate>
                 
                        <div runat="server" class="panel panel-primary">
                            <div class="panel-heading">
                                <asp:Label ID="Label9" runat="server" Text="Minutes Details:" Font-Bold="True"></asp:Label>
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
                                                <cc2:SmartTextbox ID="txtDescription" runat="server" class="form-control"   TextMode="MultiLine" Rows="2"  MaxLength="500"></cc2:SmartTextbox>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                     <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label36" runat="server"  Text="Action By"></asp:Label>
                                        </th>
                                        <td>
                                            <asp:Panel ID="Panel2" runat="server">
                                                <cc2:SmartTextbox ID="txtActionBy" runat="server" class="form-control"   TextMode="MultiLine" Rows="2" MaxLength="200"></cc2:SmartTextbox>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                     <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label4" runat="server"  Text="Responsible Parties"></asp:Label>
                                        </th>
                                        <td>
                                            <asp:Panel ID="Panel6" runat="server">
                                                <cc2:SmartTextbox ID="txtResponsibleParties" runat="server" class="form-control"   TextMode="MultiLine" Rows="2" MaxLength="200"></cc2:SmartTextbox>
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
                                             <asp:Button ID="btnAttachmentAdd" runat="server" Text="Add" ValidationGroup="Attachment" class="btn btn-info btn-block" Width="80px"
                                                    PostBackUrl="#divAttachment" OnClick="btnAttachmentAdd_Click"/>
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
                                    <asp:BoundField DataField="Upload_By" HeaderText="Upload By" SortExpression="Upload_By" />
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

                
               <div id="div_ProjectManager" runat="server">
              
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                 
                        <div runat="server" class="panel panel-primary">
                            <div class="panel-heading">
                                <asp:Label ID="Label24a" runat="server" Text="Present:" Font-Bold="True"></asp:Label>
                            </div>

                  <%--          <asp:Panel ID="Panel1" runat="server">--%>
                            <div id="div_EditProjectManager" runat="server">
                                <table class="table table-condensed table-hover">
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label25" runat="server" Text="Present"></asp:Label>
                                        </th>
                                        <td>
                                            <cc2:SmartDropDownList ID="ddlPresent_edit" runat="server" class="form-control" AutoPostBack="true">
                                            </cc2:SmartDropDownList>
                                            <asp:Button ID="btnAddPresent" runat="server" Text="Add"
                                                 class="btn btn-info btn-block" OnClick="btnAddPresent_Click" Width="80px" />
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
                                <asp:Label ID="Label24b" runat="server" Text="Absent:" Font-Bold="True"></asp:Label>
                            </div>

                  <%--          <asp:Panel ID="Panel1" runat="server">--%>
                            <div id="div_EditRelatedStaff" runat="server">
                                <table class="table table-condensed table-hover">
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label24" runat="server" Text="Absent"></asp:Label>
                                        </th>
                                        <td>
                                            <cc2:SmartDropDownList ID="ddlAbsent_edit" runat="server" class="form-control" AutoPostBack="true">
                                            </cc2:SmartDropDownList>
                                            <asp:Button ID="btnAddAbsent" runat="server" Text="Add"
                                                 class="btn btn-info btn-block" OnClick="btnAddAbsent_Click" Width="80px" />
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

             <div id="div_OtherReaders" runat="server">
              
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                 
                        <div runat="server" class="panel panel-primary">
                            <div class="panel-heading">
                                <asp:Label ID="Label1" runat="server" Text="Other Readers:" Font-Bold="True"></asp:Label>
                            </div>

                  <%--          <asp:Panel ID="Panel1" runat="server">--%>
                            <div id="div_EditOtherReaders" runat="server">
                                <table class="table table-condensed table-hover">
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label2" runat="server" Text="Other Readers"></asp:Label>
                                        </th>
                                        <td>
                                            <cc2:SmartDropDownList ID="ddlOtherReaders_edit" runat="server" class="form-control" AutoPostBack="true">
                                            </cc2:SmartDropDownList>
                                            <asp:Button ID="btnAddOtherReaders" runat="server" Text="Add"
                                                 class="btn btn-info btn-block" OnClick="btnAddOtherReaders_Click" Width="80px" />
                                        </th>
                                        <td>                                            
                                        </td>
                                    </tr>
                                </table>
                                </div>
                         <%--   </asp:Panel>--%>

                          
                            <asp:GridView ID="GridViewOR" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-hover table-bordered"

                                OnRowCommand="grdOR_RowCommand" OnRowDataBound="grdOR_RowDataBound">
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
                                            <asp:ImageButton ID="ImageButtonOR" runat="server" CausesValidation="false" CommandName="Delete1"
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



