<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPageHeader.ascx.cs" Inherits="ucPageHeader" %>
<table class="tblLSProjectHeader">
    <thead>
        <tr id="LSProjectHeader">
            <td class="LSProjectLogo">
                <asp:Image ID="imgLamsoon" runat="server" BackColor="White" ImageUrl="img/logo.gif" />
            </td>
            <td>
                <div id="LSProjectTitle">
                    <h1>
                        <asp:Literal ID="ltlTitle" runat="server" Text=""></asp:Literal>
                    </h1>
                </div>
            </td>
            <td>
                <div id="LSProjectLanguage">
                   <%-- <ul>
                        <li>
                            <asp:HyperLink ID="HyperLink1" runat="server" Target="_self">繁體</asp:HyperLink>|</li>
                        <li>
                            <asp:HyperLink ID="HyperLink2" runat="server" Target="_self">简体</asp:HyperLink>|</li>
                        <li>
                            <asp:HyperLink ID="HyperLink3" runat="server" Target="_self">Eng</asp:HyperLink></li>
                    </ul>--%>
                    <div class="textRight">
                        <asp:Label ID="lblPageHeaderTips" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
                        
                        <asp:HyperLink ID="hlSystemUpdateLog" runat="server" Target="_self">更新記錄</asp:HyperLink><asp:Label ID="lblSystemUpdateLog" runat="server" Text="" >|</asp:Label>
                        <asp:HyperLink ID="hlUserManual" runat="server" Target="_self">用戶手冊</asp:HyperLink><asp:Label ID="lblUserManual" runat="server" Text="" >|</asp:Label>
                        <asp:Literal ID="ltlName" runat="server" />&nbsp;|
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Logout" PostBackUrl="~/Account_Login.aspx"></asp:LinkButton>
                    </div>
                </div>
            </td>
        </tr>
    </thead>
</table>