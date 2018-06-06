//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//using Microsoft.VisualBasic;
//using System.Collections;
//using System.Data;
//using System.Diagnostics;
//using UserControlLibrary.Lamsoon;
//using AjaxControlToolkit;
//using System.Configuration;
//using System.Data.Common;
//using System.Data.SqlClient;
//using System.IO;
//using System.Text.RegularExpressions;
//using System.Web.UI;
//using System.Web.Security;
//using System.Web.UI.WebControls;

//using System.Security.Cryptography;
//using System.Text;
//using Microsoft.Win32;
//using System.Net.Mail;
////using System.Text.UnicodeEncoding;
//using ChartDirector;
//using System.Globalization;
//using System.IO.Compression;
//using System.Net;

////Imports iTextSharp.text
////Imports iTextSharp.text.pdf
////Imports iTextSharp.text.html
////Imports iTextSharp.text.html.simpleparser
//using System.Threading;
//using LSLIBWebBased.LSWebControl;
//using System.Data.OleDb;
//using LamsoonUserControl05.Lamsoon.WebControl;
//using Microsoft.VisualBasic.Devices;



//// Last tidy up: 20120205
//#region "nsWebControl"
//namespace nsWebControl
//{
//    public static class mWebControl
//    {
//        public static string ModeDisplay()
//        {
//            return UserControlLibrary.Lamsoon.Action.Display;
//        }

//        public static string ModeEdit()
//        {
//            return UserControlLibrary.Lamsoon.Action.Edit;
//        }

//        #region "Control Searching"
//        /// <summary>
//        /// execute pDFunc1 on each control in pControls
//        /// SearchWebControl = NoOfControl in pControls is the same, so use For Each. 
//        /// </summary>
//        public static void SearchWebControl(System.Web.UI.ControlCollection pControls, LIBWebBased.DFunc1 pDFunc1)
//        {
//            foreach (Control lcControl in pControls)
//            {
//                if (lcControl.Controls.Count > 0)
//                {
//                    pDFunc1(lcControl);
//                    SearchWebControl(lcControl.Controls, pDFunc1);
//                }
//                else
//                {
//                    pDFunc1(lcControl);
//                }
//            }
//        }

//        /// <summary>
//        /// execute pDFunc1 on each control in pControls
//        /// SearchWebControlGrowing = NoOfControl in pControls will grow, so use for loop. 
//        /// </summary>
//        public static void SearchWebControlGrowing(System.Web.UI.ControlCollection pControls, LIBWebBased.DFunc1 pDFunc1)
//        {
//            for (int i = 0; i <= pControls.Count - 1; i++)
//            {
//                Control lcControl = pControls[i];
//                if (lcControl.Controls.Count > 0)
//                {
//                    pDFunc1(lcControl);
//                    SearchWebControlGrowing(lcControl.Controls, pDFunc1);
//                }
//                else
//                {
//                    pDFunc1(lcControl);
//                }
//            }
//        }
//        #endregion

//        #region "Control Set Edit Display"
//        private static bool bSetSmartControl(Control pControl, string psAction, bool pbSmartDDL = false, bool pbSmartTxtBox = false, bool pbSmartDatePicker = false, bool pbCheckbox = false)
//        {
//            switch (pControl.GetType().Name)
//            {
//                case "SmartDropDownList":
//                    if (pbSmartDDL)
//                    {
//                        SmartDropDownList lControl = pControl;
//                        lControl.Mode = psAction;
//                    }

//                    break;
//                case "SmartTextbox":
//                    if (pbSmartTxtBox)
//                    {
//                        SmartTextbox lControl = pControl;
//                        lControl.Mode = psAction;
//                        try
//                        {
//                            lControl.Text = nsString.mString.fStringToHTMLDisplayFormat(lControl.Text);

//                        }
//                        catch (Exception ex)
//                        {
//                        }

//                    }

//                    break;
//                case "DatePicker":
//                    if (pbSmartDatePicker)
//                    {
//                        UserControlLibrary.Lamsoon.DatePicker lControl = pControl;
//                        if (psAction == nsWebControl.ModeDisplay())
//                        {
//                            lControl.Mode = "label";
//                        }
//                        else
//                        {
//                            lControl.Mode = "Textbox";
//                        }
//                    }

//                    break;
//                case "SmartCheckboxList":
//                    SmartCheckboxList lControl = pControl;
//                    lControl.Mode = psAction;

//                    break;
//                case "SmartRadioButtonList":
//                    SmartRadioButtonList lControl = pControl;
//                    lControl.Mode = psAction;

//                    break;
//                case "CheckBox":
//                    break;
//                //Dim lControl As CheckBox = pControl
//                //If psAction = nsWebControl.ModeDisplay Then
//                //    lControl.Enabled = False
//                //Else
//                //    lControl.Enabled = True
//                //End If

//            }
//            return true;
//        }

//        public static object bSetControlDisplay(object pControl)
//        {
//            bSetSmartControl(pControl, Action.Display, true, true, true, true);
//            return true;
//        }

//        public static object bSetControlEdit(object pControl)
//        {
//            bSetSmartControl(pControl, Action.Edit, true, true, true);
//            return true;
//        }

//        public static object bSetSmartDDLEdit(object pControl)
//        {
//            bSetSmartControl(pControl, Action.Edit, true, false, false);
//            return true;
//        }

//        /// <summary>
//        /// ' as we have to fit DFunc1, so I create bSetSmartTextboxDisplay
//        /// </summary>
//        public static object bSetSmartTextboxDisplay(object pControl)
//        {
//            bSetSmartControl(pControl, Action.Display, false, true, false);
//            return true;
//        }
//        #endregion

//        #region "Control Set Invisible"
//        public static object bInvisibleValidator(object pControl)
//        {
//            switch (pControl.GetType().Name)
//            {
//                case "RegularExpressionValidator":
//                    RegularExpressionValidator lControl = pControl;
//                    lControl.Visible = false;
//                    break;
//            }
//            return true;
//        }

//        public static object bSetButtonInvisible(object pControl)
//        {
//            switch (pControl.GetType().Name)
//            {
//                case "Button":
//                    pControl.Visible = false;
//                    break;
//            }
//            return true;
//        }

//        public static object bSetSmartTxtBoxInvisible(object pControl)
//        {
//            switch (pControl.GetType().Name)
//            {
//                case "SmartTextbox":
//                    pControl.Visible = false;
//                    break;
//            }
//            return true;
//        }

//        public static object bSetLabelnvisible(object pControl)
//        {
//            switch (pControl.GetType().Name)
//            {
//                case "Label":
//                    pControl.Visible = false;
//                    break;
//            }
//            return true;
//        }

//        #endregion

//        #region "Control Value set get"
//        public static void SetControlValue(object psValue, ref object poControl)
//        {
//            switch (poControl.GetType().Name)
//            {
//                case "LSTextbox":
//                    LSLIBWebBased.LSWebControl.LSTextBox lControl = poControl;
//                    lControl.Text = psValue;

//                    break;
//                case "SmartTextbox":
//                    SmartTextbox lControl = poControl;
//                    lControl.Text = psValue;

//                    break;
//                case "TextBox":
//                    System.Web.UI.WebControls.TextBox lControl = poControl;
//                    lControl.Text = psValue;

//                    break;
//                case "SmartDropDownList":
//                case "LSDropDownList":
//                case "DropDownList":
//                case "ListBox":
//                case "RadioButtonList":
//                    ListControl lControl = poControl;
//                    // when old data is not exists in DDL, add it to DDL.
//                    if (lControl.Items.FindByValue(psValue) == null)
//                    {
//                        lControl.ClearSelection();
//                        System.Web.UI.WebControls.ListItem lListItem = new System.Web.UI.WebControls.ListItem(LIBWebBased.GlobalClassHashTableHelper.sGetHash(psValue), psValue);
//                        lControl.Items.Add(lListItem);
//                        lControl.SelectedValue = psValue;
//                    }
//                    else
//                    {
//                        lControl.SelectedValue = psValue;
//                    }

//                    break;
//                case "SmartCheckboxList":
//                case "LSCheckboxList":
//                    ListControl lControl = poControl;
//                    nsCommon.mCommon.fCheckBoxListSetSelectedValueList(lControl, psValue);

//                    break;
//                case "LSDatePicker":
//                    LSLIBWebBased.LSWebControl.LSDatePicker lControl = poControl;
//                    // when Date format is not valid, set to blank.
//                    try
//                    {
//                        lControl.Text = Convert.ToDateTime(nsSQL.mSQL.oHandleNullAndNothing(psValue));
//                    }
//                    catch (Exception ex)
//                    {
//                        lControl.Text = LIBWebBased.BLANK;
//                    }

//                    break;
//                case "DatePicker":
//                    DatePicker lControl = poControl;
//                    // when Date format is not valid, set to blank.
//                    try
//                    {
//                        lControl.Text = Convert.ToDateTime(nsSQL.mSQL.oHandleNullAndNothing(psValue));
//                    }
//                    catch (Exception ex)
//                    {
//                        lControl.Text = LIBWebBased.BLANK;
//                    }

//                    break;
//                case "Label":
//                    Label lControl = poControl;
//                    lControl.Text = psValue;

//                    break;
//                case "Literal":
//                    Literal lControl = poControl;
//                    lControl.Text = psValue;

//                    break;
//                case "CheckBox":
//                    CheckBox lControl = poControl;
//                    lControl.Checked = psValue;

//                    break;
//                default:
//                    poControl = psValue;

//                    break;
//            }
//        }

//        public static object sGetControlValue(object poFieldValueControl, bool pBlankThenNull = false)
//        {
//            object lsValue = LIBWebBased.BLANK;
//            object lsObject = null;
//            lsObject = nsSQL.mSQL.oHandleNullAndNothing(poFieldValueControl);

//            switch (lsObject.GetType().Name)
//            {
//                case "TextBox":
//                    System.Web.UI.WebControls.TextBox lControl = lsObject;
//                    lsValue = lControl.Text;

//                    break;
//                case "SmartTextbox":
//                    SmartTextbox lControl = lsObject;
//                    lsValue = lControl.Text;

//                    Debug.Print(lsValue.Replace(char.ConvertFromUtf32(13), "<br/>"));
//                    Debug.Print(lsValue.Replace("&#x0D;", "<br/>"));

//                    break;
//                // Debug.Print("SiteMapPath")
//                case "SmartDropDownList":
//                case "DropDownList":
//                    ListControl lControl = lsObject;
//                    lsValue = lControl.SelectedValue;

//                    break;
//                case "SmartCheckboxList":
//                    ListControl lControl = lsObject;
//                    lsValue = nsCommon.mCommon.fCheckBoxListGetSelectedValues(lControl);

//                    break;
//                case "DatePicker":
//                    DatePicker lControl = lsObject;
//                    lsValue = lControl.Text;
//                    if (lControl.Text == LIBWebBased.BLANK)
//                    {
//                        lsValue = DBNull.Value;
//                    }
//                    else
//                    {
//                        lsValue = nsDateTime.mDataTime.sSQLDateFormat(lControl.Text);
//                    }
//                    break;
//                //Case "DateTime"
//                //    lsValue = nsDateTime.sStandardSQLDateTime(poFieldValueControl)

//                case "Label":
//                    Label lControl = lsObject;
//                    lsValue = lControl.Text;

//                    break;
//                case "Literal":
//                    Literal lControl = lsObject;
//                    lsValue = lControl.Text;

//                    break;
//                case "CheckBox":
//                    CheckBox lControl = lsObject;
//                    lsValue = lControl.Checked;

//                    break;
//                case "DropDownCheckList":
//                    DropDownCheckList lControl = lsObject;
//                    lsValue = nsCommon.mCommon.fCheckBoxListGetSelectedValues(lControl);

//                    break;
//                default:
//                    if (poFieldValueControl == null)
//                    {
//                        lsValue = DBNull.Value;
//                    }
//                    else
//                    {
//                        lsValue = poFieldValueControl;
//                    }

//                    break;


//            }

//            if (pBlankThenNull)
//            {
//                if (lsValue.ToString() == LIBWebBased.BLANK)
//                {
//                    lsValue = DBNull.Value;
//                }
//            }
//            return lsValue;
//        }


//        public static string sObjectToHTML(object pObject)
//        {
//            StringBuilder SB = new StringBuilder();
//            StringWriter SW = new StringWriter();
//            System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(SW);

//            pObject.RenderControl(hw);

//            return SW.ToString();
//        }

//        #endregion

//        #region "Control Clear"
//        public static object bClearControl(object pControl)
//        {
//            switch (pControl.GetType().Name)
//            {
//                case "SmartTextbox":
//                    SmartTextbox lControl = pControl;
//                    lControl.Text = LIBWebBased.BLANK;
//                    break;
//                case "SmartDropDownList":
//                    SmartDropDownList lControl = pControl;
//                    lControl.SelectedIndex = -1;
//                    break;
//                case "SmartRadioButtonList":
//                    SmartRadioButtonList lControl = pControl;
//                    lControl.SelectedIndex = -1;
//                    break;
//                case "DatePicker":
//                    DatePicker lControl = pControl;
//                    lControl.Text = LIBWebBased.BLANK;
//                    break;
//                case "CheckBox":
//                    CheckBox lControl = pControl;
//                    lControl.Checked = false;
//                    break;
//            }
//            return true;
//        }
//        #endregion

//        #region "Control Formatting"
//        public static object bSetGridViewForPrinting(object pControl)
//        {
//            try
//            {
//                switch (pControl.GetType().Name)
//                {
//                    case "GridView":
//                        GridView psGridView = pControl;
//                        psGridView.AllowPaging = false;
//                        psGridView.AllowSorting = false;
//                        break;
//                }

//            }
//            catch (Exception ex)
//            {
//            }
//            return true;
//        }

//        public static object bSetControlMoney(object pControl)
//        {
//            switch (pControl.GetType().Name)
//            {
//                case "SmartTextbox":
//                    SmartTextbox lControl = pControl;
//                    lControl.Text = nsCommon.mCommon.sMoney(lControl.Text);
//                    lControl.CssClass = "floatRight";

//                    break;
//            }
//            return true;
//        }

//        #endregion

//        public static object fSetDatePicker(object pControl1)
//        {
//            Control pControl = pControl1;

//            switch (pControl.GetType().Name)
//            {
//                case "DatePicker":
//                    DatePicker lControl = pControl;
//                    lControl.Clearable = true;
//                    break;
//            }
//            return true;
//        }
//    }

//}
//#endregion



//public static class LIBWebBased
//{

//    public static Computer MyComputer = new Computer();

//    public const string BLANK = "";
//    public const string gsSTPResult = "XXXXXXXXXXXXXXXXXXXXXXXXX";
//    public const string gsKey = "LSWFLS";
//    public const string gsSeperator = ",";
//    public const string gsHashTableStpName = "stp_wf_all_GetTranslationField";
//    // for testing use
//    public const bool gsShowNotUsedHashKey = true;
//    public static int gsRequiredFieldValidatorCounter = 1;

//    public static string gsMarkID = "078699";
//    public static string gsConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
//    // connect to another server
//    public static string gsConnectionString2 = ConfigurationManager.AppSettings["ConnectionString2"];
//    // seem need to download oracle provider and use standard edition of visual studio.
//    public static string gsConnectionStringOracle = ConfigurationManager.AppSettings["ConnectionStringOracle"];
//    public static string gsDefaultLogin = nsLSVersion.mVersion.sHandleLoginPage();
//    public static string gsDefaultLang = ConfigurationManager.AppSettings["DefaultLang"];
//    public static string gsProjectLevelID = ConfigurationManager.AppSettings["LID"];
//    public static string gsSecurityKey = ConfigurationManager.AppSettings["salt"];

//    public static string gsFileMaxSizeInMB = ConfigurationManager.AppSettings["FileSizeInMB"];
//    private static string _gsProjectCode = BLANK;
//    //'used for library
//    //Public Property gsProjectCode() As String
//    //    Get
//    //        If _gsProjectCode <> BLANK Then
//    //        Else
//    //            _gsProjectCode = ConfigurationManager.AppSettings["ProjectCode")
//    //        End If
//    //        Return _gsProjectCode
//    //    End Get
//    //    Set(value As String)
//    //        _gsProjectCode = value
//    //    End Set
//    //End Property

//    public static HttpCookie gsUserNameCookie
//    {
//        get { return HttpContext.Current.Request.Cookies["userName"]; }
//    }

//    public static bool gbTestingServer
//    {
//        get { return HttpContext.Current.Request.Url.ToString().Contains("hktest01"); }
//    }

//    public static bool gbLocalTesting
//    {
//        get
//        {
//            try
//            {
//                return HttpContext.Current.Request.Url.ToString().Contains("localhost");
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }
//    }

//    private static ClassHashTableHelper _GlobalClassHashTableHelper;
//    public static ClassHashTableHelper GlobalClassHashTableHelper
//    {
//        get
//        {
//            if (_GlobalClassHashTableHelper == null)
//            {
//                _GlobalClassHashTableHelper = new ClassHashTableHelper();
//            }

//            return _GlobalClassHashTableHelper;
//        }
//        set { _GlobalClassHashTableHelper = value; }
//    }

//    public static string gsUserName
//    {
//        get
//        {
//            if (gsUserNameCookie == null)
//            {
//                return BLANK;
//            }
//            return gsUserNameCookie.Value;
//        }
//    }

//    /// <summary>
//    /// Get Selected language (tc/sc/en)
//    /// f1 - get from Request.QueryString("lang")
//    /// f2 - get from Session("lang")
//    /// f3 - get from AppSettings["DefaultLang")
//    /// </summary>
//    public static string gslang
//    {
//        get
//        {

//            try
//            {
//                HttpContext lHttpContext = HttpContext.Current;
//                if ((lHttpContext.Request.QueryString["lang"] != null))
//                {
//                    // f1
//                    lHttpContext.Session["Lang"] = lHttpContext.Request.QueryString["lang"];
//                }
//                else if (lHttpContext.Session["Lang"] != BLANK)
//                {
//                    // f2
//                }
//                else
//                {
//                    // f3
//                    lHttpContext.Session["Lang"] = gsDefaultLang;
//                }

