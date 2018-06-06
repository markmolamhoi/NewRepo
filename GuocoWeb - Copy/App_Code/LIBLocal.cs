using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using UserControlLibrary.Lamsoon;
using AjaxControlToolkit;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;

using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;
using System.Net.Mail;
using ChartDirector;
using System.Globalization;
using System.IO.Compression;
using System.Net;

using System.Threading;
using LSLIBWebBased.LSWebControl;
using System.Data.OleDb;
using LamsoonUserControl05.Lamsoon.WebControl;
using Microsoft.VisualBasic.Devices;

using LSLIBWebBased;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;



public static class LIBLocal
{
    #region "Account"
    

    public static String sLoadPasswordHashValue(String psUsername, String psPassword)
    {
        String lsHashValue;
        lsHashValue = FormsAuthentication.HashPasswordForStoringInConfigFile(psPassword + psUsername, "MD5");
        return lsHashValue;
    }

    public static void UpdatePassword(String psUsername, String psPassword,String flag)
    {

        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("@username", psUsername);
        ClsLoadFieldHelper.fAddSqlParameter("@Password", LIBLocal.sLoadPasswordHashValue(psUsername, psPassword));
        ClsLoadFieldHelper.fAddSqlParameter("@pwdnt", LIBLocal.EncodeRijndael("nt",psPassword));
        ClsLoadFieldHelper.fAddSqlParameter("@flag", flag);
        
        ClsLoadFieldHelper.fBuildDataSet("stp_wf_account_UpdatePassword");
    }

    public static string EncodeRijndael(string salt, string inText)
    {
        string keyString = "thisIsASampleKey";
        byte[] keyBuffer = UTF8Encoding.UTF8.GetBytes(keyString);
        string ivString = "123defghijklmnop";
        byte[] ivBuffer = UTF8Encoding.UTF8.GetBytes(ivString);

        string decryptedString = salt + inText;
        byte[] Buffer = UTF8Encoding.UTF8.GetBytes(decryptedString);
        RijndaelManaged riMan = new RijndaelManaged();
        riMan.Key = keyBuffer;
        riMan.IV = ivBuffer;
        string encryptedString = Convert.ToBase64String(riMan.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
        return encryptedString;
    }

    public static String sLoadRandomPassword(int PasswordLength, int PasswordType)
    {
        // ==========================================
        // Password Type : -
        //    1 : Lower case only
        //    2 : Upper case only
        //    3 : Number only
        //    4 : Lower and Upper case only
        //    5 : Lower case and Number only
        //    6 : Upper case and Number only
        //    7 : Lower and Upper case and Number
        // ==========================================
        int lNumberOfLowerCases = 0;
        int lNumberOfUpperCases = 0;
        int lNumberOfNumbers = 0;
        int l;
        int j;
        string ReturnedPassword;
        if ((PasswordLength <= 0))
        {
            return "";

        }
        Random lRandom = new Random(Guid.NewGuid().GetHashCode());
        // Get the number of digits for each type of characters
        if ((PasswordType == 1))
        {
            lNumberOfLowerCases = PasswordLength;
        }
        else if ((PasswordType == 2))
        {
            lNumberOfUpperCases = PasswordLength;
        }
        else if ((PasswordType == 3))
        {
            lNumberOfNumbers = PasswordLength;
        }
        else if ((PasswordType == 4))
        {
            lNumberOfLowerCases = lRandom.Next(1, (PasswordLength - 3)) + 1;
            lNumberOfUpperCases = PasswordLength - lNumberOfLowerCases;
            lNumberOfNumbers = 0;
        }
        else if ((PasswordType == 5))
        {
            lNumberOfLowerCases = lRandom.Next(1, (PasswordLength - 3)) + 1;
            lNumberOfUpperCases = 0;
            lNumberOfNumbers = PasswordLength - lNumberOfLowerCases;
        }
        else if ((PasswordType == 6))
        {
            lNumberOfLowerCases = 0;
            lNumberOfLowerCases = lRandom.Next(1, (PasswordLength - 3)) + 1;
            lNumberOfNumbers = PasswordLength - lNumberOfUpperCases;
        }
        else
        {
            lNumberOfLowerCases = lRandom.Next(1, (PasswordLength - 3)) + 1;
            lNumberOfUpperCases = lRandom.Next(1,(PasswordLength - lNumberOfLowerCases - 2))+ 1;
            lNumberOfNumbers = PasswordLength - lNumberOfLowerCases - lNumberOfUpperCases;
        }

        ReturnedPassword = "";
        for (l = 1; (l <= PasswordLength); l++)
        {
            if ((PasswordType == 1))
            {
                j = 1;
            }
            else if ((PasswordType == 2))
            {
                j = 2;
            }
            else if ((PasswordType == 3))
            {
                j = 3;
            }
            else if ((PasswordType == 4))
            {
                j = int.Parse(sLoadRandomCharacter("12", lRandom).ToString());
            }
            else if ((PasswordType == 5))
            {
                j = int.Parse(sLoadRandomCharacter("13", lRandom).ToString());
            }
            else if ((PasswordType == 6))
            {
                j = int.Parse(sLoadRandomCharacter("23", lRandom).ToString());
            }
            else
            {
                j = int.Parse(sLoadRandomCharacter("123", lRandom).ToString());
            }

            switch (j)
            {
                case 1:
                    // Lower Case
                    if (lNumberOfLowerCases > 0)
                    {
                        ReturnedPassword = ReturnedPassword + sLoadRandomCharacter("abcdefghijklmnopqrstuvwxyz", lRandom);
                        lNumberOfLowerCases = (lNumberOfLowerCases - 1);
                    }
                    else
                    {
                        l = (l - 1);
                        // Re-do the loop
                    }

                    break;
                case 2:
                    // Upper Case
                    if (lNumberOfUpperCases > 0)
                    {
                        ReturnedPassword = ReturnedPassword + sLoadRandomCharacter("ABCDEFGHIJKLMNOPQRSTUVWXYZ", lRandom);
                        lNumberOfUpperCases = (lNumberOfUpperCases - 1);
                    }
                    else
                    {
                        l = (l - 1);
                        // Re-do the loop
                    }

                    break;
                case 3:
                    // Number
                    if (lNumberOfNumbers > 0)
                    {
                        // ReturnedPassword = ReturnedPassword & CInt(9 * Rnd)
                        ReturnedPassword = ReturnedPassword + sLoadRandomCharacter("0123456789", lRandom);
                        lNumberOfNumbers = (lNumberOfNumbers - 1);
                    }
                    else
                    {
                        l = (l - 1);
                        // Re-do the loop
                    }

                    break;
            }
        }

        return ReturnedPassword;
    }

    public static char sLoadRandomCharacter(string psText, Random pRandom)
    {
        int index = pRandom.Next(psText.Length);
        return psText[index];
    }
    #endregion


    #region PageFunction
    public static void fCheckLogin()
    {
        if (LIBLocal.gsUsername == "")
        {
            HttpContext.Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["LoginPage"] + "?ReturnURL=" + HttpContext.Current.Request.Url.ToString());

        }
        LIBLocal.SetCookie(LIBLocal.gsUsername);
    }

