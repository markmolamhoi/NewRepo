<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WF_DDLField.aspx.cs" Inherits="WF_DDLField" %>

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
                 <div id="divCoverLayer"  runat="server"></div>

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
                                        <asp:Label ID="lblKey_Header" runat="server" Text='<%# Eval("Seq_No")%>' Visible="false"> </asp:Label>
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
                                <%-- <asp:TemplateField ItemStyle-Width="50px">
                                            <ItemTemplate >
                                                 <asp:Button ID="btnCopytoDev" runat="server" Text="更新測試場"  class="btn btn-info" CommandName="CopytoDev" CommandArgument='<%# Container.DataItemIndex %>'/>  
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                <asp:BoundField DataField="Seq_No" HeaderText="Seq_No" SortExpression="Seq_No"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="Field_Key" HeaderText="Field_Key" SortExpression="Field_Key"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="Field_en" HeaderText="Field_en" SortExpression="Field_en"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="Field_tc" HeaderText="Field_tc" SortExpression="Field_tc"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="Field_sc" HeaderText="Field_sc" SortExpression="Field_sc"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="Field_Type" HeaderText="Field_Type" SortExpression="Field_Type"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="Sort_Seq" HeaderText="Sort_Seq" SortExpression="Sort_Seq"
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

                 <div id="divPopUpPanel" runat="server" >
                       <%-- <div class="panel panel-info">--%>
                        <div  class="panel panel-primary">  
                                                  
                            <div class="panel-heading">
                                <asp:Label ID="Label9" runat="server" Text="更新-tbl_wf_all_Field" Font-Bold="True"></asp:Label>
                               
                            </div>      

                            <table class="table table-condensed table-hover" >
                                <tr>
                                    <th class="width15">
                                        <asp:Label ID="Label5" runat="server" Text="Seq_No"></asp:Label>
                                    </th>
                                    <td colspan="2">
                                       <%-- <asp:Label ID="lblEditKey" runat="server" Text=""></asp:Label>--%>
                                        <cc2:SmartTextbox ID="txtSeq_No" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                </tr>   
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Field_Key"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                       <%-- <asp:Label ID="lblEditKey" runat="server" Text=""></asp:Label>--%>
                                        <cc2:SmartTextbox ID="txtKey" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                </tr>                                 
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Field_en"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <cc2:SmartTextbox ID="txtField_en" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                </tr>     
                                <tr>
                                    <td>
                                        <asp:Label ID="Label18" runat="server" Text="Field_tc" Width="115px"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <cc2:SmartTextbox ID="txtField_tc" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                </tr> 
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Field_sc" Width="115px"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <cc2:SmartTextbox ID="txtField_sc" runat="server" class="form-control" ></cc2:SmartTextbox>
                                    </td>
                                </tr>     
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Field_Type" Width="115px"></asp:Label>
                                    </td>
                                    <td >
                                        <cc2:SmartTextbox ID="txtField_Type" runat="server" class="form-control" onkeypress="return isNumberKey(event)"></cc2:SmartTextbox>                                       
                                    </td>
                                    <td>
                                         <asp:Button ID="btnGetNewField_Type" runat="server" Text="Get New"
                                            class="btn btn-info btn-block" OnClick="btnGetNewField_Type_Click" Width="100px" />
                                    </td>
                                </tr> 
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Sort_Seq" Width="115px"></asp:Label>
                                    </td>
                                   <td colspan="2">
                                        <cc2:SmartTextbox ID="txtSort_Seq" runat="server" class="form-control" onkeypress="return isNumberKey(event)"></cc2:SmartTextbox>
                                    </td>
                                </tr>                      
                                <tr>    
                                    <td > 
                                        <asp:Button ID="btnUpdateEditHeader" runat="server" Text="更新"
                                            class="btn btn-info btn-block" OnClick="btnUpdateEditHeader_Click" Width="80px" />
                                        <asp:Label ID="lblAlert1" runat="server" Text="沒有這個ID" ForeColor="Red" Visible="false"></asp:Label> 
                                    </td>
                                    <td colspan="2">
                                        <asp:Button ID="btnCloseEditHeader" runat="server" Text="關閉"
                                            class="btn btn-info btn-block" OnClick="btnCloseEditHeader_Click" Width="80px" />
                                    </td>
                                </tr>
                              
                            </table>                            
                        </div>

                    </div>
                    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender2" runat="server"
                        TargetControlID="divPopUpPanel" VerticalSide="Middle" HorizontalSide="Center" ScrollEffectDuration=".1" />

            </ContentTemplate>
        </asp:UpdatePanel>


    </form>
</body>
</html>