//                return (string)lHttpContext.Session["Lang"];

//            }
//            catch (Exception ex)
//            {
//                return gsDefaultLang;
//            }

//        }
//    }

//    /// <summary>
//    /// D mean Delegate
//    /// Func = has return value
//    /// 1 = need to pass 1 parameter into the Sub
//    /// DFunc1 = it is a Delegate Function which require 1 parameter.
//    /// </summary>
//    public delegate object DFunc0();
//    public delegate object DFunc1(object pObject);
//    public delegate object DFunc3(object pObject1, object pObject2, object pObject3);
//    public delegate object DSub0();

//    public enum enDropDownListType
//    {
//        NoValue = 0,
//        // add nothing
//        Blank = 1,
//        // add "" item
//        All = 2,
//        // add "All" item
//        DDLNoOption = 3,
//        // add "No" item
//        BlankAndOther = 4,
//        // add "" item at first and "Other" item at the end
//        Other = 5,
//        // add "Other" item at the end
//        NA = 6,
//        // add "N/A" item
//        BlankAndNA = 7
//        // add "" item at first and "NA" item at the end
//    }

//    public enum enOfficeType
//    {
//        Excel07,
//        Excel,
//        PowerPoint,
//        Word
//    }

//    public enum enProjectFunction
//    {
//        AllRecords,
//        AdvSearch,
//        Report,
//        FunctionManagement,
//        NewItem,
//        LSJuniorComparison,
//        AdminTool,
//        LSEmailList,
//        LSStaffComparison,
//        LSGroupComparison,
//        LSAnalystReport,
//        RollBack,
//        NLALeaveReport
//    }

//    public enum enYearMonthHeaderType
//    {
//        P12M = -12,
//        P11M = -11,
//        P10M = -10,
//        P9M = -9,
//        P8M = -8,
//        P7M = -7,
//        P6M = -6,
//        P5M = -5,
//        P4M = -4,
//        P3M = -3,
//        P2M = -2,
//        P1M = -1,
//        P0M = 0,
//        P0YTD = 0,
//        P1YTD = -1,
//        P0YTDF = 0,
//        P0YTDB = 0
//    }

//    #region "Encrypt/Decrypt"
//    public static string HioDecrypt(object psString, string psKey = "Default")
//    {
//        psString = (string)nsSQL.mSQL.oHandleNullAndNothing(psString);

//        try
//        {
//            TripleDESCryptoServiceProvider cryptDES3 = new TripleDESCryptoServiceProvider();
//            MD5CryptoServiceProvider cryptMD5Hash = new MD5CryptoServiceProvider();
//            if (psKey != "Default")
//            {
//                cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(psKey));
//            }
//            else
//            {
//                cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(gsKey));
//            }
//            cryptDES3.Mode = CipherMode.ECB;
//            ICryptoTransform desdencrypt = cryptDES3.CreateDecryptor();
//            byte[] buff = System.Convert.FromBase64String((string)psString);
//            return ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
//        }
//        catch (Exception ex)
//        {
//            return BLANK;
//        }
//    }

//    public static string HioEncrypt(string psString, string psKey = "Default")
//    {
//        TripleDESCryptoServiceProvider cryptDES3 = new TripleDESCryptoServiceProvider();
//        MD5CryptoServiceProvider cryptMD5Hash = new MD5CryptoServiceProvider();

//        if (psKey != "Default")
//        {
//            cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(psKey));
//        }
//        else
//        {
//            cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(gsKey));
//        }

//        cryptDES3.Mode = CipherMode.ECB;
//        ICryptoTransform desdencrypt = cryptDES3.CreateEncryptor();
//        ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();
//        byte[] buff = ASCIIEncoding.ASCII.GetBytes(psString);
//        return System.Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
//    }

//    public static string URLEncode(string psString)
//    {
//        return System.Web.HttpUtility.UrlEncode(psString);
//    }

//    public static string URLDecode(string psString)
//    {
//        return System.Web.HttpUtility.UrlDecode(psString);
//    }
//    // ''' <summary>
//    // ''' 加密字符串
//    // ''' </summary>
//    // ''' <param name="psString">源字符串</param>
//    //Public Function EncodeString(ByVal psString As String) As String
//    //    Return Web.HttpUtility.UrlDecode(Web.HttpUtility.UrlEncode(UserControlLibrary.Lamsoon.CommonFunction.EncodeRijndael(gsSecurityKey, psString)))
//    //End Function

//    // ''' <summary>
//    // ''' 解密字符串
//    // ''' </summary>
//    // ''' <param name="psString">需要解密的字符串</param>
//    //Public Function DecodeString(ByVal psString As String) As String
//    //    Return UserControlLibrary.Lamsoon.CommonFunction.DecodeRijndael(gsSecurityKey, psString)
//    //End Function
//    #endregion

//    #region "Project Function"

//    /// <summary>
//    /// If the function NeedControl, then check the user has privilege or not.
//    /// when tbl_wf_all_FunctionPrivilege 冇Data, 所有人都唔用得
//    /// when needControl = 1, 就要Check tbl_wf_all_FunctionUserPrivilege 有冇this user.
//    /// when needControl = 0, 所有人都用得
//    /// </summary>
//    public static bool AddFunctionAccessRightByFunctionName(string psFunction, object pVisibleObject, string psProjectCode, string psUserName = BLANK)
//    {
//        try
//        {
//            if (psUserName == BLANK)
//            {
//                psUserName = gsUserName;
//            }

//        }
//        catch (Exception ex)
//        {
//        }
//        // insert into tbl_wf_all_FunctionUserPrivilege values('078699','GR','AdvSearch','A')
//        // insert into tbl_wf_all_FunctionPrivilege values ('GR','AdvSearch',1)
//        // 
//        bool lsHasRight = false;
//        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//        ClsLoadFieldHelper.fAddSqlParameter("@Project_Code", psProjectCode);
//        ClsLoadFieldHelper.fAddSqlParameter("@Function_Name", psFunction);
//        ClsLoadFieldHelper.fBuildDataSet("stp_wf_all_FunctionPrivilege");
//        if (ClsLoadFieldHelper.mbDataSetHasRecord)
//        {
//            if (ClsLoadFieldHelper.oLoadSqlField("NeedControl") == "1")
//            {
//                lsHasRight = nsCommon.mCommon.bHasUserPrivilege(psProjectCode, psFunction, psUserName);
//            }
//            else
//            {
//                lsHasRight = true;
//            }
//        }

//        try
//        {
//            if (lsHasRight)
//            {
//                // pVisibleObject.Visible = true;
//            }
//            else
//            {
//                // pVisibleObject.Visible = false;
//            }

//        }
//        catch (Exception ex)
//        {
//        }
//        return lsHasRight;
//    }

//    /// <summary>
//    /// May be merge
//    /// </summary>
//    public static bool bEnableProjectFunction(string psProjectCode, string psFunction, string psUserName)
//    {
//        return AddFunctionAccessRightByFunctionName(psFunction, null, psProjectCode, psUserName);
//    }
//    #endregion

//    #region "LS Password"
//    public static string sGeneratePassWord(string psPassword, string psUserName)
//    {
//        return FormsAuthentication.HashPasswordForStoringInConfigFile(psPassword.ToLower() + psUserName.ToLower(), "md5");
//    }

//    /// <summary>
//    /// ResetTestingUserPassword
//    /// </summary>
//    public static bool bUpdatePassword(string psUsername, string psPassword)
//    {
//        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//        var _with2 = ClsLoadFieldHelper;
//        _with2.fAddSqlParameter("@staff_id", psUsername);
//        _with2.fAddSqlParameter("@password", sGeneratePassWord(psPassword, psUsername));

//        _with2.fBuildDataSet("stp_wf_all_ResetTestingUserPassword");
//        return _with2.mbDataSetHasRecord;
//    }

//    /// <summary>
//    /// not work now
//    /// </summary>
//    public static bool bCopyUser(string psUsername)
//    {
//        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//        var _with3 = ClsLoadFieldHelper;
//        _with3.fAddSqlParameter("@staff_id", psUsername);
//        _with3.fBuildDataSet("stp_wf_all_AddUserFromProduction");

//        return _with3.mbDataSetHasRecord;
//    }
//    #endregion

//    #region "Color list"
//    // use for CAS for drawing chart
//    public static int giLineColor(List<int> psList, int piSeq)
//    {
//        if (piSeq >= psList.Count)
//        {
//            piSeq = psList.Count - 1;
//        }
//        return psList[piSeq];
//    }

//    public static List<string> ColorList()
//    {
//        //using color index in this web :http://www.relief.jp/itnote/xls_colorindex.php, http://dmcritchie.mvps.org/excel/colors.htm
//        List<string> NewLineColor = new List<string>();

//        // NewLineColor.Add("&H000000") '1 ' as count from 1, so add 1 more
//        // NewLineColor.Add("&H000000") '1
//        // NewLineColor.Add("&HFFFFFF") '2
//        NewLineColor.Add("&HFF0000");
//        //3
//        NewLineColor.Add("&H00FF00");
//        //4
//        NewLineColor.Add("&H0000FF");
//        //5
//        NewLineColor.Add("&HFFFF00");
//        //6
//        NewLineColor.Add("&HFF00FF");
//        //7
//        NewLineColor.Add("&H00FFFF");
//        //8
//        NewLineColor.Add("&H800000");
//        //9
//        NewLineColor.Add("&H008000");
//        //10
//        NewLineColor.Add("&H000080");
//        //11
//        NewLineColor.Add("&H808000");
//        //12
//        NewLineColor.Add("&H800080");
//        //13
//        NewLineColor.Add("&H008080");
//        //14
//        NewLineColor.Add("&HC0C0C0");
//        //15
//        NewLineColor.Add("&H808080");
//        //16
//        NewLineColor.Add("&H9999FF");
//        //17
//        NewLineColor.Add("&H993366");
//        //18
//        NewLineColor.Add("&HFFFFCC");
//        //19
//        NewLineColor.Add("&HCCFFFF");
//        //20
//        NewLineColor.Add("&H660066");
//        //21
//        NewLineColor.Add("&HFF8080");
//        //22
//        NewLineColor.Add("&H0066CC");
//        //23
//        NewLineColor.Add("&HCCCCFF");
//        //24

//        // NewLineColor.Add("&H000080") '25
//        // NewLineColor.Add("&HFF00FF") '26
//        // NewLineColor.Add("&HFFFF00") '27
//        // NewLineColor.Add("&H00FFFF") '28
//        // NewLineColor.Add("&H800080") '29
//        // NewLineColor.Add("&H800000") '30
//        // NewLineColor.Add("&H008080") '31
//        // NewLineColor.Add("&H0000FF") '32
//        NewLineColor.Add("&H00CCFF");
//        //33
//        // NewLineColor.Add("&HCCFFFF") '34
//        NewLineColor.Add("&HCCFFCC");
//        //35
//        NewLineColor.Add("&HFFFF99");
//        //36
//        NewLineColor.Add("&H99CCFF");
//        //37
//        NewLineColor.Add("&HFF99CC");
//        //38
//        NewLineColor.Add("&HCC99FF");
//        //39
//        NewLineColor.Add("&HFFCC99");
//        //40
//        NewLineColor.Add("&H3366FF");
//        //41
//        NewLineColor.Add("&H33CCCC");
//        //42
//        NewLineColor.Add("&H99CC00");
//        //43
//        NewLineColor.Add("&HFFCC00");
//        //44
//        NewLineColor.Add("&HFF9900");
//        //45
//        NewLineColor.Add("&HFF6600");
//        //46
//        NewLineColor.Add("&H666699");
//        //47
//        NewLineColor.Add("&H969696");
//        //48
//        NewLineColor.Add("&H003366");
//        //49
//        NewLineColor.Add("&H339966");
//        //50
//        NewLineColor.Add("&H003300");
//        //51
//        NewLineColor.Add("&H333300");
//        //52
//        NewLineColor.Add("&H993300");
//        //53
//        // NewLineColor.Add("&H993366") '54
//        NewLineColor.Add("&H333399");
//        //55
//        NewLineColor.Add("&H333333");
//        //56
//        //NewLineColor.Add("aaaa") '
//        string lsColor = null;

//        for (int i = 0; i <= 15; i++)
//        {
//            for (int j = 0; j <= 15; j++)
//            {
//                for (int k = 0; k <= 15; k++)
//                {
//                    lsColor = "&H" + Conversion.Hex(i) + Conversion.Hex(i) + Conversion.Hex(j) + Conversion.Hex(j) + Conversion.Hex(k) + Conversion.Hex(k);
//                    if (NewLineColor.Contains(lsColor))
//                    {
//                    }
//                    else
//                    {
//                        NewLineColor.Add(lsColor);
//                    }
//                    k += 2;
//                }
//                j += 2;
//            }
//            i += 2;
//        }
//        return NewLineColor;
//    }
//    #endregion

//    #region "Local Function"

//    private const string gsQUOTES = "'";
//    public static string VarSQLString(object pObject)
//    {
//        // Initialize the temporary string buffer
//        string lsSQLString = BLANK;

//        switch (Information.VarType(pObject))
//        {
//            case VariantType.Empty:
//                lsSQLString = gsQUOTES + gsQUOTES;

//                break;
//            case VariantType.Null:
//                lsSQLString = "NULL";

//                break;
//            case VariantType.Integer:
//            case VariantType.Long:
//            case VariantType.Double:
//            case VariantType.Currency:
//            case VariantType.Decimal:
//                lsSQLString = Strings.Format(pObject);

//                break;
//            case VariantType.Date:
//                lsSQLString = gsQUOTES + nsDateTime.mDataTime.sStandardSQLDateTime(pObject) + gsQUOTES;

//                break;
//            case VariantType.String:
//                lsSQLString = gsQUOTES + sDoubleChar((string)pObject, gsQUOTES) + gsQUOTES;

//                break;
//            case VariantType.Boolean:
//                lsSQLString = Strings.Format(((bool)pObject ? 1 : 0));
//                break;
//            default:
//                lsSQLString = gsQUOTES + gsQUOTES;

//                break;
//        }
//        return lsSQLString;
//    }

//    private static string sDoubleChar(string psTarget, string psChar)
//    {
//        return psTarget.Replace(psChar, psChar + psChar);
//    }
//    #endregion

//    #region "Email"
//    public static bool bSendEmail(string psEmailTo, string psEmailSubject, string psEmailBody)
//    {
//        return SendMail("ebidding@lamsoon.com", psEmailTo, "", "", psEmailSubject, psEmailBody, "gb2312", "", "202.64.111.197");
//    }

//    public static bool bSendSystemEmail(MailAddressCollection psEmailTo, string psMailSubject, string psMailBody, string psProjectCode)
//    {

//        string lsDisplayName = "";
//        string lsMailFrom = "";

//        if (lsMailFrom == BLANK)
//        {
//            lsMailFrom = "workflow@lamsoon.com";
//            lsDisplayName = GlobalClassHashTableHelper.sGetHash(psProjectCode);
//        }

//        psMailSubject = GlobalClassHashTableHelper.sGetHash(psProjectCode) + " - " + psMailSubject;


//        // Add sender email for contact use.
//        psMailBody += "寄件人:" + nsCommon.mCommon.sGetStaffName(gsUserName, "sc") + "<br><br>";
//        psMailBody += "寄件人Email:" + nsCommon.mCommon.sGetStaffEmail(gsUserName) + "<br><br>";


//        // CC to sender as a backup copy.
//        MailAddressCollection lsEmailCC = new MailAddressCollection();
//        lsEmailCC.Add(nsCommon.mCommon.sGetStaffEmail(gsUserName));

//        if (bSendWorkflowRequestReplyEmail(psEmailTo, lsMailFrom, psMailSubject, psMailBody, lsDisplayName, true, lsEmailCC) == true)
//        {
//            return true;
//        }

//        return false;

//    }

//    /// <summary>
//    /// Example of 1 to many email.
//    /// </summary>
//    public static bool bSendWorkflowRequestReplyEmail(MailAddressCollection psEmailTo, string psEmailFrom, string psMailSubject, string psMailBody, string psDisplayName = BLANK, bool pbAddLog = true, MailAddressCollection psEmailCC = null)
//    {
//        MailMessage lMailMessage = new MailMessage();
//        string lsEmailList = BLANK;

//        if ((psEmailTo != null))
//        {
//            if (psEmailTo.Count > 0)
//            {
//                foreach (MailAddress lsEmailTo in psEmailTo)
//                {
//                    lMailMessage.To.Add(lsEmailTo);
//                    lsEmailList += lsEmailTo.ToString() + ", ";
//                }
//                if (psDisplayName != BLANK)
//                {
//                    lMailMessage.From = new MailAddress(psEmailFrom, psDisplayName);
//                }
//                else
//                {
//                    lMailMessage.From = new MailAddress(psEmailFrom);
//                }
//                lMailMessage.Subject = psMailSubject;
//                lMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
//                lMailMessage.IsBodyHtml = true;
//                lMailMessage.Body = psMailBody;
//                // lMailMessage.Bcc.Add(New MailAddress(psEmailFrom))
//                // lMailMessage.CC.Add(New MailAddress(psEmailFrom))
//                if (psEmailCC == null)
//                {
//                }
//                else
//                {
//                    foreach (MailAddress lsEmailCC in psEmailCC)
//                    {
//                        lMailMessage.CC.Add(lsEmailCC);
//                        // lsEmailList += lsEmailCC.ToString + ", "
//                    }
//                }
//                try
//                {
//                    SmtpClient lSmtpClient = new SmtpClient();
//                    lSmtpClient.Host = "10.1.0.18";
//                    lSmtpClient.Send(lMailMessage);

//                    if (pbAddLog)
//                    {
//                        InsertWorkflowEmailLog(psEmailFrom, lsEmailList, psMailBody);
//                    }

//                    return true;
//                }
//                catch
//                {
//                    return false;
//                }
//            }
//        }
//        return false;
//    }

