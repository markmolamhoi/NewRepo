<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View_Post.aspx.cs" Inherits="View_Post" %>

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
                        <div id="divCoverLayer" runat="server">
                         </div>

                        <div runat="server" class="panel panel-primary" id="divPostdetail">

                            <%--                        <div class="panel-heading">
                                <asp:Label ID="Label6" runat="server" Text="Edit Folder" Font-Bold="True"></asp:Label>
                            </div>--%>

                            <table class="table table-condensed table-hover">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnEdit_Info" runat="server" Text="Edit post"
                                             class="btn btn-info btn-block" OnClick="btnEdit_Info_Click" Width="80px" />
                                    </td>
                                    <td>    
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label7" runat="server" Text="Post Code"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<asp:Label ID="lbl_UserCode" runat="server" ></asp:Label>--%>
                                        <%--<cc2:SmartTextbox ID="txtPostCode" runat="server" class="form-control" Width="350px"></cc2:SmartTextbox>--%>
                                        <asp:Label ID="lblPostCode" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label14" runat="server" Text="Subject"></asp:Label>
                                    </th>
                                    <td>
                                        <cc2:SmartTextbox ID="txtSubject_edit" runat="server" class="form-control"  MaxLength="500" ValidationGroup="NewRecord"></cc2:SmartTextbox>
                                         <asp:Label ID="lblSubject_view" runat="server" Text="" Visible="false" 
                                             style="word-break:break-all;word-wrap:normal"></asp:Label>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSubject_edit" 
                                            Display="Dynamic" ErrorMessage="Please input." ForeColor="Red" ValidationGroup="NewRecord"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label3" runat="server" Text="Date"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<cc2:DatePicker ID="DPDate" runat="server" AutoPostBack="true" />--%>
                                        <asp:Label ID="lblDPDate_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartTextbox ID="DPDate_edit" runat="server" MaxLength="10" onkeypress="return isNumber(event)"></cc2:SmartTextbox>
                                        <asp:ImageButton ID="ImageButton_edit" ImageUrl="img/calendar.png" ImageAlign="Bottom" runat="server" />
                                        <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="ImageButton_edit" runat="server" TargetControlID="DPDate_edit"
                                            Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label10" runat="server" Text="Super User"></asp:Label>
                                    </th>
                                    <td>
                                        <%--<asp:Label ID="lbl_UserCode" runat="server" ></asp:Label>--%>
                                        <asp:Label ID="lblSuperUser" runat="server" Text="" ></asp:Label>
                                        <%--<cc2:SmartTextbox ID="txtSuperUser_edit" runat="server" class="form-control" Width="350px"></cc2:SmartTextbox>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label11" runat="server" Text="Owner By"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblOwnerBy" runat="server" Text="" ></asp:Label>
                                        <%--<cc2:SmartTextbox ID="txtOwnerBy_edit" runat="server" class="form-control" Width="350px"></cc2:SmartTextbox>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label4" runat="server" Text="Folder"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblFolderCode_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblFolderCode" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartDropDownList ID="ddlFolderCode_edit" runat="server" class="form-control" AutoPostBack="true">
                                        </cc2:SmartDropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label12" runat="server" Text="Distribution"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblDistribution_view" runat="server" Text="" Visible="false"
                                            style="word-break:break-all;word-wrap:normal"></asp:Label>
                                        <cc2:SmartTextbox ID="txtDistribution_edit" runat="server" class="form-control"  TextMode="MultiLine" Rows="2" MaxLength="200"></cc2:SmartTextbox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label13" runat="server" Text="Detail"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblDetail_view" runat="server" Text="" Visible="false"
                                            style="word-break:break-all;word-wrap:normal"></asp:Label>
                                        <cc2:SmartTextbox ID="txtDetail_edit" runat="server" class="form-control" TextMode="MultiLine" Rows="3" MaxLength="1000"></cc2:SmartTextbox>
                                    </td>
                                </tr>

                                <tr>
                                    <th class="width30">
                                        <asp:Label ID="Label1" runat="server" Text="Sorting"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblSorting_view" runat="server" Text="" Visible="false"></asp:Label>
                                        <cc2:SmartTextbox ID="txtSorting_edit" runat="server" class="form-control" Width="350px" onkeypress="return isNumber(event)"></cc2:SmartTextbox>
                                    </td>
                                </tr>



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
                                             <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                           <%-- <asp:Label ID="lblInfoStatus_view" runat="server" Text="" Visible="false"></asp:Label>
                                            <cc2:SmartDropDownList ID="ddlInfoStatus_edit" runat="server" class="form-control">
                                            </cc2:SmartDropDownList>--%>
                                        </td>
                                    </tr>
                                </div>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblURL" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblURLTarget" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblRemark" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblSystem" runat="server" Text="" Visible="false"></asp:Label>
                                         <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>

                                        <asp:Button ID="btnUpdate_Info" runat="server" Text="Save"
                                            class="btn btn-info btn-block" OnClick="btnUpdate_Info_Click" Width="80px" ValidationGroup="NewRecord" OnClientClick="return confirm('Confirm to update?');"/>
                                        <asp:Label ID="lblAlert3" runat="server" Text="沒有這個ID" ForeColor="Red" Visible="false"></asp:Label>

                                        

                                      <%--  <asp:Button ID="btnEdit_Info" runat="server" Text="Edit post"
                                             class="btn btn-info btn-block" OnClick="btnEdit_Info_Click" Width="80px" />--%>

                                        <asp:Button ID="btnClosePost" runat="server" Text="Close Post" OnClick="btnClosePost_Click" class="btn btn-info" OnClientClick="return confirm('Confirm to close?');"/>

                                        
                                    </td>
                                    <td>
                                         <asp:Button ID="btnPost" runat="server" Text="Post"
                                            class="btn btn-info btn-block" OnClick="btnPost_Click" Width="80px" ValidationGroup="NewRecord" OnClientClick="return confirm('Confirm to change status?');"/>
                                        <asp:Button ID="btnAdministrator" runat="server" Text="Change SuperUser and Owner" OnClick="btnAdministrator_Click" class="btn btn-info" />
                                                                                
                                        <%-- <asp:Button ID="btnClose_Info" runat="server" Text="Close"
                                            class="btn btn-info btn-block" OnClick="btnClose_Info_Click" Width="80px" />--%>
                                    
                                    </td>
                                </tr>

                            </table>
                        </div>

                        <div id="divPopUpPanel" runat="server" class="panel panel-primary">
                             <div runat="server" class="panel panel-primary">
                                <div class="panel-heading">
                                    <asp:Label ID="Label2" runat="server" Text="Administrator" Font-Bold="True"></asp:Label>
                                </div>
                                <table class="table table-condensed table-hover">
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label8" runat="server" Text="Super User"></asp:Label>
                                        </th>
                                        <td>
                                            <cc2:SmartDropDownList ID="ddlSuperUser" runat="server" class="form-control" AutoPostBack="true">
                                                </cc2:SmartDropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label15" runat="server" Text="Owner By"></asp:Label>
                                        </th>
                                        <td>
                                            <cc2:SmartDropDownList ID="ddlOwnerBy" runat="server" class="form-control" AutoPostBack="true">
                                                </cc2:SmartDropDownList>
                                        </td>
                                    </tr>
                           
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnUpdate_Administrator" runat="server" Text="Update"
                                                class="btn btn-info btn-block" OnClick="btnUpdate_Administrator_Click" Width="80px" OnClientClick="return confirm('Confirm to update?');"/>

                                        </td>
                                        <td>
                                            <asp:Button ID="btnClose_Administrator" runat="server" Text="Close"
                                                class="btn btn-info btn-block" OnClick="btnClose_Administrator_Click" Width="80px" />
                                            <asp:Label ID="lblAlert5" runat="server" Text="沒有這個ID" ForeColor="Red" Visible="false"></asp:Label>
                                        </td>
                                    </tr>

                                </table>
                            </div>
                        </div>
                <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender3" runat="server"
                    TargetControlID="divPopUpPanel" VerticalSide="Middle" HorizontalSide="Center" ScrollEffectDuration=".1" />

                    
                    </ContentTemplate>
                </asp:UpdatePanel>


                <div id="divAttachment" runat="server">
                <%-- <asp:UpdatePanel ID="upAttachment" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnAttachmentAdd" />
                    </Triggers>--%>
                <asp:UpdatePanel ID="upAttachment" runat="server">
                    <ContentTemplate>
                    <%--     <table class="table table-condensed table-hover">
                            <tr>
                                <th>
                                    <asp:Panel ID="pnlAttachmentHeader" runat="server" Height="24px">
                                        <asp:Button ID="btnAttachmentShow" runat="server" Text="Attachment" class="btn btn-info btn-block" Width="80px" OnClick="btnAttachmentShow_Click" />
                                        <asp:Label ID="Label2" runat="server" Text="Attachment" Font-Bold="True"></asp:Label>
                                    </asp:Panel>
                                </th>
                            </tr>
                        </table>--%>

                        <div runat="server" class="panel panel-primary">
                            <div class="panel-heading">
                                <asp:Label ID="Label9" runat="server" Text="Attachment:" Font-Bold="True"></asp:Label>
                            </div>

                         <%--   <asp:Panel ID="pnlAttachmentDetail" runat="server">--%>
                            <div id="div_EditAttachment" runat="server">
                                <table class="table table-condensed table-hover">
                                     <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label37" runat="server"  Text="Item"></asp:Label>
                                        </th>
                                        <td>
                                            <asp:Panel ID="Panel3" runat="server">
                                                <cc2:SmartTextbox ID="txtItem" runat="server" class="form-control"  Width="450px"  MaxLength="30"></cc2:SmartTextbox>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label16" runat="server"  Text="Description"></asp:Label>
                                        </th>
                                        <td>
                                                <cc2:SmartTextbox ID="txtDescription" runat="server"  ValidationGroup="Attachment" class="form-control" 
                                                    MaxLength="500" TextMode="MultiLine" Rows="3"></cc2:SmartTextbox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label5" runat="server" Text="File"></asp:Label>
                                        </th>
                                        <td >
                                            <asp:FileUpload ID="FileUpload1" runat="server" Width="100%" />
                                           <%-- <asp:RequiredFieldValidator ID="rfvFileUpload1" runat="server" ControlToValidate="FileUpload1"
                                                Display="Dynamic" ErrorMessage="不能為空" ValidationGroup="Attachment"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label6" runat="server"  Text="Attachment Description"></asp:Label>
                                        </th>
                                        <td>
                                            <%--<asp:Panel ID="Panel14" runat="server">--%>
                                                <cc2:SmartTextbox ID="txtFileDesc" runat="server"  ValidationGroup="Attachment" class="form-control" 
                                                    MaxLength="200" TextMode="MultiLine" Rows="2"></cc2:SmartTextbox>
                                               
                                            <%--</asp:Panel>--%>
                                        </td>
                                    </tr>
                                     <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label18" runat="server"  Text="Link"></asp:Label>
                                        </th>
                                        <td>
                                                <cc2:SmartTextbox ID="txtLink" runat="server"  ValidationGroup="Attachment" class="form-control" 
                                                    MaxLength="300" ></cc2:SmartTextbox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="width30">
                                            <asp:Label ID="Label17" runat="server"  Text="Remark"></asp:Label>
                                        </th>
                                        <td>
                                                <cc2:SmartTextbox ID="txtRemark" runat="server"  ValidationGroup="Attachment" class="form-control" 
                                                    MaxLength="500" TextMode="MultiLine" Rows="3"></cc2:SmartTextbox>

                                             <asp:Button ID="btnAttachmentAdd" runat="server" Text="Add" ValidationGroup="Attachment" class="btn btn-info btn-block" Width="80px"
                                                    PostBackUrl="#divAttachment" OnClick="btnAttachmentAdd_Click" />

                                                <asp:Label ID="lblAlert4" runat="server" Text="沒有這個ID" ForeColor="Red" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                            <%--</asp:Panel>--%>

                            <%-- <cc1:CollapsiblePanelExtender ID="cpeAttachment" runat="Server" Collapsed="true"
                                TargetControlID="pnlAttachmentDetail" ExpandControlID="btnAttachmentShow" CollapseControlID="btnAttachmentShow" />--%>

                            <asp:GridView ID="grdAttachment" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-hover table-bordered"

                                OnRowCommand="grdAttachment_RowCommand" OnRowDataBound="grdAttachment_RowDataBound" style="word-wrap:normal">
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSeq_No" runat="server" Text='<%# Eval("Seq_No")%>' Visible="false"> </asp:Label>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Attachment">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("File_Path", "~{0}") %>'
                                                Target="_blank" Text='<%# Eval("File_Path") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="Description" HeaderText="Detail" SortExpression="Description" />
                                    <asp:TemplateField HeaderText="Attachment" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("File_Path", "~{0}") %>'
                                                Target="_blank" Text='<%# bindGetFile(Eval("File_Path"))%>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Link" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("Link") %>'
                                                Target="_blank" Text='<%# bindGetLink(Eval("Link"))%>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--  <asp:BoundField DataField="File_Type" HeaderText="附件類型" SortExpression="File_Type" />--%>
                                    <asp:BoundField DataField="Upload_By" HeaderText="Upload By" SortExpression="Upload_By" HeaderStyle-Wrap="false" />
                                    <asp:BoundField DataField="Upload_Date" HeaderText="Upload Date" SortExpression="Upload_Date" HeaderStyle-Wrap="false" />
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



    </form>
</body>
</html>