    public static void SetCookie(String psUsername)
    {

        HttpCookie lHttpCookieUsername = new HttpCookie(HttpContext.Current.Server.UrlEncode("userName"), psUsername);
        lHttpCookieUsername.Expires = DateTime.Now.AddSeconds(double.Parse(System.Configuration.ConfigurationManager.AppSettings["AutoLogoutTime"]));
        System.Web.Security.FormsAuthentication.SetAuthCookie(psUsername, true);
        HttpContext.Current.Response.Cookies.Set(lHttpCookieUsername);
    }
    public static string gsUsername
    {
        get
        {
            if (HttpContext.Current.Request.Cookies["userName"] == null)
            {
                return "";
            }
            else
                return HttpContext.Current.Request.Cookies["userName"].Value.ToString();
        }
    }

    public static string sLoadUserName(String psUsername)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
        ClsLoadFieldHelper.fAddSqlParameter("@Username", psUsername);
        ClsLoadFieldHelper.fBuildDataSet("stp_wf_account_LoadUserInfo",null,"",false);
        if (ClsLoadFieldHelper.mbDataSetHasRecord)
        {
            return ClsLoadFieldHelper.oLoadSqlField("UserShortName").ToString();
        }
        return "";
    }

    public static string sLoadPostURL(String psURL, String psPostCode, String psFolderCode)
    {
        return LSLIBWebBased.nsCommon.mCommon.sAddQueryQuestionMark(psURL)
                + LSLIBWebBased.nsCommon.mCommon.sAddQueryParameter("PostCode", psPostCode);
    }

    public static string sLoadPostFullURL(String psURL, String psSystemCode, String psPostCode, String psFolderCode)
    {
        return LSLIBWebBased.nsCommon.mCommon.sAddQueryQuestionMark(psURL)
                + LSLIBWebBased.nsCommon.mCommon.sAddQueryParameter("SystemCode", psSystemCode)
                + LSLIBWebBased.nsCommon.mCommon.sAddQueryParameter("PostCode", psPostCode);
    }

    public static string sLoadSystemURL(String psSystemCode)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();

         ClsLoadFieldHelper.fAddSqlParameter("@SystemCode", psSystemCode);
         ClsLoadFieldHelper.fBuildDataSet("stp_wf_dms_LoadSystem");

         return ClsLoadFieldHelper.oLoadSqlField("URL").ToString();
    }


    public static string sLoadSystemTypeCode(String psSystemCode)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("@SystemCode", psSystemCode);
        ClsLoadFieldHelper.fBuildDataSet("stp_wf_dms_LoadSystem");

        return ClsLoadFieldHelper.oLoadSqlField("SystemTypeCode").ToString();
    }
    //this.ClsHashTableHelper.msUserName
    public static bool bCanHaveRight(String psUserName, String psSystemCode, String psFolderCode, String psPostCode, String psAction)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("@UserCode", psUserName);
        ClsLoadFieldHelper.fAddSqlParameter("@SystemCode", psSystemCode);
        ClsLoadFieldHelper.fAddSqlParameter("@FolderCode", psFolderCode);
        ClsLoadFieldHelper.fAddSqlParameter("@PostCode", psPostCode);
        ClsLoadFieldHelper.fAddSqlParameter("@Rights", psAction);

        ClsLoadFieldHelper.fBuildDataSet("stp_wf_all_Security_bHasFunctionRights");

        if (ClsLoadFieldHelper.mbDataSetHasRecord)
        {
            // LSLIBWebBased.nsScript.mScript.Alert(this, ClsLoadFieldHelper.oLoadSqlField("Result").ToString(), false);
            return false;
        }
        else
        {
            return true;
        }
    }

    public static Object fSetCoontrolEditMode(Object pControl1) //As Object
    {
        Control pControl = (Control)pControl1;

        switch (pControl.GetType().Name)
        {
            case "Label":
                Label lControl1 = (Label)pControl;
                if (lControl1.ID.Contains("_view"))
                {
                    pControl.Visible = false;
                }
                //else
                //{
                //    pControl.Visible = true;
                //}
                break;

            case "TextBox":
                System.Web.UI.WebControls.TextBox lControl2 = (System.Web.UI.WebControls.TextBox)pControl;
                if (lControl2.ID.Contains("_edit"))
                {
                    pControl.Visible = true;
                }
                //else
                //{
                //    pControl.Visible = false;
                //}
                break;
        }

        return "";
    }

    public static Object fSetCoontrolViewMode(Object pControl1) //As Object
    {
        Control pControl = (Control)pControl1;

        switch (pControl.GetType().Name)
        {
            case "Label":
                Label lControl1 = (Label)pControl;
                if (lControl1.ID.Contains("_view"))
                {
                    pControl.Visible = true;
                }
                //else
                //{
                //    pControl.Visible = false;
                //}
                break;

            case "SmartTextbox":
                System.Web.UI.WebControls.TextBox lControl2 = (System.Web.UI.WebControls.TextBox)pControl;
                if (lControl2.ID.Contains("_edit"))
                {
                    pControl.Visible = false;
                }
                //else
                //{
                //    pControl.Visible = true;
                //}
                break;

            case "SmartDropDownList":
                DropDownList lControl3 = (DropDownList)pControl;
                if (lControl3.ID.Contains("_edit"))
                {
                    pControl.Visible = false;
                }
                break;

            case "ImageButton":
                ImageButton lControl4 = (ImageButton)pControl;
                if (lControl4.ID.Contains("_edit"))
                {
                    pControl.Visible = false;
                }
                break;
        }

        return "";
    }

    public static void BindDDLUserList(UserControlLibrary.Lamsoon.SmartDropDownList pDropDownList, string psSystemCode, string psType, string psKey1, string psKey2)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
        //ClsLoadFieldHelper.fAddSqlParameter("@UserCode", this.ClsHashTableHelper.msUserName);
        ClsLoadFieldHelper.fAddSqlParameter("@SystemCode", psSystemCode);
        ClsLoadFieldHelper.fAddSqlParameter("@Type", psType);
        ClsLoadFieldHelper.fAddSqlParameter("@Key1", psKey1);
        ClsLoadFieldHelper.fAddSqlParameter("@Key2", psKey2);
        ClsLoadFieldHelper.fBuildDataSet("stp_wf_all_DDLUserList");
        ClsLoadFieldHelper.fBindControls(pDropDownList);
    }

    #endregion

    public static String fStringToHTMLDisplayFormat(String psValue)
    {
        psValue = psValue.Replace(Char.ConvertFromUtf32(13), "<br>");
        return psValue;
    }

    #region "Email"
    public static bool bIsValidEmail(string psValue)
    {
        string pattern = @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(psValue.Trim(), pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

        if (match.Success)
            return true;
        else
            return false;
    }

    public static bool bSendEmail(string psEmailTo, string psEmailSubject, string psEmailBody)
    {
        return SendMail("ebidding@lamsoon.com", psEmailTo, "", "", psEmailSubject, psEmailBody, "gb2312", "", "202.64.111.197");
    }


    /// <summary>
    /// Full Example 1 to 1 email.
    /// </summary>
    public static bool SendMail(string psEmailFrom, string psEmailTo, string psCC, string psBCC, string psMailSubject, string psMailBody, string psEncoding = "", string psAttachment = "", string psEmailSMTPServerIP = "10.1.0.18", string psEmailFromName = "", string psEmailToName = "")
    {
        ////delay depend on email
        //ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
        //ClsLoadFieldHelper.fAddSqlParameter("Email", psEmailTo);
        //ClsLoadFieldHelper.fBuildDataSet("stp_wf_rss_eCard_bDelaySecond");
        //int liSecond = Convert.ToInt32(ClsLoadFieldHelper.oLoadSqlField("Second"));

        //if (liSecond == 1)
        //{

        //}
        //else
        //{
        //    System.Threading.Thread.Sleep(liSecond * 1000);
        //}

        //sending email
        MailMessage lMailMessage = new MailMessage();
        if (!string.IsNullOrEmpty(psEmailFrom) & !string.IsNullOrEmpty(psEmailTo) & !string.IsNullOrEmpty(psMailBody))
        {
            lMailMessage.From = new MailAddress(psEmailFrom, psEmailFromName);
            lMailMessage.To.Add(new MailAddress(psEmailTo, psEmailToName));

            if (psCC != "")
            {
                lMailMessage.CC.Add(new MailAddress(psCC));
            }

            if (psBCC != "")
            {
                lMailMessage.Bcc.Add(new MailAddress(psBCC));
            }

            //if (!string.IsNullOrEmpty(psAttachment))
            //{
            //    ClassFileUploadHelper ClsFileUploadHelper = new ClassFileUploadHelper();
            //    string lsFileMapPath = ClsFileUploadHelper.sFileRealPath(psAttachment);
            //    lMailMessage.Attachments.Add(new Attachment(lsFileMapPath));
            //}

            if (string.IsNullOrEmpty(psEncoding))
            {
                lMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            }
            else
            {
                lMailMessage.BodyEncoding = System.Text.Encoding.GetEncoding(psEncoding);
            }

            lMailMessage.IsBodyHtml = true;
            lMailMessage.Subject = psMailSubject;
            lMailMessage.Body = psMailBody;

            SmtpClient lSmtpClient = new SmtpClient();
            lSmtpClient.Host = psEmailSMTPServerIP;
            //lSmtpClient.EnableSsl = true;

            lSmtpClient.Send(lMailMessage);
            return true;

        }
        return true;
    }


    public static bool SendMailnew(string psUserName, string psCC, string psBCC, string psMailSubject, string psMailBody, string psEncoding = "", string psAttachment = "", string psEmailSMTPServerIP = "10.1.0.18", string psEmailFromName = "", string psEmailToName = "")
    {

        //OpenEmail
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
        ClsLoadFieldHelper.fAddSqlParameter("@username", psUserName);
        ClsLoadFieldHelper.fBuildDataSet("stp_wf_account_LoadEmail");
        string lsEmail = ClsLoadFieldHelper.oLoadSqlField("Email").ToString();


        //sending email
        MailMessage lMailMessage = new MailMessage();
        if (!string.IsNullOrEmpty(lsEmail) & !string.IsNullOrEmpty(lsEmail) & !string.IsNullOrEmpty(psMailBody))
        {
            lMailMessage.From = new MailAddress(lsEmail, psEmailFromName);
            lMailMessage.To.Add(new MailAddress(lsEmail, psEmailToName));

            if (psCC != "")
            {
                lMailMessage.CC.Add(new MailAddress(psCC));
            }

            if (psBCC != "")
            {
                lMailMessage.Bcc.Add(new MailAddress(psBCC));
            }

         
            if (string.IsNullOrEmpty(psEncoding))
            {
                lMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            }
            else
            {
                lMailMessage.BodyEncoding = System.Text.Encoding.GetEncoding(psEncoding);
            }

            lMailMessage.IsBodyHtml = true;
            lMailMessage.Subject = psMailSubject;
            lMailMessage.Body = psMailBody;

            SmtpClient lSmtpClient = new SmtpClient();
            lSmtpClient.Host = psEmailSMTPServerIP;
            //lSmtpClient.EnableSsl = true;

            lSmtpClient.Send(lMailMessage);
            return true;

        }
        return true;
    }

    #endregion


    //private string msReportType
    //{
    //    get
    //    {
    //        return LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["psReportType"]).ToString();
    //    }
    //}


    public static string AddReportType(String Username, String psReportType, String psReportID, ClassHashTableHelper ClsHashTableHelper)
    {
        //<li role="presentation" class="active"><a href="Demopage.aspx">Inventory Turnover Days</a></li>
        String msListTemplate = @"<li role=""presentation"" ";
        String msListTemplate1 = @"><a href=""Listlink"">";
        String msListTemplate2 = @"ListName</a></li>";

        String lsReportType = "";
        String lsReportURL = "";
        String lsReportIDName = "";
        String lsReportID = "";

        String sltlMenu = "";
        //this.ltlMenu.Text

        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
        ClsLoadFieldHelper.fAddSqlParameter("@Username", Username);
        ClsLoadFieldHelper.fAddSqlParameter("@ReportType", psReportType);
        ClsLoadFieldHelper.fBuildDataSet("stp_wf_rss_BI_GridReportMaster");

        //ClassHashTableHelper ClsHashTableHelper = new ClassHashTableHelper();
        while (ClsLoadFieldHelper.bHasNextRow())
        {
            if (psReportID != ClsLoadFieldHelper.oLoadSqlField("ReportID").ToString() && psReportID != null)
            {
                sltlMenu += msListTemplate;
            }
            else
            {
                if (psReportID == null)
                {
                    psReportID = "NoData";
                }
                sltlMenu += msListTemplate + "class='active'";
            }

            lsReportID = ClsLoadFieldHelper.oLoadSqlField("ReportID").ToString();
            lsReportIDName = ClsHashTableHelper.sGetHash(lsReportID);

            lsReportURL = ClsHashTableHelper.sExchangeURL(LSLIBWebBased.nsCommon.mCommon.sAddQueryQuestionMark(ClsLoadFieldHelper.oLoadSqlField("URL").ToString())
            + LSLIBWebBased.nsCommon.mCommon.sAddQueryParameter("ReportType", psReportType) //msReportType)
            + LSLIBWebBased.nsCommon.mCommon.sAddQueryParameter("ReportID", lsReportID)
            );

            sltlMenu += msListTemplate1.Replace("Listlink", lsReportURL).ToString();

            if (lsReportIDName != lsReportID)
            {
                lsReportType = lsReportIDName;
            }
            else
            {
                lsReportType = ClsHashTableHelper.sGetHash(ClsLoadFieldHelper.oLoadSqlField("ReportName").ToString());
            }

            //lsReportType = sReportName(ClsLoadFieldHelper.oLoadSqlField("ReportID").ToString(), ClsLoadFieldHelper.oLoadSqlField("ReportName").ToString());
            sltlMenu += msListTemplate2.Replace("ListName", ClsHashTableHelper.sGetHash(lsReportType)).ToString();
        }

        return sltlMenu;
    }

    //fix if no report type, cannot load correct report.
    public static string AddReportTypeFirstUrl(String psUsername, String psReportType)
    {
        String lsReportURL = "";
        String lsReportID = "";
        String lsReportType = "";

        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
        ClsLoadFieldHelper.fAddSqlParameter("@Username", psUsername);
        ClsLoadFieldHelper.fAddSqlParameter("@ReportType", psReportType);
        ClsLoadFieldHelper.fBuildDataSet("stp_wf_rss_BI_GridReportMaster");

        ClassHashTableHelper ClsHashTableHelper = new ClassHashTableHelper();

        if (ClsLoadFieldHelper.bHasNextRow() == true)
        {
            lsReportID = ClsLoadFieldHelper.oLoadSqlField("ReportID").ToString();

            if (psReportType == "")
            {
                lsReportType = ClsLoadFieldHelper.oLoadSqlField("ReportType").ToString();
            }
            else
            {
                lsReportType = psReportType;
            }

            lsReportURL = ClsHashTableHelper.sExchangeURL(LSLIBWebBased.nsCommon.mCommon.sAddQueryQuestionMark(ClsLoadFieldHelper.oLoadSqlField("URL").ToString())
            + LSLIBWebBased.nsCommon.mCommon.sAddQueryParameter("ReportType", lsReportType)
            + LSLIBWebBased.nsCommon.mCommon.sAddQueryParameter("ReportID", lsReportID)
            );
        }

        return lsReportURL;
    }

    #region "Chart"
    public static string sLoadChartTitle(string psReportName
                        , String psOriginalReportName)
    {
        if (psOriginalReportName.IndexOf(" - ") > 0)
        {
            psOriginalReportName = psReportName + psOriginalReportName.Substring(psOriginalReportName.IndexOf(" - "));
        }
        return psOriginalReportName;
    }


    public static void BindChartAndGrid(System.Web.UI.HtmlControls.HtmlGenericControl psControl
        , System.Web.UI.DataVisualization.Charting.Chart pChart
        , GridView pGridView
        , Label pslblPrintSql
        , String psReportID
        , String psContentType
        , String psDivisionCode
        , String psRegionCode
        , String psCompanyCode
        , String psOUCode
        , String psSearchKey
        , String psUsername
        , String psYear
        , String psMonth
        , String psWeek
        , String psProductCode
        , String psSalesmanCode
        , String psConnectOracle
        , ClassHashTableHelper pClsHashTableHelper
        , string psChartType
        , string psGridSTPName
        )
    {
        LSLIBWebBased.ClassLoadFieldHelper ClsLoadFieldHelper;

        ClsLoadFieldHelper = new LSLIBWebBased.ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("ContentType", psContentType);
        ClsLoadFieldHelper.fAddSqlParameter("DivisionCode", psDivisionCode);
        ClsLoadFieldHelper.fAddSqlParameter("RegionCode", psRegionCode);
        ClsLoadFieldHelper.fAddSqlParameter("CompanyCode", psCompanyCode);
        ClsLoadFieldHelper.fAddSqlParameter("OUCode", psOUCode);
        ClsLoadFieldHelper.fAddSqlParameter("SearchKey", psSearchKey);
        ClsLoadFieldHelper.fAddSqlParameter("Username", psUsername);
        ClsLoadFieldHelper.fAddSqlParameter("Year", psYear);
        ClsLoadFieldHelper.fAddSqlParameter("Month", psMonth);
        ClsLoadFieldHelper.fAddSqlParameter("Week", psWeek);
        ClsLoadFieldHelper.fAddSqlParameter("ProductCode", psProductCode);
        ClsLoadFieldHelper.fAddSqlParameter("SalesmanCode", psSalesmanCode);
        ClsLoadFieldHelper.fAddSqlParameter("ReportID", psReportID);
        ClsLoadFieldHelper.fAddSqlParameter("Lang", pClsHashTableHelper.msLang);

        if (psConnectOracle == "Y")
        {
            ClsLoadFieldHelper.fBuildDataSet_Oracle(psGridSTPName);
        }
        else
        {
            ClsLoadFieldHelper.fBuildDataSet(psGridSTPName);
        }

        if (ClsLoadFieldHelper.mbDataSetHasRecord)
        {
            ClsLoadFieldHelper.fBindGridView(pGridView);

            //if (LIBWebBased.bEnableProjectFunction("RSS", "bCanViewSQLScript", psUsername) == true)
            //{
            //    pslblPrintSql.Visible = true;
            //    pslblPrintSql.Text = sConnectOracle + psGridSTPName + " " + ClsLoadFieldHelper.fPrintSqlParameterList();
            //}
            //else
            //{
            //    pslblPrintSql.Visible = false;
            //}
            LIBLocal.SetViewSQLScript( ClsLoadFieldHelper, pClsHashTableHelper, psConnectOracle, pslblPrintSql);


            DataTable lDatatable = ClsLoadFieldHelper.fGetDataSet().Tables[0];
            LIBLocal.BuildChart(pChart, lDatatable, pClsHashTableHelper, psReportID, psChartType);
            psControl.Visible = true;

            //set the xAxis column name

            if (pGridView.Rows[0].Cells.Count >= 2)
            {
                pGridView.HeaderRow.Cells[4].Text = pGridView.Rows[0].Cells[2].Text;
            }
        }
    }

    public static Boolean CheckBindChartAndGrid(
        String psReportID
       , String psContentType
       , String psDivisionCode
       , String psRegionCode
       , String psCompanyCode
       , String psOUCode
       , String psSearchKey
       , String psUsername
       , String psYear
       , String psMonth
       , String psWeek
       , String psProductCode
       , String psSalesmanCode
       , String psConnectOracle
       , ClassHashTableHelper pClsHashTableHelper
       , string psChartType
       , string psGridSTPName
       )
    {
        LSLIBWebBased.ClassLoadFieldHelper ClsLoadFieldHelper;

        ClsLoadFieldHelper = new LSLIBWebBased.ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("ContentType", psContentType);
        ClsLoadFieldHelper.fAddSqlParameter("DivisionCode", psDivisionCode);
        ClsLoadFieldHelper.fAddSqlParameter("RegionCode", psRegionCode);
        ClsLoadFieldHelper.fAddSqlParameter("CompanyCode", psCompanyCode);
        ClsLoadFieldHelper.fAddSqlParameter("OUCode", psOUCode);
        ClsLoadFieldHelper.fAddSqlParameter("SearchKey", psSearchKey);
        ClsLoadFieldHelper.fAddSqlParameter("Username", psUsername);
        ClsLoadFieldHelper.fAddSqlParameter("Year", psYear);
        ClsLoadFieldHelper.fAddSqlParameter("Month", psMonth);
        ClsLoadFieldHelper.fAddSqlParameter("Week", psWeek);
        ClsLoadFieldHelper.fAddSqlParameter("ProductCode", psProductCode);
        ClsLoadFieldHelper.fAddSqlParameter("SalesmanCode", psSalesmanCode);
        ClsLoadFieldHelper.fAddSqlParameter("ReportID", psReportID);
        ClsLoadFieldHelper.fAddSqlParameter("Lang", pClsHashTableHelper.msLang);

        if (psConnectOracle == "Y")
        {
            ClsLoadFieldHelper.fBuildDataSet_Oracle(psGridSTPName);
        }
        else
        {
            ClsLoadFieldHelper.fBuildDataSet(psGridSTPName);
        }


        if (ClsLoadFieldHelper.mbDataSetHasRecord)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void BuildChart(System.Web.UI.DataVisualization.Charting.Chart pChart
                                    , DataTable lDatatable
                                    , ClassHashTableHelper ClsHashTableHelper
                                    , string psReportID
                                    , string psChartType)
    {
        int no_of_row;
        no_of_row = lDatatable.Rows.Count;


        pChart.Series.Clear();
        pChart.ChartAreas.Clear();
        //pChart.Titles.Clear();
        //pChart.Legends.Clear();

        SeriesChartType lChartType = SeriesChartType.Line;
        LegendImageStyle lLegendImageStyle = LegendImageStyle.Line;


        switch (psChartType)
        {
            case "Column":
                lChartType = SeriesChartType.Column;
                break;

            case "Line":
                lChartType = SeriesChartType.Line;
                break;

            case "Bar":
                lChartType = SeriesChartType.Bar;
                break;

            case "StackedColumn100":
                lChartType = SeriesChartType.StackedColumn100;
                break;

            case "StackedColumn":
                lChartType = SeriesChartType.StackedColumn;
                break;

            case "StackedBar100":
                lChartType = SeriesChartType.StackedBar100;
                break;

            case "StackedArea100":
                lChartType = SeriesChartType.StackedArea100;
                break;

        }



        if (no_of_row > 0)
        {
            int index_Title = lDatatable.Columns["Title"].Ordinal;
            int index_xName = lDatatable.Columns["xName"].Ordinal;
            int index_yName = lDatatable.Columns["yName"].Ordinal;
            int index_xAxis = lDatatable.Columns["xAxis"].Ordinal;
            int index_NumberOfLine = lDatatable.Columns["NumberOfLine"].Ordinal;
            int iNumberOfLine = Convert.ToInt32(lDatatable.Rows[0][index_NumberOfLine].ToString());

            string lsXName = ClsHashTableHelper.sGetHash(lDatatable.Rows[0][index_xName].ToString());
            string lsYName = ClsHashTableHelper.sGetHash(lDatatable.Rows[0][index_yName].ToString());
            string lsTitle = ClsHashTableHelper.sGetHash(lDatatable.Rows[0][index_Title].ToString());

            lsTitle = sLoadChartTitle(ClsHashTableHelper.sGetHash(psReportID), lsTitle);
            double xValue = 0;

            for (int lline = 1; lline <= iNumberOfLine; lline++)
            {
                Series lSeries = new Series();
                lSeries.Name = ClsHashTableHelper.sGetHash(lDatatable.Columns[index_NumberOfLine + lline].ColumnName.ToString());
                lSeries.ChartType = lChartType;

                lSeries["ShowMarkerLines"] = "True";
                lSeries.ToolTip = lSeries.Name + "\n" + lsYName + ": #VALY \n" + lsXName + ": #VALX";
                lSeries.MarkerStyle = MarkerStyle.Circle;
                lSeries.MarkerSize = 7;
                lSeries.BorderWidth = 2;


                switch (lline)
                {
                    case 1:
                        lSeries.Color = Color.Blue;
                        lSeries.MarkerStyle = MarkerStyle.Circle;
                        lSeries.MarkerSize = 10;
                        break;

                    case 2:
                        lSeries.Color = Color.Orange;
                        lSeries.MarkerStyle = MarkerStyle.Square;
                        lSeries.MarkerSize = 10;
                        break;

                    case 3:
                        lSeries.Color = Color.Red;
                        lSeries.MarkerStyle = MarkerStyle.Triangle;
                        lSeries.MarkerSize = 10;
                        break;

                    case 4:
                        lSeries.Color = Color.Green;
                        lSeries.MarkerStyle = MarkerStyle.Star6;
                        lSeries.MarkerSize = 11;
                        break;

                    case 5:
                        lSeries.Color = Color.Purple;
                        lSeries.MarkerStyle = MarkerStyle.Diamond;
                        lSeries.MarkerSize = 10;
                        break;

                    case 6:
                        lSeries.Color = Color.Pink;
                        break;

                    case 7:
                        lSeries.Color = Color.YellowGreen;
                        break;

                    case 8:
                        lSeries.Color = Color.Yellow;
                        break;

                }

                //StackedColumn100
                if (lSeries.ChartType == SeriesChartType.StackedColumn100 || lSeries.ChartType == SeriesChartType.StackedColumn)
                {
                    lSeries.IsValueShownAsLabel = true;
                    lSeries.LabelForeColor = Color.White;
                }
                else
                {
                    lSeries.IsValueShownAsLabel = false;
                }

                //Column
                if (lSeries.ChartType == SeriesChartType.Column || lSeries.ChartType == SeriesChartType.StackedColumn100)
                {
                    lSeries.MarkerStyle = MarkerStyle.None;
                    lLegendImageStyle = LegendImageStyle.Rectangle;
                }

                //Show the y-axix value in graph
                //lSeries.IsValueShownAsLabel = true;
                //Add Data pint into Line.
                for (int iRow = 0; iRow < no_of_row; iRow++)
                {
                    if ((lDatatable.Rows[iRow][index_NumberOfLine + lline].ToString() == null) || (lDatatable.Rows[iRow][index_NumberOfLine + lline].ToString() == ""))
                    {
                        //xValue=0;
                        lSeries.Points.AddY(0);
                        lSeries.Points[iRow].IsEmpty = true;

                    }
                    else
                    {
                        xValue = Convert.ToDouble(lDatatable.Rows[iRow][index_NumberOfLine + lline].ToString());
                        lSeries.Points.AddXY(lDatatable.Rows[iRow][index_xAxis].ToString(), xValue.ToString());
                    }

                    // lSeries.Points.AddXY(lDatatable.Rows[iRow][index_xAxis].ToString(), xValue.ToString());
                }
                pChart.Series.Add(lSeries);
            }

            pChart.Width = 600;

            //Add Chart Title.
            Title lTitle = new Title(lsTitle, Docking.Top, new Font("Verdana", 14, FontStyle.Bold), System.Drawing.Color.MidnightBlue);
            //lTitle.ShadowColor = Color.Black;
            pChart.Titles.Add(lTitle);

            if (iNumberOfLine > 0)
            {
                pChart.Height = 500;
            }
            else
            {
                pChart.Height = 50;
            }

            //Add Chart Area.
            ChartArea lChartArea = new ChartArea();
            lChartArea.Name = "ChartArea1";
            lChartArea.AxisX.Title = lsXName;
            lChartArea.AxisX.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            lChartArea.AxisX.TitleForeColor = System.Drawing.Color.MidnightBlue;
            lChartArea.AxisX.LineColor = Color.LightGray;
            lChartArea.AxisX.Interval = 1;
            lChartArea.AxisX.MajorGrid.Enabled = false;

            lChartArea.AxisY.Title = lsYName;
            lChartArea.AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            lChartArea.AxisY.TitleForeColor = System.Drawing.Color.MidnightBlue;
            lChartArea.AxisY.LineColor = Color.LightGray;
            lChartArea.AxisY.MajorGrid.LineColor = Color.LightGray;

            lChartArea.BorderWidth = 0;
            lChartArea.BorderDashStyle = ChartDashStyle.NotSet;
            lChartArea.BorderColor = Color.Gray;
            lChartArea.ShadowColor = Color.Transparent;
            pChart.ChartAreas.Add(lChartArea);

            ///////

            //Add Chart Legend.
            Legend lLegend = new Legend();
            //lLegend.Title = "Legend title";
            lLegend.Docking = Docking.Top;
            // lLegend.TitleSeparator = LegendSeparatorStyle.Line;
            lLegend.Alignment = StringAlignment.Center;

            for (int i = 0; i < iNumberOfLine; i++)
            {
                pChart.Series[i].IsVisibleInLegend = false;

                lLegend.CustomItems.Add(new LegendItem("item" + i, pChart.Series[i].Color, ""));
                lLegend.CustomItems[i].Name = pChart.Series[i].Name;
                lLegend.CustomItems[i].ImageStyle = lLegendImageStyle;
                lLegend.CustomItems[i].MarkerStyle = pChart.Series[i].MarkerStyle;
                lLegend.CustomItems[i].BorderColor = pChart.Series[i].Color;
                lLegend.CustomItems[i].BorderWidth = 2;
                lLegend.CustomItems[i].MarkerBorderWidth = 100;
                lLegend.CustomItems[i].MarkerSize = 100;
            }

            pChart.Legends.Add(lLegend);
        }
    }


    #endregion
    public static bool bCanViewCompany(String pOU_Code, String Username)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("@OU_Code", pOU_Code);
        ClsLoadFieldHelper.fAddSqlParameter("@username", Username);

        ClsLoadFieldHelper.fBuildDataSet("stp_wf_ebs_rss_BI_Sales_bCanViewCompany");

        if (ClsLoadFieldHelper.mbDataSetHasRecord)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void SetViewSQLScript(LSLIBWebBased.ClassLoadFieldHelper pClsLoadFieldHelper
                            , ClassHashTableHelper pClsHashTableHelper
                            , string pbConnectOracle
                            , Label plblPrintSql)
    {

        String lsDatabaseName = "";
        if (pbConnectOracle == "Y")
        {
            lsDatabaseName = "Oracle - ";
        }
        else
        {
            lsDatabaseName = "SQLServer - ";
        }

        if (((LIBLocal.bCanHaveRight(pClsHashTableHelper.msUserName
                  , pClsHashTableHelper.mClassMyConfiguration.msSystemCode
                  , pClsHashTableHelper.mClassMyConfiguration.msFolderCode
                  , pClsHashTableHelper.mClassMyConfiguration.msPostCode
                  , "SystemAdmin") == true)
            || pClsHashTableHelper.mClassMyConfiguration.msReportType =="printsql")
            && pClsHashTableHelper.mClassMyConfiguration.msReportType !="hidesql")
        {
            plblPrintSql.Visible = true;
            plblPrintSql.Text = lsDatabaseName + pClsLoadFieldHelper.sLoadStoredProcedureName() + " " + pClsLoadFieldHelper.fPrintSqlParameterList();
        }
        else
        {
            plblPrintSql.Visible = false;
        }
    }
    
}