//    private static void InsertWorkflowEmailLog(string psEmailFrom, string psEmailTo, string psMailBody)
//    {
//        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//        var _with4 = ClsLoadFieldHelper;
//        _with4.fAddSqlParameter("@type", "EmailReply - " + psEmailFrom);
//        _with4.fAddSqlParameter("@emailTo", psEmailTo);
//        _with4.fAddSqlParameter("@content", Strings.Replace(Strings.Mid(psMailBody, 1, 500), "'", "''"));
//        _with4.fBuildDataSet("stp_wf_InsertWorkflowEmailLog");
//    }

//    /// <summary>
//    /// Full Example 1 to 1 email.
//    /// </summary>
//    public static bool SendMail(string psEmailFrom, string psEmailTo, string psCC, string psBCC, string psMailSubject, string psMailBody, string psEncoding = BLANK, string psAttachment = BLANK, string psEmailSMTPServerIP = "10.1.0.18")
//    {
//        MailMessage lMailMessage = new MailMessage();
//        if (!string.IsNullOrEmpty(psEmailFrom) & !string.IsNullOrEmpty(psMailSubject) & !string.IsNullOrEmpty(psMailBody))
//        {
//            lMailMessage.From = new MailAddress(psEmailFrom);
//            lMailMessage.To.Add(new MailAddress(psEmailTo));

//            if (psCC != BLANK)
//            {
//                lMailMessage.CC.Add(new MailAddress(psCC));
//            }

//            if (psBCC != BLANK)
//            {
//                lMailMessage.Bcc.Add(new MailAddress(psBCC));
//            }

//            if (!string.IsNullOrEmpty(psAttachment))
//            {
//                ClassFileUploadHelper ClsFileUploadHelper = new ClassFileUploadHelper();
//                string lsFileMapPath = ClsFileUploadHelper.sFileRealPath(psAttachment);
//                lMailMessage.Attachments.Add(new Attachment(lsFileMapPath));
//            }

//            if (string.IsNullOrEmpty(psEncoding))
//            {
//                lMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
//            }
//            else
//            {
//                lMailMessage.BodyEncoding = System.Text.Encoding.GetEncoding(psEncoding);
//            }

//            lMailMessage.IsBodyHtml = true;
//            lMailMessage.Subject = psMailSubject;
//            lMailMessage.Body = psMailBody;

//            // 错误处理
//            try
//            {
//                SmtpClient lSmtpClient = new SmtpClient();
//                lSmtpClient.Host = psEmailSMTPServerIP;
//                lSmtpClient.Send(lMailMessage);
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }
//        return true;
//    }

//    public static bool bSendMail(string EmailFrom, string NameFrom, string psEmailPassword, string EmailTo, string psMailSubject, string psMailBody)
//    {
//        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
//        msg.To.Add(EmailTo);
//        msg.From = new System.Net.Mail.MailAddress(EmailFrom, NameFrom, System.Text.Encoding.UTF8);
//        msg.Subject = psMailSubject;
//        msg.SubjectEncoding = System.Text.Encoding.UTF8;

//        msg.Body = psMailBody;
//        msg.IsBodyHtml = true;
//        msg.BodyEncoding = System.Text.Encoding.UTF8;
//        //msg.IsBodyHtml = False
//        msg.Priority = System.Net.Mail.MailPriority.High;

//        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);

//        client.EnableSsl = true;
//        client.UseDefaultCredentials = false;
//        client.Credentials = new System.Net.NetworkCredential(EmailFrom, psEmailPassword, "smtp.gmail.com");
//        client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

//        client.Send(msg);
//        return true;
//    }

//    #endregion

//    #region "Display number handling"
//    /// <summary>
//    /// Need to merge
//    /// </summary>
//    public static string sMoneyThousand(object psNumber)
//    {
//        return nsCommon.mCommon.sMoneyThousand(psNumber);
//    }

//    /// <summary>
//    /// Need to merge
//    /// </summary>
//    public static string sMoneyInteger(object psNumber)
//    {
//        return nsCommon.mCommon.sMoneyInteger(psNumber);
//    }

//    /// <summary>
//    /// Need to merge
//    /// </summary>
//    public static string sMoney(object psNumber)
//    {
//        return nsCommon.mCommon.sMoney(psNumber);
//    }

//    /// <summary>
//    /// Need to merge
//    /// </summary>
//    public static string sMoneyF4(object psNumber)
//    {
//        return nsCommon.mCommon.sMoneyF4(psNumber);
//    }

//    /// <summary>
//    /// Need to merge
//    /// </summary>
//    public static string sPercent(object psNumber)
//    {
//        return nsCommon.mCommon.sPercent(psNumber);
//    }

//    /// <summary>
//    /// Need to merge
//    /// </summary>
//    public static string sNumberF1(object psNumber)
//    {
//        return nsCommon.mCommon.sNumberF1(psNumber);
//    }

//    /// <summary>
//    /// Need to merge
//    /// </summary>
//    public static string sRemove00(object psNumber)
//    {
//        return nsCommon.mCommon.sRemove00(psNumber);
//    }

//    /// <summary>
//    /// Need to merge
//    /// </summary>
//    public static string sNumberF3(object psNumber)
//    {
//        return nsCommon.mCommon.sNumberF3(psNumber);
//    }
//    #endregion

//    #region "Display date handling"
//    /// <summary>
//    /// Need to merge
//    /// </summary>
//    public static string sToChineseDateTime(object pDate)
//    {
//        return nsDateTime.mDataTime.sChineseDateTime(pDate);
//    }

//    /// <summary>
//    /// Need to merge
//    /// </summary>
//    public static string sSQLDateFormat(object pDate)
//    {
//        return nsDateTime.mDataTime.sSQLDateFormat(pDate);
//    }
//    #endregion

//    #region "Export To Excel"


//    public static void ExportToExcel2007(GridView psGridView, Page pPage, DFunc0 pDFunc0)
//    {
//        // pPage.Response.ContentEncoding = System.Text.Encoding.UTF7
//        psGridView.AllowPaging = false;
//        psGridView.AllowSorting = false;
//        pDFunc0();
//        pPage.Response.Clear();

//        pPage.Response.AddHeader("Content-Disposition", "attachment;filename=Report_" + nsDateTime.mDataTime.sStandardFileNameDateTime(DateAndTime.Now) + ".xls");
//        pPage.Response.Charset = "";
//        pPage.Response.ContentType = "application/vnd.xls";

//        // Add the HTML from the GridView to a StringWriter so we can write it out later
//        System.IO.StringWriter sw = new System.IO.StringWriter();
//        System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);
//        psGridView.RenderControl(hw);

//        // Write out the data
//        pPage.Response.Write(sw.ToString());
//        pPage.Response.End();

//    }

//    public static void ExportToExcelMaster(object pControl, Page pPage, DFunc0 pDFunc0, enOfficeType penOfficeType = enOfficeType.Excel, string psFileName = BLANK)
//    {
//        ExportToOfficeMaster(pControl, pPage, pDFunc0, penOfficeType, psFileName);
//    }

//    public static void ExportToExcel(object pControl, Page pPage)
//    {
//        ExportToOffice(pControl, pPage, enOfficeType.Excel);
//    }

//    /// <summary>
//    /// Handling all web control, AllowPaging and AllowSorting is for gridview only
//    /// </summary>
//    public static void ExportToOfficeMaster(object pControl, Page pPage, DFunc0 pDFunc0, enOfficeType penOfficeType = enOfficeType.Excel, string psFileName = BLANK)
//    {
//        try
//        {
//            switch (pControl.GetType().Name)
//            {
//                case "GridView":
//                    nsWebControl.mWebControl.bSetGridViewForPrinting(pControl);

//                    break;
//                case "HtmlGenericControl":
//                    System.Web.UI.HtmlControls.HtmlGenericControl lpControl = (System.Web.UI.HtmlControls.HtmlGenericControl)pControl;
//                    nsWebControl.mWebControl.SearchWebControl(lpControl.Controls, nsWebControl.mWebControl.bSetGridViewForPrinting());

//                    break;
//            }


//        }
//        catch (Exception ex)
//        {
//        }

//        pDFunc0();
//        ExportToOffice(pControl, pPage, penOfficeType, psFileName);
//    }

//    public static void ExportToOffice(object pControl, Page pPage, enOfficeType penOfficeType, string psFileName = BLANK)
//    {
//        // seem can only work outside updatepanel
//        // add to aspx Header
//        // <%@ Page Language="VB" AutoEventWireup="false" CodeFile="AdvancedSearch.aspx.vb" Inherits="AdvancedSearch" EnableEventValidation="false"%>

//        pPage.Response.Clear();
//        pPage.Response.Buffer = true;
//        pPage.Response.Charset = "";
//        pPage.Response.ContentEncoding = System.Text.Encoding.UTF8;

//        psFileName = HttpUtility.UrlPathEncode(pPage.Title + "_" + psFileName) + "_" + nsDateTime.mDataTime.sStandardFileNameDateTime(DateAndTime.Now);
//        // psFileName = HttpUtility.UrlEncode(pPage.Title + "_" + psFileName, System.Text.Encoding.UTF8) + "_" + nsDateTime.sStandardFileNameDateTime(Now)
//        switch (penOfficeType)
//        {
//            case enOfficeType.Excel07:
//                pPage.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
//                pPage.Response.AddHeader("Content-Disposition", "attachment;filename=Report_" + psFileName + ".xlsx");

//                break;
//            case enOfficeType.Excel:
//                pPage.Response.ContentType = "application/vnd.ms-excel";
//                pPage.Response.AddHeader("Content-Disposition", "attachment;filename=Report_" + psFileName + ".xls");

//                break;
//            case enOfficeType.PowerPoint:
//                pPage.Response.ContentType = "application/vnd.ppt";
//                pPage.Response.AddHeader("Content-Disposition", "attachment;filename=Report_" + psFileName + ".ppt");

//                break;
//            case enOfficeType.Word:
//                pPage.Response.ContentType = "application/vnd.doc";
//                pPage.Response.AddHeader("Content-Disposition", "attachment;filename=Report_" + psFileName + ".doc");

//                break;
//        }

//        //' Add the HTML from the GridView to a StringWriter so we can write it out later
//        //Dim sw As System.IO.StringWriter = New System.IO.StringWriter
//        //Dim hw As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(sw)
//        //pControl.RenderControl(hw)

//        //' Write out the data
//        //pPage.Response.Write(sw.ToString)
//        //pPage.Response.End()


//        // using Response.Output can handle big file size
//        System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(pPage.Response.Output);

//        System.Web.UI.HtmlControls.HtmlForm hf = new System.Web.UI.HtmlControls.HtmlForm();
//        pPage.Controls.Add(hf);
//        hf.Controls.Add((Control)pControl);
//        hf.RenderControl(hw);

//        // pPage.Response.Write(sw.ToString)

//        // handle Big file
//        pPage.Response.Flush();
//        pPage.Response.End();

//    }


//    // ''' <summary>
//    // ''' need to implement cPageLoadHelper_GuocoWeb at Page_Init for auto login
//    // ''' </summary>
//    //Public Sub ExportToPDF(ByVal pPage As Page, _
//    //                       Optional ByVal pbAddPassword As Boolean = False, _
//    //                       Optional ByVal psURL As String = BLANK, _
//    //                       Optional ByVal psFilename As String = "PDFReport")

//    //    'Asp.Net - function to convert webpage to pdf

//    //    'flow
//    //    '-User click Download as PDF button
//    //    '-in server side, use wkhtmltopdf.exe to generate the output.pdf
//    //    '-in server side, use iTextSharp to add file info and password to output.pdf
//    //    '-User get the output.pdf file as attachment


//    //    'program reminder:
//    //    '--Need handle autologin if the webpage require login.
//    //    '--Need to check the pdf is completedly generated or not
//    //    '--

//    //    ' Process.Start("C:\Program Files\wkhtmltopdf\wkhtmltopdf.exe", "http://www.google.com C:\Download\google.pdf")
//    //    ' p1: wkhtmltopdf.exe argument length is limited
//    //    ' p2: PDF cannot open directly when using BinaryWrite(memorystream.ToArray())  

//    //    Dim lsFileName As String = psFilename & "_" & nsDateTime.sStandardFileNameDateTimeFull(Now) & ".pdf"
//    //    Dim lsPDFSourcePath As String = GlobalClassHashTableHelper.sGetHash("ExportToPDFFolder") & lsFileName
//    //    Dim lsPDFFileNameExport As String = psFilename & "_" & nsDateTime.sStandardFileNameDateTimeFull(Now) & ".pdf"

//    //    ' Make the url, so that we can autologin.

//    //    Dim lsURL As String = HttpContext.Current.Request.Url.ToString

//    //    If psURL <> BLANK Then
//    //        lsURL = psURL
//    //    End If
//    //    If lsURL.Contains("?") Then
//    //        lsURL += nsCommon.sAddQueryParameter("AutoLogin", gsUserName)
//    //    Else
//    //        lsURL += "?" & nsCommon.sAddQueryParameter("AutoLogin", gsUserName)
//    //    End If

//    //    ' Generate Source File
//    //    Process.Start("C:\Program Files\wkhtmltopdf\wkhtmltopdf.exe", lsURL & " " & lsPDFSourcePath)

//    //    ' Check whether File generated completed
//    //    Dim lbCompleteTask As Boolean = False
//    //    Dim liCounter As Integer = 0
//    //    While lbCompleteTask = False And liCounter < 600 ' 2mins
//    //        If File.Exists(lsPDFSourcePath) Then
//    //            Try
//    //                Using fs As FileStream = New FileStream(lsPDFSourcePath, FileMode.OpenOrCreate, FileAccess.Read)
//    //                    lbCompleteTask = True
//    //                End Using
//    //            Catch ex As Exception
//    //                liCounter = liCounter + 1
//    //                Threading.Thread.Sleep(200)
//    //            End Try
//    //        Else
//    //            liCounter = liCounter + 1
//    //            Threading.Thread.Sleep(200)
//    //        End If
//    //    End While


//    //    Using input As Stream = New FileStream(lsPDFSourcePath, FileMode.Open, FileAccess.Read, FileShare.Read)
//    //        Using Reader1 As New PdfReader(input)
//    //            Using output1 As New MemoryStream
//    //                Using stamper As New PdfStamper(Reader1, output1)
//    //                    Dim info As Dictionary(Of [String], [String]) = Reader1.Info
//    //                    info.Add("Subject", "")
//    //                    info.Add("Keywords", "Report")
//    //                    info.Add("Creator", "Lamsoon")
//    //                    info.Add("Author", "Lamsoon")
//    //                    stamper.MoreInfo = info
//    //                    stamper.Close()

//    //                    Using output2 As New MemoryStream(output1.ToArray)
//    //                        Using Reader2 As New PdfReader(output2)
//    //                            Dim result As New MemoryStream
//    //                            If pbAddPassword Then
//    //                                PdfEncryptor.Encrypt(Reader2, result, True, gsUserName, gsMarkID, PdfWriter.ALLOW_SCREENREADERS)
//    //                            Else
//    //                                PdfEncryptor.Encrypt(Reader2, result, True, "", gsMarkID, PdfWriter.ALLOW_SCREENREADERS)
//    //                            End If
//    //                            pPage.Response.ContentType = "application/pdf"
//    //                            pPage.Response.AddHeader("content-disposition", "attachment;filename=" & lsPDFFileNameExport)
//    //                            pPage.Response.Cache.SetCacheability(HttpCacheability.NoCache)
//    //                            pPage.Response.BinaryWrite(result.ToArray())
//    //                            pPage.Response.End()
//    //                        End Using
//    //                    End Using

//    //                End Using
//    //            End Using
//    //        End Using
//    //    End Using

//    //    'lbCompleteTask = False
//    //    'liCounter = 0
//    //    'While lbCompleteTask = False And liCounter < 30
//    //    '    If File.Exists(lsPDFSourcePath) Then
//    //    '        Try
//    //    '            File.Delete(lsPDFSourcePath)
//    //    '            liCounter = liCounter + 1
//    //    '            Threading.Thread.Sleep(200)
//    //    '        Catch ex As Exception
//    //    '            liCounter = liCounter + 1
//    //    '            Threading.Thread.Sleep(200)
//    //    '        End Try
//    //    '    Else
//    //    '        lbCompleteTask = True
//    //    '    End If
//    //    'End While


//    //End Sub

//    //Public Sub ExportToPDF(ByVal pPage As Page)


//    //    'Version 1
//    //    'Dim styles As New iTextSharp.text.html.simpleparser.StyleSheet()
//    //    'Dim hw As New iTextSharp.text.html.simpleparser.HTMLWorker(doc)
//    //    '' hw.Parse(New StringReader(HTML))
//    //    'Try
//    //    '    hw.Parse(nsNetwork.sURLHTMLSource(HttpContext.Current.Request.Url.ToString))
//    //    'Catch ex As Exception

//    //    'End Try

//    //    'Version 2
//    //    'Dim sr As New StreamReader(HttpContext.Current.Request.Url.ToString, System.Text.Encoding.UTF8)
//    //    'Dim htmlElement As List(Of IElement) = HTMLWorker.ParseToList(sr, styles)
//    //    'For i As Integer = 0 To htmlElement.Count - 1
//    //    '    '以這一份html檔,iTextSharp將其解讀為iTextSharp.text.Paragraph與
//    //    '    'iTextSharp.text.pdf.PdfPTable物件
//    //    '    System.Console.WriteLine("第" & (i + 1) & "個物件為: " & Convert.ToString(htmlElement(i)))
//    //    '    '將每個被HTMLWorker解析的物件加到Document物件中
//    //    '    doc.Add(htmlElement(i))
//    //    'Next


//    //    'method 3
//    //    'Response.ContentType = "application/pdf"

//    //    'Response.AddHeader("content-disposition", "attachment;filename=Export.pdf")
//    //    'Response.Cache.SetCacheability(HttpCacheability.NoCache)
//    //    'Dim sw As New StringWriter()
//    //    'Dim hw As New HtmlTextWriter(sw)
//    //    'Dim frm As New HtmlForm()
//    //    'GridView1.Parent.Controls.Add(frm)
//    //    'frm.Attributes("runat") = "server"
//    //    'frm.Controls.Add(GridView1)
//    //    'frm.RenderControl(hw)
//    //    'Dim sr As New StringReader(sw.ToString())
//    //    'Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)
//    //    'Dim htmlparser As New HTMLWorker(pdfDoc)
//    //    'PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
//    //    'pdfDoc.Open()
//    //    'htmlparser.Parse(sr)
//    //    'pdfDoc.Close()
//    //    'Response.Write(pdfDoc)
//    //    'Response.End()



