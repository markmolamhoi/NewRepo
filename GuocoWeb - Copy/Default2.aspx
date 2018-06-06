<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="_Default2" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="UserControlLibrary" Namespace="UserControlLibrary.Lamsoon"
    TagPrefix="cc2" %>
<%@ Register Assembly="LSLIBWebBased" Namespace="LSLIBWebBased.LSWebControl" TagPrefix="cc3" %>
<%@ Register Src="ucPageHeader.ascx" TagName="ucPageHeader" TagPrefix="uc5" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="CSS/bootstrap.min.css" type="text/css" rel="stylesheet" />
    <link href="CSS/bootstrap-theme.min.css" type="text/css" rel="stylesheet" />
    <link href="CSS/bootstrap-select.min.css" type="text/css" rel="stylesheet" />

    <script src="js/jquery-1.12.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/bootstrap-select.min.js"></script>
    <script src="js/Tree.js"></script>


    <link href="CSS/StyleBootstrapBI.css" type="text/css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript">
        window.onload = function () {
            $('#tree1').treed();

            $('#tree2').treed({ openedClass: 'glyphicon-folder-open', closedClass: 'glyphicon-folder-close' });

            $('#tree3').treed({ openedClass: 'glyphicon-chevron-right', closedClass: 'glyphicon-chevron-down' });
        };
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <uc5:ucPageHeader ID="ucPageHeader1" runat="server" />
            <div id="divSalesDetail" runat="server" class="panel panel-primary">
                <div class="panel-heading">
                    <asp:Label ID="lblReportName" runat="server" Text="ReportName" Font-Bold="True"></asp:Label>
                </div>
                <asp:TreeView ID="TreeView1" runat="server">
                </asp:TreeView>
            </div>

            <ul class="list-group">
  <li class="list-group-item disabled">Cras justo odio</li>
  <li class="list-group-item">Dapibus ac facilisis in</li>
  <li class="list-group-item">Morbi leo risus</li>
                <ul class="list-group">
  <li class="list-group-item disabled">Cras justo odio</li>
  <li class="list-group-item">Dapibus ac facilisis in</li>
  <li class="list-group-item">Morbi leo risus</li>
  <li class="list-group-item">Porta ac consectetur ac</li>
  <li class="list-group-item">Vestibulum at eros</li>
</ul>
  <li class="list-group-item">Porta ac consectetur ac</li>
  <li class="list-group-item">Vestibulum at eros</li>
</ul>
        </div>

            <input data-type="search" id="searchForCollapsibleSetChildren">
                <div data-role="collapsibleset" data-filter="true" data-children="> div, > div div ul li" data-inset="true" id="collapsiblesetForFilterChildren" data-input="#searchForCollapsibleSetChildren">
                    
                    <asp:Literal runat="server" ID="ltlMenu"></asp:Literal>
                </div>

        <div class="container" style="margin-top: 30px;">
            <div class="row">
                <div class="col-md-4">
                    <ul id="tree1">
                        <p class="well" style="height: 135px;">
                            <strong>Initialization no parameters</strong>

                            <br />
                            <code>$('#tree1').treed();</code>

                        </p>
                        <li><a href="#">TECH</a>

                            <ul>
                                <li>Company Maintenance</li>
                                <li>Employees
                           
                                    <ul>
                                        <li>Reports
                                   
                                            <ul>
                                                <li>Report1</li>
                                                <li>Report2</li>
                                                <li>Report3</li>
                                            </ul>
                                        </li>
                                        <li>Employee Maint.</li>
                                    </ul>
                                </li>
                                <li>Human Resources</li>
                            </ul>
                        </li>
                        <li>XRP
                   
                            <ul>
                                <li>Company Maintenance</li>
                                <li>Employees
                           
                                    <ul>
                                        <li>Reports
                                   
                                            <ul>
                                                <li>Report1</li>
                                                <li>Report2</li>
                                                <li>Report3</li>
                                            </ul>
                                        </li>
                                        <li>Employee Maint.</li>
                                    </ul>
                                </li>
                                <li>Human Resources</li>
                            </ul>
                        </li>
                    </ul>
                </div>
                <div class="col-md-4">
                    <p class="well" style="height: 135px;">
                        <strong>Initialization optional parameters</strong>

                        <br />
                        <code>$('#tree2').treed({openedClass : 'glyphicon-folder-open', closedClass : 'glyphicon-folder-close'});</code>

                    </p>
                    <ul id="tree2">
                        <li><a href="#">TECH</a>

                            <ul>
                                <li>Company Maintenance</li>
                                <li>Employees
                           
                                    <ul>
                                        <li>Reports
                                   
                                            <ul>
                                                <li>Report1</li>
                                                <li>Report2</li>
                                                <li>Report3</li>
                                            </ul>
                                        </li>
                                        <li>Employee Maint.</li>
                                    </ul>
                                </li>
                                <li>Human Resources</li>
                            </ul>
                        </li>
                        <li>XRP
                   
                            <ul>
                                <li>Company Maintenance</li>
                                <li>Employees
                           
                                    <ul>
                                        <li>Reports
                                   
                                            <ul>
                                                <li>Report1</li>
                                                <li>Report2</li>
                                                <li>Report3</li>
                                            </ul>
                                        </li>
                                        <li>Employee Maint.</li>
                                    </ul>
                                </li>
                                <li>Human Resources</li>
                            </ul>
                        </li>
                    </ul>
                </div>
                <div class="col-md-4">
                    <p class="well" style="height: 135px;">
                        <strong>Initialization optional parameters</strong>

                        <br />
                        <code>$('#tree3').treed({openedClass:'glyphicon-chevron-right', closedClass:'glyphicon-chevron-down'});</code>

                    </p>
                    <ul id="tree3">
                        <li><a href="#">TECH</a>

                            <ul>
                                <li>Company Maintenance</li>
                                <li>Employees
                           
                                    <ul>
                                        <li>Reports
                                   
                                            <ul>
                                                <li>Report1</li>
                                                <li>Report2</li>
                                                <li>Report3</li>
                                            </ul>
                                        </li>
                                        <li>Employee Maint.</li>
                                    </ul>
                                </li>
                                <li>Human Resources</li>
                            </ul>
                        </li>
                        <li>XRP
                   
                            <ul>
                                <li>Company Maintenance</li>
                                <li>Employees
                           
                                    <ul>
                                        <li>Reports
                                   
                                            <ul>
                                                <li>Report1</li>
                                                <li>Report2</li>
                                                <li>Report3</li>
                                            </ul>
                                        </li>
                                        <li>Employee Maint.</li>
                                    </ul>
                                </li>
                                <li>Human Resources</li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
