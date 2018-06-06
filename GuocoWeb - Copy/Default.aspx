<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="css/jquery.mobile-1.4.5.min.css" type="text/css" />
    
    <link href="CSS/Stylebootstrap.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/themes/jquery.mobile.icons.min.css" />
    
    <link rel="stylesheet" type="text/css" href="css/themes/LS.min.css" />

    <script src="js/jquery-1.12.4.min.js" type="text/javascript"></script>
    <script src="js/jquery.mobile-1.4.5.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div data-role="page" id="pageone" >
            <div data-role="header">
                <uc5:ucPageHeader ID="ucPageHeader1" runat="server" />
            </div>

            <div data-role="content" >
                    <asp:Literal runat="server" ID="ltlMenu"></asp:Literal>
            </div>
        </div>
    </form>
</body>
</html>