//    //    Dim doc As New Document()

//    //    Dim lsFilename As String = "Chap0101.pdf"
//    //    PdfWriter.GetInstance(doc, New FileStream(pPage.Request.PhysicalApplicationPath + "\" + lsFilename, FileMode.Create))
//    //    doc.Open()

//    //    Dim styles As New iTextSharp.text.html.simpleparser.StyleSheet()

//    //    Dim wc As New WebClient()
//    //    Dim htmlText As String = wc.DownloadString(HttpContext.Current.Request.Url.ToString)
//    //    ' Response.Write(htmlText)
//    //    Dim htmlarraylist As List(Of IElement) = HTMLWorker.ParseToList(New StringReader(htmlText), Nothing)


//    //    Dim hw As New iTextSharp.text.html.simpleparser.HTMLWorker(doc)
//    //    ' hw.Parse(New StringReader(HTML))
//    //    Try
//    //        hw.Parse(nsNetwork.sURLHTMLSource(HttpContext.Current.Request.Url.ToString))
//    //    Catch ex As Exception

//    //    End Try

//    //    doc.Close()

//    //    pPage.Response.ClearContent()
//    //    pPage.Response.ClearHeaders()
//    //    pPage.Response.AddHeader("Content-Disposition", "inline;filename=" + lsFilename)
//    //    pPage.Response.ContentType = "application/pdf"
//    //    pPage.Response.WriteFile(lsFilename)
//    //    pPage.Response.Flush()
//    //    pPage.Response.Clear()
//    //End Sub


//    public static void ExportToCSV(DataTable Table, Page pPage)
//    {
//        pPage.Response.Buffer = true;
//        pPage.Response.ContentType = "application/vnd.ms-excel";
//        pPage.Response.AddHeader("Content-Disposition", "attachment;filename=Report_" + nsDateTime.mDataTime.sStandardFileNameDateTime(DateAndTime.Now) + ".txt");
//        pPage.Response.ContentEncoding = System.Text.Encoding.GetEncoding(System.Text.Encoding.Default.WebName);
//        pPage.EnableViewState = false;

//        System.IO.Stream lStream = pPage.Response.OutputStream;
//        using (System.IO.StreamWriter Writer = new System.IO.StreamWriter(lStream, System.Text.Encoding.UTF8))
//        {
//            foreach (DataColumn Column in Table.Columns)
//            {
//                Writer.Write(Column.ColumnName);
//                if (Column.Ordinal + 1 < Table.Columns.Count)
//                    Writer.Write(",");
//            }

//            Writer.WriteLine("");
//            foreach (DataRow Row in Table.Rows)
//            {
//                foreach (DataColumn Column in Table.Columns)
//                {
//                    if (object.ReferenceEquals(Row[Column].GetType(), typeof(DateTime)))
//                    {
//                        Writer.Write(((DateTime)Row[Column]).ToString(MyComputer.Info.InstalledUICulture.DateTimeFormat.SortableDateTimePattern));
//                    }
//                    else
//                    {
//                        string Value = Row[Column].ToString();
//                        if (Value.Contains("\r"))
//                        {
//                            Writer.Write(Strings.Chr(34) + Row[Column].ToString() + Strings.Chr(34));
//                        }
//                        else
//                        {
//                            Writer.Write(Row[Column].ToString());
//                        }
//                    }
//                    if (Column.Ordinal + 1 < Table.Columns.Count)
//                        Writer.Write(",");
//                }
//                Writer.WriteLine();
//            }
//        }

//        pPage.Response.End();

//    }
//    #endregion

//    /// <summary>
//    /// normally use for building URL in aspx, better than hyperlink control
//    /// </summary>
//    public static string sURLHTML(object psTargetPath, object psValue, string psTarget = "_blank")
//    {
//        psTargetPath = nsSQL.mSQL.oHandleNullAndNothing(psTargetPath);
//        psValue = nsSQL.mSQL.oHandleNullAndNothing(psValue);

//        if (psTargetPath == BLANK)
//        {
//            psValue = BLANK;
//        }

//        return "<a href=\"" + psTargetPath + "\" target=\"" + psTarget + "\"> " + psValue + "</a>";
//    }

//    public static object ExecuteBatchInASPDotNetUsingCMD(string psFolderPath, string psFilePath)
//    {

//        // Create the ProcessInfo object
//        System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("cmd.exe");

//        //Dim PwdString As String = BLANK
//        //psi.Domain = "HONGKONG"

//        //psi.UserName = "ASUSER"
//        //PwdString = "useras"
//        //Dim newPass As System.Security.SecureString
//        //newPass = New System.Security.SecureString
//        //For Each c As Char In PwdString
//        //    newPass.AppendChar(c)
//        //Next c
//        //psi.Password = newPass


//        psi.UseShellExecute = false;
//        psi.RedirectStandardOutput = true;
//        psi.RedirectStandardInput = true;
//        psi.RedirectStandardError = true;
//        psi.WorkingDirectory = psFolderPath + "\\";

//        // Start the process
//        System.Diagnostics.Process proc = System.Diagnostics.Process.Start(psi);
//        string results = BLANK;

//        try
//        {
//            // Open the batch file for reading
//            System.IO.StreamReader strm = System.IO.File.OpenText(psFilePath);
//            // Attach the output for reading
//            System.IO.StreamReader sOut = proc.StandardOutput;

//            // Attach the in for writing
//            System.IO.StreamWriter sIn = proc.StandardInput;

//            // Write each line of the batch file to standard input
//            while ((strm.Peek() != -1))
//            {
//                sIn.WriteLine(strm.ReadLine());
//            }

//            strm.Close();
//            string stEchoFmt = "# {0} run successfully. Exiting";

//            sIn.WriteLine(string.Format(stEchoFmt, psFilePath));
//            // Exit CMD.EXE
//            sIn.WriteLine("EXIT");

//            // Close the process
//            proc.Close();

//            // Read the sOut to a string.
//            results = sOut.ReadToEnd().Trim();

//            // Close the io Streams
//            sIn.Close();
//            sOut.Close();
//        }
//        catch (Exception ex)
//        {
//            results = ex.ToString() + results;

//        }
//        finally
//        {
//            proc.Close();
//        }

//        return results;

//    }
//}


//// Last tidy up: 20120315
//#region "ClassPageLoadHelper"
///// <summary>
///// no use now
///// </summary>
//public class ClassPageLoadHelper : ClassLoadHelperBase
//{

//    private System.Web.UI.Page mPage;

//    private System.Web.UI.UserControl mUserControl;
//    /// <summary>
//    /// Initializes a new instance of the <see cref="ClassPageLoadHelper" /> class.
//    /// </summary>
//    public ClassPageLoadHelper(System.Web.UI.Page pPage)
//    {
//        mPage = pPage;
//    }

//    public ClassPageLoadHelper(System.Web.UI.UserControl pUserControl)
//    {
//        mUserControl = pUserControl;
//    }

//}

//public abstract class ClassLoadHelperBase
//{

//}
//#endregion

//// Last tidy up: 20130603
//#region "ClassHashTableHelper"
///// <summary>
///// Contains Useful objects of the page.
///// f1 - sGetHash, to get the HashValue in mHashtable
///// f2 - msLang, to store the selected Language of the page(tc/sc/en).
///// f3 - fAddValidator, auto add requiredFieldValidator into parent panel of the target control.
///// f4 - msUserName, to store Login User ID.
///// </summary>
//public class ClassHashTableHelper
//{

//    private System.Web.HttpRequest mRequest = HttpContext.Current.Request;
//    private Hashtable _mHashtable;
//    public Hashtable mHashtable
//    {
//        get { return _mHashtable; }
//        private set { _mHashtable = value; }
//    }

//    // f2
//    public string msLang
//    {
//        get { return LIBWebBased.gslang(); }
//    }

//    // f4
//    public string msUserName
//    {
//        get { return LIBWebBased.gsUserName(); }
//    }

//    // f1
//    /// <summary>
//    /// Get HashValue based on psHashKey
//    /// </summary>
//    public string sGetHash(object psHashKey)
//    {
//        return nsCommon.mCommon.sGetHash(mHashtable, psHashKey);
//    }

//    //f7
//    public object fFillHashTable(object pControl1)
//    {
//        Control pControl = pControl1;

//        switch (pControl.GetType().Name)
//        {
//            case "LinkButton":
//                LinkButton lControl = pControl;
//                lControl.Text = this.sGetHash(lControl.Text);

//                break;
//            case "CheckBox":
//                CheckBox lControl = pControl;
//                lControl.Text = this.sGetHash(lControl.Text);

//                break;
//            case "Button":
//                Button lControl = pControl;
//                lControl.Text = this.sGetHash(lControl.Text);
//                if (lControl.ID == "btnDeleteRecord")
//                {
//                    nsCommon.mCommon.fButtonSetDeleteReminder(lControl);
//                }

//                break;
//            case "Label":
//                Label lControl = pControl;
//                lControl.Text = this.sGetHash(lControl.Text);

//                break;
//            case "Literal":
//                if (pControl.Visible == true)
//                {
//                    Literal lControl = pControl;
//                    lControl.Text = this.sGetHash(lControl.Text);
//                }

//                break;
//            case "RequiredFieldValidator":
//                RequiredFieldValidator lControl = pControl;
//                lControl.ErrorMessage = this.sGetHash(lControl.ErrorMessage);

//                break;
//            case "RegularExpressionValidator":
//                RegularExpressionValidator lControl = pControl;
//                lControl.ErrorMessage = this.sGetHash(lControl.ErrorMessage);
//                lControl.ValidationExpression = this.sGetHash(lControl.ValidationExpression);

//                break;
//            case "TextBoxWatermarkExtender":
//                TextBoxWatermarkExtender lControl = pControl;
//                lControl.WatermarkText = this.sGetHash(lControl.WatermarkText);

//                break;
//            case "GridView":
//                GridView lControl = pControl;
//                nsCommon.mCommon.fGridViewSetHeader(lControl, this.mHashtable);
//                lControl.ToolTip = this.sGetHash(lControl.ToolTip);

//                break;
//            case "DataGrid":
//                DataGrid lControl = pControl;
//                nsCommon.mCommon.fDataGridSetHeader(lControl, this.mHashtable);

//                break;
//            //Case "TextBoxWatermarkExtender"
//            //    Dim lControl As TextBoxWatermarkExtender = pControl
//            //    lControl.WatermarkText = ClsHashTableHelper.sGetHash(lControl.WatermarkText)

//            //Case "CollapsiblePanelExtender"
//            //    Dim lControl As CollapsiblePanelExtender = pControl
//            //    lControl.CollapsedText = ClsHashTableHelper.sGetHash(lControl.CollapsedText)
//            //    lControl.ExpandedText = ClsHashTableHelper.sGetHash(lControl.ExpandedText)

//            case "SiteMapPath":
//                SiteMapPath lControl = pControl;
//                Debug.Print("SiteMapPath");

//                break;
//            case "SiteMapNodeItem":
//                SiteMapNodeItem lControl = pControl;
//                Debug.Print("SiteMapNodeItem");

//                break;
//            case "HyperLink":
//                HyperLink lControl = pControl;
//                lControl.Text = this.sGetHash(lControl.Text);

//                break;
//            case "DatePicker":
//                DatePicker lControl = pControl;
//                lControl.Clearable = true;

//                break;
//        }
//        return true;

//    }

//    #region "New"
//    /// <summary>
//    /// Initializes a new instance of the <see cref="ClassHashTableHelper" /> class.
//    /// And pass the built pHashtable into this class.
//    /// </summary>
//    public ClassHashTableHelper(Hashtable pHashtable)
//    {
//        this.mHashtable = pHashtable;
//    }

//    public ClassHashTableHelper()
//    {
//        this.mHashtable = nsSQL.mSQL.BuildHashTable(msLang);
//    }

//    public ClassHashTableHelper(string psString, enHashTableType pHashTableType)
//    {
//        switch (pHashTableType)
//        {
//            case enHashTableType.StoredProcedure:
//                this.mHashtable = nsSQL.mSQL.BuildHashTable(msLang, psString);

//                break;
//            case enHashTableType.XMLFile:
//                this.mHashtable = new Language(msLang, psString).hash;
//                break;
//        }
//    }

//    public enum enHashTableType
//    {
//        StoredProcedure,
//        XMLFile
//    }

//    #endregion

//    #region "For Checking HashTable"
//    public void PrintAllHashValue()
//    {
//        foreach (object lKey in mHashtable.Keys)
//        {
//            Debug.Print(mHashtable[lKey].ToString());
//        }
//    }

//    public void PrintAllHashKey()
//    {
//        foreach (object lKey in mHashtable.Keys)
//        {
//            Debug.Print(lKey.ToString());
//        }
//    }
//    #endregion

//    #region "fAddValidator"
//    /// <summary>
//    /// Web base only
//    /// f3 - Add validator to all SmartTextbox and SmartDropDownList in pPage, 
//    /// it is based on value of their ValidationGroup.
//    /// </summary>
//    public void fAddValidator(ref System.Web.UI.TemplateControl pMe)
//    {
//        nsWebControl.mWebControl.SearchWebControlGrowing(pMe.Controls, this.AddValidator);
//    }

//    private object AddValidator(object pControl1)
//    {
//        Control pControl = pControl1;

//        string lsControlName = pControl.GetType().Name;

//        switch (lsControlName)
//        {

//            case "SmartDropDownList":
//            case "SmartTextbox":
//            case "TextBox":
//            case "SmartRadioButtonList":
//            case "SmartCheckboxList":
//            case "CheckBoxList":
//            case "FileUpload":

//                string lsValidationGroup = LIBWebBased.BLANK;

//                switch (lsControlName)
//                {
//                    case "SmartDropDownList":
//                        SmartDropDownList lControl = pControl;
//                        lsValidationGroup = lControl.ValidationGroup;
//                        break;
//                    case "SmartTextbox":
//                        SmartTextbox lControl = pControl;
//                        lsValidationGroup = lControl.ValidationGroup;
//                        break;
//                    case "TextBox":
//                        System.Web.UI.WebControls.TextBox lControl = pControl;
//                        lsValidationGroup = lControl.ValidationGroup;
//                        break;
//                    case "SmartCheckboxList":
//                        SmartCheckboxList lControl = pControl;
//                        lsValidationGroup = lControl.ValidationGroup;
//                        break;
//                    case "SmartRadioButtonList":
//                        SmartRadioButtonList lControl = pControl;
//                        lsValidationGroup = lControl.ValidationGroup;
//                        break;
//                    case "CheckBoxList":
//                        break;
//                    case "FileUpload":

//                        break;

//                }

//                if (lsValidationGroup != LIBWebBased.BLANK)
//                {
//                    if (!lsValidationGroup.StartsWith("not"))
//                    {
//                        RequiredFieldValidator lRequiredFieldValidator = new RequiredFieldValidator();
//                        lRequiredFieldValidator.SetFocusOnError = true;
//                        lRequiredFieldValidator.ValidationGroup = lsValidationGroup;
//                        lRequiredFieldValidator.ControlToValidate = pControl.ID;
//                        lRequiredFieldValidator.Display = ValidatorDisplay.Dynamic;
//                        lRequiredFieldValidator.ErrorMessage = this.sGetHash("不能為空");
//                        lRequiredFieldValidator.ID = "rfv" + pControl.ID + LIBWebBased.gsRequiredFieldValidatorCounter;
//                        LIBWebBased.gsRequiredFieldValidatorCounter += 1;

//                        pControl.Parent.Controls.Add(lRequiredFieldValidator);
//                    }
//                }
//                break;
//        }
//        return true;
//    }
//    #endregion

//}
//#endregion

//// Last tidy up: 20120229
//#region "ClassLoadFieldHelper"

//#region "ClassSqlParameterHelper"
///// <summary>
///// This class aim at simplified the loading and saving steps between user interface and Database.
///// Can execute Stored procedure/SQL
///// Can use in all window/web base programming.
///// Can build dataSet
///// Can Load data from dataSet, single row / multi rows
///// Store the parameter Field and Value in hashtable for further uses (eg.Passing data). 
///// </summary>
//public abstract class ClassSqlParameterHelperBaseAllBased
//{
//    private List<string> mListParameterName = new List<string>();
//    private List<object> mListParameterValue = new List<object>();
//    private List<bool> mListParameterInOut = new List<bool>();

//    private Hashtable mHashTable = new Hashtable();
//    protected DataRow mdrRow;

//    protected string msStoreProcedureName = LIBWebBased.BLANK;
//    private System.Data.DataSet _mDataSet;
//    protected System.Data.DataSet mDataSet
//    {
//        get { return _mDataSet; }
//        private set
//        {
//            if (nsDataSet.mDataSet.bExistDataSet(value))
//            {
//                _mDataSet = value;
//            }
//            if (nsDataSet.mDataSet.bExistDataSet(_mDataSet))
//            {
//                if (iRowCount() > 0)
//                {
//                    mdrRow = _mDataSet.Tables[0].Rows[0];
//                    mbDataSetHasRecord = true;
//                }
//            }
//        }
//    }

//    private SqlParameter[] _mSqlParameter = null;
//    protected SqlParameter[] mSqlParameter
//    {
//        get
//        {
//            if (_mSqlParameter == null)
//            {
//                if (mListParameterName.Count > 0)
//                {
//                    int liNoOfParameter = mListParameterName.Count - 1;
//                    SqlParameter[] lSqlParameter = new SqlParameter[liNoOfParameter + 1];
//                    for (int i = 0; i <= liNoOfParameter; i++)
//                    {
//                        lSqlParameter[i] = new SqlParameter(mListParameterName[i], mListParameterValue[i]);
//                        if (mListParameterInOut[i] == true)
//                        {
//                            lSqlParameter[i].Direction = ParameterDirection.InputOutput;
//                        }
//                    }
//                    _mSqlParameter = lSqlParameter;
//                }
//            }
//            return _mSqlParameter;
//        }
//        private set
//        {
//            if (value == null)
//            {
//            }
//            else
//            {
//                this._mSqlParameter = value;
//            }
//        }
//    }

//    private bool _mbDataSetHasRecord = false;
//    public bool mbDataSetHasRecord
//    {
//        get { return _mbDataSetHasRecord; }
//        private set { _mbDataSetHasRecord = value; }
//    }

//    #region "SQLParameter and HashTable related"

//    /// <summary>
//    /// Add SQL parameter.
//    /// </summary>

//    protected void AddSqlParameter(string psFieldName, object poFieldValue, bool pbIsInOut = false)
//    {
//        mHashTable.Add(sFixedFieldName(psFieldName), poFieldValue);
//        mListParameterName.Add(sFixedFieldName(psFieldName));
//        mListParameterValue.Add(poFieldValue);
//        mListParameterInOut.Add(pbIsInOut);
//    }

//    /// <summary>
//    /// Auto Fill @ into Filedname if @ does not exist.
//    /// </summary>
//    private string sFixedFieldName(string psFieldName)
//    {
//        if (psFieldName.IndexOf("@") >= 0)
//        {
//            return psFieldName;
//        }
//        else
//        {
//            return "@" + psFieldName;
//        }
//    }

//    /// <summary>
//    /// For debug use, easily copy to SQL and execute.
//    /// </summary>
//    public string fPrintSqlParameterList()
//    {
//        string lsString = LIBWebBased.BLANK;
//        foreach (SqlParameter lsValue in mSqlParameter)
//        {
//            lsString += lsValue.ToString() + "='" + lsValue.Value + "'" + ",";
//        }

//        if (lsString != LIBWebBased.BLANK)
//        {
//            lsString = lsString.Substring(0, lsString.Length - 1);
//        }
//        return lsString;
//    }

//    public object fGetHashFieldValue(string psFieldName)
//    {
//        return nsCommon.mCommon.sGetHash(mHashTable, sFixedFieldName(psFieldName));

//    }

//    public void fSetHashFieldValue(string psFieldName, string psFieldValue)
//    {
//        mHashTable[sFixedFieldName(psFieldName)] = psFieldValue;
//    }

//    /// <summary>
//    /// Get whole SQL parameter.
//    /// </summary>
//    public SqlParameter[] fGetSqlParameter()
//    {
//        return mSqlParameter;
//    }
//    #endregion

//    #region "DataSet and DataTable related"
//    /// <summary>
//    /// Execute the STP and return the result as a Dataset
//    /// </summary>
//    public System.Data.DataSet fBuildDataSet(string psStoreProcedureName, SqlParameter[] pSqlParameter = null, string psConnectionString = LIBWebBased.BLANK)
//    {


//        msStoreProcedureName = psStoreProcedureName;
//        this.mSqlParameter = pSqlParameter;
//        System.Data.DataSet lDataSet = nsSQL.mSQL.BuildDataSet(psStoreProcedureName, this.fGetSqlParameter(), psConnectionString);

//        mDataSet = lDataSet;
//        try
//        {
//            if (LIBWebBased.gbLocalTesting)
//            {
//                Debug.Print("STP's Paramaterlist: " + psStoreProcedureName + " " + this.fPrintSqlParameterList());
//                // NotSet3Lang
//            }

//        }
//        catch (Exception ex)
//        {
//        }

//        return lDataSet;

//    }

//    /// <summary>
//    /// Build Table from MDX and pass into this class for further use
//    /// </summary>
//    public void SetDataTable(DataTable pDataTable = null)
//    {
//        System.Data.DataSet lDataset = new System.Data.DataSet();
//        lDataset.Tables.Add(pDataTable);
//        mDataSet = lDataset;
//    }

//    /// <summary>
//    /// Pass in dataset for further use
//    /// </summary>
//    public void SetDataSet(System.Data.DataSet pDataset = null)
//    {
//        mDataSet = pDataset;
//    }

//    public System.Data.DataSet fGetDataSet()
//    {
//        return mDataSet;
//    }

//    public int iRowCount()
//    {
//        try
//        {
//            return mDataSet.Tables[0].Rows.Count;
//        }
//        catch (Exception ex)
//        {
//            return 0;
//        }
//    }

//    protected int miCurrentRow = 0;
//    /// <summary>
//    /// if has next row, keep on reading.
//    /// </summary>
//    public bool bHasNextRow()
//    {
//        if (mbDataSetHasRecord)
//        {
//            if (miCurrentRow <= mDataSet.Tables[0].Rows.Count - 1)
//            {
//                mdrRow = mDataSet.Tables[0].Rows[miCurrentRow];
//                miCurrentRow = miCurrentRow + 1;
//                return true;
//            }
//        }
//        return false;
//    }

//    public bool bHasNextRow(string psFilter)
//    {
//        DataRow[] lDataRow = mDataSet.Tables[0].Select(psFilter);
//        if (mbDataSetHasRecord)
//        {
//            if (miCurrentRow <= lDataRow.Length - 1)
//            {
//                mdrRow = lDataRow[miCurrentRow];
//                miCurrentRow = miCurrentRow + 1;
//                return true;
//            }
//        }
//        return false;
//    }
//    #endregion

//    #region "Get/ Load data from Dataset/DataTable"
//    public object oLoadSqlFieldByIndex(int psFieldIndex)
//    {
//        if (mbDataSetHasRecord == true)
//        {
//            return nsSQL.mSQL.oHandleDBNull(mdrRow[psFieldIndex]);
//        }
//        else
//        {
//            return LIBWebBased.BLANK;
//        }
//    }

//    public object oLoadSqlField(string psFieldName)
//    {
//        if (mbDataSetHasRecord == true)
//        {
//            return nsSQL.mSQL.oHandleDBNull(mdrRow[psFieldName]);
//        }
//        else
//        {
//            return LIBWebBased.BLANK;
//        }
//    }
//    #endregion
//}

//public abstract class ClassSqlParameterHelperBase : ClassSqlParameterHelperBaseAllBased
//{

//    /// <summary>
//    /// Add field into SQLParameter.
//    /// Can pass Control/Value directly as poFieldValueControl.
//    /// Handle all kinds of controls.
//    /// </summary>
//    public void fAddSqlParameter(string psParameterName, object poParameterValueControl, bool pbIsInOut = false, bool pBlankThenNull = false, bool pBlankThenNotAdd = false, bool pbToNumber = false, bool pbHandleMultiOption = false)
//    {
//        object lsValue = nsWebControl.mWebControl.sGetControlValue(poParameterValueControl, pBlankThenNull);

//        try
//        {
//            // lsValue = nsString.sBig5ToGb(lsValue)

//        }
//        catch (Exception ex)
//        {
//        }

//        if (pBlankThenNotAdd)
//        {
//            if (nsSQL.mSQL.oHandleNullAndNothing(lsValue) == LIBWebBased.BLANK)
//            {
//                return;
//            }
//        }

//        if (pbHandleMultiOption)
//        {
//            lsValue = "," + lsValue;
//        }

//        if (pbToNumber)
//        {
//            lsValue = nsCommon.mCommon.sToNumber(lsValue);
//        }

//        base.AddSqlParameter(psParameterName, lsValue, pbIsInOut);

//    }

//}

///// <summary>
///// To Bind dataset with Gridview/ DataGrid/ DropDownList...
///// </summary>
//public class ClassSqlParameterHelper : ClassSqlParameterHelperBase
//{

//    private ClassHashTableHelper _mClsHashTableHelper;
//    protected ClassHashTableHelper mClsHashTableHelper
//    {
//        get
//        {
//            if (_mClsHashTableHelper == null)
//            {
//                _mClsHashTableHelper = LIBWebBased.GlobalClassHashTableHelper;
//            }

//            return _mClsHashTableHelper;
//        }
//        set
//        {
//            if (value == null)
//            {
//            }
//            else
//            {
//                _mClsHashTableHelper = value;
//            }
//        }
//    }

//    /// <summary>
//    /// Load Sql Data to Control
//    /// Can Handle DBNull error, Empty the control when no result found
//    /// Can pass Control directly.
//    /// </summary>
//    public void LoadSqlField(string psFieldName, ref object poFieldValueControl)
//    {
//        try
//        {
//            object lsValue = null;
//            try
//            {
//                //If GlobalClassHashTableHelper.msLang = "sc" Then
//                //    lsValue = nsString.sBig5ToGb(Me.oLoadSqlField(psFieldName))
//                //ElseIf GlobalClassHashTableHelper.msLang = "tc" Then
//                //    lsValue = nsString.sGbToBig5(Me.oLoadSqlField(psFieldName))
//                //Else
//                //    lsValue = Me.oLoadSqlField(psFieldName)
//                //End If

//                lsValue = this.oLoadSqlField(psFieldName);
//            }
//            catch (Exception ex)
//            {
//                lsValue = this.oLoadSqlField(psFieldName);
//            }
//            nsWebControl.mWebControl.SetControlValue(lsValue, ref poFieldValueControl);

//        }
//        catch (Exception ex)
//        {
//        }
//    }

//    public object iRowCountDesc()
//    {
//        try
//        {
//            return mClsHashTableHelper.sGetHash("總數") + ":" + this.iRowCount();
//        }
//        catch (Exception ex)
//        {
//            return 0;
//        }
//    }

//    #region "GridViewRow Related"

//    protected GridViewRow mGridViewRow;
//    public void SetGridViewRow(GridViewRow pGridViewRow)
//    {
//        this.mGridViewRow = pGridViewRow;
//    }

//    public void fAddSqlParameterFromGridViewRow(string psFieldName, bool pBlankThenNull = false)
//    {
//        try
//        {
//            WebControl lWebControl = mGridViewRow.FindControl(psFieldName);

//            if (lWebControl != null)
//            {
//                fAddSqlParameter(psFieldName, lWebControl, false, pBlankThenNull);
//            }
//            // End If

//        }
//        catch (Exception ex)
//        {
//        }
//    }

//    public void LoadSqlFieldIntoGridViewRow(GridViewRow lGridViewRow, bool pbShowNumber = false)
//    {
//        // Aim   : Load Sql Value into control in GridViewRow in auto mode (No need to do manual mapping of fieldname/controlname)
//        // Limit : ControlName in GridViewRow = ColumnName in Sql
//        // Result: ControlName.text = Column.Value
//        if (mbDataSetHasRecord == true)
//        {
//            foreach (System.Data.DataColumn lColumn in mdrRow.Table.Columns)
//            {
//                object lObject = lGridViewRow.FindControl(lColumn.Caption);

//                if (lObject == null)
//                {
//                }
//                else
//                {
//                    LoadSqlField(lColumn.Caption, ref lObject);
//                    if (pbShowNumber)
//                    {
//                        nsWebControl.mWebControl.SetControlValue(nsCommon.mCommon.sNumber(lObject.text), ref lObject);
//                    }
//                }
//            }
//        }
//    }
//    #endregion

//    /// <summary>
//    /// Handle ListControl, GridView, DataGrid
//    /// </summary>
//    public void fBindControls(object pControl, LIBWebBased.enDropDownListType penDropDownListType = LIBWebBased.enDropDownListType.NoValue, bool pbDoTranslation = false)
//    {
//        switch (true)
//        {
//            case pControl is ListControl:
//                nsDataSet.mDataSet.BindListControl(base.mDataSet, ref pControl, penDropDownListType, pbDoTranslation);

//                break;
//            case pControl is GridView:
//                GridView lControl = pControl;
//                nsDataSet.mDataSet.BindGridView(base.mDataSet, pControl);

//                break;
//            case pControl is DataGrid:
//                nsDataSet.mDataSet.BindDataGrid(base.mDataSet, pControl);
//                break;
//        }
//    }

//}
//#endregion

//public class ClassLoadFieldHelper : ClassSqlParameterHelper
//{

//    /// <summary>
//    /// 由 Dataset > Gridview
//    /// </summary>
//    public void fBindGridView(System.Web.UI.WebControls.GridView pGridView, bool pKeepLog = true)
//    {
//        KeepLog(pKeepLog);
//        base.fBindControls(pGridView);

//    }

//    private void KeepLog(bool pKeepLog)
//    {
//        try
//        {

//            if (pKeepLog)
//            {
//                nsCommon.mCommon.PageFunctionLog(LIBWebBased.gsUserName(), gsProjectCode, HttpContext.Current.Request.RawUrl, this.fPrintSqlParameterList(), this.msStoreProcedureName, LIBWebBased.BLANK, LIBWebBased.BLANK, LIBWebBased.BLANK);
//            }

//        }
//        catch (Exception ex)
//        {
//        }
//    }

//}
//#endregion

//// Last tidy up: 20120229
//#region "ClassGridViewHelper"
///// <summary>
///// Can Add Extra Column Header/ Footer
///// </summary>
//public class ClassGridViewHelper
//{
//    // Implements IGridViewHelper

//    public enum enGridViewType
//    {
//        DynamicReportWithAutoGeneratedColumn,
//        DynamicReportWithAutoGeneratedColumnWithOutTotal,
//        DetailReportWithAutoGeneratedColumn,
//        DetailReportWithAutoGeneratedColumnWithNoHeader,
//        DetailReportWithAutoGeneratedColumnWithNoHeaderAndNoFormat,
//        NormalReport
//    }
//    private const string mddlName = "ddlGoToPage";
//    private const string mlblNameCurrentOverTotalPage = "lblNoOfPage";

//    private const string mlblNameGotoPage = "lblGoToPage";

//    private enGridViewType miGridViewType = enGridViewType.NormalReport;
//    private bool mbHighLightMaximumColumn = true;

//    private bool mbHideEmptyColumn = true;
//    private GridView mGridView;
//    private ListControl mDDLRowOption;
//    private ListControl mDDLColumnOption;
//    private ListControl mDDLYear;
//    private ListControl mDDLMonth;

//    private ClassHashTableHelper mClsHashTableHelper = LIBWebBased.GlobalClassHashTableHelper;
//    private Page mPage;

//    private LIBWebBased.DFunc0 mDFunc0FillGridView;
//    private Label mSortLabel;

//    private LIBWebBased.DFunc0 mDFunc0BuildGridHeader;

//    private LIBWebBased.DFunc3 mDFunc3sGetCellURLCode;
//    private List<object> mListHeaderName = new List<object>();
//    private List<object> mListSpanValue = new List<object>();

//    private List<object> mListAlign = new List<object>();
//    /// <summary>
//    /// 設定目標gridview
//    /// </summary>
//    public void SetGridView(GridView pGridView, ClassGridViewHelper.enGridViewType piGridViewType = enGridViewType.NormalReport)
//    {
//        this.mGridView = pGridView;
//        this.miGridViewType = piGridViewType;
//        this.mGridView.EmptyDataText = nsCommon.mCommon.sEmptyDataText();
//    }

//    /// <summary>
//    /// Used for DynamicReport AutoGeneratedColumn
//    /// </summary>
//    public void SetDDLRowColumnOption(ListControl pDDLRowOption, ListControl pDDLColumnOption)
//    {
//        if (pDDLRowOption == null)
//        {
//        }
//        else
//        {
//            this.mDDLRowOption = pDDLRowOption;
//            this.mDDLColumnOption = pDDLColumnOption;
//        }
//    }

//    /// <summary>
//    /// Used for DynamicReport AutoGeneratedColumn
//    /// </summary>
//    public void SetDDLYearMonth(ListControl pDDLYear, ListControl pDDLMonth)
//    {
//        this.mDDLYear = pDDLYear;
//        this.mDDLMonth = pDDLMonth;
//    }

//    /// <summary>
//    /// Used for DynamicReport AutoGeneratedColumn
//    /// </summary>
//    public void SetHideEmptyColumn(bool pbHideEmptyColumn)
//    {
//        mbHideEmptyColumn = pbHideEmptyColumn;
//    }

//    /// <summary>
//    /// Used for DynamicReport AutoGeneratedColumn
//    /// </summary>
//    public void SetHighLightMaximumColumn(bool pbHighLightMaximumColumn)
//    {
//        mbHighLightMaximumColumn = pbHighLightMaximumColumn;
//    }

//    /// <summary>
//    /// Used for GridSorting
//    /// </summary>
//    public void SetSortLabel(Label pLabel)
//    {
//        this.mSortLabel = pLabel;
//        this.mGridView.AllowSorting = true;
//    }

//    /// <summary>
//    /// Used for GridHeader
//    /// </summary>
//    public void RemoveAt(int piIndex)
//    {
//        this.mListHeaderName.RemoveAt(piIndex);
//        this.mListSpanValue.RemoveAt(piIndex);
//        this.mListAlign.RemoveAt(piIndex);
//    }

//    #region "Add Extra Column Header/ Footer"
//    /// <summary>
//    /// Add Extra Column Header/ Footer to list
//    /// </summary>
//    public void fAddMasterColumn(object pHeaderText, string pColumnSpan = "1", HorizontalAlign pAlign = HorizontalAlign.Center)
//    {
//        try
//        {
//            this.mListHeaderName.Add(LIBWebBased.GlobalClassHashTableHelper.sGetHash(pHeaderText));
//            this.mListSpanValue.Add(pColumnSpan);
//            this.mListAlign.Add(pAlign);

//        }
//        catch (Exception ex)
//        {
//            this.mListHeaderName.Add(pHeaderText);
//            this.mListSpanValue.Add(pColumnSpan);
//            this.mListAlign.Add(pAlign);
//        }
//    }

//    /// <summary>
//    /// Add header Row to Grid
//    /// </summary>
//    public void fAddExtraMasterHeaderRow(bool pbEnableViewState = false)
//    {
//        try
//        {
//            mGridView.Controls[0].Controls.AddAt(0, this.fGridViewRow());
//            // 20120830, when EnableViewState = False, header cannot be translated, after postback so need to set true in local.
//            // when EnableViewState = true, if other control postback, will remove the header.
//            mGridView.EnableViewState = pbEnableViewState;


//        }
//        catch (Exception ex)
//        {
//        }
//    }

//    public void fAddExtraMasterFooterRow()
//    {
//        try
//        {
//            mGridView.Controls[0].Controls.Add(this.fGridViewRow());
//            mGridView.EnableViewState = false;

//        }
//        catch (Exception ex)
//        {
//        }
//    }

//    private GridViewRow fGridViewRow()
//    {
//        GridViewRow lGridViewRow = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal);
//        TableCell lTableCell = null;
//        for (int i = 0; i <= this.mListHeaderName.Count - 1; i++)
//        {
//            lTableCell = new TableCell();
//            lTableCell.Text = this.mListHeaderName[i];
//            lTableCell.HorizontalAlign = this.mListAlign[i];
//            lTableCell.BackColor = System.Drawing.Color.LightSkyBlue;
//            lTableCell.Font.Bold = true;

//            lTableCell.ColumnSpan = this.mListSpanValue[i];
//            lGridViewRow.Cells.Add(lTableCell);
//        }
//        lGridViewRow.ID = "Test" + mGridView.Controls[0].Controls.Count.ToString();
//        lGridViewRow.EnableViewState = false;
//        return lGridViewRow;
//    }

//    public void fAddExtraDataRow(int psRedColorLimit = 0)
//    {
//        GridViewRow lGridViewRow = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal);

//        TableCell lTableCell = null;
//        for (int i = 0; i <= this.mListHeaderName.Count - 1; i++)
//        {
//            lTableCell = new TableCell();
//            lTableCell.Text = this.mListHeaderName[i];

//            if (i != 0)
//            {
//                lTableCell.HorizontalAlign = HorizontalAlign.Right;
//            }

//            if (psRedColorLimit != 0)
//            {
//                try
//                {
//                    if (nsCommon.mCommon.sToNumber(lTableCell.Text) > psRedColorLimit)
//                    {
//                        lTableCell.ForeColor = System.Drawing.Color.Red;
//                    }

//                }
//                catch (Exception ex)
//                {
//                }
//            }

//            lTableCell.BackColor = System.Drawing.Color.LightSkyBlue;
//            lTableCell.ColumnSpan = this.mListSpanValue[i];
//            lGridViewRow.Cells.Add(lTableCell);
//        }
//        mGridView.Controls[0].Controls.Add(lGridViewRow);

//    }
//    #endregion

//    #region "fAddPaging - Using SQLdatasource"
//    /// <summary>
//    /// Using SQLdatasource
//    /// </summary>
//    public void fAddPaging(System.Web.UI.TemplateControl pPage)
//    {
//        if (mGridView.AllowPaging == true)
//        {
//            this.mPage = pPage;
//            mPage.Load += Page_Load;
//            mGridView.DataBound += GridView_DataBound;
//        }
//    }

//    #region "Paging - - Add DDL, gv Handler"
//    /// <summary>
//    /// 只能在page load 時, 增加ddlGoToPage 的handler.
//    /// </summary>
//    protected void Page_Load(object sender, System.EventArgs e)
//    {
//        fAddDropDownListHandler();
//    }

//    private void fAddDropDownListHandler()
//    {
//        if (mGridView.BottomPagerRow != null)
//        {
//            ListControl lDropDownList = fGetPagerDDL(mGridView);
//            lDropDownList.SelectedIndexChanged += PagerDropDownList_SelectedIndexChanged;
//        }
//    }

//    /// <summary>
//    /// ddl SelectedIndexChanged時, 就會更新gridview.
//    /// </summary>
//    protected void PagerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        ListControl lDropDownList = fGetPagerDDL(mGridView);
//        mGridView.PageIndex = lDropDownList.SelectedIndex;
//    }
//    #endregion

//    #region "Paging - DDL, lbl and image interaction."
//    protected void GridView_DataBound(object sender, System.EventArgs e)
//    {
//        GridView lGridView = mGridView;
//        GridViewRow lGridViewRow = lGridView.BottomPagerRow;

//        if (lGridViewRow != null)
//        {
//            int liCurrentPage = lGridView.PageIndex + 1;
//            int liTotalPage = lGridView.PageCount;
//            ListControl lddlNoOfPage = fGetPagerDDL(lGridView);
//            if (lddlNoOfPage != null)
//            {
//                lddlNoOfPage.Items.Clear();
//                for (int i = 0; i <= liTotalPage - 1; i++)
//                {
//                    lddlNoOfPage.Items.Add(i + 1);
//                }
//                lddlNoOfPage.SelectedValue = liCurrentPage;
//            }
//            Label lblGotoPage = (Label)lGridViewRow.Cells[0].FindControl(mlblNameGotoPage);
//            lblGotoPage.Text = mClsHashTableHelper.sGetHash("Go To Page");

//            Label lblCurrentOverTotalPage = (Label)lGridViewRow.Cells[0].FindControl(mlblNameCurrentOverTotalPage);
//            lblCurrentOverTotalPage.Text = liCurrentPage + "/" + liTotalPage;
//            SetImageButton();
//        }
//    }

//    private void SetImageButton()
//    {
//        GridView lGridView = mGridView;
//        GridViewRow lGridViewRow = lGridView.BottomPagerRow;
//        if (lGridViewRow != null)
//        {
//            int liCurrentPage = lGridView.PageIndex + 1;
//            int liTotalPage = lGridView.PageCount;

//            ImageButton lImgBtnFirst = (ImageButton)lGridViewRow.Cells[0].FindControl("ImgBtnFirst");
//            ImageButton lImgBtnPrev = (ImageButton)lGridViewRow.Cells[0].FindControl("ImgBtnPrev");
//            ImageButton lImgBtnNext = (ImageButton)lGridViewRow.Cells[0].FindControl("ImgBtnNext");
//            ImageButton lImgBtnLast = (ImageButton)lGridViewRow.Cells[0].FindControl("ImgBtnLast");

//            lImgBtnFirst.ToolTip = mClsHashTableHelper.sGetHash("首頁");
//            lImgBtnPrev.ToolTip = mClsHashTableHelper.sGetHash("上一頁");
//            lImgBtnNext.ToolTip = mClsHashTableHelper.sGetHash("下一頁");
//            lImgBtnLast.ToolTip = mClsHashTableHelper.sGetHash("尾頁");

//            switch (mGridView.PageIndex)
//            {
//                case 0:
//                    lImgBtnFirst.Enabled = false;
//                    lImgBtnPrev.Enabled = false;
//                    lImgBtnFirst.ImageUrl = "~/img/Firstd.gif";
//                    lImgBtnPrev.ImageUrl = "~/img/Prevd.gif";

//                    break;
//                case liTotalPage - 1:
//                    lImgBtnNext.Enabled = false;
//                    lImgBtnLast.Enabled = false;
//                    lImgBtnNext.ImageUrl = "~/img/Nextd.gif";
//                    lImgBtnLast.ImageUrl = "~/img/Lastd.gif";

//                    break;
//                default:
//                    lImgBtnFirst.Enabled = true;
//                    lImgBtnPrev.Enabled = true;
//                    lImgBtnNext.Enabled = true;
//                    lImgBtnLast.Enabled = true;

//                    lImgBtnFirst.ImageUrl = "~/img/First.gif";
//                    lImgBtnPrev.ImageUrl = "~/img/Prev.gif";
//                    lImgBtnNext.ImageUrl = "~/img/Next.gif";
//                    lImgBtnLast.ImageUrl = "~/img/Last.gif";

//                    break;
//            }

//        }
//    }
//    #endregion

//    private ListControl fGetPagerDDL(GridView pGridView)
//    {
//        // Retrieve the pager row.
//        GridViewRow lGridViewRow = pGridView.BottomPagerRow;
//        return (ListControl)lGridViewRow.Cells[0].FindControl(mddlName);
//    }
//    #endregion

//    #region "fAddSortIcon - Using SQLdatasource"
//    /// <summary>
//    /// Using SQLdatasource, 當用戶點選header of gridview時, column會有"上""下"的sorting icon.
//    /// </summary>
//    public void fAddSortIcon()
//    {
//        mGridView.RowDataBound += GridView_RowDataBound;
//    }


//    protected void GridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
//    {
//        GridView lGridView = mGridView;

//        if (e.Row.RowType == DataControlRowType.Header)
//        {
//            int liSelectedColumn = -1;
//            // 尋找按下的coloumn
//            foreach (DataControlField lField in lGridView.Columns)
//            {
//                if (lField.SortExpression == lGridView.SortExpression)
//                {
//                    liSelectedColumn = lGridView.Columns.IndexOf(lField);
//                    break; // TODO: might not be correct. Was : Exit For
//                }
//            }
//            // 設定icon
//            if (liSelectedColumn > -1 & lGridView.SortExpression != LIBWebBased.BLANK)
//            {
//                Label lblIcon = new Label();
//                var _with64 = lblIcon;
//                _with64.Font.Name = "Webdings";
//                _with64.Font.Size = FontUnit.Large;
//                _with64.ForeColor = System.Drawing.Color.OrangeRed;

//                if (lGridView.SortDirection == SortDirection.Ascending)
//                {
//                    lblIcon.Text = "5";
//                    lblIcon.ToolTip = mClsHashTableHelper.sGetHash("遞增排序");

//                }
//                else
//                {
//                    lblIcon.Text = "6";
//                    lblIcon.ToolTip = mClsHashTableHelper.sGetHash("遞減排序");
//                }

//                e.Row.Cells[liSelectedColumn].Controls.Add(lblIcon);
//            }
//        }
//    }
//    #endregion

//    #region "fAddAutoGeneratedColumn"

//    public void fAddAutoGeneratedColumn(LIBWebBased.DFunc3 pDFunc3sGetCellURLCode = null)
//    {
//        mDFunc3sGetCellURLCode = pDFunc3sGetCellURLCode;

//        mGridView.RowDataBound += GridView_RowDataBoundAutoGeneratedColumn;
//        mGridView.DataBound += GridView_DataBoundAutoGeneratedColumn;
//    }


//    protected void GridView_RowDataBoundAutoGeneratedColumn(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
//    {
//        switch (miGridViewType)
//        {
//            case enGridViewType.DynamicReportWithAutoGeneratedColumn:
//            case enGridViewType.DynamicReportWithAutoGeneratedColumnWithOutTotal:

//                fGridViewDynamicReportHideUselessColumn(e);
//                if (mbHighLightMaximumColumn)
//                {
//                    nsCommon.mCommon.fGridViewDynamicReportHighLightMaxColumnCell(e, mGridView);
//                }
//                nsCommon.mCommon.fGridViewAutoColumnSetNumberFieldFormat(e, mGridView);

//                break;
//            case enGridViewType.DetailReportWithAutoGeneratedColumn:
//            case enGridViewType.DetailReportWithAutoGeneratedColumnWithNoHeader:
//                nsCommon.mCommon.fGridViewAutoColumnSetNumberFieldFormat(e, mGridView);

//                break;
//            case enGridViewType.DetailReportWithAutoGeneratedColumnWithNoHeaderAndNoFormat:

//                break;
//        }

//    }


//    protected void GridView_DataBoundAutoGeneratedColumn(object sender, System.EventArgs e)
//    {
//        switch (miGridViewType)
//        {
//            case enGridViewType.DynamicReportWithAutoGeneratedColumn:
//            case enGridViewType.DynamicReportWithAutoGeneratedColumnWithOutTotal:
//                if (mbHideEmptyColumn)
//                {
//                    nsCommon.mCommon.fGridViewDynamicInvisibleColumnWihEmptyAll(mGridView);
//                }
//                BuildGridDynamicReportHeaderFooter(mGridView, mDDLRowOption, mDDLColumnOption, mDFunc3sGetCellURLCode);

//                break;
//            case enGridViewType.DetailReportWithAutoGeneratedColumn:
//                BuildGridDetailReportHeader(mGridView);

//                break;
//        }

//    }

//    /// <summary>
//    /// DynamicReport, Hide columns ID,RowHeader,Sort1,Sort2 ,only fit for stp_wf_rss_GridStardardReportRowColumnDynamic
//    /// </summary>
//    public void fGridViewDynamicReportHideUselessColumn(System.Web.UI.WebControls.GridViewRowEventArgs e)
//    {
//        try
//        {
//            e.Row.Cells[1].Visible = false;
//            //ID
//            e.Row.Cells[2].Visible = false;
//            //RowHeader

//            switch (miGridViewType)
//            {
//                case enGridViewType.DynamicReportWithAutoGeneratedColumn:
//                    e.Row.Cells[e.Row.Cells.Count - 3].Visible = false;
//                    //Sort1
//                    e.Row.Cells[e.Row.Cells.Count - 2].Visible = false;
//                    //Sort2
//                    break;

//                case enGridViewType.DynamicReportWithAutoGeneratedColumnWithOutTotal:
//                    e.Row.Cells[e.Row.Cells.Count - 4].Visible = false;
//                    //All
//                    e.Row.Cells[e.Row.Cells.Count - 3].Visible = false;
//                    //Sort1
//                    e.Row.Cells[e.Row.Cells.Count - 2].Visible = false;
//                    //Sort2
//                    e.Row.Cells[e.Row.Cells.Count - 1].Visible = false;
//                    //% of All
//                    break;
//            }

//        }
//        catch (Exception ex)
//        {
//        }
//    }

//    /// <summary>
//    /// DynamicReport
//    /// </summary>
//    private object BuildGridDynamicReportHeaderFooter(GridView pGridview, ListControl pDDLRowOption, ListControl pDDLColumnOption, LIBWebBased.DFunc3 pDFunc3sGetCellURLCode)
//    {
//        object functionReturnValue = null;

//        if (pDDLColumnOption == null | pDDLColumnOption == null)
//        {
//            return functionReturnValue;
//        }
//        ClassGridViewHelper lClassGridViewHelperFooter = new ClassGridViewHelper();
//        lClassGridViewHelperFooter.SetGridView(pGridview);
//        ClassGridViewHelper lClsGridViewHelperHeader = new ClassGridViewHelper();
//        lClsGridViewHelperHeader.SetGridView(pGridview);

//        Hashtable lHashtable = nsCommon.mCommon.sGetDynamicHeaderHashTable(pDDLColumnOption);
//        DataTable lDataTable = nsCommon.mCommon.fGridviewGetDataTable(pGridview);

//        int liColCount = 0;
//        string lsFooterDesc = LIBWebBased.BLANK;
//        string lsHeaderDesc = LIBWebBased.BLANK;

//        foreach (GridViewRow lGridViewRow in pGridview.Rows)
//        {
//            // Use header base on valid value in row All
//            // Should build header and footer first, as the text is still pure number.
//            if (lGridViewRow.Cells[0].Text == "All")
//            {
//                for (int i = 0; i <= lGridViewRow.Cells.Count - 1; i++)
//                {
//                    if (lGridViewRow.Cells[i].Text != LIBWebBased.BLANK | mbHideEmptyColumn == false)
//                    {
//                        string lsColumnHeader = lDataTable.Columns[i].Caption.ToString();

//                        switch (i)
//                        {
//                            case 0:
//                                // 自定第一列標題
//                                if (pDDLRowOption == null)
//                                {
//                                }
//                                else
//                                {
//                                    lsHeaderDesc = pDDLRowOption.SelectedItem.Text + " \\ " + pDDLColumnOption.SelectedItem.Text;
//                                    lsFooterDesc = pDDLColumnOption.SelectedItem.Text + "% VS All";
//                                }

//                                break;
//                            case lGridViewRow.Cells.Count - 1:
//                                lsFooterDesc = LIBWebBased.BLANK;
//                                // 因STP計算有時會有小數, 所以寫死100.00
//                                lGridViewRow.Cells[i].Text = "100.00";
//                                lsHeaderDesc = nsCommon.mCommon.sGetHash(lHashtable, lsColumnHeader);

//                                break;
//                            default:

//                                lsFooterDesc = nsCommon.mCommon.sPercentage(lGridViewRow.Cells[i].Text, lGridViewRow.Cells[lGridViewRow.Cells.Count - 4].Text);
//                                lsHeaderDesc = nsCommon.mCommon.sGetHash(lHashtable, lsColumnHeader);

//                                if (pDDLColumnOption.SelectedValue == "ByP12Month")
//                                {
//                                    try
//                                    {
//                                        // format轉換- 將P1M 轉為 May 2006
//                                        lsHeaderDesc = nsDateTime.mDataTime.sMonthDescByYearMonthCalculation(this.mDDLYear.SelectedValue, this.mDDLMonth.SelectedValue, nsDateTime.mDataTime.iYearAdjustment(lsColumnHeader));
//                                    }
//                                    catch (Exception ex)
//                                    {
//                                        lsHeaderDesc = nsCommon.mCommon.sGetHash(lHashtable, lsColumnHeader);
//                                    }
//                                }
//                                break;
//                        }
//                        if (i == 0)
//                        {
//                        }

//                        lClsGridViewHelperHeader.fAddMasterColumn(lsHeaderDesc);
//                        lClassGridViewHelperFooter.fAddMasterColumn(lsFooterDesc);

//                        liColCount += 1;
//                    }
//                }

//                // Must remove from last to front, as the index update after remove

//                switch (miGridViewType)
//                {
//                    case enGridViewType.DynamicReportWithAutoGeneratedColumn:
//                        lClsGridViewHelperHeader.RemoveAt(liColCount - 2);
//                        lClsGridViewHelperHeader.RemoveAt(liColCount - 3);

//                        lClassGridViewHelperFooter.RemoveAt(liColCount - 2);
//                        lClassGridViewHelperFooter.RemoveAt(liColCount - 3);

//                        break;
//                    case enGridViewType.DynamicReportWithAutoGeneratedColumnWithOutTotal:
//                        lClsGridViewHelperHeader.RemoveAt(liColCount - 1);
//                        lClsGridViewHelperHeader.RemoveAt(liColCount - 2);
//                        lClsGridViewHelperHeader.RemoveAt(liColCount - 3);
//                        lClsGridViewHelperHeader.RemoveAt(liColCount - 4);

//                        lClassGridViewHelperFooter.RemoveAt(liColCount - 1);
//                        lClassGridViewHelperFooter.RemoveAt(liColCount - 2);
//                        lClassGridViewHelperFooter.RemoveAt(liColCount - 3);
//                        lClassGridViewHelperFooter.RemoveAt(liColCount - 4);

//                        break;
//                }
//                lClsGridViewHelperHeader.RemoveAt(2);
//                lClsGridViewHelperHeader.RemoveAt(1);

//                lClassGridViewHelperFooter.RemoveAt(2);
//                lClassGridViewHelperFooter.RemoveAt(1);

//            }

//            // Add URL property to data field. .text will contain many HTML code.
//            string lsRowHeader = lGridViewRow.Cells[1].Text;
//            for (int i = 0; i <= lGridViewRow.Cells.Count - 1; i++)
//            {
//                string lsColumnHeader = lDataTable.Columns[i].Caption.ToString();
//                if (Information.IsNumeric(lGridViewRow.Cells[i].Text))
//                {
//                    if (lsColumnHeader == "% of All")
//                    {
//                    }
//                    else
//                    {
//                        lGridViewRow.Cells[i].Text = pDFunc3sGetCellURLCode(lsRowHeader, lsColumnHeader, lGridViewRow.Cells[i].Text);
//                    }
//                }
//            }
//        }

//        // Finally Add Footer and Header to Grid
//        lClassGridViewHelperFooter.fAddExtraDataRow();
//        lClsGridViewHelperHeader.fAddExtraMasterHeaderRow();

//        return null;
//        return functionReturnValue;

//    }

//    // seem no use

//    private void AddTotalRow(GridView pGridview, ClassLoadFieldHelper pClsLoadFieldHelper)
//    {
//        var _with65 = pClsLoadFieldHelper;

//        ClassGridViewHelper lClassGridViewHelper = new ClassGridViewHelper();
//        var _with66 = lClassGridViewHelper;
//        _with66.SetGridView(pGridview);

//        _with66.fAddMasterColumn("", 1);

//        _with66.fAddMasterColumn(nsCommon.mCommon.sPercentage(1, 2));

//        _with66.fAddExtraDataRow();


//    }

//    /// <summary>
//    /// DetailReport
//    /// </summary>
//    private object BuildGridDetailReportHeader(GridView pGridview)
//    {

//        ClassGridViewHelper lClsGridViewHelperHeader = new ClassGridViewHelper();
//        lClsGridViewHelperHeader.SetGridView(pGridview);

//        Hashtable lHashtable = LIBWebBased.GlobalClassHashTableHelper.mHashtable;
//        DataTable lDataTable = nsCommon.mCommon.fGridviewGetDataTable(pGridview);

//        int liColCount = 0;
//        string lsHeaderDesc = LIBWebBased.BLANK;
//        bool lbBuildHeader = false;

//        foreach (GridViewRow lGridViewRow in pGridview.Rows)
//        {
//            if (lbBuildHeader == true)
//                break; // TODO: might not be correct. Was : Exit For

//            if (lGridViewRow.RowType == DataControlRowType.DataRow)
//            {
//                for (int i = 0; i <= lGridViewRow.Cells.Count - 1; i++)
//                {
//                    if (lGridViewRow.Cells[i].Visible == true)
//                    {
//                        string lsColumnHeader = lDataTable.Columns[i].Caption.ToString();
//                        lsHeaderDesc = nsCommon.mCommon.sGetHash(lHashtable, lsColumnHeader);
//                        lClsGridViewHelperHeader.fAddMasterColumn(lsHeaderDesc);
//                    }

//                    liColCount += 1;
//                }

//                lbBuildHeader = true;
//            }
//        }

//        lClsGridViewHelperHeader.fAddExtraMasterHeaderRow();

//        return null;

//    }
//    #endregion

//    #region "fAddSortMethod - Using Databind"
//    /// <summary>
//    /// Using Databind
//    /// Can handle extra header rebuild
//    /// </summary>
//    public void fAddSortMethod(LIBWebBased.DFunc0 pObject, LIBWebBased.DFunc0 pObject2BuildGridHeader = null)
//    {
//        mDFunc0FillGridView = pObject;
//        mDFunc0BuildGridHeader = pObject2BuildGridHeader;
//        mGridView.Sorting += GridView_Sorting;
//    }

//    protected void GridView_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
//    {
//        mDFunc0FillGridView();
//        fGridViewAddSortingMethod(mGridView, e, mSortLabel);

//        // rebuild Grid Header
//        if (mDFunc0BuildGridHeader == null)
//        {
//        }
//        else
//        {
//            mDFunc0BuildGridHeader();
//        }
//    }

//    /// <summary>
//    /// Use this function in GridView.Sorting
//    /// Add Icon and Tooltips
//    /// </summary>
//    private void fGridViewAddSortingMethod(GridView pGridview, System.Web.UI.WebControls.GridViewSortEventArgs e, Label llblSorting)
//    {
//        // f2 - Set Sorting direction
//        bool lbAscSorting = false;
//        if (llblSorting.Text.IndexOf("Desc") > -1)
//        {
//            llblSorting.Text = e.SortExpression + " " + "Asc";
//            lbAscSorting = true;
//        }
//        else
//        {
//            llblSorting.Text = e.SortExpression + " " + "Desc";
//            lbAscSorting = false;
//        }

//        // f3 - Set Sort Icon
//        foreach (DataControlField lDataGridColumn in pGridview.Columns)
//        {
//            //Clear any <img> tags that might be present
//            lDataGridColumn.HeaderText = Regex.Replace(lDataGridColumn.HeaderText, "\\s<.*>", string.Empty);

//            if (lDataGridColumn.SortExpression == e.SortExpression)
//            {
//                if (lbAscSorting)
//                {
//                    lDataGridColumn.HeaderText += " <img src=\"img/Col_up.gif\" border=\"0\" title=\"" + mClsHashTableHelper.sGetHash("遞增排序") + "\">";
//                }
//                else
//                {
//                    lDataGridColumn.HeaderText += " <img src=\"img/Col_down.gif\" border=\"0\" title=\"" + mClsHashTableHelper.sGetHash("遞減排序") + "\">";
//                }

//                try
//                {
//                    // use try catch to handle non lBoundField control
//                    //Dim bb As String = lDataGridColumn.GetType.ToString()
//                    System.Web.UI.WebControls.BoundField lBoundField = null;
//                    lBoundField = lDataGridColumn;
//                    lBoundField.HtmlEncode = false;

//                }
//                catch (Exception ex)
//                {
//                }
//            }
//        }

//        // dont work when add icon on autogenerated column
//        //Dim lDataTable As DataTable = nsCommon.fGridviewGetDataTable(pGridview)
//        //Dim lGridViewRow As GridViewRow = pGridview.Rows(0)
//        //For i As Integer = 0 To lGridViewRow.Cells.Count - 1
//        //    Dim lsColumnHeader As String = lDataTable.Columns(i).Caption.ToString
//        //    If lsColumnHeader = e.SortExpression Then
//        //        lGridViewRow.Cells(i).Text = " <img src=""img/Col_up.gif"" border=""0"">"
//        //    End If
//        //Next

//        // f4 - Sorting
//        SortingGrid(pGridview, llblSorting);

//    }

//    #endregion

//    #region "fAddPaging - Using Databind"
//    /// <summary>
//    /// Using Databind
//    /// </summary>
//    public void fAddPageIndexChangingMethod(LIBWebBased.DFunc0 pObject)
//    {
//        mDFunc0FillGridView = pObject;
//        mGridView.PageIndexChanging += GridView_PageIndexChanging;
//    }

//    protected void GridView_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
//    {
//        mGridView.PageIndex = e.NewPageIndex;
//        if (mGridView.AllowPaging)
//        {
//            mDFunc0FillGridView();
//            SortingGrid(mGridView, mSortLabel);
//        }
//    }

//    #endregion

//    private void SortingGrid(GridView pGridView, Label llblSorting)
//    {
//        DataView lDataView = null;
//        string lDataSourceType = pGridView.DataSource.GetType().ToString();

//        switch (lDataSourceType)
//        {
//            case "System.Data.DataSet":
//                System.Data.DataSet lDataSet = pGridView.DataSource;
//                lDataView = lDataSet.Tables[0].DefaultView;
//                break;
//            case "System.Data.DataTable":
//                DataTable lDataTable = pGridView.DataSource;
//                lDataView = lDataTable.DefaultView;
//                break;
//            case "System.Collections.ArrayList":
//                lDataView = null;

//                break;
//            default:
//                lDataView = pGridView.DataSource;

//                break;
//        }


//        if (lDataView == null)
//        {
//        }
//        else
//        {
//            lDataView.Sort = llblSorting.Text;
//            pGridView.DataSource = lDataView;
//            pGridView.DataBind();
//        }
//    }

//}

//interface IGridViewHelper
//{
//    void SetSortLabel(Label pLabel);
//    void SetGridView(GridView pGridView);
//    void fAddSortMethod(LIBWebBased.DFunc0 pObject, LIBWebBased.DFunc0 pObject2BuildGridHeader = null);
//    void fAddPageIndexChangingMethod(LIBWebBased.DFunc0 pObject);
//}

//#endregion

//// Last tidy up: 20120229
//#region "ClassSQLExecuteHelper"
///// <summary>
///// used to execute the SQL query
///// </summary>
//public class ClassSQLExecuteHelper
//{
//    private ArrayList msSQLArraylist = new ArrayList();

//    DbConnection mDbConnection;
//    /// <summary>
//    /// Add SQL into this class
//    /// </summary>
//    public void AddSQL(string psSQLString)
//    {
//        if (psSQLString != LIBWebBased.BLANK)
//        {
//            msSQLArraylist.Add(psSQLString);
//        }
//        else
//        {
//            //  Call MsgBoxOkOnly("It is Blank SQL.")
//            Debug.Print("ClassSQLExecuteHelper - AddSQL() It is Blank SQL");
//        }
//    }

//    /// <summary>
//    /// Set the connection of this class to database,if you do not set,the default is gcnOLEDBHIS
//    /// </summary>
//    public void SetConnection(object pConnectionObject)
//    {
//        mDbConnection = pConnectionObject;
//    }

//    /// <summary>
//    /// Execute all the SQL you added into this class.(execute all or nothing)
//    /// </summary>
//    public bool bExecute()
//    {
//        bool functionReturnValue = false;
//        functionReturnValue = false;

//        if (mDbConnection == null)
//        {
//            mDbConnection = nsSQL.mSQL.NewDBConnection();
//        }

//        try
//        {
//            nsSQL.mSQL.bCheckDBConnection(mDbConnection);

//            DbCommand lDBCommand = mDbConnection.CreateCommand();

//            using (lDBCommand)
//            {
//                try
//                {
//                    // Begin Transaction
//                    lDBCommand.Transaction = mDbConnection.BeginTransaction();

//                    for (int liSQL = 0; liSQL <= msSQLArraylist.Count - 1; liSQL++)
//                    {
//                        lDBCommand.CommandText = msSQLArraylist[liSQL];
//                        lDBCommand.ExecuteNonQuery();
//                        functionReturnValue = true;
//                    }

//                    lDBCommand.Transaction.Commit();

//                }
//                catch (Exception ex)
//                {
//                    lDBCommand.Transaction.Rollback();
//                    functionReturnValue = false;
//                }
//            }

//        }
//        catch (Exception Err)
//        {
//            functionReturnValue = false;
//        }
//        finally
//        {
//            mDbConnection.Close();
//        }
//        return functionReturnValue;
//    }
//}
//#endregion

//// Last tidy up: 20120229
//#region "ClassSQLSaveHelper"
///// <summary>
///// Build Update, Insert,Delete  Query, Old Style, Change to use Parameter(ClassLoadFieldHelper)
///// </summary>
//public class ClassSQLSaveHelper
//{

//    public string TableName = LIBWebBased.BLANK;
//    public string SQLExtraSelect = LIBWebBased.BLANK;

//    public string SQLExtraCriteria = LIBWebBased.BLANK;
//    private ArrayList SearchKeyNames = new ArrayList();

//    private ArrayList SearchKeyValues = new ArrayList();
//    private ArrayList FieldNames = new ArrayList();
//    private ArrayList Fields = new ArrayList();

//    private ArrayList FieldUniCodes = new ArrayList();
//    public void AddSearchKey(string psSearchKeyName, string psSearchKeyValue)
//    {
//        // AddSearchKey -) add criteria fields (eg : where XXX = YYY)

//        this.SearchKeyNames.Add(psSearchKeyName);
//        this.SearchKeyValues.Add(psSearchKeyValue);

//    }

//    public void AddField(string psSQLFieldName, object psSaveValue, bool pbChineseField = false)
//    {
//        // AddField -) Field that we want to make change in Database (insert / update)

//        psSaveValue = UpdateNull(psSaveValue);
//        this.FieldNames.Add(psSQLFieldName);
//        this.Fields.Add(psSaveValue);
//        this.FieldUniCodes.Add(pbChineseField);

//    }

//    #region "3 SQL type"

//    public string sGenerateSQLInsert()
//    {
//        string functionReturnValue = null;
//        // will change to sAddFullRecordClass

//        functionReturnValue = LIBWebBased.BLANK;

//        // Initialize the return flag to false.

//        string lsSQL = null;
//        // Final SQL statement for record insertion
//        string lsSQLselect = null;
//        // SQL statement for Selection part
//        string lsSQLUpdate = null;
//        // Fields of table for SQL record insertion
//        short liNumOfFields = 0;
//        // Counter for looping the insertion field name

//        // Prepare SQL statement.
//        lsSQLselect = "Insert into " + this.TableName + " ";
//        lsSQLUpdate = "(";

//        //Construct the fields required for record insertion
//        for (liNumOfFields = 0; liNumOfFields <= this.FieldNames.Count - 1; liNumOfFields++)
//        {
//            if (this.FieldNames[liNumOfFields] != LIBWebBased.BLANK)
//            {
//                if (lsSQLUpdate != "(")
//                    lsSQLUpdate += ", ";
//                lsSQLUpdate += this.FieldNames[liNumOfFields];
//            }
//        }

//        lsSQLUpdate += ") ";
//        lsSQLUpdate += "values (";

//        //Construct the fields values for record insertion
//        for (liNumOfFields = 0; liNumOfFields <= this.FieldNames.Count - 1; liNumOfFields++)
//        {
//            if (this.FieldNames[liNumOfFields] != LIBWebBased.BLANK)
//            {
//                if (liNumOfFields > 0)
//                    lsSQLUpdate += ", ";

//                if (this.FieldUniCodes[liNumOfFields] == true & nsSQL.mSQL.bHasValue(this.Fields[liNumOfFields]))
//                {
//                    lsSQLUpdate += "N" + LIBWebBased.VarSQLString(this.Fields[liNumOfFields]);
//                }
//                else
//                {
//                    lsSQLUpdate += LIBWebBased.VarSQLString(this.Fields[liNumOfFields]);
//                }
//            }
//        }

//        lsSQLUpdate += ") ";

//        // Display error messsage when no condition was specified.
//        if (Strings.Trim(lsSQLUpdate) == "() values ()")
//        {
//            Interaction.MsgBox("No condition specified in SQL", MsgBoxStyle.OkOnly, "Record Creation Error");
//            return functionReturnValue;
//        }

//        // Construct the full SQL statement.
//        lsSQL = lsSQLselect + lsSQLUpdate;


//        functionReturnValue = lsSQL;
//        return functionReturnValue;

//    }

//    public string sGenerateSQLDelete()
//    {
//        string functionReturnValue = null;
//        // will change to  sDeleteFullRecordClass

//        functionReturnValue = LIBWebBased.BLANK;

//        string lsSQL = null;
//        // Final SQL statement for record deletion
//        string lsSQLselect = null;
//        // SQL statement for Selection part
//        string lsSQLCriteria = null;
//        // Deletion criteria

//        short liNumOfKeys = 0;
//        // Number of fields required for deletion

//        // Constructing the SQL statement for record deletion.
//        lsSQLselect = "Delete from " + this.TableName + " ";
//        lsSQLCriteria = "Where ";

//        for (liNumOfKeys = 0; liNumOfKeys <= this.SearchKeyNames.Count - 1; liNumOfKeys++)
//        {
//            if (liNumOfKeys > 0)
//                lsSQLCriteria = lsSQLCriteria + "and ";
//            lsSQLCriteria = lsSQLCriteria + this.SearchKeyNames[liNumOfKeys] + " = " + LIBWebBased.VarSQLString(this.SearchKeyValues[liNumOfKeys]) + " ";
//        }
//        //End If

//        // Construct for the extra SQL statment of Where clause.
//        if (this.SQLExtraCriteria != LIBWebBased.BLANK)
//        {
//            lsSQLCriteria = lsSQLCriteria + "and " + this.SQLExtraCriteria + " ";
//        }

//        // Display error message when no condition for record deletion.
//        if (Strings.Trim(lsSQLCriteria) == "Where ")
//        {
//            Interaction.MsgBox("No condition specified in SQL", MsgBoxStyle.OkOnly, "Record Deletion Error");
//            return functionReturnValue;
//        }

//        // Construct the completed SQL statement
//        lsSQL = lsSQLselect + lsSQLCriteria;

//        functionReturnValue = lsSQL;
//        return functionReturnValue;

//    }

//    public string sGenerateSQLUpdate()
//    {
//        string functionReturnValue = null;
//        // will change to  sUpdateFullRecordClass
//        functionReturnValue = LIBWebBased.BLANK;

//        string lsSQL = null;
//        // Final SQL statement for update
//        string lsSQLselect = LIBWebBased.BLANK;
//        // SQL statement for selection part
//        string lsSQLUpdate = null;
//        // SQL statement for "Set" update fields.
//        string lsSQLCriteria = null;
//        short liNumOfFields = 0;
//        short liNumOfKeys = 0;

//        //Construct SQL statement for update
//        lsSQLselect = lsSQLselect + "Update " + this.TableName + " ";

//        lsSQLUpdate = "Set ";

//        // Construct the number of fields required to update on lsSQLUpdate string

//        for (liNumOfFields = 0; liNumOfFields <= this.FieldNames.Count - 1; liNumOfFields++)
//        {

//            if (this.FieldNames[liNumOfFields] != LIBWebBased.BLANK)
//            {
//                if (lsSQLUpdate != "Set ")
//                    lsSQLUpdate += ", ";
//                if (this.FieldUniCodes[liNumOfFields] == true & nsSQL.mSQL.oHandleDBNull(this.Fields[liNumOfFields]).ToString() != LIBWebBased.BLANK)
//                {
//                    lsSQLUpdate += this.FieldNames[liNumOfFields] + " = N" + LIBWebBased.VarSQLString(this.Fields[liNumOfFields]) + " ";
//                }
//                else
//                {
//                    lsSQLUpdate += this.FieldNames[liNumOfFields] + " = " + LIBWebBased.VarSQLString(this.Fields[liNumOfFields]) + " ";
//                }
//            }
//        }

//        // Display the error message when no condition was selected for update
//        if (Strings.Trim(lsSQLUpdate) == "Set")
//        {
//            Interaction.MsgBox("No criteria specified in SQL", MsgBoxStyle.OkOnly, "Update Full Record");
//            return functionReturnValue;
//        }

//        //Construct where clause for the SQL data manipulation
//        lsSQLCriteria = "Where ";

//        for (liNumOfKeys = 0; liNumOfKeys <= this.SearchKeyNames.Count - 1; liNumOfKeys++)
//        {
//            if (liNumOfKeys > 0)
//                lsSQLCriteria = lsSQLCriteria + "and ";
//            lsSQLCriteria = lsSQLCriteria + this.SearchKeyNames[liNumOfKeys] + " = " + LIBWebBased.VarSQLString(this.SearchKeyValues[liNumOfKeys]) + " ";
//        }
//        //End If

//        // Construct for the SQL extra criteria condition
//        if (this.SQLExtraCriteria != LIBWebBased.BLANK)
//        {
//            lsSQLCriteria = lsSQLCriteria + "and " + this.SQLExtraCriteria + " ";
//        }

//        if (Strings.Trim(lsSQLCriteria) == "Where")
//        {
//            Interaction.MsgBox("No criteria specified in SQL", MsgBoxStyle.OkOnly, "Update Error");
//            return functionReturnValue;
//        }

//        // Construct the final SQL statement.
//        lsSQL = lsSQLselect + lsSQLUpdate + lsSQLCriteria;

//        functionReturnValue = lsSQL;
//        return functionReturnValue;

//    }

//    private object UpdateNull(object pObject)
//    {
//        // 2010-04-19 - I guess to handle insert blank to number.
//        if (object.ReferenceEquals(pObject, System.DBNull.Value))
//        {
//            return System.DBNull.Value;
//        }
//        else
//        {
//            if (Strings.Trim(pObject) == LIBWebBased.BLANK)
//            {
//                return System.DBNull.Value;
//            }
//            else
//            {
//                return pObject;
//            }
//        }
//    }
//    #endregion

//}
//#endregion

//// Last tidy up: 20120229
//#region "ClassSQLLoadHelper"
///// <summary>
///// Build Select Query, Old Style, Change to use Parameter(ClassLoadFieldHelper)
///// </summary>
//public class ClassSQLLoadHelper
//{
//    // class record loading
//    public string SQLString = LIBWebBased.BLANK;

//    public string TableName = LIBWebBased.BLANK;
//    public string SQLExtraSelect = LIBWebBased.BLANK;

//    public string SQLExtraCriteria = LIBWebBased.BLANK;
//    public string SQLOrder = LIBWebBased.BLANK;

//    public string SQLGroupBy = LIBWebBased.BLANK;

//    private ArrayList RequiredFields = new ArrayList();
//    /// <summary>
//    /// Field name that we want to select
//    /// </summary>
//    /// <param name="psSQLFieldName">Name of the SQLField.</param>
//    public void AddRequiredField(string psSQLFieldName)
//    {
//        // AddRequiredField -) 
//        this.RequiredFields.Add(psSQLFieldName);
//    }

//    /// <summary>
//    /// Generate select SQL
//    /// </summary>
//    public string sGenerateSQLSelect()
//    {
//        string functionReturnValue = null;
//        functionReturnValue = LIBWebBased.BLANK;
//        string lsSQLSelect = null;
//        // SQL statement for Selection part
//        string lsSQLCriteria = null;
//        // SQL criteria
//        string lsSQLOrder = null;
//        // SQL ordering sequence

//        short liNumReqFields = 0;
//        // Counter for the number of fields
//        string lsFieldsRequired = LIBWebBased.BLANK;
//        // Fields of table for SQL statement

//        // Constructing the SQL statement for record retrieval fields.
//        for (liNumReqFields = 0; liNumReqFields <= this.RequiredFields.Count - 1; liNumReqFields++)
//        {
//            if (liNumReqFields > 0)
//            {
//                lsFieldsRequired += ", ";
//            }
//            lsFieldsRequired += this.RequiredFields[liNumReqFields];
//        }

//        // Construct SQL statement with using retrieval fields variable lsFieldsRequired.
//        lsSQLSelect = "Select " + lsFieldsRequired + " From " + this.TableName + " ";
//        // Construct SQL statement with extra SQL select statement.
//        if (this.SQLExtraSelect != LIBWebBased.BLANK)
//        {
//            lsSQLSelect += this.SQLExtraSelect + " ";
//        }

//        // Initialize the SQL Criteria to [Where].
//        lsSQLCriteria = "Where ";

//        //Construct SQL extra criteria statement.
//        if (this.SQLExtraCriteria != LIBWebBased.BLANK)
//        {
//            if (Strings.Trim(lsSQLCriteria) != "Where")
//            {
//                lsSQLCriteria += "and ";
//            }
//            lsSQLCriteria += this.SQLExtraCriteria + " ";
//        }

//        //Remove the  [Where] in lsSQLCriteria when there is no filtering condition.
//        if (Strings.Trim(lsSQLCriteria) == "Where")
//        {
//            lsSQLCriteria = LIBWebBased.BLANK;
//        }

//        lsSQLOrder = LIBWebBased.BLANK;
//        // Construct Group by SQL statement. (Avoid of using this)
//        if (Strings.Trim(this.SQLGroupBy) != LIBWebBased.BLANK)
//        {
//            lsSQLOrder = " Group by " + this.SQLGroupBy;
//        }

//        // Construct Order by SQL statement.
//        if (Strings.Trim(this.SQLOrder) != LIBWebBased.BLANK)
//        {
//            lsSQLOrder += " Order by " + this.SQLOrder;
//        }

//        //Final SQL statement construction.
//        this.SQLString = lsSQLSelect + lsSQLCriteria + lsSQLOrder;

//        functionReturnValue = this.SQLString;
//        return functionReturnValue;

//    }

//}
//#endregion



//// Last tidy up: 20120229
//#region "ClassFileUploadHelper"
//public class ClassFileUploadHelper
//{
//    private string msAttachmentFolderLoad = "/Attachment/";
//    private string msAttachmentFolderSave = "/Attachment/";
//    public delegate void DSub3InsertAttachment(string psItemID, string psFileDesc, string psFilePath);

//    private Page mPage;
//    private FileUpload mFileUpload;

//    private ClassHashTableHelper mClsHashTableHelper = LIBWebBased.GlobalClassHashTableHelper;
//    public void SetAttachmentFolderLoad(string psAttachmentFolder)
//    {
//        this.msAttachmentFolderLoad = "/" + psAttachmentFolder;
//    }

//    public void SetAttachmentFolderSave(string psAttachmentFolder)
//    {
//        this.msAttachmentFolderSave = "/" + psAttachmentFolder;
//    }

//    public void SetPage(System.Web.UI.TemplateControl pMe)
//    {
//        mPage = pMe;
//    }

//    public void SetFileUpload(FileUpload pFileUpload)
//    {
//        mFileUpload = pFileUpload;
//    }

//    private bool bVerifyFile()
//    {
//        if (mFileUpload.FileName.ToLower().Contains(".exe"))
//        {
//            nsScript.mScript.Alert(mPage, mClsHashTableHelper.sGetHash("檔案格式不正確"), false);
//            return false;

//        }
//        if (mFileUpload.FileBytes.Length > miFileMaxSizeInMB() * 1024 * 1024 | mFileUpload.FileBytes.Length == 0)
//        {
//            nsScript.mScript.Alert(mPage, mClsHashTableHelper.sGetHash("檔案大小不能超過4MB"), false);
//            return false;
//        }
//        else
//        {
//            if (mFileUpload.FileName.Length > 100)
//            {
//                nsScript.mScript.Alert(mPage, mClsHashTableHelper.sGetHash("檔案名稱不能超過100字"), false);
//                return false;
//            }
//            else
//            {
//                if (mFileUpload.HasFile)
//                {
//                    return true;
//                }
//            }
//        }

//        return false;
//    }

//    private int miFileMaxSizeInMB()
//    {
//        int liFileSize = 4;

//        try
//        {
//            if (LIBWebBased.gsFileMaxSizeInMB != LIBWebBased.BLANK)
//            {
//                liFileSize = Convert.ToInt32(LIBWebBased.gsFileMaxSizeInMB);
//            }
//            return liFileSize;
//        }
//        catch (Exception ex)
//        {
//            return 4;
//        }
//    }

//    /// <summary>
//    /// Upload File To Server and return file path 
//    /// File path is not full path, eg:"/Attachment/abc.txt".
//    /// </summary>
//    /// <param name="psItemID"></param>
//    /// <returns>File Name</returns>
//    /// <remarks></remarks>
//    public string sUploadFileToServerAndReturnFilePath(string psItemID)
//    {
//        string lsFileName = sFileName(mFileUpload.FileName, psItemID);

//        lsFileName = lsFileName.Replace(".INH", ".txt");
//        lsFileName = lsFileName.Replace(".inh", ".txt");
//        int liCounterHeader = 0;
//        string lsSaveFileName = lsFileName;
//        string lsSaveFileSQLPath = sFileWithFolderPath(lsSaveFileName);
//        string lsSaveFileRealPath = sFileRealPath(lsSaveFileSQLPath);

//        // f1 - prevent duplicated filename
//        while (File.Exists(lsSaveFileRealPath))
//        {
//            lsSaveFileName = sDuplicatedFileName(lsFileName, liCounterHeader);
//            lsSaveFileSQLPath = sFileWithFolderPath(lsSaveFileName);
//            lsSaveFileRealPath = sFileRealPath(lsSaveFileSQLPath);

//            liCounterHeader += 1;
//        }

//        // f3 - Handle no Folder problem.
//        string lsFileFolder = sFileRealPath(sFileWithFolderPath(LIBWebBased.BLANK));
//        if (Directory.Exists(lsFileFolder))
//        {
//        }
//        else
//        {
//            Directory.CreateDirectory(lsFileFolder);
//        }

//        // f4 - save file into server Folder.
//        mFileUpload.SaveAs(lsSaveFileRealPath);

//        if (this.msAttachmentFolderLoad != this.msAttachmentFolderSave)
//        {
//            lsSaveFileSQLPath = lsSaveFileSQLPath.Replace(msAttachmentFolderSave, LIBWebBased.BLANK);
//        }

//        return lsSaveFileSQLPath;
//    }

//    #region "Special Handling For Excel"
//    public System.Data.DataSet fUploadFileFromExcelToDataset(string psItemID)
//    {

//        if (bVerifyFile())
//        {
//            string lsSaveFileSQLPath = sUploadFileToServerAndReturnFilePath(psItemID);

//            string lsRealPath = this.sFileRealPath(lsSaveFileSQLPath);
//            System.Data.DataSet lDataSet = nsImport.mImport.sImportExcelToDataSet(lsRealPath);

//            File.Delete(lsRealPath);

//            return lDataSet;

//        }
//        return null;
//    }

//    #endregion

//    #region "Special Handling For LCR"
//    public void fSpecial_UploadFile(string psItemID, string psFileType, SmartTextbox pFileDesc)
//    {
//        if (bVerifyFile())
//        {
//            string lsSaveFileSQLPath = sUploadFileToServerAndReturnFilePath(psItemID);

//            // f2 - isnert record into database.
//            fSpecial_InsertAttachment(psItemID, pFileDesc.Text, lsSaveFileSQLPath, psFileType);

//            pFileDesc.Text = LIBWebBased.BLANK;

//            nsScript.mScript.RefreshParentPage(mPage, true);
//        }
//    }

//    private void fSpecial_InsertAttachment(string psItemID, string psFileDesc, string psFilePath, string psFileType)
//    {
//        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//        var _with67 = ClsLoadFieldHelper;
//        _with67.fAddSqlParameter("@Item_ID", psItemID);
//        _with67.fAddSqlParameter("@File_Desc", psFileDesc);
//        _with67.fAddSqlParameter("@File_Path", psFilePath);
//        _with67.fAddSqlParameter("@stp_Result", LIBWebBased.gsSTPResult, true);
//        _with67.fAddSqlParameter("@File_Type", psFileType);

//        _with67.fBuildDataSet("stp_wf_all_Special_InsertAttachment");
//    }

//    public void fSpecial_LoadAttachmentInfo(string psItemID, string psFileType, HyperLink pHyperLink)
//    {
//        string lsFilePath = LIBWebBased.BLANK;
//        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//        var _with68 = ClsLoadFieldHelper;
//        _with68.fAddSqlParameter("@ItemID", psItemID);
//        _with68.fAddSqlParameter("@File_Type", psFileType);
//        _with68.fBuildDataSet("stp_wf_all_Special_LoadAttachmentInfo");
//        if (_with68.mbDataSetHasRecord)
//        {
//            pHyperLink.ToolTip = _with68.oLoadSqlField("File_Desc");
//            lsFilePath = _with68.oLoadSqlField("File_Path");
//            pHyperLink.NavigateUrl = "~" + lsFilePath;
//            pHyperLink.Text = sGetShortFilePath(lsFilePath);
//        }
//    }

//    public void fSpecial_DeleteAttachmentInfo(string psItemID, string psFileType, HyperLink pHyperLink)
//    {
//        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//        var _with69 = ClsLoadFieldHelper;
//        _with69.fAddSqlParameter("@Item_ID", psItemID);
//        _with69.fAddSqlParameter("@File_Type", psFileType);
//        _with69.fBuildDataSet("stp_wf_all_Special_DeleteAttachment");

//        fRemoveFile(pHyperLink.NavigateUrl);
//        pHyperLink.ToolTip = LIBWebBased.BLANK;
//        pHyperLink.NavigateUrl = LIBWebBased.BLANK;
//        pHyperLink.Text = LIBWebBased.BLANK;


//    }
//    #endregion

//    /// <summary>
//    /// Standard attachment template for each e-flow
//    /// </summary>
//    /// <param name="psItemID"></param>
//    /// <param name="pFileDesc"></param>
//    /// <param name="pDSub3InsertAttachment">function to insert record into Database</param>
//    /// <param name="pbNeedRedirect"></param>
//    /// <remarks></remarks>
//    public void fUpLoadFile(string psItemID, SmartTextbox pFileDesc, DSub3InsertAttachment pDSub3InsertAttachment, bool pbNeedRedirect = true)
//    {

//        if (bVerifyFile())
//        {
//            string lsSaveFileSQLPath = sUploadFileToServerAndReturnFilePath(psItemID);

//            // f2 - isnert record into database.
//            pDSub3InsertAttachment(psItemID, pFileDesc.Text, lsSaveFileSQLPath);

//            pFileDesc.Text = LIBWebBased.BLANK;

//            // f5 - handle F5 problem.
//            if (pbNeedRedirect)
//            {
//                nsScript.mScript.RefreshThePage(mPage);
//                // mMe.Response.Redirect(Me.msRedirectHeader & psItemID & Me.msRedirectFooter, True)
//            }
//        }
//    }

//    public string sUploadFileAndGetPath(string psItemID)
//    {

//        if (bVerifyFile())
//        {
//            string lsSaveFileSQLPath = sUploadFileToServerAndReturnFilePath(psItemID);
//            return lsSaveFileSQLPath;

//        }
//        else
//        {
//            return LIBWebBased.BLANK;
//        }
//        return LIBWebBased.BLANK;

//    }

//    public void fChangeFileName(string psOrgFilePath, string psDesFilePath)
//    {
//        string lsOrgFilePath = sFileRealPath(psOrgFilePath);
//        string lsDesFilePath = sFileRealPath(psDesFilePath);

//        if (File.Exists(lsOrgFilePath))
//        {
//            File.Move(lsOrgFilePath, lsDesFilePath);
//            File.Delete(lsOrgFilePath);
//        }
//    }

//    public void fRemoveFile(string psFilePath)
//    {
//        string lsFileMapPath = sFileRealPath(psFilePath);
//        if (File.Exists(lsFileMapPath))
//        {
//            File.Delete(lsFileMapPath);
//        }
//    }

//    public string sGetShortFilePath(string psLongFilePath)
//    {

//        try
//        {
//            return psLongFilePath.Substring(psLongFilePath.LastIndexOf("-") + 1);

//        }
//        catch (Exception ex)
//        {
//            return LIBWebBased.BLANK;
//        }
//    }

//    public string sFileRealPath(string psFilePath)
//    {
//        psFilePath = sRemoveFolder(psFilePath);

//        string lsFolder = HttpContext.Current.Request.MapPath("~" + msAttachmentFolderSave);
//        return lsFolder + psFilePath;
//    }

//    public string sFileWithFolderPath(object psFileName)
//    {

//        psFileName = nsSQL.mSQL.oHandleNullAndNothing(psFileName);
//        psFileName = sRemoveFolder(psFileName);
//        psFileName = msAttachmentFolderSave + psFileName;
//        return psFileName;
//    }

//    private string sRemoveFolder(string psFileName)
//    {
//        psFileName = psFileName.Replace(msAttachmentFolderSave, LIBWebBased.BLANK);
//        psFileName = psFileName.Replace("~", LIBWebBased.BLANK);
//        psFileName = psFileName.Replace("//", "/");
//        return psFileName;
//    }

//    private string sFileName(string psFileName, string psItemNo)
//    {
//        return psItemNo + "_" + psFileName;
//    }

//    private string sDuplicatedFileName(string psFileName, string psNumber)
//    {
//        return psFileName.Replace(".", "_" + psNumber + ".");
//    }
//}
//#endregion

//public class MyPage : Page
//{


//    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
//    {
//    }
//}