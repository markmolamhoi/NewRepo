//using Microsoft.VisualBasic;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Data;
//using System.Diagnostics;
//using UserControlLibrary.Lamsoon;
//using AjaxControlToolkit;
//using System.Configuration;
//using System.Data.Common;
//using System.Data.SqlClient;
//using System.IO;
//using System.Text.RegularExpressions;
//using System.Web;
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

//// Imports Microsoft.SqlServer.Dts.Runtime

////LIBWebBased.vb is a Code library.
//// 設計原理:
//// Simple - simple to use.
//// Reuse - easy to reuse.
//// Maintain - good to maintain

//// ns = shortForm of Namespace
//// g = shortform of Gobal
//// m = shortform of Module
//// l = shortform of local
//// p = shortform of PassIn

////i - integer
////s - string
////ds - dataset
////grd - GridView
////o - object
////f - function

////For File namimg
////PC - Page Control  - design for single project
////UC - User Control  - design for all system.

//// Coding design logic
//// 3 layers - Common Function1 > Class > Core Function2
//// Function1 can handle most common case
//// Class handle some special case, if it becomes common, I will code it into Function1.
//// Function2 is a sub function in Class, which is seldom use directly.
//// Class name start with ClassXXX - Group related function together for easily call and maintain
//// namespace called nsClass - Can use everywhere. Easy to use. only 1 code can finish the task.

////update log
////2011-05-12 - Tidy up the nscommon's function
////   ForeColor       >ForeColorWhenZero
////   TranslateDDL    >fListControlTranslateDDL
////   DeleteRecord    >fDeleteRecord
////   bExitsGridRow   >bExistGridRow
////   fVisibleSwitchOtherTxt  >fTextBoxVisibleWhenOther
////   fInvisibleWhenBlank     >fTextBoxInvisibleWhenBlank
////   SetDeleteRecordButton   >fButtonSetDeleteRecordProperty
////   New     >sMoney - Add remove Zero property
////   New     >sRemoveZero
////   New     >fStringToYesNo
////   Remove  >sShowTextWhenHasData
////2011-05-17 
////   New     >BindDDLAccountYear
////   New     >bIsKeyField
////   Remove  >fButtonSetRefreshParentPage
////   Update  >BuildHashTable
////20110601
////   Update  >LoadSqlField, handle old data case.
////   Update  >gsProjectCode, get from web.config, can use as library
////   New     >bWorkflowSendEmail, can send to multi emails and cc to owner.
////   New     >InsertWorkflowEmailLog, change to standard format.
////20110610
////   New     >fCheckBoxListGetSelectedString, display multi checkbox in gridview.
////   New     >bSetControlMoney, set money format and aligh right
////20110613
////   New     >gsShowNotUsedHashKey, for development use
////20110616   
////   Update  >sChineseDateTime
////   New     >fHyperLinkInvisibleWhenBlank
////20110623
////   New     >nsLSVersion, sHandleLoginPage to handle to merge with LamSoon other project.
////   New     >UserControlLibrary2010
////   New     >BindDDLYesNo
////20110624
////   Update  >fUpLoadFile, handle all page without passing any name again.
////20110627
////   New     >sCompanyRegistrationPlace
////20110628
////   New     >sCompanyCategory
////20110630
////   Update  >nsSQL.oHandleNullAndNothing(pDate).ToString
////   Update  >sGetStaffEmail, handle ","
////20110704   
////   New     >fButtonSetCollapseDisplay  添加/隱藏Button
////   New     >fControlSetVisible  
////20110708
////   New     >giLineColor
////20110713
////   New     >BindDDLCity
////   New     >BindDDLCityProvince
////   Update  >BindListControl, Fixed the bug >if bind no data, DDL will use the last dataset.
////   Update  >Auto set All when 沒有資料.
////20110714
////   New     >fGridViewGetSelectedValueList
////   New     >fGridViewSetCheckBoxAll
////20110715
////   New     >sToNumber -->handle if not number, then return 0
////20110718
////   Update  >If Nothing, return Blank.
////   New     >bValidJDESupplierCode
////20110719
////   New     >WriteArraylistToFile
////20110720
////   New     >fGridViewSetColumnSpan
////   New     >fGridViewSetRowSpan
////20110722
////   New     >Add ClsHashTableHelper = GlobalClassHashTableHelper to fixed the null bug.
////20110726
////   Update  >giLineColor -->Add up to 46 color
////   New     >sNumberF2
////20110727
////   Update  >fAddSqlParameter ->handle Checkbox
////   Update  >bClearControl ->handle Checkbox
////   New     >fCheckBox1TrueThen2False > Checkbox 1 true then chk2 false
////20110728
////   New     >sSQLDateFormatInNumber
////20110802   
////   New     >sCombineString
////   New     >sCheckBoxGetStringWhenTrue
////20110804
////   New     >fCheckBoxListGetSelectedValueListWithSeparator
////20110808   
////   Update  >giLineColor
////20110809   
////   New     >ModeDisplay
////20110816
////   New     >fGridViewSetCommandArgument
////20110818   
////   New     >AlertDBNoRecord
////   New     >AlertCannotBlank
////20110823
////   Update  >fAddSqlParameter when nothing, then DBNull
////   New     >sToNumberWithNothing
////   New     >LoadSqlFieldIntoGridViewRow   突破
////   New     >fAddSqlParameterFromGridViewRow
////   New     >SetGridViewRow
////20110824
////   Update  >LoadSqlField
////20110825
////   update  >Tidy the code
////   update  >Merge BindDDL and BindlistControl
////   Add     >getApproverList, use to handle upgrade usercontrollibrary
////20110907   
////   Add     >fAddMasterColumnHeader
////20110909  
////   update  >fAddMasterColumnHeader
////   update  >fGridViewSetHeader dynamic set sort expression
////   Update  >enDropDownListType add other type
////   New     >SetDateRangeByYearTypeByYear
////20110915   
////   New     >sRemoveZero2
////20110916
////   Update  >datepicker lControl.Mode = "Textbox"
////   Update  >fAddSqlParameterFromGridViewRow > add try catch, remove useless code
////   Update  >LoadSqlFieldIntoGridViewRow Handle Display mode
////   New     >sPercentage
////   New     >sNumber, sNumberBase, sMoneyBase
////   New     >fAddExtraDataRow
////   New     >ForeColorToRedWhenOverLimit
////20110920   
////   New     >AlertNoAccessRight
////20110923
////   New     >sAddQueryParameter
////20110926
////   New     >fGridViewSetAllColumnWidth
////20110927
////   New     >sSetDateLastYTD,sSetDateThisYTD,sSetDateCurrentMonth,sGetLastDayOfThisMonth,sSetDate12Month
////   New     >AddProjectFunctionAccessRight
////20111003
////   New     >bCheck24HourFormat
////20111004
////   Update  >sGetYearYTD add return value
////20111006
////   New     >sCombineString, sYTDEnd, sYTDEndByYear, sYTDStart, sYTDStartByYear, sYTDYear
////20111013
////   New     >SetControlValue
////   Update  >sPercentage
////20111020
////   New     >BindDDLMonth
////   New     >ForeColorOfPercentageChange
////   New     >sToYTDMonth
////20111025
////   New     >ForeColorToRedWhenOverZero
////20111026
////   New     >sCalendarYearStart
////20111027
////   New     >DatePicker property: lControl.Clearable = True
////20111031
////   New     >iRowCount
////20111102
////   New     >BindDDLCustomerCat
////   Update  >ClsHashTableHelper : Set To optional, nothing then use GlobalClsHashTableHelper
////   Update  >sToYTDMonth Fixed bug : if 6 , will show 0.
////   Update  >sYTDYearDisplayFormat
////20111104
////   Update  >fGridViewAddSortingMethod, to handle Dataset, DataTable, DefaultView
////20111110
////   New     >GridView_PageIndexChanging
////20111111
////   New     >ExportToExcelMaster handle Remove sorting and paging
////20111111
////   New     >BindDDLRegionByStaff, BindDDLProvinceByStaff, BindDDLCityByStaff, BindDDL3DivisionByStaff, BindDDLFullDivisionByStaff
////20111117
////   New     >sYearHeader, sYearMonthHeader, BindDDLProductCat
////   Update  >ExportToExcel
////20111122   
////   Update  >BindDDLYear add 1 year for forecast
////   New     >s5YearHeader
////20111202
////   New     >iRowCountDesc
////   New     >SetDataTable
////20111206
////   New     >sURLHTML
////20111213
////   New     >PageLoginLog, PageFunctionLog, PageFunctionLogByPage
////   New     >msStoreProcedureName ClassSqlParameterHelper
////   New     >fBindGridView
////   New     >fPrintSqlParameterList
////20120103
////   Update  >BindDDLYear    
////20120104
////   New     >StreamToByte,ByteToStream,ArraylistToFullText
////20120109
////   New     >AddFunctionAccessRightByFunctionName
////20120119
////   New     >fCheckBoxListSetSelectByArraylist
////20120127   
////   Update  >BindDDLYear, add display format
////20120130
////   New     >ChartHio
////20120212
////   New     >add BuildGridHeader after sorting of gridview
////20120216
////   New     >bExistItemCode2, bExistCustomerCode
////20120223
////   New     >Add mHashTable in ClassLoadFieldHelper
////20120228
////   New     >AutoDisable gridview sorting in ExportToExcelMaster
////   New     >Auto set HtmlEncode for BoundField
////20120229
////   New     >bSetGridViewForPrinting
////20120306
////   New     >ClassSqlParameterHelperBase using property
////20120307
////   New     >Add SortingGrid in gridviewHelper, fix page index cannot sort bug
////20120314
////   New     >No need to pass control to get Request anymore
////   Update  >gsHashTableStpName, gsUserName, gslang, gsUserNameCookie, fBindControls, fCheckLoginName
////20120315
////   New     >gsUserNameCookie, GlobalClassHashTableHelper, gsUserName, gslang
////   Update  >cPageCheckLogin, cPageLoadHelper_GuocoWeb, ClassPageLoadHelper, ClassHashTableHelper, ClassSqlParameterHelper
////20120327
////   Update  >handle remove file
////20120419   
////   New     >LSLIBWebBased.dll, Source code in vss LSWFRSS.root folder
////20120430   
////   Update  Optional DDLType
////20120608
////   Add     >load and Save handle SmartCheckboxList, fCheckBoxListGetSelectedValues
////20120618
////   Add     >DebugPrint
////           >fGridviewGetDataTable, fGridviewGetDataView, fGridViewDynamicInvisibleColumnWihEmptyTotal
////           >fCheckboxlistUnselect
////20120620
////   Add     >sGetDynamicHeaderHashTable
////20120704
////   Add     >Add Translation in SetControlValue
////20120831
////   Remove  >fAddExtraMasterHeaderRow remove mGridView.EnableViewState = False
////20121008   
////   Add     >sGetLastDateOfMonth
////20130204
////   Add     >fDataGridSetDeleteReminder
////20130207
////   Add     >ExportToPDF
////           >Handle auto login
////20130221   
////   Add     >ExportToOffice
////           >SetHighLightMaximumColumn
////20130308
////   Add     >SetDateRangeByRowColumnOption
////20130411
////   Add     >sObjectToHTML
////20130503
////   Add     >ExecuteBatchInASPDotNetUsingCMD
////20130606   
////   Add     >Add handle for checkbox > bSetControlDisplay,SetControlValue

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


//    public static void ExportToExcel2007(GridView psGridView, Page pPage,LIBWebBased.DFunc0 pDFunc0)
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

//    public static void ExportToExcelMaster(object pControl, Page pPage, LIBWebBased.DFunc0 pDFunc0, enOfficeType penOfficeType = enOfficeType.Excel, string psFileName = BLANK)
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
//    public static void ExportToOfficeMaster(object pControl, Page pPage, LIBWebBased.DFunc0 pDFunc0, enOfficeType penOfficeType = enOfficeType.Excel, string psFileName = BLANK)
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

//namespace nsImport
//{
//    public static class mImport
//    {
//        public static System.Data.DataSet sImportExcelToDataSet(string psFilepath, string psSheetName = "Sheet1")
//        {
//            string sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + psFilepath + ";" + "Extended Properties=Excel 8.0;";

//            // Create the connection object by using the preceding connection string.
//            OleDbConnection objConn = new OleDbConnection(sConnectionString);

//            // Open connection with the database.
//            objConn.Open();

//            string lsFirstSheetName = LIBWebBased.BLANK;

//            try
//            {
//                DataTable lExcelDataTable = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
//                lsFirstSheetName = lExcelDataTable.Rows[0]["TABLE_NAME"].ToString();

//            }
//            catch (Exception ex)
//            {
//            }

//            if (lsFirstSheetName == LIBWebBased.BLANK)
//            {
//                lsFirstSheetName = psSheetName + "$";
//            }

//            // The code to follow uses a SQL SELECT command to display the data from the worksheet.
//            // Create new OleDbCommand to return data from worksheet.
//            OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [" + lsFirstSheetName + "]", objConn);

//            // Create new OleDbDataAdapter that is used to build a DataSet
//            // based on the preceding SQL SELECT statement.
//            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();

//            // Pass the Select command to the adapter.
//            objAdapter1.SelectCommand = objCmdSelect;

//            // Create new DataSet to hold information from the worksheet.
//            System.Data.DataSet objDataset1 = new System.Data.DataSet();

//            // Fill the DataSet with the information from the worksheet.
//            objAdapter1.Fill(objDataset1, "XLData");

//            objConn.Close();

//            return objDataset1;
//            // Build a table from the original data.
//            //DataGrid1.DataSource = objDataset1.Tables(0).DefaultView
//            //DataGrid1.DataBind()

//        }
//    }
//}

//namespace nsExport
//{
//    public static class mExport
//    {
//        private static string OS(string Word)
//        {
//            int i = Word.IndexOf(".");
//            while (i > -1)
//            {
//                Word = Word.Remove(i, 1);
//                i = Word.IndexOf(".");
//            }
//            return Word;
//        }

//        public static void ExportExcel(DataTable Table, string Location = "test123.xls")
//        {
//            string lsFolder = HttpContext.Current.Request.MapPath("~") + "\\";
//            Location = lsFolder + Location;


//            string lsTableName = "TestingTable";
//            if (LIBWebBased.MyComputer.FileSystem.FileExists(Location))
//                LIBWebBased.MyComputer.FileSystem.DeleteFile(Location);
//            string CreateString = "";
//            string Columns = "";
//            string Mark = "";
//            using (System.Data.OleDb.OleDbConnection Connection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Location + ";Extended Properties=\"Excel 8.0;HDR=YES\""))
//            {
//                Connection.Open();
//                CreateString = "CREATE TABLE [" + lsTableName + "] (";
//                Columns = "(";
//                Mark = "(";
//                foreach (DataColumn Column in Table.Columns)
//                {
//                    CreateString += OS(Column.ColumnName);
//                    switch (Column.DataType.Name)
//                    {
//                        case "SByte":
//                        case "Byte":
//                        case "Int16":
//                        case "Int32":
//                        case "Int64":
//                        case "Decimal":
//                        case "Double":
//                        case "Single":
//                            CreateString += " Number, ";
//                            break;
//                        case "Boolean":
//                            CreateString += " Bit, ";
//                            break;
//                        case "Char":
//                        case "String":
//                            CreateString += " Memo, ";
//                            break;
//                        case "DateTime":
//                            CreateString += " DateTime, ";
//                            break;
//                        default:
//                            CreateString += " Text, ";
//                            break;
//                    }
//                    Columns += OS(Column.ColumnName) + ", ";
//                    Mark += "?,";
//                }
//                CreateString = CreateString.Remove(CreateString.Length - 2, 2);
//                CreateString += ")";
//                Columns = Columns.Remove(Columns.Length - 2, 2);
//                Columns += ")";
//                Mark = Mark.Remove(Mark.Length - 1, 1);
//                Mark += ")";
//                using (System.Data.OleDb.OleDbCommand Command = new System.Data.OleDb.OleDbCommand(CreateString.ToString(), Connection))
//                {
//                    Command.ExecuteNonQuery();
//                }
//                using (System.Data.OleDb.OleDbDataAdapter Adapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [" + lsTableName + "$]", Connection))
//                {
//                    using (System.Data.DataSet ExcelDataset = new System.Data.DataSet())
//                    {
//                        Adapter.Fill(ExcelDataset, lsTableName);
//                        Adapter.InsertCommand = new System.Data.OleDb.OleDbCommand("INSERT INTO [" + lsTableName + "] " + Columns.ToString() + " VALUES " + Mark.ToString(), Connection);
//                        foreach (DataColumn Column in Table.Columns)
//                        {
//                            switch (Column.DataType.Name)
//                            {
//                                case "SByte":
//                                case "Byte":
//                                case "Int16":
//                                case "Int32":
//                                case "Int64":
//                                case "Decimal":
//                                case "Double":
//                                case "Single":
//                                    Adapter.InsertCommand.Parameters.Add("@" + OS(Column.ColumnName), System.Data.OleDb.OleDbType.Numeric, 100, OS(Column.ColumnName));
//                                    break;
//                                case "Boolean":
//                                    Adapter.InsertCommand.Parameters.Add("@" + OS(Column.ColumnName), System.Data.OleDb.OleDbType.Boolean, 100, OS(Column.ColumnName));
//                                    break;
//                                case "Char":
//                                case "String":
//                                    Adapter.InsertCommand.Parameters.Add("@" + OS(Column.ColumnName), System.Data.OleDb.OleDbType.Char, 65536, OS(Column.ColumnName));
//                                    break;
//                                case "DateTime":
//                                    Adapter.InsertCommand.Parameters.Add("@" + OS(Column.ColumnName), System.Data.OleDb.OleDbType.DBTimeStamp, 100, OS(Column.ColumnName));
//                                    break;
//                                default:
//                                    Adapter.InsertCommand.Parameters.Add("@" + OS(Column.ColumnName), System.Data.OleDb.OleDbType.Char, 65536, OS(Column.ColumnName));
//                                    break;
//                            }
//                        }
//                        foreach (DataRow Row in Table.Rows)
//                        {
//                            if (Row.RowState != DataRowState.Deleted)
//                            {
//                                DataRow ExcelRow = ExcelDataset.Tables[lsTableName].NewRow();
//                                for (int i = 0; i <= Table.Columns.Count - 1; i++)
//                                {
//                                    ExcelRow[i] = Row[i];
//                                }
//                                ExcelDataset.Tables[lsTableName].Rows.Add(ExcelRow);
//                            }
//                        }
//                        Adapter.Update(ExcelDataset, lsTableName);
//                    }
//                }
//            }
//        }

//        public static void ExportXML(DataTable Table, string Location = "test123.xml")
//        {
//            string lsFolder = HttpContext.Current.Request.MapPath("~") + "\\";
//            Location = lsFolder + Location;

//            using (System.Xml.XmlTextWriter Writer = new System.Xml.XmlTextWriter(Location, System.Text.Encoding.UTF8))
//            {
//                Writer.WriteStartDocument();
//                Table.WriteXml(Writer, XmlWriteMode.WriteSchema);
//                Writer.WriteEndDocument();
//                Writer.Close();
//            }
//        }

//        public static void ExportHTML(DataTable Table, string Location = "test123.html")
//        {
//            string lsFolder = HttpContext.Current.Request.MapPath("~") + "\\";
//            Location = lsFolder + Location;

//            using (System.IO.StreamWriter Writer = new System.IO.StreamWriter(Location))
//            {
//                Writer.WriteLine("<HTML>");
//                Writer.WriteLine(" <HEAD>");
//                Writer.WriteLine("  <meta http-equiv='Content-Type' content='text/html; charset=utf-8'>");
//                Writer.WriteLine(" </HEAD>");
//                Writer.WriteLine(" <BODY>");
//                Writer.WriteLine("<TABLE border='1'>");
//                Writer.WriteLine(" <TR>");
//                foreach (DataColumn Column in Table.Columns)
//                {
//                    Writer.WriteLine("  <TD>" + Column.ColumnName + "</td>");
//                }
//                Writer.WriteLine(" </TR>");
//                foreach (DataRow Row in Table.Rows)
//                {
//                    Writer.WriteLine(" <TR>");
//                    foreach (DataColumn Column in Table.Columns)
//                    {
//                        Writer.WriteLine("  <TD>" + Row[Column].ToString() + "</TD>");
//                    }
//                    Writer.WriteLine(" </TR>");
//                }
//                Writer.WriteLine("</TABLE>");
//                Writer.WriteLine(" </BODY>");
//                Writer.WriteLine("</HTML>");
//            }
//        }

//        public static void ExportText(DataTable Table, string Location = "test123.txt")
//        {
//            string lsFolder = HttpContext.Current.Request.MapPath("~") + "\\";
//            Location = lsFolder + Location;

//            using (System.IO.StreamWriter Writer = new System.IO.StreamWriter(Location, false, System.Text.Encoding.UTF8))
//            {
//                Writer.WriteLine("Executed: " + DateTime.Now.ToString());
//                for (int i = 0; i <= 99; i++)
//                {
//                    Writer.Write("*");
//                }
//                Writer.WriteLine("");
//                foreach (DataColumn Column in Table.Columns)
//                {
//                    Writer.WriteLine("");
//                    Writer.WriteLine(Column.ColumnName);
//                    for (int i = 0; i <= 99; i++)
//                    {
//                        Writer.Write("-");
//                    }
//                    Writer.WriteLine("");
//                    foreach (DataRow Row in Table.Rows)
//                    {
//                        Writer.WriteLine(Row[Column].ToString());
//                    }
//                }
//                for (int i = 0; i <= 99; i++)
//                {
//                    Writer.Write("*");
//                }
//                Writer.Close();
//            }
//        }

//        public static void ExportCSV(DataTable Table, string Location = "test123.csv")
//        {
//            string lsFolder = HttpContext.Current.Request.MapPath("~") + "\\";
//            Location = lsFolder + Location;

//            using (System.IO.StreamWriter Writer = new System.IO.StreamWriter(Location, false, System.Text.Encoding.UTF8))
//            {
//                foreach (DataColumn Column in Table.Columns)
//                {
//                    Writer.Write(Column.ColumnName);
//                    if (Column.Ordinal + 1 < Table.Columns.Count)
//                        Writer.Write(",");
//                }
//                Writer.WriteLine("");
//                foreach (DataRow Row in Table.Rows)
//                {
//                    foreach (DataColumn Column in Table.Columns)
//                    {
//                        if (object.ReferenceEquals(Row[Column].GetType(), typeof(DateTime)))
//                        {
//                            Writer.Write(((DateTime)Row[Column]).ToString(LIBWebBased.MyComputer.Info.InstalledUICulture.DateTimeFormat.SortableDateTimePattern));
//                        }
//                        else
//                        {
//                            string Value = Row[Column].ToString();
//                            if (Value.Contains("\r"))
//                            {
//                                Writer.Write(Strings.Chr(34) + Row[Column].ToString() + Strings.Chr(34));
//                            }
//                            else
//                            {
//                                Writer.Write(Row[Column].ToString());
//                            }
//                        }
//                        if (Column.Ordinal + 1 < Table.Columns.Count)
//                            Writer.Write(",");
//                    }
//                    Writer.WriteLine();
//                }
//                Writer.Close();
//            }
//        }
//    }
//}

//// Last tidy up: 20130603
//namespace nsDateTime
//{
//    public static class mDataTime
//    {

//        /// <summary>
//        /// Not useful at all, only return YTD / LYTD
//        /// remove LIBWebBased.enYearMonthHeaderType in future
//        /// </summary>
//        public static string sYTDDesc(LIBWebBased.enYearMonthHeaderType psType)
//        {
//            switch (psType)
//            {
//                case LIBWebBased.enYearMonthHeaderType.P0YTD:
//                case LIBWebBased.enYearMonthHeaderType.P0YTDF:
//                case LIBWebBased.enYearMonthHeaderType.P0YTDB:
//                    return "YTD";
//                case LIBWebBased.enYearMonthHeaderType.P1YTD:
//                    return "LYTD";
//            }
//            return "";
//        }

//        /// <summary>
//        /// get Year number using iYearAdjustment eg : 12/13 
//        /// </summary>
//        public static string s5YearDesc(string psYear, string psAdjectNYear)
//        {
//            return mDataTime.sYTDYearDisplayFormat(s5YearValue(psYear, psAdjectNYear));
//        }

//        /// <summary>
//        /// </summary>
//        public static string s5YearValue(string psYear, string psAdjectNYear)
//        {
//            return psYear + iYearAdjustment(psAdjectNYear);
//        }

//        /// <summary>
//        /// </summary>
//        public static int iYearAdjustment(string psAdjectNYear)
//        {
//            int liNumber = 0;

//            switch (psAdjectNYear)
//            {
//                case LIBWebBased.enYearMonthHeaderType.P12M.ToString:
//                    liNumber = -12;
//                    break;
//                case LIBWebBased.enYearMonthHeaderType.P11M.ToString:
//                    liNumber = -11;
//                    break;
//                case LIBWebBased.enYearMonthHeaderType.P10M.ToString:
//                    liNumber = -10;
//                    break;
//                case LIBWebBased.enYearMonthHeaderType.P9M.ToString:
//                    liNumber = -9;
//                    break;
//                case LIBWebBased.enYearMonthHeaderType.P8M.ToString:
//                    liNumber = -8;
//                    break;
//                case LIBWebBased.enYearMonthHeaderType.P7M.ToString:
//                    liNumber = -7;
//                    break;
//                case LIBWebBased.enYearMonthHeaderType.P6M.ToString:
//                    liNumber = -6;
//                    break;
//                case LIBWebBased.enYearMonthHeaderType.P5M.ToString:
//                    liNumber = -5;
//                    break;
//                case LIBWebBased.enYearMonthHeaderType.P4M.ToString:
//                    liNumber = -4;
//                    break;
//                case LIBWebBased.enYearMonthHeaderType.P3M.ToString:
//                    liNumber = -3;
//                    break;
//                case "P1M":
//                    liNumber = -1;
//                    break;
//                case "P0M":
//                    liNumber = 0;
//                    break;
//                case LIBWebBased.enYearMonthHeaderType.P2M.ToString:
//                    liNumber = -2;
//                    break;
//                case LIBWebBased.enYearMonthHeaderType.P4M:
//                    liNumber = -4;
//                    break;
//                case LIBWebBased.enYearMonthHeaderType.P3M:
//                    liNumber = -3;
//                    break;
//                case LIBWebBased.enYearMonthHeaderType.P2M:
//                    liNumber = -2;
//                    break;
//                case LIBWebBased.enYearMonthHeaderType.P1M:
//                    liNumber = -1;
//                    break;
//                case LIBWebBased.enYearMonthHeaderType.P0M:
//                    liNumber = 0;
//                    break;
//                default:
//                    liNumber = psAdjectNYear;
//                    break;
//            }


//            return liNumber;
//        }

//        #region "Year Month psAdjustNMonth calculation related"
//        /// <summary>
//        /// get Month description using dtYearMonthCalculation
//        /// </summary>
//        public static string sMonthDescByYearMonthCalculation(int psYear, int psMonth, int psAdjustNMonth)
//        {
//            return dtYearMonthCalculation(psYear, psMonth, psAdjustNMonth).ToString("MMM yy");
//        }

//        /// <summary>
//        /// get Month value using dtYearMonthCalculation
//        /// </summary>
//        public static int sMonthValueByYearMonthCalculation(int psYear, int psMonth, int psAdjustNMonth)
//        {
//            return DateAndTime.Month(dtYearMonthCalculation(psYear, psMonth, psAdjustNMonth));
//        }

//        /// <summary>
//        /// get Year value using dtYearMonthCalculation
//        /// </summary>
//        public static int sYearValueByYearMonthCalculation(int psYear, int psMonth, int psAdjustNMonth)
//        {
//            return DateAndTime.Year(dtYearMonthCalculation(psYear, psMonth, psAdjustNMonth));
//        }

//        /// <summary>
//        /// Calculate Date by Year by Month and psAdjustNMonth
//        /// </summary>
//        private static System.DateTime dtYearMonthCalculation(int psYear, int psMonth, int psAdjustNMonth)
//        {
//            System.DateTime lDate = DateAndTime.DateAdd(DateInterval.Month, psAdjustNMonth, Convert.ToDateTime(psYear + "/" + psMonth + "/" + "01"));
//            return lDate;
//        }

//        #endregion


//        #region "24 Hours 0000-2400 calculation related"
//        /// <summary>
//        /// eg: 0000 - 2400
//        /// </summary>
//        public static bool bCheck24HourFormat(string psValue)
//        {
//            if (string.IsNullOrEmpty(psValue))
//            {
//                return false;
//            }
//            else
//            {
//                if (Strings.Len(Strings.Trim(psValue)) != 4)
//                {
//                    return false;

//                }
//                else if (!Information.IsNumeric(psValue))
//                {
//                    return false;

//                }
//                else if (psValue >= 2400 | psValue < 0)
//                {
//                    return false;

//                }
//                else if (Strings.Right(psValue, 2) >= 60)
//                {
//                    return false;

//                }
//                else if (Strings.InStr(psValue, ".") != 0)
//                {
//                    return false;

//                }
//            }
//            return true;
//        }

//        /// <summary>
//        /// EndTime should > StartTime
//        /// </summary>
//        public static bool bCheck24HourFormatStartEndTime(string psStartTime, string psEndTime)
//        {
//            if (psStartTime - psEndTime >= 0)
//            {
//                return false;
//            }
//            else
//            {
//                return true;
//            }
//        }

//        /// <summary>
//        /// get NoOfMin between StartTime and EndTime
//        /// </summary>
//        public static string sGetMinsOf24HourFormatStartEndTime(string psStartTime, string psEndTime)
//        {
//            return (Strings.Left(psEndTime, 2) - Strings.Left(psStartTime, 2)) * 60 + Math.Floor((Strings.Right(psEndTime, 2) - Strings.Right(psStartTime, 2)));
//        }

//        #endregion

//        #region "Date translate YTD Calendar"
//        /// <summary>
//        /// get YTDMonth by CalendarMonth
//        /// </summary>
//        public static int sToYTDMonth(int psCalendarMonth)
//        {
//            psCalendarMonth = psCalendarMonth - 6;
//            if (psCalendarMonth <= 0)
//            {
//                psCalendarMonth = psCalendarMonth + 12;
//            }
//            return psCalendarMonth;
//        }

//        public static string sToCalendarMonth(string psYTDMonth)
//        {
//            psYTDMonth = psYTDMonth + 6;
//            if (psYTDMonth > 12)
//            {
//                psYTDMonth = psYTDMonth - 12;
//            }
//            return psYTDMonth;
//        }

//        /// <summary>
//        /// get YTDYear by CalendarYear, CalendarMonth
//        /// </summary>
//        public static int sToYTDYear(int psCalendarYear, int psCalendarMonth)
//        {
//            if (psCalendarMonth < 7)
//            {

//            }
//            else
//            {
//                psCalendarYear = psCalendarYear + 1;
//            }
//            return psCalendarYear;
//        }

//        public static int sToCalendarYear(int psYTDYear, int psYTDMonth)
//        {
//            if (psYTDMonth >= 7)
//            {

//            }
//            else
//            {
//                psYTDYear = psYTDYear - 1;
//            }
//            return psYTDYear;
//        }

//        #endregion

//        #region "Date set YTD Calender"
//        /// <summary>
//        /// get first YTD day by Date
//        /// </summary>
//        public static string sYTDStart(string psDate, int piPreviousNYear)
//        {
//            return sYTDStartByYear(sYTDYear(psDate), piPreviousNYear);
//        }

//        /// <summary>
//        /// get last YTD day by Date
//        /// </summary>
//        public static string sYTDEnd(string psDate, int piPreviousNYear)
//        {
//            return sYTDEndByYear(sYTDYear(psDate), piPreviousNYear);
//        }

//        /// <summary>
//        /// get first YTD day by YTDYear
//        /// </summary>
//        public static string sYTDStartByYear(string psYTDYear, int piPreviousNYear)
//        {
//            if (piPreviousNYear > 0)
//            {
//                piPreviousNYear = 0;
//            }
//            return (psYTDYear + piPreviousNYear).ToString() + "/07/01";
//        }

//        /// <summary>
//        /// get last YTD day by YTDYear, if cuurent year, sGetLastDayOfThisMonth
//        /// </summary>
//        public static string sYTDEndByYear(string psYTDYear, int piPreviousNYear)
//        {
//            if (piPreviousNYear > 0)
//            {
//                piPreviousNYear = 0;
//            }
//            psYTDYear = psYTDYear + piPreviousNYear;
//            if (psYTDYear == sYTDYear(DateAndTime.Now))
//            {
//                return mDataTime.sGetLastDayOfThisMonth();
//            }
//            else
//            {
//                return (psYTDYear + 1).ToString() + "/06/30";
//            }
//        }

//        /// <summary>
//        /// get first day of CalendarDate by Year
//        /// </summary>
//        public static string sCalendarYearStart(string psYear)
//        {
//            return psYear.ToString() + "/01/01";
//        }

//        /// <summary>
//        /// get last day of CalendarDate by Year
//        /// </summary>
//        public static string sCalendarYearEnd(string psYear)
//        {
//            return psYear.ToString() + "/12/31";
//        }

//        /// <summary>
//        /// get YTDYear by Date
//        /// </summary>
//        public static string sYTDYear(object psDateTime)
//        {
//            if (DateAndTime.Month(psDateTime) > 6)
//            {
//                return DateAndTime.Year(psDateTime);
//            }
//            else
//            {
//                return DateAndTime.Year(psDateTime) - 1;
//            }
//        }

//        /// <summary>
//        /// Set FromDate, ToDate as Last YTD
//        /// </summary>
//        public static void sSetDateLastYTD(ref string psFromDate, ref string psToDate)
//        {
//            mDataTime.sGetYTDStartYearAndSetFromTo(ref psFromDate, ref psToDate, -1);
//        }

//        /// <summary>
//        /// Set FromDate, ToDate as Current YTD
//        /// </summary>
//        public static void sSetDateThisYTD(ref string psFromDate, ref string psToDate)
//        {
//            mDataTime.sGetYTDStartYearAndSetFromTo(ref psFromDate, ref psToDate, 0);
//        }

//        public static string sGetYTDStartYearAndSetFromTo(ref string psDateFrom, ref string psDateTo, int piPreviousNYear = 0)
//        {
//            int liYear = DateAndTime.Year(DateAndTime.Now);
//            int liMonth = DateAndTime.Month(DateAndTime.Now);

//            DateTime lDate = DateAndTime.Now;
//            int liDateFrom = 0;
//            int liDateTo = 0;

//            string lsYTDStart = "/07/01";
//            string lsYTDEnd = "/06/30";

//            if (liMonth < 7)
//            {
//                liDateFrom = DateAndTime.Year(DateAndTime.DateAdd(DateInterval.Year, -1 + piPreviousNYear, lDate));
//            }
//            else
//            {
//                liDateFrom = DateAndTime.Year(DateAndTime.DateAdd(DateInterval.Year, 0 + piPreviousNYear, lDate));
//            }
//            liDateTo = liDateFrom + 1;

//            lsYTDStart = liDateFrom.ToString() + lsYTDStart;
//            lsYTDEnd = liDateTo.ToString() + lsYTDEnd;

//            if (piPreviousNYear == 0)
//            {
//                lsYTDEnd = mDataTime.sGetLastDayOfThisMonth();
//            }

//            psDateFrom = lsYTDStart.ToString();
//            psDateTo = lsYTDEnd.ToString();

//            return DateAndTime.Year(psDateFrom);
//        }

//        /// <summary>
//        /// Set FromDate, ToDate as Current Month
//        /// </summary>
//        public static void sSetDateCurrentMonth(ref string psFromDate, ref string psToDate)
//        {
//            System.DateTime lDate = System.DateTime.Now;
//            psToDate = mDataTime.sGetLastDayOfThisMonth();
//            psFromDate = Convert.ToString(lDate.Year) + "/" + Convert.ToString(lDate.Month) + "/01";
//        }

//        /// <summary>
//        /// get last day of Current Month
//        /// </summary>
//        public static string sGetLastDayOfThisMonth()
//        {
//            System.DateTime lDate = System.DateTime.Now;
//            return mDataTime.sSQLDateFormat(Convert.ToDateTime(Convert.ToString(lDate.Year) + "/" + Convert.ToString(lDate.Month) + "/01").AddMonths(1).AddDays(-1));
//        }

//        public static string sGetLastDateOfMonth(string psYear, string psMonth)
//        {
//            return mDataTime.sSQLDateFormat(Convert.ToDateTime(Convert.ToString(psYear) + "/" + Convert.ToString(psMonth) + "/01").AddMonths(1).AddDays(-1));
//        }

//        public static DateTime sGetFirstDateOfWeek(int piYear, int piWeekOfYear)
//        {
//            DateTime jan1 = new DateTime(piYear, 1, 1);
//            int daysOffset = Convert.ToInt32(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek) - Convert.ToInt32(jan1.DayOfWeek);
//            DateTime lFirstWeekDay = jan1.AddDays(daysOffset);
//            System.Globalization.CultureInfo curCulture = System.Globalization.CultureInfo.CurrentCulture;
//            int firstWeek = curCulture.Calendar.GetWeekOfYear(jan1, curCulture.DateTimeFormat.CalendarWeekRule, curCulture.DateTimeFormat.FirstDayOfWeek);
//            if (firstWeek <= 1)
//            {
//                piWeekOfYear -= 1;
//            }
//            return lFirstWeekDay.AddDays(piWeekOfYear * 7);
//        }
//        public static DateTime sGetLastDateOfWeek(int piYear, int piWeekOfYear)
//        {

//            return mDataTime.sGetFirstDateOfWeek(piYear, piWeekOfYear).AddDays(6);
//        }

//        /// <summary>
//        /// Set FromDate, ToDate as 12 Month
//        /// </summary>
//        public static void sSetDate12Month(ref string psFromDate, ref string psToDate)
//        {
//            System.DateTime toDate = System.DateTime.Now;
//            psToDate = mDataTime.sGetLastDayOfThisMonth();
//            if (DateAndTime.Month(toDate.Date) == 12)
//            {
//                psFromDate = Convert.ToString(toDate.Year) + "/01/01";
//            }
//            else
//            {
//                psFromDate = Convert.ToString(toDate.Year - 1) + "/" + Convert.ToString(toDate.Month + 1) + "/01";
//            }
//        }

//        #endregion

//        #region "Date/ year Display Format"
//        /// <summary>
//        /// get YTD Year Desciption, eg : 12/13 
//        /// , pbFullDescription : 2012/2013
//        /// </summary>
//        public static string sYTDYearDisplayFormat(string psYear, bool pbFullDescription = false)
//        {
//            if (pbFullDescription)
//            {
//                return psYear + "/" + psYear + 1;
//            }
//            else
//            {
//                return Strings.Right(psYear, 2) + "/" + Strings.Right(psYear + 1, 2);
//            }
//        }

//        public static string sChineseDateTime(object pDate)
//        {
//            if (nsSQL.mSQL.oHandleNullAndNothing(pDate).ToString() == LIBWebBased.BLANK)
//            {
//                return LIBWebBased.BLANK;
//            }
//            return Convert.ToDateTime(pDate).ToString("yyyy年MM月dd日 HH:mm:ss");
//        }

//        public static string sStandardDisplayDateTime(object pDate)
//        {
//            if (nsSQL.mSQL.oHandleNullAndNothing(pDate).ToString() == LIBWebBased.BLANK)
//            {
//                return LIBWebBased.BLANK;
//            }
//            return Convert.ToDateTime(pDate).ToString("dd-MM-yyyy HH:mm:ss");
//        }

//        public static string sStandardDisplayDate(object pDate)
//        {
//            if (nsSQL.mSQL.oHandleNullAndNothing(pDate).ToString() == LIBWebBased.BLANK)
//            {
//                return LIBWebBased.BLANK;
//            }
//            return Convert.ToDateTime(pDate).ToString("dd-MM-yyyy");
//        }

//        public static string sStandardSQLDateTime(object pDate)
//        {
//            if (nsSQL.mSQL.oHandleNullAndNothing(pDate).ToString() == LIBWebBased.BLANK)
//            {
//                return LIBWebBased.BLANK;
//            }
//            return Convert.ToDateTime(pDate).ToString("yyyy/MM/dd HH:mm:ss");
//        }

//        public static string sStandardFileNameDateTime(object pDate)
//        {
//            if (nsSQL.mSQL.oHandleNullAndNothing(pDate).ToString() == LIBWebBased.BLANK)
//            {
//                return LIBWebBased.BLANK;
//            }

//            return mDataTime.sHandleDate1900(Convert.ToDateTime(pDate).ToString("yyyy-MM-dd"));
//        }

//        public static string sHandleDate1900(object pDate)
//        {
//            if (Convert.ToDateTime(pDate).ToString("yyyy-MM-dd") == "1900-01-01")
//            {
//                return LIBWebBased.BLANK;
//            }
//            else
//            {
//                return pDate;
//            }
//        }

//        public static string sStandardFileNameDateTimeFull(object pDate)
//        {
//            return Convert.ToDateTime(pDate).ToString("yyyyMMdd_HHmmss");
//        }

//        public static string sSQLDateTime(object pDate)
//        {
//            if (nsSQL.mSQL.oHandleNullAndNothing(pDate).ToString() == LIBWebBased.BLANK)
//            {
//                return LIBWebBased.BLANK;
//            }
//            return Convert.ToDateTime(pDate).ToString("HH:mm:ss");
//        }

//        public static string sSQLDateFormatInNumber(object pDate)
//        {
//            if (nsSQL.mSQL.oHandleNullAndNothing(pDate).ToString() == LIBWebBased.BLANK)
//            {
//                return LIBWebBased.BLANK;
//            }
//            return Convert.ToDateTime(pDate).ToString("yyyyMMdd");
//        }

//        public static string sSQLDateFormat(object pDate)
//        {
//            if (nsSQL.mSQL.oHandleNullAndNothing(pDate).ToString() == LIBWebBased.BLANK)
//            {
//                return LIBWebBased.BLANK;
//            }
//            return Convert.ToDateTime(pDate).ToString("yyyy/MM/dd");
//        }

//        public static string sDisplayDateFormat(object pDate)
//        {
//            if (nsSQL.mSQL.oHandleNullAndNothing(pDate).ToString() == LIBWebBased.BLANK)
//            {
//                return LIBWebBased.BLANK;
//            }
//            return Convert.ToDateTime(pDate).ToString("dd/MM/yyyy");
//        }

//        public static string sAddStartTime(object pDate)
//        {
//            if (pDate.ToString() == LIBWebBased.BLANK)
//                return LIBWebBased.BLANK;
//            return sSQLDateFormat(Strings.FormatDateTime(pDate, DateFormat.ShortDate)) + " " + "00:00:00";
//        }

//        public static string sAddEndTime(object pDate)
//        {
//            if (pDate.ToString() == LIBWebBased.BLANK)
//                return LIBWebBased.BLANK;
//            return sSQLDateFormat(Strings.FormatDateTime(pDate, DateFormat.ShortDate)) + " " + "23:59:59";
//        }
//        #endregion


//        public static void SetDateRangeByRowColumnOption(ListControl pddlRowColumnOption, DatePicker pdtFrom, DatePicker pdtTo)
//        {
//            switch (pddlRowColumnOption.SelectedValue)
//            {
//                case "ByP5YearGroup":
//                    pdtTo.Text = mDataTime.sCalendarYearEnd(DateAndTime.Year(pdtTo.Text));
//                    pdtFrom.Text = mDataTime.sCalendarYearStart(DateAndTime.Year(DateAndTime.DateAdd(DateInterval.Year, -4, Convert.ToDateTime(pdtTo.Text))));

//                    break;
//                case "ByP12MonthGroup":
//                    if (DateAndTime.DateDiff(DateInterval.Day, Convert.ToDateTime(pdtTo.Text), DateAndTime.Now) < 0)
//                    {
//                        pdtTo.Text = mDataTime.sGetLastDateOfMonth(DateAndTime.Year(DateAndTime.Now), DateAndTime.Month(DateAndTime.Now));
//                        pdtFrom.Text = mDataTime.sGetLastDateOfMonth(DateAndTime.Year(DateAndTime.DateAdd(DateInterval.Year, -1, DateAndTime.Now)), DateAndTime.Month(DateAndTime.DateAdd(DateInterval.Year, -1, DateAndTime.Now)));
//                    }
//                    else
//                    {
//                        pdtTo.Text = mDataTime.sGetLastDateOfMonth(DateAndTime.Year(pdtTo.Text), DateAndTime.Month(pdtTo.Text));
//                        pdtFrom.Text = mDataTime.sGetLastDateOfMonth(DateAndTime.Year(DateAndTime.DateAdd(DateInterval.Year, -1, Convert.ToDateTime(pdtTo.Text))), DateAndTime.Month(DateAndTime.DateAdd(DateInterval.Year, -1, Convert.ToDateTime(pdtTo.Text))));
//                    }

//                    break;
//            }
//        }
//        public static void SetDateRangeByYearTypeByYear(ListControl prblYearType, ListControl pddlYear, DatePicker pdtFrom, DatePicker pdtTo)
//        {
//            int liYear = pddlYear.SelectedValue;
//            pddlYear.Visible = true;

//            switch (prblYearType.SelectedValue)
//            {
//                // 
//                case "ERSReportYearType1":
//                    //Calender 
//                    pdtFrom.Text = liYear.ToString() + "/01/01";
//                    pdtTo.Text = liYear.ToString() + "/12/31";

//                    break;
//                case "ERSReportYearType2":
//                    //YTD 
//                    pdtFrom.Text = liYear.ToString() + "/07/01";
//                    pdtTo.Text = (liYear + 1).ToString() + "/06/30";

//                    break;
//                case "其他":
//                    pddlYear.Visible = false;

//                    break;
//                default:
//                    prblYearType.SelectedIndex = "2";
//                    System.DateTime lTempDate = new System.DateTime(DateAndTime.Now.Year, DateAndTime.Now.Month, 1);
//                    pdtFrom.Text = mDataTime.sSQLDateFormat(lTempDate.AddYears(-1).AddMonths(1));
//                    pdtTo.Text = mDataTime.sSQLDateFormat(lTempDate.AddMonths(1).AddDays(-1));
//                    pddlYear.Visible = false;
//                    break;
//            }
//        }

//        public static string sHolidayDesc(string psSelectedCalYear, string psSelectedCalMonth = "0", string psSelectedCalWeek = "0", string psAdjustNMonth = "0")
//        {
//            int lsCalendarMonth = mDataTime.sMonthValueByYearMonthCalculation(psSelectedCalYear, psSelectedCalMonth, psAdjustNMonth);
//            int lsCalendarYear = mDataTime.sYearValueByYearMonthCalculation(psSelectedCalYear, psSelectedCalMonth, psAdjustNMonth);
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with5 = ClsLoadFieldHelper;
//            _with5.fAddSqlParameter("@yr", mDataTime.sToYTDYear(lsCalendarYear, lsCalendarMonth));
//            _with5.fAddSqlParameter("@mm", mDataTime.sToYTDMonth(lsCalendarMonth));
//            _with5.fAddSqlParameter("@wk", psSelectedCalWeek);
//            _with5.fBuildDataSet("sp_bpp_checkHoliday", null);

//            string lsDesc = LIBWebBased.BLANK;
//            while (_with5.bHasNextRow)
//            {
//                lsDesc += mDataTime.sSQLDateFormat(_with5.oLoadSqlField("hdateStart")) + " " + _with5.oLoadSqlField("hdesc") + ",";
//            }
//            return lsDesc;
//        }
//    }

//}

//// Part
//// Last tidy up: 20130603
//namespace nsString
//{
//    public static class mString
//    {
//        public static string fStringToHTMLDisplayFormat(string psValue)
//        {
//            psValue = (string)nsSQL.mSQL.oHandleNullAndNothing(psValue);
//            psValue = psValue.Replace(char.ConvertFromUtf32(13), "<br/>");
//            psValue = psValue.Replace("&#x0D;", "<br/>");
//            psValue = psValue.Replace("&lt;br/&gt;", "<br/>");
//            psValue = psValue.Replace("；", "；<br/>");

//            return psValue;
//        }

//        public static string fStringToYBlank(object psValue)
//        {
//            psValue = nsSQL.mSQL.oHandleNullAndNothing(psValue);
//            if (psValue == "1" | psValue.ToString().ToLower() == "true")
//            {
//                return "Y";
//            }
//            else
//            {
//                return LIBWebBased.BLANK;
//            }
//        }

//        public static string fStringToYesNo(object psValue, bool pbShowBlank = false)
//        {
//            psValue = nsSQL.mSQL.oHandleNullAndNothing(psValue);
//            if (psValue == "1" | psValue.ToString().ToLower() == "true")
//            {
//                return LIBWebBased.GlobalClassHashTableHelper.sGetHash("是");
//            }
//            else
//            {
//                if (pbShowBlank)
//                {
//                    if (psValue.ToString() == LIBWebBased.BLANK)
//                    {
//                        return LIBWebBased.BLANK;
//                    }
//                }

//                return LIBWebBased.GlobalClassHashTableHelper.sGetHash("否");
//            }
//        }

//        /// <summary>
//        /// 省略太長的字串
//        /// </summary>
//        public static string sOmitLongString(object psString)
//        {
//            psString = nsSQL.mSQL.oHandleDBNull(psString);
//            if (psString == LIBWebBased.BLANK)
//            {
//                return LIBWebBased.BLANK;
//            }
//            else
//            {
//                string lsString = psString;
//                if (lsString.Length > 30)
//                {
//                    return lsString.Substring(0, 30) + "...";
//                }
//                else
//                {
//                    return psString;
//                }
//            }

//        }

//        /// <summary>
//        /// split text to display in html
//        /// </summary>
//        public static string sSplitString(object psString, string psSeperator = LIBWebBased.gsSeperator)
//        {
//            psString = nsSQL.mSQL.oHandleDBNull(psString);
//            if (psString == LIBWebBased.BLANK)
//            {
//                return LIBWebBased.BLANK;
//            }
//            else
//            {
//                return psString.ToString().Replace(psSeperator, "<br/>");
//            }
//        }

//        public static string sCombineString(string psParent, string psSon, string psSeperator = LIBWebBased.BLANK, bool pbRemoveDuplicated = false)
//        {
//            if (psSon != LIBWebBased.BLANK)
//            {
//                if (pbRemoveDuplicated & psParent.Contains(psSon))
//                {
//                    return psParent;
//                }

//                if (psParent != LIBWebBased.BLANK)
//                {
//                    psParent += psSeperator;
//                }

//                return psParent + psSon;
//            }
//            else
//            {
//                return psParent;
//            }
//        }

//        public static string sAddUnit(string psParent, string psUnit)
//        {
//            if (psParent != LIBWebBased.BLANK)
//            {
//                return psParent + psUnit;
//            }
//            else
//            {
//                return psParent;
//            }
//        }

//        public static string sShowTextWhenHasData(string psDisplayText, object psData)
//        {
//            try
//            {
//                if (psData != LIBWebBased.BLANK)
//                {
//                    return psDisplayText;
//                }
//            }
//            catch (Exception ex)
//            {
//                return LIBWebBased.BLANK;
//            }
//            return LIBWebBased.BLANK;
//        }

//        /// <summary>
//        /// 將繁體中文字轉換成簡體中文。
//        /// http://sanchen.blogspot.com/2007/12/microsoftvisualbasicstringsstrconv.html
//        /// 使用1033的原因, 是因為轉換時會使用unicode 而不會出現??
//        /// </summary>
//        public static string sBig5ToGb(string Text)
//        {
//            // 將繁體中文字轉換成簡體中文，LocaleID 設為 2052
//            return Strings.StrConv(Text, VbStrConv.SimplifiedChinese, 1033);
//        }

//        public static string sGbToBig5(string Text)
//        {
//            // 將繁體中文字轉換成簡體中文，LocaleID 設為 2052
//            return Strings.StrConv(Text, VbStrConv.TraditionalChinese, 1033);
//        }
//    }
//}

//public static class mTestingCode
//{
//    // all code in this module is not yet release to use.

//    // not in use
//    //Private Sub SetOpenFileReminder(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
//    //    If e.Row.RowType = DataControlRowType.DataRow Then
//    //        '
//    //        Dim lLinkButton As LinkButton = e.Row.FindControl("LinkButton1")
//    //        If lLinkButton Is Nothing Then
//    //        Else
//    //            lLinkButton.CommandArgument = e.Row.RowIndex.ToString
//    //            lLinkButton.OnClientClick = "return confirm('" & ClsHashTableHelper.sGetHash("您確定要打開嗎") & "');"
//    //        End If
//    //    End If
//    //End Sub

//    //Private Sub RunSSIS()
//    //    Imports Microsoft.SqlServer.Dts.Runtime
//    //    Dim pkgLocation As String
//    //    Dim pkg As New Package
//    //    Dim app As New Application
//    //    Dim pkgResults As DTSExecResult
//    //    pkgLocation = "C:\Users\itd-mark\Desktop\Copy A Table From old 37 to old 33.dtsx"
//    //    pkg = app.LoadPackage(pkgLocation, Nothing)
//    //    pkgResults = pkg.Execute()
//    //    Dim aaa As String = pkgResults.ToString()
//    //End Sub

//    /// <summary>
//    /// Get DB connection string From AppSettings.
//    /// Not yet Use
//    /// </summary>
//    public static string sDBConnectionString(string psConnStrName = LIBWebBased.BLANK)
//    {
//        string lsConnStr = null;
//        if (psConnStrName == LIBWebBased.BLANK)
//        {
//            lsConnStr = LIBWebBased.gsConnectionString;
//        }
//        else
//        {
//            lsConnStr = ConfigurationManager.AppSettings[psConnStrName];
//        }
//        return lsConnStr;
//    }

//}

//// Web
//namespace nsLSVersion
//{
//    public static class mVersion
//    {
//        public static string sHandleLoginPage()
//        {
//            if (ConfigurationManager.AppSettings["DefaultLang"] == null)
//            {
//                return ConfigurationManager.AppSettings["DefaultLang"];
//            }
//            else
//            {
//                return ConfigurationManager.AppSettings["loginPage"];
//            }
//        }
//    }
//}

//// Web
//// Last tidy up: 20130603
//namespace nsChart
//{
//    public static class mChart
//    {

//        public static double sHandleChartNoValue(object psObject)
//        {
//            if (nsSQL.mSQL.oHandleNullAndNothing(psObject).ToString() == LIBWebBased.BLANK)
//            {
//                return ChartDirector.Chart.NoValue;
//            }
//            else if ((int)psObject == 0)
//            {
//                return ChartDirector.Chart.NoValue;
//            }
//            else
//            {
//                return (double)psObject;
//            }

//        }

//        public static void Build_DynamicBarChart(ChartDirector.WebChartViewer pWebChartViewer, System.Data.DataSet pDataset, string psReportColumnType, string psTitle = "ChartTitle", string psXAxisName = "XAxisName", string psYAxisName = "YAxisName", bool pbFixedWidth = false)
//        {
//            pWebChartViewer.Visible = true;
//            List<string> miLineColorList = LIBWebBased.ColorList();

//            ChartDirector.XYChart lXYChart = new ChartDirector.XYChart(800, 800, ChartDirector.Chart.silverColor(90), -1, 2);

//            // fixed parameter
//            lXYChart.xAxis().setMargin(15, 15);
//            lXYChart.xAxis().setLabelStyle("Arial Bold", 8, ChartDirector.Chart.TextColor, 90);
//            lXYChart.yAxis().setLabelStyle("Arial Bold", 8, ChartDirector.Chart.TextColor, 90);

//            lXYChart.xAxis().setTitle(psXAxisName, "Arial Bold Italic", 10);
//            lXYChart.yAxis().setTitle(psYAxisName, "Arial Bold Italic", 10);

//            // Set zero affinity to 0 to make sure the line is displayed in the most detail
//            // scale
//            lXYChart.yAxis().setAutoScale(1, 1, 0);
//            lXYChart.xAxis().setAutoScale(1, 1, 0);

//            // Set X Label
//            ArrayList lXAxis = new ArrayList();
//            ArrayList lYData = new ArrayList();
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with6 = ClsLoadFieldHelper;
//            _with6.fAddSqlParameter("@ByReportRowType", psReportColumnType);
//            _with6.fBuildDataSet("stp_wf_rss_GridStandardReportHeaderTranslationField");
//            while (_with6.bHasNextRow)
//            {
//                if (_with6.oLoadSqlField("Header") != "All")
//                {
//                    lXAxis.Add(_with6.oLoadSqlField("Header"));

//                }
//            }

//            string[] lsXLabel = Convert.ToString(lXAxis.ToArray(Type.GetType("System.String")));
//            lXYChart.xAxis().setLabels(lsXLabel);

//            // fixed parameter
//            lXYChart.xAxis().setTickOffset(0.2);
//            lXYChart.xAxis().setWidth(1);


//            // Build Data
//            ChartDirector.BarLayer lBarLayer = lXYChart.addBarLayer2(ChartDirector.Chart.Side);

//            int liBarCount = 0;
//            int liColCount = 0;

//            ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with7 = ClsLoadFieldHelper;

//            _with7.SetDataSet(pDataset);

//            while (_with7.bHasNextRow)
//            {

//                if (_with7.oLoadSqlField("ID") != "All")
//                {
//                    liColCount = 0;
//                    for (int liCol = 3; liCol <= pDataset.Tables[0].Columns.Count - 5; liCol++)
//                    {
//                        lYData.Add(mChart.sHandleChartNoValue(_with7.oLoadSqlFieldByIndex(liCol)));
//                        liColCount += 1;
//                    }
//                    lBarLayer.addDataSet(Convert.ToDouble(lYData.ToArray(Type.GetType("System.Double"))), miLineColorList[liBarCount], _with7.oLoadSqlField("RowName"));
//                    lYData.Clear();

//                    liBarCount += 1;
//                }
//            }
//            lBarLayer.setBarGap(0.1, ChartDirector.Chart.TouchBar);
//            // lBarLayer.setBorderColor(ChartDirector.Chart.Transparent, 0)
//            lBarLayer.setBarShape(ChartDirector.Chart.CircleShape);
//            // lBarLayer.setOverlapRatio(0.4)

//            int liYAxisLineCount = liBarCount;
//            int liXAxisLineCount = liColCount;
//            int li3DLineHeight = 0;
//            int li3DLineWidth = 0;
//            int liChartLineHeaderHeight = 30 + liYAxisLineCount * 14;
//            int liPlotHeight = 600 + (liYAxisLineCount * 20) + li3DLineHeight;
//            int liPlotWidth = 800 + (liXAxisLineCount * 1) + (liYAxisLineCount * 60) + li3DLineWidth;

//            if (pbFixedWidth)
//            {
//                liPlotWidth = 1400;
//            }

//            int liXAxisLabelHeight = 0;
//            try
//            {
//                liXAxisLabelHeight = Convert.ToInt32(lXAxis[0].ToString().Length) * 7 + 60;
//            }
//            catch (Exception ex)
//            {
//                liXAxisLabelHeight = 100;
//            }

//            lXYChart.setSize(liPlotWidth + li3DLineWidth, liPlotHeight + liChartLineHeaderHeight + liXAxisLabelHeight);

//            // Set the plotarea at (60, 80) and of 510 x 275 pixels in size. Use transparent
//            // border and dark grey (444444) dotted grid lines
//            ChartDirector.PlotArea plotArea = lXYChart.setPlotArea(50, 45, liPlotWidth - 150, liPlotHeight, -1, -1, ChartDirector.Chart.Transparent, lXYChart.dashLineColor(0x444444, 0x101), -1);

//            //******************
//            // Add a legend box where the top-center is anchored to the horizontal center of
//            // the plot area at y = 45. Use horizontal layout and 10 points Arial Bold font,
//            // and transparent background and border.
//            ChartDirector.LegendBox legendBox = default(ChartDirector.LegendBox);
//            // legendBox = lXYChart.addLegend(350, liPlotHeight + 100, False, "Arial Bold", 10)
//            legendBox = lXYChart.addLegend(10, liPlotHeight + liXAxisLabelHeight);
//            legendBox.setFontSize(8);
//            legendBox.setBackground(ChartDirector.Chart.Transparent, ChartDirector.Chart.Transparent);

//            //****************** Set Title
//            // Add a title using 18 pts Times New Roman Bold Italic font. #Set top margin to
//            // 16 pixels.
//            lXYChart.addTitle(psTitle, "Times New Roman Bold Italic", 18).setBackground(ChartDirector.Chart.metalColor(0x9999ff), -1, 1);

//            //****************** Output the chart
//            pWebChartViewer.Image = lXYChart.makeWebImage(ChartDirector.Chart.JPG);

//            //****************** Include tool tip for the chart
//            pWebChartViewer.ImageMap = lXYChart.getHTMLImageMap("", "", "title=' {dataSetName} " + psYAxisName + " :{value}  " + psXAxisName + ": {xLabel}'");

//        }

//        public static void Build_DynamicLineChart(ChartDirector.WebChartViewer pWebChartViewer, System.Data.DataSet pDataset, string psReportColumnType, string psTitle = "ChartTitle", string psXAxisName = "XAxisName", string psYAxisName = "YAxisName", bool pbFixedWidth = false, bool pbShowAvg = false)
//        {
//            pWebChartViewer.Visible = true;
//            List<string> miLineColorList = LIBWebBased.ColorList();

//            ChartDirector.XYChart lXYChart = new ChartDirector.XYChart(800, 800, ChartDirector.Chart.silverColor(90), -1, 2);

//            // fixed parameter
//            lXYChart.xAxis().setMargin(15, 15);
//            lXYChart.xAxis().setLabelStyle("Arial Bold", 8, ChartDirector.Chart.TextColor, 90);
//            lXYChart.yAxis().setLabelStyle("Arial Bold", 8, ChartDirector.Chart.TextColor, 90);

//            lXYChart.xAxis().setTitle(psXAxisName, "Arial Bold Italic", 10);
//            lXYChart.yAxis().setTitle(psYAxisName, "Arial Bold Italic", 10);

//            // Set zero affinity to 0 to make sure the line is displayed in the most detail
//            // scale
//            lXYChart.yAxis().setAutoScale(1, 1, 0);
//            lXYChart.xAxis().setAutoScale(1, 1, 0);

//            // Set X Label
//            ArrayList lXAxis = new ArrayList();
//            ArrayList lYData = new ArrayList();
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with8 = ClsLoadFieldHelper;
//            _with8.fAddSqlParameter("@ByReportRowType", psReportColumnType);
//            _with8.fBuildDataSet("stp_wf_rss_GridStandardReportHeaderTranslationField");
//            while (_with8.bHasNextRow)
//            {
//                if (_with8.oLoadSqlField("Header") != "All")
//                {
//                    lXAxis.Add(_with8.oLoadSqlField("Header"));

//                }
//            }

//            string[] lsXLabel = Convert.ToString(lXAxis.ToArray(Type.GetType("System.String")));
//            lXYChart.xAxis().setLabels(lsXLabel);

//            // fixed parameter
//            // lXYChart.xAxis().setTickOffset(0.2)
//            lXYChart.xAxis().setWidth(1);

//            // Build Data
//            ChartDirector.LineLayer lLineLayer = lXYChart.addLineLayer();

//            int liLineCount = 0;
//            int liColCount = 0;
//            int liValueCount = 0;
//            double liValueTotal = 0;

//            ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with9 = ClsLoadFieldHelper;

//            _with9.SetDataSet(pDataset);

//            while (_with9.bHasNextRow)
//            {
//                if (_with9.oLoadSqlField("ID") != "All")
//                {
//                    liValueCount = 0;
//                    liValueTotal = 0;
//                    liColCount = 0;
//                    for (int liCol = 3; liCol <= pDataset.Tables[0].Columns.Count - 5; liCol++)
//                    {
//                        object loObject = mChart.sHandleChartNoValue(_with9.oLoadSqlFieldByIndex(liCol));
//                        lYData.Add(loObject);
//                        if (loObject != ChartDirector.Chart.NoValue)
//                        {
//                            liValueCount += 1;
//                            liValueTotal += loObject;
//                        }
//                        liColCount += 1;
//                    }
//                    lLineLayer.addDataSet(Convert.ToDouble(lYData.ToArray(Type.GetType("System.Double"))), miLineColorList[liLineCount], _with9.oLoadSqlField("RowName")).setDataSymbol(Chart.DiamondSymbol, 9);


//                    if (pbShowAvg)
//                    {
//                        Mark yMark = lXYChart.yAxis().addMark(liValueTotal / liValueCount, lXYChart.dashLineColor(miLineColorList[liLineCount]));
//                        yMark.setLineWidth(2);
//                        yMark.setAlignment(Chart.TopCenter);

//                        Mark yMark2 = lXYChart.yAxis().addMark(liValueTotal / liValueCount, miLineColorList[liLineCount], _with9.oLoadSqlField("RowName") + "平均數");
//                        yMark2.setLineWidth(0);
//                        yMark2.setAlignment(Chart.TopCenter);
//                    }


//                    lYData.Clear();

//                    liLineCount += 1;
//                }
//            }
//            // lLineLayer.setBarGap(0.1, ChartDirector.Chart.TouchBar)
//            // lBarLayer.setBorderColor(ChartDirector.Chart.Transparent, 0)
//            // lLineLayer.setBarShape(ChartDirector.Chart.CircleShape)
//            // lBarLayer.setOverlapRatio(0.4)

//            lLineLayer.setLineWidth(1.5);




//            // lXYChart.yAxis().addMark(3000.0, miLineColorList(liLineCount), "Testing").setLineWidth(2)

//            int liYAxisLineCount = liLineCount;
//            int liXAxisLineCount = liColCount;
//            int li3DLineHeight = 0;
//            int li3DLineWidth = 0;
//            int liChartLineHeaderHeight = 30 + liYAxisLineCount * 14;
//            int liPlotHeight = 600 + (liYAxisLineCount * 20) + li3DLineHeight;
//            int liPlotWidth = 800 + (liXAxisLineCount * 1) + (liYAxisLineCount * 60) + li3DLineWidth;

//            if (pbFixedWidth)
//            {
//                liPlotWidth = 1400;
//            }

//            int liXAxisLabelHeight = 0;
//            try
//            {
//                liXAxisLabelHeight = Convert.ToInt32(lXAxis[0].ToString().Length) * 7 + 60;
//            }
//            catch (Exception ex)
//            {
//                liXAxisLabelHeight = 100;
//            }

//            lXYChart.setSize(liPlotWidth + li3DLineWidth, liPlotHeight + liChartLineHeaderHeight + liXAxisLabelHeight);

//            // Set the plotarea at (60, 80) and of 510 x 275 pixels in size. Use transparent
//            // border and dark grey (444444) dotted grid lines
//            ChartDirector.PlotArea plotArea = lXYChart.setPlotArea(50, 45, liPlotWidth - 150, liPlotHeight, -1, -1, ChartDirector.Chart.Transparent, lXYChart.dashLineColor(0x444444, 0x101), -1);

//            //******************
//            // Add a legend box where the top-center is anchored to the horizontal center of
//            // the plot area at y = 45. Use horizontal layout and 10 points Arial Bold font,
//            // and transparent background and border.
//            ChartDirector.LegendBox legendBox = default(ChartDirector.LegendBox);
//            // legendBox = lXYChart.addLegend(350, liPlotHeight + 100, False, "Arial Bold", 10)
//            legendBox = lXYChart.addLegend(10, liPlotHeight + liXAxisLabelHeight);
//            legendBox.setFontSize(8);
//            legendBox.setBackground(ChartDirector.Chart.Transparent, ChartDirector.Chart.Transparent);

//            //****************** Set Title
//            // Add a title using 18 pts Times New Roman Bold Italic font. #Set top margin to
//            // 16 pixels.
//            lXYChart.addTitle(psTitle, "Times New Roman Bold Italic", 18).setBackground(ChartDirector.Chart.metalColor(0x9999ff), -1, 1);

//            //****************** Output the chart
//            pWebChartViewer.Image = lXYChart.makeWebImage(ChartDirector.Chart.JPG);

//            //****************** Include tool tip for the chart
//            pWebChartViewer.ImageMap = lXYChart.getHTMLImageMap("", "", "title=' {dataSetName} " + psYAxisName + " :{value}  " + psXAxisName + ": {xLabel}'");

//        }

//        public static void Build_XDate_YValue_ChartUsingDataTable(ChartDirector.WebChartViewer pWebChartViewer, DataTable pDataTable, int psStartColumn, string psTitle = "ChartTitle", string psXAxisName = "XAxisName", string psYAxisName = "YAxisName", bool pbFixedWidth = false)
//        {
//            pWebChartViewer.Visible = true;
//            List<string> miLineColorList = LIBWebBased.ColorList();

//            //************************Set Chart
//            // Create a XYChart object of size 600 x 400 pixels. Use a vertical gradient color
//            // from light blue (99ccff) to white (ffffff) spanning the top 100 pixels as
//            // background. Set border to grey (888888). Use rounded corners. Enable soft drop
//            // shadow.
//            ChartDirector.XYChart lXYChart = new ChartDirector.XYChart(800, 800, ChartDirector.Chart.silverColor(90), -1, 2);

//            // Set the x-axis margins to 15 pixels, so that the horizontal grid lines can
//            // extend beyond the leftmost and rightmost vertical grid lines
//            lXYChart.xAxis().setMargin(15, 15);
//            lXYChart.xAxis().setLabelStyle("Arial Bold", 8, ChartDirector.Chart.TextColor, 90);
//            lXYChart.yAxis().setLabelStyle("Arial Bold", 8, ChartDirector.Chart.TextColor, 90);

//            lXYChart.xAxis().setTitle(psXAxisName, "Arial Bold Italic", 10);
//            lXYChart.yAxis().setTitle(psYAxisName, "Arial Bold Italic", 10);

//            // Set zero affinity to 0 to make sure the line is displayed in the most detail
//            // scale
//            lXYChart.yAxis().setAutoScale(1, 1, 0);
//            lXYChart.xAxis().setAutoScale(1, 1, 0);

//            // Build XAxis
//            ArrayList pXAxis = new ArrayList();

//            int liColCount = 0;
//            foreach (DataColumn lCol in pDataTable.Columns)
//            {
//                if (liColCount >= psStartColumn)
//                {
//                    try
//                    {
//                        pXAxis.Add(Convert.ToDateTime(lCol.Caption));


//                    }
//                    catch (Exception ex)
//                    {
//                    }
//                }
//                liColCount += 1;
//            }


//            int liRowCount = 0;
//            foreach (DataRow lRow in pDataTable.Rows)
//            {
//                // Build YAxis
//                ChartDirector.LineLayer lLineLayer = lXYChart.addLineLayer2;
//                int liRowCol = 0;
//                string lsLineName = LIBWebBased.BLANK;
//                ArrayList pYAxis = new ArrayList();
//                foreach (DataColumn lCol in pDataTable.Columns)
//                {
//                    if (liRowCol >= psStartColumn)
//                    {
//                        pYAxis.Add(mChart.sHandleChartNoValue(lRow[liRowCol]));
//                    }
//                    else
//                    {
//                        lsLineName += lRow[liRowCol] + " ";
//                    }
//                    liRowCol += 1;
//                }

//                double[] data0Y = Convert.ToDouble(pYAxis.ToArray(Type.GetType("System.Double")));
//                System.DateTime[] data0X = Convert.ToDateTime(pXAxis.ToArray(Type.GetType("System.DateTime")));
//                //Dim data0Remark() As String = CType(pRemark.ToArray(Type.GetType("System.String")), String())

//                // lLineLayer.addExtraField(data0Remark)
//                lLineLayer.addDataSet(data0Y, LIBWebBased.giLineColor(miLineColorList, liRowCount), lsLineName).setDataSymbol(ChartDirector.Chart.CircleShape, 6);
//                lLineLayer.setLineWidth(1.5);
//                lLineLayer.setXData(data0X);
//                lLineLayer.setDataLabelFormat("{value|2}");
//                // lLineLayer.setLegendOrder(1, 1 )
//                lLineLayer.setGapColor((LIBWebBased.giLineColor(miLineColorList, liRowCount)));
//                liRowCount += 1;
//            }

//            int liYAxisLineCount = liRowCount;
//            int liXAxisLineCount = liColCount;
//            int li3DLineHeight = 0;
//            int li3DLineWidth = 0;

//            int liChartLineHeaderHeight = 30 + liYAxisLineCount * 14;
//            int liPlotHeight = 350 + (liYAxisLineCount * 20) + li3DLineHeight;
//            int liPlotWidth = 600 + (liXAxisLineCount * 15) + li3DLineWidth;

//            if (pbFixedWidth)
//            {
//                liPlotWidth = 1400;
//            }

//            int liXAxisLabelHeight = 0;
//            try
//            {
//                liXAxisLabelHeight = Convert.ToInt32(pXAxis[0].ToString().Length) * 7 + 60;
//            }
//            catch (Exception ex)
//            {
//                liXAxisLabelHeight = 100;
//            }

//            lXYChart.setSize(liPlotWidth + li3DLineWidth, liPlotHeight + liChartLineHeaderHeight + liXAxisLabelHeight);

//            // Set the plotarea at (60, 80) and of 510 x 275 pixels in size. Use transparent
//            // border and dark grey (444444) dotted grid lines
//            ChartDirector.PlotArea plotArea = lXYChart.setPlotArea(50, 45, liPlotWidth - 150, liPlotHeight, -1, -1, ChartDirector.Chart.Transparent, lXYChart.dashLineColor(0x444444, 0x101), -1);

//            //******************
//            // Add a legend box where the top-center is anchored to the horizontal center of
//            // the plot area at y = 45. Use horizontal layout and 10 points Arial Bold font,
//            // and transparent background and border.
//            ChartDirector.LegendBox legendBox = default(ChartDirector.LegendBox);
//            // legendBox = lXYChart.addLegend(350, liPlotHeight + 100, False, "Arial Bold", 10)
//            legendBox = lXYChart.addLegend(10, liPlotHeight + liXAxisLabelHeight);
//            legendBox.setFontSize(8);
//            legendBox.setBackground(ChartDirector.Chart.Transparent, ChartDirector.Chart.Transparent);

//            //****************** Set Title
//            // Add a title using 18 pts Times New Roman Bold Italic font. #Set top margin to
//            // 16 pixels.
//            lXYChart.addTitle(psTitle, "Times New Roman Bold Italic", 18).setBackground(ChartDirector.Chart.metalColor(0x9999ff), -1, 1);

//            //****************** Output the chart
//            pWebChartViewer.Image = lXYChart.makeWebImage(ChartDirector.Chart.JPG);

//            //****************** Include tool tip for the chart
//            pWebChartViewer.ImageMap = lXYChart.getHTMLImageMap("", "", "title=' {dataSetName} " + psYAxisName + " :{value}  " + psXAxisName + " :{x|dd/mm/yyyy} '");

//        }

//        public static void BuildChartUsingDataTable(ChartDirector.WebChartViewer pWebChartViewer, DataTable pDataTable, int psStartColumn, string psTitle = "ChartTitle", string psXAxisName = "XAxisName", string psYAxisName = "YAxisName", bool pbFixedWidth = false, int pbXAxisType = 2)
//        {
//            pWebChartViewer.Visible = true;
//            List<string> miLineColorList = LIBWebBased.ColorList();

//            //************************Set Chart
//            // Create a XYChart object of size 600 x 400 pixels. Use a vertical gradient color
//            // from light blue (99ccff) to white (ffffff) spanning the top 100 pixels as
//            // background. Set border to grey (888888). Use rounded corners. Enable soft drop
//            // shadow.
//            ChartDirector.XYChart lXYChart = new ChartDirector.XYChart(800, 800, ChartDirector.Chart.silverColor(90), -1, 2);

//            // Set the x-axis margins to 15 pixels, so that the horizontal grid lines can
//            // extend beyond the leftmost and rightmost vertical grid lines
//            lXYChart.xAxis().setMargin(15, 15);
//            lXYChart.xAxis().setLabelStyle("Arial Bold", 8, ChartDirector.Chart.TextColor, 90);
//            lXYChart.yAxis().setLabelStyle("Arial Bold", 8, ChartDirector.Chart.TextColor, 90);

//            lXYChart.xAxis().setTitle(psXAxisName, "Arial Bold Italic", 10);
//            lXYChart.yAxis().setTitle(psYAxisName, "Arial Bold Italic", 10);

//            // Set zero affinity to 0 to make sure the line is displayed in the most detail
//            // scale
//            // lXYChart.yAxis().setAutoScale(1, 1, 0)
//            lXYChart.xAxis().setAutoScale(1, 1, 0);

//            // Build XAxis
//            ArrayList pXAxis = new ArrayList();
//            int liAxisType = 0;

//            int liColCount = 0;
//            foreach (DataColumn lCol in pDataTable.Columns)
//            {
//                if (liColCount >= psStartColumn)
//                {
//                    //If IsDate(lCol.Caption) Then
//                    //    pXAxis.Add(CDate(lCol.Caption))
//                    //    liAxisType = 0
//                    //ElseIf IsNumeric(lCol.Caption) Then
//                    //    pXAxis.Add(CDbl(lCol.Caption))
//                    //    liAxisType = 1
//                    //Else
//                    //    pXAxis.Add(lCol.Caption)
//                    //    liAxisType = 2
//                    //End If
//                    if (pbXAxisType == 0)
//                    {
//                        pXAxis.Add(Convert.ToDateTime(lCol.Caption));
//                    }
//                    else
//                    {
//                        pXAxis.Add(lCol.Caption);
//                    }
//                    liAxisType = pbXAxisType;

//                }
//                liColCount += 1;
//            }

//            if (liAxisType == 0)
//            {
//                lXYChart.xAxis().setLabels(Convert.ToDateTime(pXAxis.ToArray(Type.GetType("System.DateTime"))));
//            }
//            else if (liAxisType == 1)
//            {
//                lXYChart.xAxis().setLabels(Convert.ToDouble(pXAxis.ToArray(Type.GetType("System.Double"))));
//            }
//            else
//            {
//                lXYChart.xAxis().setLabels(Convert.ToString(pXAxis.ToArray(Type.GetType("System.String"))));
//            }

//            // Build YAxis
//            ChartDirector.LineLayer lLineLayer = lXYChart.addLineLayer2;
//            // lLineLayer.set3D(2 , 5 )

//            int liRowCount = 0;
//            foreach (DataRow lRow in pDataTable.Rows)
//            {
//                int liRowCol = 0;
//                string lsLineName = LIBWebBased.BLANK;
//                ArrayList pYAxis = new ArrayList();
//                foreach (DataColumn lCol in pDataTable.Columns)
//                {
//                    if (liRowCol >= psStartColumn)
//                    {
//                        pYAxis.Add(mChart.sHandleChartNoValue(lRow[liRowCol]));
//                    }
//                    else
//                    {
//                        lsLineName += lRow[liRowCol] + " ";
//                    }
//                    liRowCol += 1;
//                }

//                double[] data0Y = Convert.ToDouble(pYAxis.ToArray(Type.GetType("System.Double")));
//                //Dim data0Remark() As String = CType(pRemark.ToArray(Type.GetType("System.String")), String())

//                // lLineLayer.addExtraField(data0Remark)
//                lLineLayer.addDataSet(data0Y, LIBWebBased.giLineColor(miLineColorList, liRowCount), lsLineName).setDataSymbol(Chart.CircleShape, 6);
//                lLineLayer.setLineWidth(1.5);
//                // lLineLayer.setLegendOrder(1, 1 )
//                lLineLayer.setGapColor(lXYChart.dashLineColor(LIBWebBased.giLineColor(miLineColorList, liRowCount)));
//                liRowCount += 1;
//            }

//            int liYAxisLineCount = liRowCount;
//            int liXAxisLineCount = liColCount;
//            int li3DLineHeight = 0;
//            int li3DLineWidth = 0;

//            int liChartLineHeaderHeight = 30 + liYAxisLineCount * 14;
//            int liPlotHeight = 350 + (liYAxisLineCount * 20) + li3DLineHeight;
//            int liPlotWidth = 600 + (liXAxisLineCount * 15) + li3DLineWidth;

//            if (pbFixedWidth)
//            {
//                liPlotWidth = 1400;
//            }

//            int liXAxisLabelHeight = 0;
//            try
//            {
//                liXAxisLabelHeight = Convert.ToInt32(pXAxis[0].ToString().Length) * 7 + 60;
//            }
//            catch (Exception ex)
//            {
//                liXAxisLabelHeight = 100;
//            }

//            lXYChart.setSize(liPlotWidth + li3DLineWidth, liPlotHeight + liChartLineHeaderHeight + liXAxisLabelHeight);

//            // Set the plotarea at (60, 80) and of 510 x 275 pixels in size. Use transparent
//            // border and dark grey (444444) dotted grid lines
//            ChartDirector.PlotArea plotArea = lXYChart.setPlotArea(50, 45, liPlotWidth - 150, liPlotHeight, -1, -1, ChartDirector.Chart.Transparent, lXYChart.dashLineColor(0x444444, 0x101), -1);

//            //******************
//            // Add a legend box where the top-center is anchored to the horizontal center of
//            // the plot area at y = 45. Use horizontal layout and 10 points Arial Bold font,
//            // and transparent background and border.
//            ChartDirector.LegendBox legendBox = default(ChartDirector.LegendBox);
//            // legendBox = lXYChart.addLegend(350, liPlotHeight + 100, False, "Arial Bold", 10)
//            legendBox = lXYChart.addLegend(10, liPlotHeight + liXAxisLabelHeight);
//            legendBox.setFontSize(8);
//            legendBox.setBackground(ChartDirector.Chart.Transparent, ChartDirector.Chart.Transparent);

//            //****************** Set Title
//            // Add a title using 18 pts Times New Roman Bold Italic font. #Set top margin to
//            // 16 pixels.
//            lXYChart.addTitle(psTitle, "Times New Roman Bold Italic", 18).setBackground(ChartDirector.Chart.metalColor(0x9999ff), -1, 1);

//            //****************** Output the chart
//            pWebChartViewer.Image = lXYChart.makeWebImage(ChartDirector.Chart.JPG);

//            //****************** Include tool tip for the chart
//            pWebChartViewer.ImageMap = lXYChart.getHTMLImageMap("", "", "title='{dataSetName} " + psYAxisName + ":{value}  " + psXAxisName + ":{xLabel} '");

//        }
//    }

//}

//// Web
//// Last tidy up: 20130603
//#region "nsScript"
//namespace nsScript
//{
//    public static class mScript
//    {
//        public static void RefreshThePage(Page pPage)
//        {
//            pPage.Response.Redirect(pPage.Request.Url.ToString());
//        }

//        public static void ExecuteScript(System.Web.UI.TemplateControl pPage, string psScript)
//        {
//            string lsScript = "<script defer='defer'>" + psScript + "</script>";
//            fRegisterStartupScript(pPage, lsScript, "Script", false);
//        }

//        public static void RefreshParentPage(System.Web.UI.TemplateControl pPage, bool pbClose)
//        {
//            string lsScript = "window.open('','_self');window.opener.location=window.opener.location;";
//            lsScript = sJSAddWindowClose(lsScript, pbClose);
//            fRegisterStartupScript(pPage, lsScript, "refreshParentPage");
//        }

//        public static void CloseWindow(System.Web.UI.TemplateControl pPage, bool pbClose)
//        {
//            string lsScript = LIBWebBased.BLANK;
//            lsScript = sJSAddWindowClose(lsScript, pbClose);
//            fRegisterStartupScript(pPage, lsScript, "CloseWindow");
//        }

//        public static void RefreshRecords(System.Web.UI.TemplateControl pPage, bool pbClose)
//        {
//            string lsScript = "window.open('','_self');window.opener.refreshRecords();";
//            lsScript = sJSAddWindowClose(lsScript, pbClose);
//            fRegisterStartupScript(pPage, lsScript, "refreshRecords");
//        }

//        /// <summary>
//        /// Alert弹出对话框.
//        /// Use for signal of saving completed.
//        /// </summary>
//        public static void Alert(System.Web.UI.TemplateControl pPage, string psMessage, bool pbClose)
//        {
//            string lsScript = "window.alert('" + psMessage + "');";
//            lsScript = sJSAddWindowClose(lsScript, pbClose);
//            fRegisterStartupScript(pPage, lsScript, "alert");
//        }

//        public static void QuestionYesNo(System.Web.UI.TemplateControl pPage, string psTest)
//        {
//            string lsScript = "confirm('" + psTest + "')";
//            lsScript = sJSAddWindowClose(lsScript, false);
//            fRegisterStartupScript(pPage, lsScript, "openQuestion", true);
//        }
//        public static void AlertDuplidated(System.Web.UI.TemplateControl pPage)
//        {
//            mScript.Alert(pPage, LIBWebBased.GlobalClassHashTableHelper.sGetHash("Add_fail_Duplicated"), false);
//        }

//        public static void AlertNoRecord(System.Web.UI.TemplateControl pPage)
//        {
//            mScript.Alert(pPage, LIBWebBased.GlobalClassHashTableHelper.sGetHash("沒有記錄"), false);
//        }

//        public static void AlertNoAccessRight(System.Web.UI.TemplateControl pPage)
//        {
//            mScript.Alert(pPage, LIBWebBased.GlobalClassHashTableHelper.sGetHash("沒有權限使用"), true);
//        }

//        public static void AlertAddSucess(System.Web.UI.TemplateControl pPage)
//        {
//            mScript.Alert(pPage, LIBWebBased.GlobalClassHashTableHelper.sGetHash("已成功添加"), false);
//        }

//        public static void AlertDBNoRecord(System.Web.UI.TemplateControl pPage, string psMessage)
//        {
//            mScript.Alert(pPage, LIBWebBased.GlobalClassHashTableHelper.sGetHash(psMessage) + " " + LIBWebBased.GlobalClassHashTableHelper.sGetHash("Alert_No_Record"), false);
//        }

//        public static void AlertCannotBlank(System.Web.UI.TemplateControl pPage, string psMessage)
//        {
//            mScript.Alert(pPage, LIBWebBased.GlobalClassHashTableHelper.sGetHash(psMessage) + " " + LIBWebBased.GlobalClassHashTableHelper.sGetHash("不能為空"), false);
//        }

//        /// <summary>
//        /// get output value from SQL stp
//        /// </summary>
//        public static void SQLResult(System.Web.UI.TemplateControl pPage, SqlParameter[] pSqlParameter)
//        {
//            string lsResult = pSqlParameter[pSqlParameter.Length - 1].Value;
//            if (lsResult != LIBWebBased.BLANK)
//            {
//                mScript.Alert(pPage, LIBWebBased.GlobalClassHashTableHelper.sGetHash(lsResult), false);
//            }
//        }

//        private static string sJSAddWindowClose(string psScript, bool pbClose)
//        {
//            if (pbClose)
//            {
//                return psScript + "window.close();";
//            }
//            else
//            {
//                return psScript;
//            }
//        }

//        private static void fRegisterStartupScript(System.Web.UI.TemplateControl pPage, string psScript, string psKey, bool pbAddScriptTag = true)
//        {
//            ScriptManager.RegisterStartupScript(pPage, pPage.GetType(), psKey, psScript, pbAddScriptTag);
//        }

//        // dont know where use
//        public static void OpenURL(HttpContext pHttpContext, string psURL)
//        {
//            string lsScript = "window.open('" + psURL + "');";
//            lsScript = sJSAddWindowClose(lsScript, false);
//            fRegisterStartupScript(pHttpContext, lsScript, "open");
//        }

//        public static void OpenURL(System.Web.UI.TemplateControl pPage, string psURL)
//        {
//            string lsScript = "window.open('" + psURL + "','_newtab');";
//            lsScript = sJSAddWindowClose(lsScript, false);

//            ScriptManager.RegisterStartupScript(pPage, pPage.GetType(), "open", lsScript, true);
//        }

//        private static void fRegisterStartupScript(HttpContext pContext, string psScript, string psKey, bool pbAddScriptTag = true)
//        {
//            ScriptManager.RegisterStartupScript((Page)pContext.CurrentHandler, typeof(Page), "alert", psScript, pbAddScriptTag);
//        }
//    }
//}
//#endregion

//namespace nsFileIO
//{
//    public static class mFileIO
//    {
//        public static ArrayList WriteArraylistToFile(string psDirPath, ArrayList pArrayList)
//        {
//            ArrayList lArrayList = new ArrayList();

//            if (File.Exists(psDirPath))
//            {
//                File.Delete(psDirPath);
//            }

//            FileStream fs = new FileStream(psDirPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
//            using (StreamWriter w = new StreamWriter(fs))
//            {
//                w.BaseStream.Seek(0, SeekOrigin.Begin);
//                foreach (string lsItem in pArrayList)
//                {
//                    lArrayList.Add(lsItem);
//                    w.WriteLine(lsItem, Encoding.Unicode);
//                }
//            }


//            return pArrayList;
//        }
//        public static string sGetTextFromFile(string psFilePath)
//        {
//            using (StreamReader sr = new StreamReader(psFilePath))
//            {
//                return sr.ReadToEnd();
//            }
//        }
//        public static ArrayList GetListFromFile(string psFilePath)
//        {
//            FileStream fs = new FileStream(psFilePath, FileMode.OpenOrCreate, FileAccess.Read);
//            return mFileIO.FileStreamToArraylist(fs);
//        }

//        public static ArrayList FileStreamToArraylist(Stream psSystemIOStream)
//        {
//            ArrayList lArrayList = new ArrayList();
//            StreamReader r = new StreamReader(psSystemIOStream);
//            r.BaseStream.Seek(0, SeekOrigin.Begin);
//            while (r.Peek() > -1)
//            {
//                lArrayList.Add(r.ReadLine());
//            }
//            r.Close();
//            // close the read
//            r.Dispose();
//            return lArrayList;
//        }

//        public static byte[] StreamToByte(System.IO.Stream pStream)
//        {
//            byte[] lFileByte = new byte[pStream.Length + 1];
//            pStream.Read(lFileByte, 0, lFileByte.Length);
//            return lFileByte;
//        }

//        public static System.IO.Stream ByteToStream(byte[] pByte)
//        {
//            return new MemoryStream(pByte);
//        }

//        public static string ArraylistToFullText(ArrayList psArraylist)
//        {
//            StringBuilder lStringBuilder = new StringBuilder();
//            foreach (string lLine in psArraylist)
//            {
//                lStringBuilder.AppendLine(Strings.Trim(lLine));
//            }
//            return lStringBuilder.ToString();
//        }
//    }
//}


//namespace nsNetwork
//{
//    public static class mNetwork
//    {

//        public static TextReader sURLHTMLSource(string Url)
//        {
//            Stream sStream = null;
//            HttpWebRequest URLReq = null;
//            HttpWebResponse URLRes = null;
//            URLReq = WebRequest.Create(Url);
//            URLRes = URLReq.GetResponse();
//            sStream = URLRes.GetResponseStream();

//            return new StreamReader(sStream);
//        }
//        public static bool bURLIsValid(string Url, string psUser)
//        {
//            Stream sStream = null;
//            HttpWebRequest URLReq = null;
//            HttpWebResponse URLRes = null;

//            try
//            {
//                URLReq = WebRequest.Create(Url);
//                URLRes = URLReq.GetResponse();


//                try
//                {
//                    nsCommon.mCommon.URL404Log(psUser, "", Url, "URL Status:" + URLRes.StatusCode.ToString() + "   URLFrom:" + HttpContext.Current.Request.Url.ToString() + "   URLTo:" + Url);
//                }
//                catch (Exception ex)
//                {
//                    nsCommon.mCommon.URL404Log(psUser, "", Url, "Error 1" + ex.ToString());
//                }


//                try
//                {
//                    if (URLRes.StatusCode == HttpStatusCode.OK)
//                    {
//                    }
//                    else
//                    {
//                        return false;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    nsCommon.mCommon.URL404Log(psUser, "", Url, "Error 2" + ex.ToString());
//                }

//                sStream = URLRes.GetResponseStream();
//                string reader = new StreamReader(sStream).ReadToEnd();

//                try
//                {
//                    if (string.IsNullOrEmpty(reader))
//                    {
//                        nsCommon.mCommon.URL404Log(psUser, "", Url, "GetResponseStream = blank");
//                        return false;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    nsCommon.mCommon.URL404Log(psUser, "", Url, "Error 3" + ex.ToString());
//                }

//                return true;
//            }
//            catch (Exception ex)
//            {
//                nsCommon.mCommon.URL404Log(psUser, "", Url, "Error " + ex.ToString());
//                //Url not valid
//                return false;
//            }
//        }

//        public static bool bURLIsValid(string Url)
//        {
//            return bURLIsValid(LIBWebBased.gsUserName, Url);
//        }
//    }
//}

//namespace nsWorkFlow
//{
//    public static class mWorkFlow
//    {

//        public class Action
//        {
//            //Action
//            public static readonly string Add = "Add";
//            public static readonly string Modify = "Modify";
//            public static readonly string Display = "Display";
//            public static readonly string Disable = "Disable";
//            public static readonly string Err = "Error";
//            public static readonly string Initiate = "Initiate";
//            public static readonly string Edit = "Edit";
//        }

//        /// <summary>
//        /// Check User Login
//        /// seem 2003 version does not support  HttpContext.Current.Response
//        /// f1 - if no login, redirect to default login page
//        /// f2 - if no privilege, redirect to default login page
//        /// </summary>
//        public static void CheckLoginName()
//        {
//            // f1
//            if (LIBWebBased.gsUserNameCookie == null)
//            {
//                HttpContext.Current.Response.Redirect(LIBWebBased.gsDefaultLogin);
//            }
//            else
//            {
//                // f2
//                if (UserControlLibrary.Lamsoon.CommonFunction.checkSecurityLevel(LIBWebBased.gsConnectionString, LIBWebBased.gsUserName, LIBWebBased.gsProjectLevelID) == false)
//                {
//                    HttpContext.Current.Response.Redirect(LIBWebBased.gsDefaultLogin);
//                }
//            }
//        }

//        public static string sCurrentLevel(string psItemID)
//        {
//            int liCurrentLevel = Workflow.getLevel(psItemID);
//            return liCurrentLevel;
//        }

//        public static string sCurrentRole(string psItemID, string psUsername = "All")
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with10 = ClsLoadFieldHelper;
//            _with10.fAddSqlParameter("@ItemID", psItemID);
//            _with10.fAddSqlParameter("@psUsername", psUsername);
//            _with10.fBuildDataSet("stp_wf_all_GetCurrentApproverRole");
//            if (_with10.mbDataSetHasRecord)
//            {
//                return _with10.oLoadSqlField("role");
//            }
//            return LIBWebBased.BLANK;
//        }

//        public static string sUserRoleList(string psItemID, string psUsername)
//        {
//            string lsRoleList = LIBWebBased.BLANK;

//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with11 = ClsLoadFieldHelper;
//            _with11.fAddSqlParameter("@ItemID", psItemID);
//            _with11.fAddSqlParameter("@psUsername", psUsername);
//            _with11.fBuildDataSet("stp_wf_all_GetUserRole");
//            while (_with11.bHasNextRow)
//            {
//                lsRoleList += _with11.oLoadSqlField("role") + ",";
//            }

//            return lsRoleList;
//        }

//        public static bool bCanEdit(string psItemID, string psUsername, string psRole)
//        {
//            if (mWorkFlow.bIsCurrentApprover(psItemID, psUsername) & mWorkFlow.sCurrentRole(psItemID, psUsername) == psRole | psUsername == LIBWebBased.gsMarkID)
//            {
//                return true;
//            }
//            return false;
//        }

//        public static bool bIsCurrentApprover(string psItemID, string psUserID)
//        {
//            bool lbIsCurrentApprover = Workflow.isCurrentApprover(psUserID, psItemID, "");
//            int liCurrentLevel = sCurrentLevel(psItemID);

//            if (lbIsCurrentApprover & liCurrentLevel > 0)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        /// <summary>
//        /// When upgrade to userControlLibrary2010, need to use this function for approver list
//        /// </summary>
//        public static System.Data.DataSet getApproverList(string psItemID)
//        {
//            // Create Instance of Connection and Command Object
//            SqlConnection con = new SqlConnection(LIBWebBased.gsConnectionString);
//            SqlCommand cmd = new SqlCommand("stp_wf_getApprover", con);

//            // Mark the Command as a SPROC
//            cmd.CommandType = CommandType.StoredProcedure;

//            SqlParameter parameterItemID = new SqlParameter("@item_id", SqlDbType.VarChar, 50);
//            parameterItemID.Value = psItemID;
//            cmd.Parameters.Add(parameterItemID);
//            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//            System.Data.DataSet ds = new System.Data.DataSet();

//            // Open the connection and execute the Command
//            con.Open();
//            adapter.Fill(ds, "Approver");
//            con.Close();

//            //Dim cmd As SqlCommand = New SqlCommand
//            //cmd.Connection = New SqlConnection(connectionString)
//            //cmd.CommandText = "exec stp_wf_rss_GetEDINewFileID @psUsername,@CompleteFileDetail,@File_Desc"
//            //cmd.CommandType = CommandType.Text
//            //' Open the connection and execute the Command
//            //cmd.Parameters.Add("@psUsername", "EXEUpload")
//            //cmd.Parameters.Add("@CompleteFileDetail", SqlDbType.VarBinary).Value = lFileContent
//            //cmd.Parameters.Add("@File_Desc", sRemAdvFile)
//            //cmd.Connection.Open()
//            //cmd.ExecuteNonQuery()
//            //cmd = Nothing

//            return ds;
//        }

//        // handle upgrade only
//        //Private Function getLevel(ByVal item_id As String) As Integer

//        //    ' Create Instance of Connection and Command Object
//        //    Dim myConnection As SqlConnection = New SqlConnection(gsConnectionString)
//        //    Dim myCommand As SqlCommand = New SqlCommand("stp_wf_getLevel", myConnection)

//        //    ' Mark the Command as a SPROC
//        //    myCommand.CommandType = CommandType.StoredProcedure

//        //    ' Add Parameters to SPROC

//        //    Dim parameterItemID As SqlParameter = New SqlParameter("@item_id", SqlDbType.NVarChar, 50)
//        //    parameterItemID.Value = item_id
//        //    myCommand.Parameters.Add(parameterItemID)

//        //    Dim parameterLevel As SqlParameter = New SqlParameter("@level", SqlDbType.Int, 24)
//        //    parameterLevel.Direction = ParameterDirection.Output
//        //    myCommand.Parameters.Add(parameterLevel)

//        //    ' Open the connection and execute the Command
//        //    myConnection.Open()
//        //    myCommand.ExecuteNonQuery()
//        //    myConnection.Close()

//        //    Try
//        //        If parameterLevel.Value = -1 Then
//        //            Return -1
//        //        Else
//        //            Return parameterLevel.Value
//        //        End If
//        //    Catch ex As Exception
//        //        Return -1
//        //    End Try
//        //End Function
//        // handle upgrade only
//        //Private Function isCurrentApprover(ByVal username As String, ByVal item_id As String, ByRef originalApprover As String) As Boolean

//        //    ' Create Instance of Connection and Command Object
//        //    Dim myConnection As SqlConnection = New SqlConnection(gsConnectionString)
//        //    Dim myCommand As SqlCommand = New SqlCommand("stp_wf_isCurrentApproverDelegate", myConnection)

//        //    ' Mark the Command as a SPROC
//        //    myCommand.CommandType = CommandType.StoredProcedure

//        //    ' Add Parameters to SPROC
//        //    Dim parameterUserName As SqlParameter = New SqlParameter("@username", SqlDbType.NVarChar, 50)
//        //    parameterUserName.Value = username
//        //    myCommand.Parameters.Add(parameterUserName)

//        //    Dim parameterItemID As SqlParameter = New SqlParameter("@item_id", SqlDbType.NVarChar, 50)
//        //    parameterItemID.Value = item_id
//        //    myCommand.Parameters.Add(parameterItemID)

//        //    Dim parameterNum As SqlParameter = New SqlParameter("@Num", SqlDbType.Int, 24)
//        //    parameterNum.Direction = ParameterDirection.Output
//        //    myCommand.Parameters.Add(parameterNum)

//        //    Dim parameterOriginalApprover As SqlParameter = New SqlParameter("@originalApprover", SqlDbType.VarChar, 50)
//        //    parameterOriginalApprover.Direction = ParameterDirection.Output
//        //    myCommand.Parameters.Add(parameterOriginalApprover)

//        //    ' Open the connection and execute the Command
//        //    myConnection.Open()
//        //    myCommand.ExecuteNonQuery()
//        //    myConnection.Close()


//        //    If parameterNum.Value > 0 Then
//        //        originalApprover = parameterOriginalApprover.Value
//        //        Return True
//        //    Else
//        //        Return False
//        //    End If

//        //End Function

//        public static bool bIsApprovedItemID(string psItemID)
//        {
//            return nsSQL.mSQL.bSQLExecuteWithSinglePara("ItemID", psItemID, "stp_wf_all_bIsApprovedItemID");
//        }
//    }
//}

//#region "nsSQL"
//namespace nsSQL
//{
//    public static class mSQL
//    {

//        /// <summary>
//        /// Old place, will remove later, set private for checking where it used, the change to nsWorkFlow
//        /// </summary>
//        private static bool bIsCurrentApprover(string psItemID, string psUserID)
//        {
//            return nsWorkFlow.mWorkFlow.bIsCurrentApprover(psItemID, psUserID);
//        }

//        /// <summary>
//        /// return "" when Nothing/DBNull.
//        /// </summary>
//        public static object oHandleNullAndNothing(object pObject)
//        {
//            if (pObject == null | Information.IsDBNull(pObject))
//            {
//                return "";
//            }
//            else
//            {
//                return pObject;
//            }
//        }
//        /// <summary>
//        /// 当从数据库里面取到的日期数据为空时，返回当前日期
//        /// </summary>
//        public static object oHandleNullForDate(object pObject)
//        {
//            if (pObject == null | Information.IsDBNull(pObject))
//            {
//                return DateTime.Now;
//            }
//            else
//            {
//                return pObject;
//            }
//        }

//        /// <summary>
//        /// return Nothing when DBNull.
//        /// </summary>
//        public static object oHandleDBNull(object pObject)
//        {
//            if (Information.IsDBNull(pObject))
//            {
//                return null;
//            }
//            else
//            {
//                return pObject;
//            }
//        }

//        /// <summary>
//        /// return "" when Nothing.
//        /// </summary>
//        public static object oHandleNothing(object pObject)
//        {
//            if (pObject == null)
//            {
//                return LIBWebBased.BLANK;
//            }
//            else
//            {
//                return pObject;
//            }
//        }

//        /// <summary>
//        /// function to handle blank for SqlDataSource1 (normally in default.aspx), as we can not pass BLANK to it.
//        /// return EMPTY when blank.
//        /// </summary>
//        public static object oHandleBlank(string psText)
//        {
//            if (psText == LIBWebBased.BLANK)
//            {
//                return "EMPTY";
//            }
//            else
//            {
//                return psText;
//            }
//        }

//        /// <summary>
//        /// True when not Nothing/DBNull
//        /// </summary>
//        public static bool bHasValue(object pObject)
//        {
//            if (Information.IsDBNull(pObject))
//            {
//                return false;
//            }
//            else if (pObject == null)
//            {
//                return false;
//            }
//            else
//            {
//                return true;
//            }
//        }

//        /// <summary>
//        /// build a new connection, later may use factory.
//        /// </summary>
//        public static DbConnection NewDBConnection(string psConnectionString = LIBWebBased.BLANK)
//        {
//            if (psConnectionString == LIBWebBased.BLANK)
//            {
//                return new SqlConnection(LIBWebBased.gsConnectionString);
//            }
//            else
//            {
//                return new SqlConnection(psConnectionString);
//            }

//            return new SqlConnection(LIBWebBased.gsConnectionString);
//        }

//        /// <summary>
//        /// auto handle SQLQuery or StoredProcedure by detecting the pSQLParameter.
//        /// if pSQLParameter = nothing, SQLQuery
//        ///     else StoredProcedure
//        /// </summary>
//        public static System.Data.DataSet BuildDataSet(string psSQLString, SqlParameter[] pSQLParameter = null, string psConnectionString = LIBWebBased.BLANK)
//        {

//            ArrayList lArraylist = new ArrayList();

//            // Checking: Get List of STP parameter
//            if (LIBWebBased.gbLocalTesting)
//            {
//                try
//                {
//                    SqlCommand lSqlCommand = new SqlCommand();
//                    lSqlCommand.Connection = mSQL.NewDBConnection(psConnectionString);
//                    using (lSqlCommand.Connection)
//                    {
//                        lSqlCommand.Connection.Open();

//                        lSqlCommand.CommandText = psSQLString;
//                        lSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

//                        SqlCommandBuilder.DeriveParameters(lSqlCommand);

//                        foreach (SqlParameter a in lSqlCommand.Parameters)
//                        {
//                            lArraylist.Add(a.ParameterName);
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Debug.Print("Error: " + psSQLString + ": is not STP ");

//                }
//            }

//            System.Data.DataSet lDataSet = new System.Data.DataSet();
//            DbConnection lDBConnection = mSQL.NewDBConnection(psConnectionString);
//            mSQL.bCheckDBConnection(lDBConnection);
//            DbCommand lDBCommand = lDBConnection.CreateCommand();
//            try
//            {
//                using (lDBCommand)
//                {
//                    lDBCommand.CommandText = psSQLString;
//                    lDBCommand.Transaction = null;
//                    lDBCommand.CommandTimeout = 0;

//                    if (pSQLParameter == null)
//                    {
//                        lDBCommand.CommandType = CommandType.Text;
//                    }
//                    else
//                    {
//                        lDBCommand.CommandType = CommandType.StoredProcedure;

//                        // Print error parameter
//                        if (LIBWebBased.gbLocalTesting)
//                        {
//                            foreach (SqlParameter p in pSQLParameter)
//                            {
//                                if (!lArraylist.Contains(p.ParameterName))
//                                {
//                                    Debug.Print("Error: " + psSQLString + ": Dont Have " + p.ParameterName);
//                                }
//                            }
//                        }
//                        foreach (SqlParameter p in pSQLParameter)
//                        {
//                            lDBCommand.Parameters.Add(p);
//                        }

//                    }

//                    SqlDataAdapter lSqlDataAdapter = null;
//                    lSqlDataAdapter = new SqlDataAdapter(lDBCommand);
//                    lSqlDataAdapter.Fill(lDataSet);
//                    lDBCommand.Parameters.Clear();

//                }
//            }
//            catch (Exception ex)
//            {
//                try
//                {
//                    lDBCommand.Transaction.Rollback();

//                }
//                catch (Exception ex2)
//                {
//                }
//            }
//            finally
//            {
//                lDBConnection.Close();
//            }
//            return lDataSet;
//        }

//        /// <summary>
//        /// lazy code. to Check DBConnection of all kinds of connection in VB.Net.(prepare for future web base or other use.)
//        /// </summary>
//        public static bool bCheckDBConnection(DbConnection pDBCon)
//        {
//            if (LIBWebBased.MyComputer.Network.IsAvailable)
//            {
//                if (pDBCon.State == ConnectionState.Open)
//                {
//                    return true;
//                }
//                else
//                {
//                    if (pDBCon.State != ConnectionState.Open)
//                    {
//                        pDBCon.Open();
//                    }
//                }
//            }
//            return false;
//        }

//        /// <summary>
//        /// lazy code. to execute 1 SQL. If you have to execute more than 1 in the same time, you should use the ClassSQLExecuteHelper directly.
//        /// </summary>
//        public static bool bSQLExecute(string psSQLString)
//        {
//            ClassSQLExecuteHelper clsSQLExecuteHelper = new ClassSQLExecuteHelper();
//            clsSQLExecuteHelper.AddSQL(psSQLString);
//            return clsSQLExecuteHelper.bExecute();
//        }

//        public static bool bSQLExistRecord(string psSQLString)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with12 = ClsLoadFieldHelper;
//            _with12.fBuildDataSet(psSQLString);
//            return _with12.mbDataSetHasRecord;
//        }

//        /// <summary>
//        /// STP Has record with any 1 para
//        /// </summary>
//        public static bool bSQLExecuteWithSinglePara(string psFirstParameter, string psFirstParameterValue, string psStoreProcedureName)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with13 = ClsLoadFieldHelper;
//            _with13.fAddSqlParameter(psFirstParameter, psFirstParameterValue);
//            _with13.fBuildDataSet(psStoreProcedureName);
//            return _with13.mbDataSetHasRecord;
//        }

//        /// <summary>
//        /// STP with 2 parameters only, Item_ID and Field_Key
//        /// </summary>
//        public static void bSQLFieldKeyInsertDelete(string psItem_ID, string psField_Key, string psSTPName)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with14 = ClsLoadFieldHelper;
//            _with14.fAddSqlParameter("@Item_ID", psItem_ID);
//            _with14.fAddSqlParameter("@Field_Key", psField_Key);
//            _with14.fBuildDataSet(psSTPName);
//        }

//        /// <summary>
//        /// STP/SQL Load 1 field 
//        /// </summary>
//        public static string sSQLLoadOneField(string psSQLString, string psFieldName)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with15 = ClsLoadFieldHelper;
//            _with15.fBuildDataSet(psSQLString);
//            return _with15.oLoadSqlField(psFieldName);
//        }

//        /// <summary>
//        /// Dataset Load 1 field 
//        /// </summary>
//        public static string sSQLLoadOneField(System.Data.DataSet pDataSet, string psFieldName)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with16 = ClsLoadFieldHelper;
//            _with16.SetDataSet(pDataSet);
//            return _with16.oLoadSqlField(psFieldName);
//        }

//        public static Hashtable BuildHashTable(string psLang, string psStoredProcedure = LIBWebBased.BLANK)
//        {

//            if (psStoredProcedure == LIBWebBased.BLANK)
//            {
//                psStoredProcedure = LIBWebBased.gsHashTableStpName;
//            }
//            Hashtable lHashTable = new Hashtable();
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with17 = ClsLoadFieldHelper;
//            _with17.fAddSqlParameter("@lang", psLang);
//            System.Data.DataSet lDataSet = _with17.fBuildDataSet(psStoredProcedure);
//            int liKeyIndex = 0;
//            int liTextIndex = 1;
//            try
//            {
//                if (nsCommon.mCommon.bIsKeyField(lDataSet.Tables[0].Columns[1].Caption))
//                {
//                    liKeyIndex = 1;
//                    liTextIndex = 0;
//                }

//            }
//            catch (Exception ex)
//            {
//            }
//            while (_with17.bHasNextRow)
//            {
//                lHashTable.Add(_with17.oLoadSqlFieldByIndex(liKeyIndex).ToString.ToLower, _with17.oLoadSqlFieldByIndex(liTextIndex));
//            }
//            return lHashTable;
//        }
//    }

//}
//#endregion

//// Last tidy up: 20120205
//#region "nsWebControl"
//namespace nsWebControl
//{
//    public static class mWebControl
//    {
//        public static string ModeDisplay()
//        {
//            return Action.Display;
//        }

//        public static string ModeEdit()
//        {
//            return Action.Edit;
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

//// Web Based
//#region "nsCommon"
//namespace nsCommon
//{
//    public static class mCommon
//    {

//        public static void DebugPrint(string psString, string psHeader = LIBWebBased.BLANK)
//        {
//            System.Diagnostics.Debug.Print(psString);
//        }

//        // Unknown use
//        public static void fDropDownListNoDataReminder(UserControlLibrary.Lamsoon.SmartDropDownList pSmartDropDownList, string psReminderText)
//        {
//            // Add extra description when there is no data.
//            if (pSmartDropDownList.Items.Count == 1)
//            {
//                pSmartDropDownList.Items(0).Text += ", " + psReminderText;
//            }
//        }
//        #region "ForeColor"
//        /// <summary>
//        /// return red color when (Value less than zero)
//        /// </summary>
//        public static System.Drawing.Color ForeColorWhenZero(object psValue)
//        {
//            if (nsSQL.mSQL.oHandleNullAndNothing(psValue).ToString() == LIBWebBased.BLANK)
//            {
//                return System.Drawing.Color.Black;
//            }
//            else if (psValue >= 0)
//            {
//                return System.Drawing.Color.Black;
//            }
//            else
//            {
//                return System.Drawing.Color.Red;
//            }
//        }

//        /// <summary>
//        /// return red color when (Value greater than Limit)
//        /// </summary>
//        public static System.Drawing.Color ForeColorToRedWhenOverLimit(object psValue, object psLimit)
//        {
//            psValue = nsSQL.mSQL.oHandleNullAndNothing(psValue);
//            psLimit = nsSQL.mSQL.oHandleNullAndNothing(psLimit);

//            if (psValue.ToString() == LIBWebBased.BLANK | psLimit.ToString() == LIBWebBased.BLANK)
//            {
//                return System.Drawing.Color.Black;
//            }
//            if (psValue == 0 | psLimit == 0)
//            {
//                return System.Drawing.Color.Black;
//            }
//            string lsUnit = LIBWebBased.BLANK;
//            try
//            {
//                if (psValue > psLimit)
//                {
//                    return System.Drawing.Color.Red;
//                }
//                else
//                {
//                    return System.Drawing.Color.Black;
//                }
//            }
//            catch (Exception ex)
//            {
//                return System.Drawing.Color.Black;
//            }
//        }

//        /// <summary>
//        /// HTML, set red when (Value > Limit) or (Value + limit > 0)
//        /// </summary>
//        public static string ForeColorToRedWhenOverZero(object psValue, object psLimit)
//        {
//            psValue = nsSQL.mSQL.oHandleNullAndNothing(psValue);
//            psLimit = nsSQL.mSQL.oHandleNullAndNothing(psLimit);
//            string lsDisplayText = psValue;
//            psValue = psValue.ToString().Replace("%", "");

//            if (psValue.ToString() == LIBWebBased.BLANK | psLimit.ToString() == LIBWebBased.BLANK)
//            {
//                return lsDisplayText;
//            }
//            if (psValue == 0 | psLimit == 0)
//            {
//                return lsDisplayText;
//            }
//            string lsUnit = LIBWebBased.BLANK;
//            try
//            {
//                if (psLimit > 0)
//                {
//                    if (psValue > psLimit)
//                    {
//                        return "<font color='red'>" + lsDisplayText + "</font>";
//                    }
//                    else
//                    {
//                        return lsDisplayText;
//                    }
//                }
//                else
//                {
//                    if (psValue + psLimit < 0)
//                    {
//                        return "<font color='red'>" + lsDisplayText + "</font>";
//                    }
//                    else
//                    {
//                        return lsDisplayText;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                return psValue;
//            }
//        }

//        public static string ForeColorToRedWhenOverToday(object psValue)
//        {
//            psValue = nsSQL.mSQL.oHandleNullAndNothing(psValue);

//            if (psValue.ToString() == LIBWebBased.BLANK)
//            {
//                return LIBWebBased.BLANK;
//            }
//            if (DateAndTime.DateDiff(DateInterval.Day, psValue, DateAndTime.Now) > 0)
//            {
//                return "<font color='red'>" + psValue + "</font>";
//            }
//            else
//            {
//                return psValue;
//            }

//        }

//        /// <summary>
//        /// HTML, set color base on percentage change.
//        /// </summary>
//        public static string ForeColorOfPercentageChange(object psValue, string psGridTitle = "Growth")
//        {
//            psValue = nsSQL.mSQL.oHandleNullAndNothing(psValue);
//            if (psValue == LIBWebBased.BLANK)
//            {
//                return psValue;
//            }
//            if (psGridTitle.Contains("Growth"))
//            {
//                if (psValue < 0)
//                {
//                    return "<font color='red'>" + psValue + "</font>";
//                }
//                else if (psValue > 50)
//                {
//                    return "<font color='green'>" + psValue + "</font>";
//                }
//                else if (psValue > 20)
//                {
//                    return "<font color='blue'>" + psValue + "</font>";
//                }
//                else
//                {
//                    return psValue;
//                }
//            }
//            else
//            {
//                return psValue;
//            }
//        }


//        public static string ForeColorOfAchievementChange(object psValue, string psGridTitle = "Growth")
//        {
//            psValue = nsSQL.mSQL.oHandleNullAndNothing(psValue);
//            if (psValue == LIBWebBased.BLANK)
//            {
//                return psValue;
//            }
//            if (psGridTitle.Contains("Growth"))
//            {
//                if (psValue < 100)
//                {
//                    return "<font color='red'>" + psValue + "</font>";
//                }
//                else if (psValue > 150)
//                {
//                    return "<font color='green'>" + psValue + "</font>";
//                }
//                else if (psValue > 120)
//                {
//                    return "<font color='blue'>" + psValue + "</font>";
//                }
//                else
//                {
//                    return psValue;
//                }
//            }
//            else
//            {
//                return psValue;
//            }
//        }

//        /// <summary>
//        /// HTML, set red color if true
//        /// </summary>
//        public static string ForeColorToRed(object psValue, bool pbTurnRed)
//        {
//            if (pbTurnRed)
//            {
//                return "<font color='red' >" + psValue + "</font>";
//            }
//            else
//            {
//                return psValue;
//            }
//        }

//        /// <summary>
//        /// HTML, set red color if has psTooltips
//        /// </summary>
//        public static string ForeColorToRed(object psValue, string psTooltips)
//        {
//            if (psTooltips != LIBWebBased.BLANK)
//            {
//                return "<font color='red' title=\"" + psTooltips + "\">" + psValue + "</font>";
//            }
//            else
//            {
//                return psValue;
//            }
//        }
//        #endregion

//        /// <summary>
//        /// Should use nsScript
//        /// </summary>
//        public static void AlertNoRecord(System.Web.UI.TemplateControl pPage)
//        {
//            nsScript.mScript.AlertNoRecord(pPage);
//        }

//        /// <summary>
//        /// Should use nsScript
//        /// </summary>
//        public static void AlertRepeatRecord(System.Web.UI.TemplateControl pPage)
//        {
//            nsScript.mScript.AlertDuplidated(pPage);
//        }

//        public static string sEmptyDataText()
//        {
//            return ("<div style=\"text-align:center ; color:Red;\">" + LIBWebBased.GlobalClassHashTableHelper.sGetHash("沒有記錄") + "</div>");
//        }

//        public static string bExistData(object psData)
//        {
//            try
//            {
//                if (psData != LIBWebBased.BLANK)
//                {
//                    return true;
//                }
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//            return false;
//        }

//        public static bool bIsKeyField(string psColumnName)
//        {
//            if (psColumnName == "DataValueField" | psColumnName.ToLower().Contains("id") | psColumnName.ToLower().Contains("key"))
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        public static bool bValidJDESupplierCode(string psJDRCode, string psJDELimitation)
//        {
//            string[] lsCodeLimitationList = psJDELimitation.Split("/");
//            foreach (string lsCodeLimitation in lsCodeLimitationList)
//            {
//                if (psJDRCode.StartsWith(lsCodeLimitation))
//                {
//                    return true;
//                }
//            }
//            return false;
//        }

//        // Unknown use
//        //Public Sub fDropDownListNoDataReminder(ByVal pSmartDropDownList As UserControlLibrary.Lamsoon.SmartDropDownList, _
//        //                   ByVal psReminderText As String)
//        //    ' Add extra description when there is no data.
//        //    If pSmartDropDownList.Items.Count = 1 Then
//        //        pSmartDropDownList.Items(0).Text += ", " & psReminderText
//        //    End If
//        //End Sub

//        public static void fControlSetVisible(Control pControl, object pbVisible)
//        {
//            try
//            {
//                if (pbVisible == true)
//                {
//                    pControl.Visible = true;
//                }
//                else
//                {
//                    pControl.Visible = false;
//                }
//            }
//            catch (Exception ex)
//            {
//                pControl.Visible = false;
//            }
//        }

//        /// <summary>
//        /// get YTD Year start  of today / PreviousNYear, and can set DateFrom and DateTo.
//        /// piyear = 0, this year
//        /// piYear = -1, last year
//        /// </summary>
//        public static string sGetYearYTD(ref string psDateFrom, ref string psDateTo, int piPreviousNYear = 0)
//        {
//            return nsDateTime.mDataTime.sGetYTDStartYearAndSetFromTo(ref psDateFrom, ref psDateTo, piPreviousNYear);
//        }

//        #region "SQL"

//        public static void URL404Log(string psUsername, string psProjectCode, string lsUrl, string psRemark)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with18 = ClsLoadFieldHelper;
//            _with18.fAddSqlParameter("@LoginBy", psUsername);
//            _with18.fAddSqlParameter("@ProjectCode", psProjectCode);
//            _with18.fAddSqlParameter("@Url", lsUrl);
//            _with18.fAddSqlParameter("@Remark", psRemark);
//            _with18.fBuildDataSet("stp_wf_all_log_UpdateURL404");
//        }



//        public static void PageLoginLog(string psUsername, string psProjectCode, string lsUrl, string psRemark)
//        {
//            if (LIBWebBased.gbLocalTesting)
//            {
//                return;
//            }

//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with19 = ClsLoadFieldHelper;
//            _with19.fAddSqlParameter("@LoginBy", psUsername);
//            _with19.fAddSqlParameter("@ProjectCode", psProjectCode);
//            _with19.fAddSqlParameter("@Url", lsUrl);
//            _with19.fAddSqlParameter("@Remark", psRemark);
//            _with19.fBuildDataSet("stp_wf_all_log_UpdatePageLogin");
//        }

//        public static void PageFunctionLog(object psUsername, object psProjectCode, object lsUrl, object psRemark, object psFunctionCode, object psRegionCode, object psCityCode, object psDivisionCode)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with20 = ClsLoadFieldHelper;
//            _with20.fAddSqlParameter("@LoginBy", psUsername);
//            _with20.fAddSqlParameter("@ProjectCode", psProjectCode);
//            _with20.fAddSqlParameter("@Url", lsUrl);
//            _with20.fAddSqlParameter("@Remark", psRemark);
//            _with20.fAddSqlParameter("@FunctionCode", psFunctionCode);
//            _with20.fAddSqlParameter("@RegionCode", psRegionCode);
//            _with20.fAddSqlParameter("@CityCode", psCityCode);
//            _with20.fAddSqlParameter("@DivisionCode", psDivisionCode);
//            _with20.fBuildDataSet("stp_wf_all_log_UpdatePageFunction");
//        }

//        public static void PageFunctionLogByPage(ref System.Web.UI.Page pMe, object psRemark, object psFunctionCode, object psRegionCode, object psCityCode, object psDivisionCode)
//        {
//            string lsUrl = pMe.Request.RawUrl;
//            mCommon.PageFunctionLog(LIBWebBased.gsUserName, gsProjectCode, lsUrl, psRemark, psFunctionCode, psRegionCode, psCityCode, psDivisionCode);
//        }

//        public static bool bHasUserPrivilege(string psProjectCode, string psFunction, string psUserName)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with21 = ClsLoadFieldHelper;
//            _with21.fAddSqlParameter("@Project_Code", psProjectCode);
//            _with21.fAddSqlParameter("@Function_Name", psFunction);
//            _with21.fAddSqlParameter("@UserName", psUserName);
//            _with21.fBuildDataSet("stp_wf_all_FunctionUserPrivilege");
//            if (_with21.mbDataSetHasRecord)
//            {
//                return true;
//            }
//            return false;
//        }

//        /// <summary>
//        /// Check the user has access right on this Function or not.
//        /// if not, hide the Object.
//        /// </summary>
//        public static void AddProjectFunctionAccessRight(string psFunctionName, object pObject)
//        {
//            if (mCommon.bHasUserPrivilege(gsProjectCode, psFunctionName, LIBWebBased.GlobalClassHashTableHelper.msUserName))
//            {
//                pObject.Visible = true;
//            }
//            else
//            {
//                pObject.Visible = false;
//            }
//        }

//        /// <summary>
//        /// 得到项目编号
//        /// </summary>
//        /// <param name="psStaffID">员工编号</param>
//        /// <param name="psProjectCode">项目代码</param>
//        public static string sGetProjectNum(string psStaffID, string psProjectCode)
//        {
//            string lsProjectNum = "";
//            if (!string.IsNullOrEmpty(psStaffID))
//            {
//                System.Data.DataSet lDataSet = null;
//                ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//                var _with22 = ClsLoadFieldHelper;
//                _with22.fAddSqlParameter("@staff_id", psStaffID);
//                _with22.fAddSqlParameter("@project_code", psProjectCode);
//                lDataSet = _with22.fBuildDataSet("stp_wf_getProjectNum");

//                string lsSeqNo = Strings.Trim(Convert.ToString(lDataSet.Tables[0].Rows[0]["seq_no"] + 1));
//                for (int i = 1; i <= 8 - Strings.Len(lsSeqNo); i++)
//                {
//                    lsProjectNum += "0";
//                }
//                lsProjectNum += lsSeqNo;
//                lsProjectNum = lDataSet.Tables[0].Rows[0]["company_id"] + lDataSet.Tables[0].Rows[0]["dept_id"] + psProjectCode + lsProjectNum;
//            }
//            return lsProjectNum;
//        }

//        public static void fDeleteAttachment(string psItemID, string psFilePath, string psSTPName)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with23 = ClsLoadFieldHelper;
//            _with23.fAddSqlParameter("@Item_ID", psItemID);
//            _with23.fAddSqlParameter("@File_Path", psFilePath);
//            _with23.fBuildDataSet(psSTPName);
//        }

//        public static void fDeleteFieldKey(string psItemID, string psFieldKey, string psSTPName)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with24 = ClsLoadFieldHelper;
//            _with24.fAddSqlParameter("@Item_ID", psItemID);
//            _with24.fAddSqlParameter("@Field_Key", psFieldKey);
//            _with24.fBuildDataSet(psSTPName);
//        }

//        public static void fDeleteRecord(Page psPage, string psItemID, string psStoredProcedure)
//        {
//            nsSQL.mSQL.bSQLExecuteWithSinglePara("ItemID", psItemID, psStoredProcedure);
//            nsScript.mScript.RefreshParentPage(psPage, true);
//        }

//        public static void fWorkFlowInsert1(Page pPage, string psItemID)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with25 = ClsLoadFieldHelper;
//            _with25.fAddSqlParameter("@itemId", psItemID);
//            _with25.fAddSqlParameter("@username", LIBWebBased.gsUserName());
//            _with25.fAddSqlParameter("@IPaddress", pPage.Request.ServerVariables["Remote_Addr"]);
//            _with25.fAddSqlParameter("@Project_Type", gsProjectCode);
//            _with25.fBuildDataSet("stp_wf_all_WFInsert_Part1");
//        }

//        public static void fWorkFlowInsert2(Page pPage, string psItemID, string psStoredProcedureName)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with26 = ClsLoadFieldHelper;
//            _with26.fAddSqlParameter("@itemId", psItemID);
//            _with26.fAddSqlParameter("@username", LIBWebBased.gsUserName());
//            _with26.fAddSqlParameter("@IPaddress", pPage.Request.ServerVariables["Remote_Addr"]);
//            _with26.fBuildDataSet(psStoredProcedureName);
//        }

//        public static bool bCanDeleteItem(string psItemID)
//        {
//            return nsSQL.mSQL.bSQLExecuteWithSinglePara("@ItemID", psItemID, "stp_wf_all_bCanDeleteItem");
//        }

//        public static string sRSSReportName()
//        {
//            return nsSQL.mSQL.oHandleNullAndNothing(sReportName(HttpContext.Current.Request.QueryString["ReportID"]));
//        }

//        private static string sReportName(string psReportID)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with27 = ClsLoadFieldHelper;
//            _with27.fAddSqlParameter("@ReportID", psReportID);
//            _with27.fBuildDataSet("stp_wf_rss_GetReportInfoByReportID");
//            return _with27.oLoadSqlField("ReportName");
//        }

//        /// <summary>
//        /// 获取员工名称
//        /// </summary>
//        /// <param name="psStaffId">员工编号</param>
//        /// <param name="lang">语言种类</param>
//        /// <returns>员工名称</returns>
//        public static string sGetStaffName(string psStaffId, string lang)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with28 = ClsLoadFieldHelper;
//            _with28.fAddSqlParameter("@username", psStaffId);
//            _with28.fAddSqlParameter("@lang", lang);
//            _with28.fBuildDataSet("stp_wf_all_GetUserAccInfoDetail");
//            if (_with28.mbDataSetHasRecord)
//            {
//                return _with28.oLoadSqlField("StaffName");
//            }
//            return LIBWebBased.BLANK;
//        }

//        public static string sGetStaffNameAndDepartment(string psStaffId, string lang)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with29 = ClsLoadFieldHelper;
//            _with29.fAddSqlParameter("@username", psStaffId);
//            _with29.fAddSqlParameter("@lang", lang);
//            _with29.fBuildDataSet("stp_wf_all_GetUserAccInfoDetail");
//            if (_with29.mbDataSetHasRecord)
//            {
//                return _with29.oLoadSqlField("StaffName") + " " + _with29.oLoadSqlField("DepartmentName");
//            }
//            return LIBWebBased.BLANK;
//        }

//        public static string sGetStaffID(string psSearchKey)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with30 = ClsLoadFieldHelper;
//            _with30.fAddSqlParameter("@key", psSearchKey);
//            _with30.fBuildDataSet("stp_all_SearchStaff");
//            if (_with30.mbDataSetHasRecord)
//            {
//                return _with30.oLoadSqlField("staff_id");
//            }
//            return LIBWebBased.BLANK;
//        }

//        public static string sGetStaffInfo(string psStaffId, string lang = "sc")
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with31 = ClsLoadFieldHelper;
//            _with31.fAddSqlParameter("@username", psStaffId);
//            _with31.fAddSqlParameter("@lang", lang);
//            _with31.fBuildDataSet("stp_wf_all_GetUserAccInfoDetail");
//            if (_with31.mbDataSetHasRecord)
//            {
//                return _with31.oLoadSqlField("psUsername") + " - " + _with31.oLoadSqlField("StaffName") + " - " + _with31.oLoadSqlField("grade");
//            }
//            return LIBWebBased.BLANK;
//        }

//        public static string sGetStaffEmail(string psStaffId, string lang = "sc")
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with32 = ClsLoadFieldHelper;
//            _with32.fAddSqlParameter("@username", psStaffId);
//            _with32.fAddSqlParameter("@lang", lang);
//            _with32.fBuildDataSet("stp_wf_all_GetUserAccInfoDetail");
//            if (_with32.mbDataSetHasRecord)
//            {
//                return _with32.oLoadSqlField("email").ToString.Replace(",", "");
//            }
//            return LIBWebBased.BLANK;
//        }

//        public static string sItemShortCode(string psItemCode)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with33 = ClsLoadFieldHelper;
//            _with33.fAddSqlParameter("@ItemCode", psItemCode);
//            _with33.fBuildDataSet("stp_wf_all_LoadProductShortCode");

//            if (_with33.mbDataSetHasRecord)
//            {
//                return _with33.oLoadSqlField("ItemCode");
//            }
//            return LIBWebBased.BLANK;
//        }

//        public static string sItemName(string psItemCode)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with34 = ClsLoadFieldHelper;
//            _with34.fAddSqlParameter("@ItemCode", psItemCode);
//            _with34.fBuildDataSet("stp_wf_all_LoadProductShortCode");

//            if (_with34.mbDataSetHasRecord)
//            {
//                return _with34.oLoadSqlField("ItemName");
//            }
//            return LIBWebBased.BLANK;
//        }
//        public static string sGetExchangeRateRMBToHKD()
//        {

//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with35 = ClsLoadFieldHelper;
//            _with35.fBuildDataSet("stp_wf_rss_GetExchangeRate");
//            return _with35.oLoadSqlField("ExchangeRate");

//        }

//        public static string sDivisionName(string psDivisionCode, string psLang)
//        {
//            string lsDivision = LIBWebBased.BLANK;
//            if (psDivisionCode != LIBWebBased.BLANK)
//            {
//                string lsSQLString = LIBWebBased.BLANK;
//                ClassSQLLoadHelper ClsSQLLoadHelper = new ClassSQLLoadHelper();
//                var _with36 = ClsSQLLoadHelper;
//                _with36.TableName = "tbl_division";
//                _with36.SQLExtraCriteria = " div_id = " + LIBWebBased.VarSQLString(psDivisionCode);
//                _with36.AddRequiredField("div_" + psLang);
//                lsSQLString = _with36.sGenerateSQLSelect;

//                ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//                var _with37 = ClsLoadFieldHelper;
//                _with37.fBuildDataSet(lsSQLString);
//                if (_with37.mbDataSetHasRecord)
//                {
//                    lsDivision = _with37.oLoadSqlField("div_" + psLang);
//                }
//            }
//            return lsDivision;
//        }

//        public static string sCustomerDivisionCode(string psCustomerCode)
//        {
//            string lsDivision = LIBWebBased.BLANK;
//            if (psCustomerCode != LIBWebBased.BLANK)
//            {
//                ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//                var _with38 = ClsLoadFieldHelper;
//                _with38.fAddSqlParameter("cust_id", psCustomerCode);
//                _with38.fBuildDataSet("stp_wf_all_getCustomerDivision");
//                lsDivision = _with38.oLoadSqlField("ddiv_id");
//            }
//            return lsDivision;
//        }

//        public static bool bExistCustomerCode(string psCustomerCode)
//        {
//            return nsSQL.mSQL.bSQLExecuteWithSinglePara("CustomerCode", psCustomerCode, "stp_wf_rss_bExistCustomerCode");
//        }

//        public static bool bExistItemCode2(string psItemCode)
//        {
//            return nsSQL.mSQL.bSQLExecuteWithSinglePara("ItemCode", psItemCode, "stp_wf_rss_bExistItemCode2");
//        }

//        public static string sCompanyDivisionCode(string psCompanyCode)
//        {
//            string lsDivision = LIBWebBased.BLANK;
//            if (psCompanyCode != LIBWebBased.BLANK)
//            {
//                ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//                var _with39 = ClsLoadFieldHelper;
//                _with39.fAddSqlParameter("Company_id", psCompanyCode);
//                _with39.fBuildDataSet("stp_wf_all_LoadCompanyInfo");
//                lsDivision = _with39.oLoadSqlField("div_id");
//            }
//            return lsDivision;
//        }

//        public static string sCompanyCurrency(string psCompanyCode)
//        {
//            string lsDivision = LIBWebBased.BLANK;
//            if (psCompanyCode != LIBWebBased.BLANK)
//            {
//                ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//                var _with40 = ClsLoadFieldHelper;
//                _with40.fAddSqlParameter("Company_id", psCompanyCode);
//                _with40.fBuildDataSet("stp_wf_all_LoadCompanyInfo");
//                lsDivision = _with40.oLoadSqlField("Currency");
//            }
//            return lsDivision;
//        }

//        public static string sCompanyRegistrationPlace(string psCompanyID)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with41 = ClsLoadFieldHelper;
//            _with41.fAddSqlParameter("Company_id", psCompanyID);
//            _with41.fBuildDataSet("stp_wf_bas_LoadCompanySubInfo");
//            return LIBWebBased.GlobalClassHashTableHelper.sGetHash(_with41.oLoadSqlField("CompanyRegistrationPlace"));
//        }

//        public static string sCompanyJDECompanyCodeRestriction(string psCompanyID)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with42 = ClsLoadFieldHelper;
//            _with42.fAddSqlParameter("Company_id", psCompanyID);
//            _with42.fBuildDataSet("stp_wf_bas_LoadCompanySubInfo");
//            return LIBWebBased.GlobalClassHashTableHelper.sGetHash(_with42.oLoadSqlField("JDECompanyCodeRestriction"));
//        }

//        public static string sCompanyCategory(string psCompanyID)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with43 = ClsLoadFieldHelper;
//            _with43.fAddSqlParameter("Company_id", psCompanyID);
//            _with43.fBuildDataSet("stp_wf_bas_LoadCompanySubInfo");
//            return LIBWebBased.GlobalClassHashTableHelper.sGetHash(_with43.oLoadSqlField("CompanyCategory"));
//        }

//        public static string sIndexBase(string psRType, string psCat)
//        {
//            //1. For regional - Unit price and GP index use SZ as 100.

//            //2. For brands and price segment- use
//            //       Flour(-GS)
//            //       Oil(-Knife)
//            //       Detergent(-AXE)

//            //3. For(Category - us)
//            //       Flour(-bakery)
//            //       Oil - Peanut oil
//            //       Detergent - Dish wash detergent

//            //4. For Supply mode - use Direct

//            //5.  For Channel Type - no change

//            //6.  For Outlet Type - no change

//            //7.  For Location types - use local

//            //8.  For contract type - use local
//            string lsBase = LIBWebBased.BLANK;
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with44 = ClsLoadFieldHelper;
//            _with44.fAddSqlParameter("@Rtype", psRType);
//            _with44.fAddSqlParameter("@Cat", psCat);
//            _with44.fBuildDataSet("stp_wf_rss_getIndexBase");
//            lsBase = _with44.oLoadSqlField("base");
//            if (lsBase != LIBWebBased.BLANK)
//            {
//                return lsBase;
//            }
//            else
//            {
//                return "[All]";
//            }
//        }
//        #endregion

//        #region "String"
//        public static void fHyperLinkInvisibleWhenBlank(string pString, HyperLink pHyperLink)
//        {
//            if (pString == LIBWebBased.BLANK)
//            {
//                pHyperLink.Visible = false;
//            }
//            else
//            {
//                pHyperLink.Visible = true;
//                pHyperLink.NavigateUrl = pString;
//            }
//        }

//        /// <summary>
//        /// not yet use.
//        /// </summary>
//        private static string sSQLFilter(string psSQLString)
//        {
//            psSQLString = psSQLString.Replace("_", "");
//            //过滤SQL注入_  
//            psSQLString = psSQLString.Replace("*", "");
//            //过滤SQL注入*  
//            psSQLString = psSQLString.Replace("  ", "");
//            //过滤SQL注入空格  
//            psSQLString = psSQLString.Replace(Strings.Chr(34), "");
//            //过滤SQL注入"  
//            psSQLString = psSQLString.Replace(Strings.Chr(39), "");
//            //过滤SQL注入'  
//            psSQLString = psSQLString.Replace(Strings.Chr(91), "");
//            //过滤SQL注入[  
//            psSQLString = psSQLString.Replace(Strings.Chr(93), "");
//            //过滤SQL注入]  
//            psSQLString = psSQLString.Replace(Strings.Chr(37), "");
//            //过滤SQL注入%  
//            psSQLString = psSQLString.Replace(Strings.Chr(58), "");
//            //过滤SQL注入:  
//            psSQLString = psSQLString.Replace(Strings.Chr(59), "");
//            //过滤SQL注入;  
//            psSQLString = psSQLString.Replace(Strings.Chr(43), "");
//            //过滤SQL注入+  
//            psSQLString = psSQLString.Replace("{", "");
//            //过滤SQL注入{  
//            psSQLString = psSQLString.Replace("}", "");
//            //过滤SQL注入}  
//            psSQLString = psSQLString.Replace("<", "");
//            //过滤SQL注入<  
//            psSQLString = psSQLString.Replace(">", "");
//            //过滤SQL注入>
//            psSQLString = psSQLString.Replace(".", "");
//            //过滤SQL注入.
//            return psSQLString;
//        }

//        /// <summary>
//        /// HashTable Checking,
//        /// If hashkey = blank, then return blank.
//        /// else if pHashTable(psHashKey) = blank, then return blank.
//        /// </summary>
//        public static string sGetHash(Hashtable pHashTable, object psHashKey)
//        {
//            try
//            {
//                psHashKey = nsSQL.mSQL.oHandleNullAndNothing(psHashKey);
//                if (psHashKey.ToString() == LIBWebBased.BLANK)
//                {
//                    // Debug.Print(psHashKey)
//                    return LIBWebBased.BLANK;
//                }
//                else
//                {
//                    string lsHashKey = psHashKey.ToString().ToLower();
//                    if (pHashTable[lsHashKey] != LIBWebBased.BLANK)
//                    {
//                        // Debug.Print(pHashTable(psHashKey))
//                        return pHashTable[lsHashKey];
//                    }
//                    else
//                    {
//                        if (LIBWebBased.gsShowNotUsedHashKey)
//                        {
//                            Debug.Print("NoTranslation:" + psHashKey);
//                            // NotSet3Lang
//                        }
//                        return psHashKey;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                return psHashKey;
//            }
//        }

//        public static Hashtable sGetDynamicHeaderHashTable(ListControl pDDLColumnOption)
//        {
//            string lsHeader = LIBWebBased.BLANK;
//            if (pDDLColumnOption == null)
//            {
//                lsHeader = "ByInventoryColumn";
//            }
//            else
//            {
//                lsHeader = pDDLColumnOption.SelectedValue;
//            }
//            Hashtable lHashTable = new Hashtable();
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with45 = ClsLoadFieldHelper;
//            _with45.fAddSqlParameter("@ByReportRowType", lsHeader);
//            System.Data.DataSet lDataSet = _with45.fBuildDataSet("stp_wf_rss_GridStandardReportHeaderTranslationField");
//            int liKeyIndex = 0;
//            int liTextIndex = 1;

//            while (_with45.bHasNextRow)
//            {
//                lHashTable.Add(_with45.oLoadSqlFieldByIndex(liKeyIndex), _with45.oLoadSqlFieldByIndex(liTextIndex));
//            }
//            return lHashTable;
//        }

//        public static string fStringToYesNo(object psValue)
//        {
//            return nsString.mString.fStringToYesNo(psValue);
//        }


//        public static string sOmitLongString(object psString)
//        {
//            return nsString.mString.sOmitLongString(psString);
//        }

//        public static string sCombineString(string psParent, string psSon)
//        {
//            return nsString.mString.sCombineString(psParent, psSon, ",");
//        }
//        #endregion

//        #region "GridView"
//        public static void fGridViewSetAllColumnWidth(GridView pGridView, int piWidth)
//        {
//            for (int i = 0; i <= pGridView.Columns.Count - 1; i++)
//            {
//                pGridView.Columns[i].ItemStyle.Width = Unit.Pixel(piWidth);
//                pGridView.Columns[i].HeaderStyle.Width = Unit.Pixel(piWidth);
//            }
//        }

//        public static void fGridViewInvisibleColumnUsingHeaderText(GridView pGridView, string pHeaderText, bool pbVisible)
//        {
//            for (int i = 0; i <= pGridView.Columns.Count - 1; i++)
//            {
//                if (LIBWebBased.GlobalClassHashTableHelper.sGetHash(pGridView.Columns[i].HeaderText).Contains(LIBWebBased.GlobalClassHashTableHelper.sGetHash(pHeaderText)))
//                {
//                    pGridView.Columns[i].Visible = pbVisible;
//                }
//            }
//        }

//        /// <summary>
//        /// Invisible delete button in grid view.
//        /// we assume the last column is delete button.
//        /// </summary>
//        public static void fGridViewInvisibleDeleteButton(GridView pGrid)
//        {
//            pGrid.Columns[pGrid.Columns.Count - 1].Visible = false;
//        }

//        public static void fGridViewVisibleDeleteButton(GridView pGrid)
//        {
//            pGrid.Columns[pGrid.Columns.Count - 1].Visible = true;
//        }

//        /// <summary>
//        /// Set delete reminder on grid view.
//        /// We assume it is imageButton and named "ImageButton1"
//        /// </summary>
//        public static void fGridViewSetDeleteReminder(System.Web.UI.WebControls.GridViewRowEventArgs e)
//        {
//            if (e.Row.RowType == DataControlRowType.DataRow)
//            {
//                // 加載删除提示
//                // 只支援 名為ImageButton1 的 ImageButton
//                ImageButton lImageButton = e.Row.FindControl("ImageButton1");
//                if (lImageButton == null)
//                {
//                }
//                else
//                {
//                    lImageButton.CommandArgument = e.Row.RowIndex.ToString();
//                    lImageButton.OnClientClick = "return confirm('" + LIBWebBased.GlobalClassHashTableHelper.sGetHash("您確定要刪除嗎") + "');";
//                }
//            }
//        }

//        public static void fGridViewSetCommandArgument(System.Web.UI.WebControls.GridViewRowEventArgs e, string psControlName)
//        {
//            if (e.Row.RowType == DataControlRowType.DataRow)
//            {
//                object lObject = e.Row.FindControl(psControlName);
//                lObject.CommandArgument = e.Row.RowIndex.ToString();
//            }
//        }

//        /// <summary>
//        /// Merge same content column cell together
//        /// </summary>
//        public static void fGridViewSetColumnSpan(GridView pGridView, int piStartColumn, int piLength)
//        {
//            foreach (GridViewRow lGridViewRow in pGridView.Rows)
//            {
//                lGridViewRow.Cells[piStartColumn].ColumnSpan = piLength;
//                for (int i = piStartColumn + 1; i <= piLength; i++)
//                {
//                    lGridViewRow.Cells[i].Visible = false;
//                }
//            }
//        }

//        /// <summary>
//        /// Merge same content row cells together
//        /// </summary>
//        public static void fGridViewSetRowSpan(GridView pGridView, int piStartColumn, int piEndColumn)
//        {
//            for (int rowIndex = pGridView.Rows.Count - 2; rowIndex >= 0; rowIndex += -1)
//            {
//                GridViewRow lGridViewRow = pGridView.Rows[rowIndex];
//                GridViewRow lGridViewRowPrevious = pGridView.Rows[rowIndex + 1];
//                for (int cellCount = piStartColumn; cellCount <= piEndColumn; cellCount++)
//                {
//                    if (lGridViewRow.Cells[cellCount].Text == lGridViewRowPrevious.Cells[cellCount].Text)
//                    {
//                        if (lGridViewRowPrevious.Cells[cellCount].RowSpan < 2)
//                        {
//                            lGridViewRow.Cells[cellCount].RowSpan = 2;
//                        }
//                        else
//                        {
//                            lGridViewRow.Cells[cellCount].RowSpan = lGridViewRowPrevious.Cells[cellCount].RowSpan + 1;
//                        }
//                        lGridViewRowPrevious.Cells[cellCount].Visible = false;
//                    }
//                }
//            }
//        }

//        /// <summary>
//        /// Merge every NRow cells together
//        /// </summary>
//        public static void fGridViewMergeNRowCells(GridView pGridView, int piColumn, int piNRows)
//        {
//            for (int rowIndex = 0; rowIndex <= pGridView.Rows.Count - 1; rowIndex++)
//            {
//                GridViewRow lGridViewRow = pGridView.Rows[rowIndex];
//                if (rowIndex % piNRows == 0)
//                {
//                    lGridViewRow.Cells[piColumn].RowSpan = piNRows;
//                }
//                else
//                {
//                    lGridViewRow.Cells[piColumn].Visible = false;
//                }
//            }
//        }

//        /// <summary>
//        /// Select/unselect all "chkSelect" column controls in gridview.
//        /// </summary>
//        public static void fGridViewSetCheckBoxAll(GridView pGridView, bool pbSelected)
//        {
//            foreach (GridViewRow lGridViewRow in pGridView.Rows)
//            {
//                CheckBox lCheckBox = lGridViewRow.FindControl("chkSelect");
//                if (lCheckBox != null)
//                {
//                    lCheckBox.Checked = pbSelected;
//                }
//            }
//        }

//        public static DataTable fGridviewGetDataTable(GridView pGridView)
//        {
//            DataTable lDataTable = null;
//            string lDataSourceType = pGridView.DataSource.GetType().ToString();

//            switch (lDataSourceType)
//            {
//                case "System.Data.DataSet":
//                    System.Data.DataSet lDataSet = pGridView.DataSource;
//                    lDataTable = lDataSet.Tables[0];
//                    break;
//                case "System.Data.DataTable":
//                    lDataTable = pGridView.DataSource;
//                    break;
//                default:
//                    DataView lDataView = pGridView.DataSource;
//                    lDataTable = lDataView.ToTable();

//                    break;
//            }

//            return lDataTable;
//        }

//        public static string fGridViewGetSelectedValueList(GridView pGridView)
//        {
//            string lsString = LIBWebBased.BLANK;
//            foreach (GridViewRow lGridViewRow in pGridView.Rows)
//            {
//                CheckBox lCheckBox = lGridViewRow.FindControl("chkSelect");
//                Label lLabel = lGridViewRow.FindControl("lblKey");
//                if (lCheckBox != null)
//                {
//                    if (lLabel != null)
//                    {
//                        if (lCheckBox.Checked == true)
//                        {
//                            lsString += lLabel.Text + ", ";
//                        }
//                    }
//                }
//            }
//            return lsString;
//        }

//        /// <summary>
//        /// Check the row "All", if no value, then hide the column
//        /// </summary>
//        public static void fGridViewDynamicInvisibleColumnWihEmptyAll(GridView pGridview)
//        {
//            foreach (GridViewRow lGridViewRow in pGridview.Rows)
//            {
//                if (lGridViewRow.Cells[0].Text == "All")
//                {
//                    for (int i = 0; i <= lGridViewRow.Cells.Count - 1; i++)
//                    {
//                        if (lGridViewRow.Cells[i].Text == LIBWebBased.BLANK)
//                        {
//                            for (int ii = 0; ii <= pGridview.Rows.Count - 1; ii++)
//                            {
//                                pGridview.Rows[ii].Cells[i].Visible = false;
//                                pGridview.HeaderRow.Cells[i].Visible = false;

//                            }
//                        }
//                    }

//                    break; // TODO: might not be correct. Was : Exit For
//                }
//            }
//        }

//        /// <summary>
//        /// If the field is numeric, then RightAlign and hide the 0.
//        /// </summary>

//        public static void fGridViewAutoColumnSetNumberFieldFormat(System.Web.UI.WebControls.GridViewRowEventArgs e, GridView pGridview)
//        {
//            if (e.Row.RowType == DataControlRowType.DataRow)
//            {
//                for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
//                {
//                    if (Information.IsNumeric(e.Row.Cells[i].Text))
//                    {
//                        // change Number Format
//                        e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Right;
//                        e.Row.Cells[i].Text = mCommon.sRemoveZero2(e.Row.Cells[i].Text);

//                        if (e.Row.Cells[i].Text.Contains("."))
//                        {
//                            e.Row.Cells[i].Text = mCommon.sMoney(e.Row.Cells[i].Text);
//                        }

//                    }
//                    else if (Information.IsDate(e.Row.Cells[i].Text))
//                    {
//                        e.Row.Cells[i].Text = nsDateTime.mDataTime.sStandardFileNameDateTime(e.Row.Cells[i].Text);
//                    }

//                }
//            }

//        }

//        /// <summary>
//        /// If the field is numeric, then Highlight the max column cell.
//        /// </summary>

//        public static void fGridViewDynamicReportHighLightMaxColumnCell(System.Web.UI.WebControls.GridViewRowEventArgs e, GridView pGridview)
//        {
//            double liMax = 0;
//            string lsMax = LIBWebBased.BLANK;
//            if (e.Row.RowType == DataControlRowType.DataRow)
//            {
//                for (int i = 3; i <= e.Row.Cells.Count - 5; i++)
//                {
//                    if (Information.IsNumeric(e.Row.Cells[i].Text))
//                    {
//                        // change Number Format

//                        if (pGridview.HeaderRow.Cells[i].Text == "All")
//                        {
//                        }
//                        else
//                        {
//                            if (e.Row.Cells[i].Text > liMax)
//                            {
//                                liMax = e.Row.Cells[i].Text;
//                                lsMax = e.Row.Cells[i].Text;
//                            }
//                        }

//                    }
//                }

//                for (int i = 3; i <= e.Row.Cells.Count - 5; i++)
//                {
//                    if (e.Row.Cells[i].Text == lsMax)
//                    {
//                        e.Row.Cells[i].BackColor = System.Drawing.Color.Yellow;
//                    }
//                }
//            }

//        }

//        public static void fGridViewSetKeyVisible(System.Web.UI.WebControls.GridViewRowEventArgs e)
//        {
//            if (mCommon.bExistGridRow(e))
//            {
//                e.Row.Cells[0].Visible = false;
//            }
//        }

//        public static bool bExistGridRow(System.Web.UI.WebControls.GridViewRowEventArgs e)
//        {
//            if (e.Row.Cells.Count > 1)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        /// <summary>
//        /// Set grid view header name.繁簡英
//        /// Rename the header based on the pHashTable(ColumnFieldname)
//        /// how to use : only use in page load, when the header of gridview is fieldname.
//        /// </summary>
//        public static void fGridViewSetHeader(GridView pGrid, Hashtable pHashTable)
//        {
//            foreach (System.Web.UI.WebControls.DataControlField pColumn in pGrid.Columns)
//            {
//                if (pColumn.HeaderText == "Role")
//                {
//                    // fit UserControlLibrary2010
//                    return;
//                }

//                pColumn.HeaderText = mCommon.sGetHash(pHashTable, pColumn.HeaderText);
//                pColumn.FooterText = pColumn.HeaderText;

//                pColumn.FooterStyle.BackColor = System.Drawing.Color.LightSkyBlue;

//                // Dynamic set SortExpression.
//                switch (pColumn.GetType().Name.ToString())
//                {
//                    case "BoundField":
//                        if (pColumn is BoundField)
//                        {
//                            BoundField lColumnField = (BoundField)pColumn;
//                            if (pColumn.SortExpression == LIBWebBased.BLANK)
//                            {
//                                // pColumn.SortExpression = lColumnField.DataField
//                            }
//                            lColumnField.HtmlEncode = false;
//                        }

//                        break;
//                    case "HyperLinkField":
//                        if (pColumn is HyperLinkField)
//                        {
//                            HyperLinkField lColumnField = (HyperLinkField)pColumn;
//                            if (pColumn.SortExpression == LIBWebBased.BLANK)
//                            {
//                                // pColumn.SortExpression = lColumnField.DataTextField
//                            }
//                        }

//                        break;
//                    case "TemplateField":
//                        break;
//                    // Dim lColumnField As TemplateField = DirectCast(pColumn, TemplateField)

//                }
//            }
//        }

//        public static void fGridViewSetWrapItem(GridView pGrid, bool pbWrap)
//        {
//            foreach (System.Web.UI.WebControls.DataControlField pColumn in pGrid.Columns)
//            {
//                pColumn.ItemStyle.Wrap = pbWrap;
//            }
//        }
//        public static void fGridViewSetWrapHeader(GridView pGrid, bool pbWrap)
//        {
//            foreach (System.Web.UI.WebControls.DataControlField pColumn in pGrid.Columns)
//            {
//                pColumn.HeaderStyle.Wrap = pbWrap;
//            }
//        }
//        #endregion

//        #region "DataGrid"
//        /// <summary>
//        /// Set delete reminder on grid view.
//        /// We assume it is imageButton and named "ImageButton1"
//        /// </summary>
//        public static void fDataGridSetDeleteReminder(System.Web.UI.WebControls.DataGridItemEventArgs e)
//        {
//            if (e.Item.ItemType == DataControlRowType.DataRow)
//            {
//                // 加載删除提示
//                // 只支援 名為ImageButton1 的 ImageButton
//                ImageButton lImageButton = e.Item.FindControl("ImageButton1");
//                if (lImageButton == null)
//                {
//                }
//                else
//                {
//                    lImageButton.CommandArgument = e.Item.ItemIndex.ToString();
//                    lImageButton.OnClientClick = "return confirm('" + LIBWebBased.GlobalClassHashTableHelper.sGetHash("您確定要刪除嗎") + "');";
//                }
//            }
//        }
//        public static void fDataGridSetCheckBoxAll(DataGrid pGridView, bool pbSelected)
//        {
//            foreach (DataGridItem lDataGridItem in pGridView.Items)
//            {
//                CheckBox lCheckBox = lDataGridItem.FindControl("chkSelect");
//                if (lCheckBox != null)
//                {
//                    lCheckBox.Checked = pbSelected;
//                }
//            }
//        }

//        public static void fDataGridInvisibleDeleteButton(DataGrid pGrid)
//        {
//            pGrid.Columns[pGrid.Columns.Count - 1].Visible = false;
//        }

//        public static void fDataGridVisibleDeleteButton(DataGrid pGrid)
//        {
//            pGrid.Columns[pGrid.Columns.Count - 1].Visible = true;
//        }

//        /// <summary>
//        /// Set DataGrid header name.繁簡英
//        /// Rename the header based on the pHashTable(ColumnFieldname)
//        /// </summary>
//        public static void fDataGridSetHeader(DataGrid pDataGrid, Hashtable pHashTable)
//        {
//            foreach (System.Web.UI.WebControls.DataGridColumn pColumn in pDataGrid.Columns)
//            {
//                pColumn.HeaderText = mCommon.sGetHash(pHashTable, pColumn.HeaderText);
//            }
//        }

//        /// <summary>
//        /// data grid add sorting icon.
//        /// Use this function in DataGrid1.SortCommand
//        /// need to Fill datagrid before using this function, otherwise lDataGrid.DataSource = NULL.
//        /// Call nsCommon.fDataGridAddSortingIcon(Me.DataGrid1, Me.lblSorting, e)
//        /// </summary>
//        public static void fDataGridAddSortingIcon(DataGrid lDataGrid, Label llblSorting, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
//        {
//            // f2 - Set Sorting direction
//            bool lbAscSorting = false;
//            if (llblSorting.Text.IndexOf("Desc") > -1)
//            {
//                llblSorting.Text = "Asc";
//                lbAscSorting = true;
//            }
//            else
//            {
//                llblSorting.Text = "Desc";
//                lbAscSorting = false;
//            }

//            // f3 - Set Sort Icon
//            foreach (DataGridColumn lDataGridColumn in lDataGrid.Columns)
//            {
//                //Clear any <img> tags that might be present
//                lDataGridColumn.HeaderText = Regex.Replace(lDataGridColumn.HeaderText, "\\s<.*>", string.Empty);
//                //Clear any <img> tags that might be present
//                if (lDataGridColumn.SortExpression == e.SortExpression)
//                {
//                    if (lbAscSorting)
//                    {
//                        lDataGridColumn.HeaderText += " <img src=\"img/Col_up.gif\" border=\"0\">";
//                    }
//                    else
//                    {
//                        lDataGridColumn.HeaderText += " <img src=\"img/Col_down.gif\" border=\"0\">";
//                    }
//                }
//            }

//            // f4 - Sorting
//            DataView lDataView = lDataGrid.DataSource;
//            lDataView.Sort = e.SortExpression + " " + llblSorting.Text;
//            lDataGrid.DataSource = lDataView;
//            lDataGrid.DataBind();
//        }

//        public static void fDataGridSetAllColumnWidth(DataGrid pDataGrid, int piWidth)
//        {
//            foreach (System.Web.UI.WebControls.DataGridColumn pColumn in pDataGrid.Columns)
//            {
//                pColumn.ItemStyle.Width = Unit.Pixel(piWidth);
//                pColumn.HeaderStyle.Width = Unit.Pixel(piWidth);
//            }
//        }

//        public static void fDataGridSetTargetColumnWidth(DataGrid pDataGrid, int piWidth, int piTargetColumnIndex)
//        {
//            System.Web.UI.WebControls.DataGridColumn pColumn = pDataGrid.Columns[piTargetColumnIndex];
//            pColumn.ItemStyle.Width = Unit.Pixel(piWidth);
//            pColumn.HeaderStyle.Width = Unit.Pixel(piWidth);
//        }
//        #endregion

//        #region "TextBox"
//        public static void fTextBoxVisibleWhenOther(ListControl pDDL, UserControlLibrary.Lamsoon.SmartTextbox pSmartTxt)
//        {
//            // use in LCR, may enhance later
//            if (pDDL.SelectedValue != "其他")
//            {
//                pSmartTxt.Visible = false;
//                pSmartTxt.Text = LIBWebBased.BLANK;
//            }
//            else
//            {
//                pSmartTxt.Visible = true;
//            }
//        }

//        public static void fTextBoxInvisibleWhenBlank(UserControlLibrary.Lamsoon.SmartTextbox pSmartTxt)
//        {
//            if (pSmartTxt.Text == LIBWebBased.BLANK)
//            {
//                pSmartTxt.Visible = false;
//            }
//            else
//            {
//                pSmartTxt.Visible = true;
//            }
//        }

//        /// <summary>
//        /// Add onkeydown event on textbox.
//        /// When Click Enter in TextBox, then trigger the pButton.Click
//        /// </summary>
//        public static void fTextBoxSetEnterEvent(SmartTextbox pTxtBox, Button pButton)
//        {
//            pTxtBox.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + pButton.UniqueID + "').click();return false;}} else {return true}; ");
//        }
//        #endregion

//        #region "CheckBox"
//        public static void fCheckBox1TrueThen2False(CheckBox pchk1, CheckBox pchk2)
//        {
//            if (pchk1.Checked)
//            {
//                pchk2.Checked = false;
//            }
//        }

//        public static string sCheckBoxGetStringWhenTrue(CheckBox pCheckBox)
//        {
//            if (pCheckBox.Checked == true)
//            {
//                return pCheckBox.Text;
//            }
//            return LIBWebBased.BLANK;
//        }
//        #endregion

//        #region "CheckBoxList, ListControl"
//        // vs2003有用
//        public static string sGetSelectedCheckBoxList(UserControlLibrary.Lamsoon.SmartCheckboxList pSmartCheckBoxList)
//        {
//            int a = 0;
//            int i = 0;
//            a = pSmartCheckBoxList.Items.Count - 1;
//            string lsCheckedItem = "";
//            if (a > 0)
//            {
//                for (i = 0; i <= pSmartCheckBoxList.Items.Count - 1; i++)
//                {
//                    if (pSmartCheckBoxList.Items(i).Selected)
//                    {
//                        lsCheckedItem += "1";
//                    }
//                    else
//                    {
//                        lsCheckedItem += "0";
//                    }
//                }
//            }
//            return lsCheckedItem;
//        }

//        // vs2003有用
//        public static bool SetSelectedCheckBoxList(string psClickLocation, UserControlLibrary.Lamsoon.SmartCheckboxList pSmartCheckBoxList)
//        {
//            for (int i = 0; i <= pSmartCheckBoxList.Items.Count - 1; i++)
//            {
//                pSmartCheckBoxList.Items(i).Selected = false;
//            }

//            if (psClickLocation != LIBWebBased.BLANK)
//            {
//                for (int i = 1; i <= psClickLocation.Length; i++)
//                {
//                    if (Strings.Mid(psClickLocation, i, 1) == "1")
//                    {
//                        pSmartCheckBoxList.Items(i - 1).Selected = true;
//                    }
//                }
//            }
//            return true;
//        }
//        public static string fCheckBoxListGetSelectedValues(ListControl pListControl)
//        {
//            System.Web.UI.WebControls.ListItem item = null;
//            string chkstring = ",";
//            foreach (ListItem item_loopVariable in pListControl.Items)
//            {
//                item = item_loopVariable;
//                if (item.Selected)
//                {
//                    chkstring += item.Value + ",";
//                }
//            }
//            return chkstring;
//        }
//        public static void fCheckBoxListSetSelectedValueList(ListControl pListControl, string itemlist)
//        {
//            int i = 0;
//            int j = 0;
//            string[] item = Strings.Split(itemlist, ",");
//            for (j = 0; j <= pListControl.Items.Count - 1; j++)
//            {
//                pListControl.Items[j].Selected = false;
//            }
//            for (i = 0; i <= item.Length - 1; i++)
//            {
//                for (j = 0; j <= pListControl.Items.Count - 1; j++)
//                {
//                    if (item[i] == pListControl.Items[j].Value)
//                    {
//                        pListControl.Items[j].Selected = true;
//                    }
//                }

//            }
//        }
//        public static string fCheckBoxListGetSelectedValueList(ListControl pListControl)
//        {
//            string lsString = LIBWebBased.BLANK;
//            for (int i = 0; i <= pListControl.Items.Count - 1; i++)
//            {
//                if (pListControl.Items[i].Selected == true)
//                {
//                    lsString += pListControl.Items[i].Value + ", ";
//                }
//            }
//            return lsString;
//        }

//        public static string fCheckBoxListGetSelectedValueListWithSeparator(ListControl pListControl)
//        {
//            string lsString = LIBWebBased.BLANK;
//            for (int i = 0; i <= pListControl.Items.Count - 1; i++)
//            {
//                if (pListControl.Items[i].Selected == true)
//                {
//                    lsString += "," + pListControl.Items[i].Value + ",";
//                }
//            }
//            return lsString;
//        }
//        public static string fCheckBoxListGetSelectedString(object psClickLocation, UserControlLibrary.Lamsoon.SmartCheckboxList pSmartCheckBoxList)
//        {
//            string lsString = LIBWebBased.BLANK;
//            psClickLocation = nsSQL.mSQL.oHandleNullAndNothing(psClickLocation);
//            for (int i = 0; i <= pSmartCheckBoxList.Items.Count - 1; i++)
//            {
//                pSmartCheckBoxList.Items(i).Selected = false;
//            }
//            if (psClickLocation != LIBWebBased.BLANK)
//            {
//                for (int i = 1; i <= psClickLocation.Length; i++)
//                {
//                    if (Strings.Mid(psClickLocation, i, 1) == "1")
//                    {
//                        lsString += pSmartCheckBoxList.Items(i - 1).Text + ", ";

//                    }
//                }
//            }
//            return lsString;
//        }

//        public static void fListControlTranslateDDL(ListControl pListControl)
//        {
//            foreach (System.Web.UI.WebControls.ListItem lListItem in pListControl.Items)
//            {
//                lListItem.Text = LIBWebBased.GlobalClassHashTableHelper.sGetHash((lListItem.Text));
//            }
//        }

//        public static void fListControlClickBox(ListControl pListControl, string psValue)
//        {
//            for (int i = 0; i <= pListControl.Items.Count - 1; i++)
//            {
//                if (pListControl.Items[i].Value == psValue)
//                {
//                    pListControl.Items[i].Selected = true;
//                }
//            }
//        }

//        public static void fCheckBoxListSetAll(ListControl pListControl, bool pbSelected)
//        {
//            for (int i = 0; i <= pListControl.Items.Count - 1; i++)
//            {
//                pListControl.Items[i].Selected = pbSelected;
//            }
//        }

//        public static void fCheckBoxListSetSelectByArraylist(ref ListControl pListControl, List<string> lList)
//        {
//            for (int liCol = 0; liCol <= pListControl.Items.Count - 1; liCol++)
//            {
//                if (lList.Contains(pListControl.Items[liCol].Text))
//                {
//                    pListControl.Items[liCol].Selected = true;
//                }
//                else
//                {
//                    pListControl.Items[liCol].Selected = false;
//                }
//            }
//        }

//        public static bool bIsCheckBoxListSelected(ListControl pListControl)
//        {
//            // Has selected
//            for (int i = 0; i <= pListControl.Items.Count - 1; i++)
//            {
//                if (pListControl.Items[i].Selected == true)
//                {
//                    return true;
//                }
//            }
//            return false;
//        }

//        public static bool fCheckBoxListInsertDelete(ListControl pListControl, LIBWebBased.DFunc1 pDFunc1Insert, LIBWebBased.DFunc1 pDFunc1Delete)
//        {
//            for (int i = 0; i <= pListControl.Items.Count - 1; i++)
//            {
//                if (pListControl.Items[i].Selected == true)
//                {
//                    pDFunc1Insert(pListControl.Items[i].Value);
//                }
//                else
//                {
//                    pDFunc1Delete(pListControl.Items[i].Value);
//                }
//            }
//            return false;
//        }

//        /// <summary>
//        /// Set checklist = a list of Griview Column.
//        /// get a list of Gridview column,
//        /// then assign into checklist.
//        /// Call nsCommon.fCheckBoxListBuildGridColList(Me.CheckBoxList1, Me.grdAdvancedSearch)
//        /// </summary>
//        public static void fCheckBoxListBuildGridColList(ListControl pListControl, object pControl)
//        {
//            List<string> lList = new List<string>();
//            switch (pControl.GetType().Name)
//            {
//                case "GridView":
//                    GridView lControl = pControl;
//                    for (int liCol = 0; liCol <= pControl.Columns.Count - 1; liCol++)
//                    {
//                        lList.Add(pControl.Columns(liCol).HeaderText);
//                    }


//                    break;
//                case "DataGrid":
//                    DataGrid lControl = pControl;
//                    for (int liCol = 0; liCol <= pControl.Columns.Count - 1; liCol++)
//                    {
//                        lList.Add(pControl.Columns(liCol).HeaderText);
//                    }


//                    break;
//            }
//            pListControl.DataSource = lList;
//            pListControl.DataBind();

//            for (int liCol = 0; liCol <= pListControl.Items.Count - 1; liCol++)
//            {
//                pListControl.Items[liCol].Selected = true;
//            }
//        }

//        public static void fCheckBoxListUnselected(ListControl pListControl, object piIndex)
//        {
//            try
//            {
//                pListControl.Items[piIndex].Selected = false;


//            }
//            catch (Exception ex)
//            {
//            }
//        }

//        /// <summary>
//        /// Visible GridView Column based on tick in CheckBoxList
//        /// </summary>
//        public static void fCheckBoxListVisibleGridCol(ListControl pListControl, object pControl)
//        {
//            switch (pControl.GetType().Name)
//            {
//                case "GridView":
//                    GridView lControl = pControl;
//                    for (int liCol = 0; liCol <= pListControl.Items.Count - 1; liCol++)
//                    {
//                        pControl.Columns(liCol).visible = pListControl.Items[liCol].Selected;
//                    }


//                    break;
//                case "DataGrid":
//                    DataGrid lControl = pControl;
//                    for (int liCol = 0; liCol <= pListControl.Items.Count - 1; liCol++)
//                    {
//                        pControl.Columns(liCol).Visible = pListControl.Items[liCol].Selected;
//                    }

//                    break;
//            }
//        }
//        #endregion

//        #region "Button"
//        public static void fButtonSetCollapseButtonName(Button psButton)
//        {
//            if (psButton.Text == LIBWebBased.GlobalClassHashTableHelper.sGetHash("添加"))
//            {
//                psButton.Text = LIBWebBased.GlobalClassHashTableHelper.sGetHash("隱藏");
//            }
//            else
//            {
//                psButton.Text = LIBWebBased.GlobalClassHashTableHelper.sGetHash("添加");
//            }
//        }

//        public static void fButtonSetCollapseDisplay(Button psButton, Control pControl)
//        {
//            if (psButton.Text == LIBWebBased.GlobalClassHashTableHelper.sGetHash("添加"))
//            {
//                psButton.Text = LIBWebBased.GlobalClassHashTableHelper.sGetHash("隱藏");
//                mCommon.fControlSetVisible(pControl, true);
//            }
//            else
//            {
//                psButton.Text = LIBWebBased.GlobalClassHashTableHelper.sGetHash("添加");
//                mCommon.fControlSetVisible(pControl, false);
//            }
//        }

//        public static void fButtonSetOpenURL(Button pButton, string psURL)
//        {
//            pButton.Attributes.Add("onClick", "window.open('" + psURL + "');");
//        }

//        //Public Sub fButtonSetRefreshParentPage(ByVal pButton As Button)
//        //    pButton.Attributes.Add("onClick", "window.opener.document.Form1.submit();top.close();")
//        //End Sub

//        public static void fButtonSetReminder(System.Web.UI.WebControls.Button btnButton, string psReminderString)
//        {
//            btnButton.OnClientClick = "return confirm('" + psReminderString + "');";
//        }

//        public static void fButtonSetDeleteReminder(System.Web.UI.WebControls.Button btnDelete)
//        {
//            mCommon.fButtonSetReminder(btnDelete, LIBWebBased.GlobalClassHashTableHelper.sGetHash("您確定要刪除嗎"));
//        }

//        public static void fButtonSetDeleteRecordProperty(string psItemID, ref System.Web.UI.WebControls.Button btnDelete)
//        {
//            mCommon.fButtonSetDeleteReminder(btnDelete);
//            if (mCommon.bCanDeleteItem(psItemID))
//            {
//                btnDelete.Visible = true;
//            }
//            else
//            {
//                btnDelete.Visible = false;
//            }
//        }

//        #endregion

//        #region "Number Handling"
//        // need to check
//        public static object sToNumber(object psNumber)
//        {
//            try
//            {
//                if (psNumber.ToString() == LIBWebBased.BLANK)
//                {
//                    return 0;
//                }
//                else
//                {
//                    // return 0 when "All"
//                    double ldTestNumberUse = Convert.ToDouble(psNumber.ToString().Replace(",", ""));
//                    return ldTestNumberUse;
//                }
//            }
//            catch (Exception ex)
//            {
//                return 0;
//            }
//        }

//        public static object sToNumberWithNothing(object psNumber)
//        {
//            try
//            {
//                if (psNumber.ToString() == LIBWebBased.BLANK)
//                {
//                    return null;
//                }
//                else
//                {
//                    // return 0 when "All"
//                    double ldTestNumberUse = Convert.ToDouble(psNumber.ToString().Replace(",", ""));
//                    return psNumber.ToString().Replace(",", "");
//                }
//            }
//            catch (Exception ex)
//            {
//                return null;
//            }
//        }

//        public static string sMoneyThousand(object psNumber)
//        {
//            psNumber = nsSQL.mSQL.oHandleDBNull(psNumber);
//            double lDouble = psNumber;
//            lDouble = lDouble / 1000;
//            return lDouble.ToString("N0");
//        }

//        public static string sMoneyInteger(object psNumber)
//        {
//            return sMoneyBase(psNumber, "0");
//        }

//        public static string sMoneyF4(object psNumber)
//        {
//            return sMoneyBase(psNumber, "4");
//        }

//        public static string sMoney(object psNumber, bool pbRemoveZero = false)
//        {
//            return sMoneyBase(psNumber, LIBWebBased.BLANK, pbRemoveZero);
//        }

//        private static string sMoneyBase(object psNumber, string psNoOfDecimal, bool pbRemoveZero = false)
//        {
//            try
//            {
//                psNumber = nsSQL.mSQL.oHandleDBNull(psNumber);
//                if (psNumber == null)
//                {
//                    return LIBWebBased.BLANK;
//                }
//                double lDouble = psNumber;
//                if (pbRemoveZero)
//                {
//                    return mCommon.sRemoveZero(lDouble.ToString("N" + psNoOfDecimal));
//                }
//                else
//                {
//                    return lDouble.ToString("N" + psNoOfDecimal);
//                }

//            }
//            catch (Exception ex)
//            {
//                return psNumber;
//            }
//        }

//        public static string sPercent(object psNumber, int psNoOfDecimal = 1)
//        {
//            psNumber = nsSQL.mSQL.oHandleDBNull(psNumber);
//            double lDouble = psNumber;
//            lDouble = lDouble * 100;

//            if (lDouble == 0)
//            {
//                return LIBWebBased.BLANK;
//            }
//            else
//            {
//                return mCommon.sNumberBase(lDouble, psNoOfDecimal, true) + "%";
//            }

//        }

//        public static string sPercentage(object psSon, object psParent, bool pbWithUnit = false, string pbDeciaml = "1")
//        {
//            try
//            {
//                string lsResult = "0";
//                string lsUnit = LIBWebBased.BLANK;

//                if (pbWithUnit)
//                {
//                    lsUnit = "%";
//                }

//                psSon = nsSQL.mSQL.oHandleNullAndNothing(psSon);
//                psParent = nsSQL.mSQL.oHandleNullAndNothing(psParent);

//                // add handling for MDX

//                if (psSon.ToString() == LIBWebBased.BLANK | psParent.ToString() == LIBWebBased.BLANK | psSon.ToString() == "-1.#IND" | psParent.ToString() == "-1.#IND")
//                {
//                }
//                else
//                {

//                    if (psSon == 0 | psParent == 0)
//                    {
//                    }
//                    else
//                    {
//                        lsResult = mCommon.sNumberBase(psSon / psParent * 100, pbDeciaml, true) + lsUnit;

//                    }
//                }

//                return lsResult;
//            }
//            catch (Exception ex)
//            {
//                return 0;
//            }
//        }

//        public static string sNumber(object psNumber)
//        {
//            return mCommon.sNumberBase(psNumber, "0");
//        }

//        public static string sNumberF1(object psNumber)
//        {
//            return mCommon.sNumberBase(psNumber, "1");
//        }

//        public static string sNumberF2(object psNumber)
//        {
//            return mCommon.sNumberBase(psNumber, "2");
//        }

//        public static string sNumberF3(object psNumber)
//        {
//            return mCommon.sNumberBase(psNumber, "3");
//        }

//        public static string sNumberWithZero(object psNumber)
//        {
//            return mCommon.sNumberBase(psNumber, "0", true);
//        }

//        public static string sNumberBase(object psNumber, string psNoOfDecimal, bool pbWithZero = false)
//        {
//            try
//            {
//                psNumber = nsSQL.mSQL.oHandleDBNull(psNumber);

//                double lDouble = 0;
//                if (psNumber == null)
//                {
//                    if (pbWithZero)
//                    {
//                        return lDouble.ToString("N" + psNoOfDecimal);
//                    }
//                    else
//                    {
//                        return LIBWebBased.BLANK;
//                    }
//                }

//                lDouble = psNumber;
//                if (pbWithZero)
//                {
//                    return lDouble.ToString("N" + psNoOfDecimal);
//                }
//                else
//                {
//                    return sRemoveZero2(lDouble.ToString("N" + psNoOfDecimal));
//                }
//            }
//            catch (Exception ex)
//            {
//                if (pbWithZero)
//                {
//                    return "0";
//                }
//                else
//                {
//                    return LIBWebBased.BLANK;
//                }
//            }
//        }

//        /// <summary>
//        /// set 0 to "-"
//        /// </summary>
//        public static string sRemove00(object psNumber)
//        {
//            // use in NLA report, may remove later
//            psNumber = nsSQL.mSQL.oHandleNullAndNothing(psNumber);
//            psNumber = mCommon.sNumberBase(psNumber, "1", true);
//            return mCommon.sRemoveZero(psNumber);
//        }

//        /// <summary>
//        /// set 0 to "-"
//        /// </summary>
//        public static string sRemoveZero(object psNumber)
//        {
//            psNumber = nsSQL.mSQL.oHandleNullAndNothing(psNumber);

//            if (psNumber == 0)
//            {
//                psNumber = "-";
//            }

//            return psNumber;
//        }

//        /// <summary>
//        /// set 0 to ""
//        /// </summary>
//        public static string sRemoveZero2(object psNumber)
//        {
//            psNumber = nsSQL.mSQL.oHandleNullAndNothing(psNumber);
//            if (psNumber.ToString() == LIBWebBased.BLANK)
//            {
//                return psNumber;
//            }

//            if (psNumber == 0)
//            {
//                psNumber = LIBWebBased.BLANK;
//            }
//            return psNumber;
//        }
//        #endregion

//        #region "DDL"
//        private static void BindDDLByStaffTemplate(ListControl pDDL, string psSTP, string psCriteria = LIBWebBased.BLANK)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with46 = ClsLoadFieldHelper;

//            _with46.fAddSqlParameter("lang", LIBWebBased.GlobalClassHashTableHelper.msLang);
//            _with46.fAddSqlParameter("psUsername", LIBWebBased.GlobalClassHashTableHelper.msUserName);
//            _with46.fAddSqlParameter("ProjectCode", gsProjectCode);

//            if (psCriteria != LIBWebBased.BLANK)
//            {
//                _with46.fAddSqlParameter("Criteria", psCriteria);
//            }

//            _with46.fBuildDataSet(psSTP);
//            _with46.fBindControls(pDDL, enDropDownListType.NoValue);
//        }

//        public static void BindDDL3DivisionByStaff(ListControl ddl)
//        {
//            BindDDLByStaffTemplate(ddl, "stp_wf_all_DDL3DivisionByStaff");
//        }

//        public static void BindDDLDivisionBySalesByStaff(ListControl ddl)
//        {
//            BindDDLByStaffTemplate(ddl, "stp_wf_all_DDLDivisionBySalesByStaff");
//        }

//        public static void BindDDLDivisionByCustomerByStaff(ListControl ddl)
//        {
//            BindDDLByStaffTemplate(ddl, "stp_wf_all_DDLDivisionByCustomerByStaff");
//        }

//        public static void BindDDLCompanyByStaff(ListControl ddl)
//        {
//            BindDDLByStaffTemplate(ddl, "stp_wf_all_DDLCompanyByStaff");
//        }

//        public static void BindDDLCompanyByStaff_SalesReport(ListControl ddl)
//        {
//            BindDDLByStaffTemplate(ddl, "stp_wf_all_DDLCompanyByStaff_SalesReport");
//        }

//        public static void BindDDLRegionByStaff(ListControl ddl)
//        {
//            BindDDLByStaffTemplate(ddl, "stp_wf_all_DDLRegionByStaff");
//        }

//        public static void BindDDLProvinceByStaff(ListControl ddl, string psCriteria = LIBWebBased.BLANK)
//        {
//            BindDDLByStaffTemplate(ddl, "stp_wf_all_DDLProvinceByStaff", psCriteria);
//        }

//        public static void BindDDLCityByStaff(ListControl ddl, string psCriteria = LIBWebBased.BLANK)
//        {
//            BindDDLByStaffTemplate(ddl, "stp_wf_all_DDLCityByStaff", psCriteria);
//        }

//        public static void BindDDLCityProvince(ListControl ddlCityProvince, ListControl ddlCityRegion)
//        {
//            nsDataSet.mDataSet.BindListControl("stp_wf_all_DDLCityProvince", ddlCityProvince, enDropDownListType.All, false, "RegionCode", ddlCityRegion.SelectedValue);
//        }

//        public static void BindDDLCity(ListControl pDDL, ListControl ddlCityProvince, ListControl ddlCityRegion)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with47 = ClsLoadFieldHelper;
//            _with47.fAddSqlParameter("RegionCode", ddlCityRegion);
//            _with47.fAddSqlParameter("ProvinceCode", ddlCityProvince);
//            _with47.fBuildDataSet("stp_wf_all_DDLCity");
//            _with47.fBindControls(pDDL, enDropDownListType.All);
//        }

//        public static void BindDDLDepartment(ListControl pDDL, string psCompanyCode, int enDropDownListType)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with48 = ClsLoadFieldHelper;
//            _with48.fAddSqlParameter("@company_id", psCompanyCode);
//            _with48.fAddSqlParameter("@lang", LIBWebBased.GlobalClassHashTableHelper.msLang);
//            _with48.fAddSqlParameter("@all", 0);
//            _with48.fBuildDataSet("stp_wf_all_DDLDepartmentByCompany");
//            _with48.fBindControls(pDDL, enDropDownListType);
//        }

//        public static void BindDDLFeeObjectType(ListControl pDDL, string psCompanyCode, string psDepartmentCode, int enDropDownListType)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with49 = ClsLoadFieldHelper;
//            _with49.fAddSqlParameter("@Company_Code", psCompanyCode);
//            _with49.fAddSqlParameter("@Department_Code", psDepartmentCode);
//            _with49.fAddSqlParameter("@lang", LIBWebBased.GlobalClassHashTableHelper.msLang);
//            _with49.fBuildDataSet("stp_wf_all_DDLFeeObjectType");
//            _with49.fBindControls(pDDL, enDropDownListType);
//        }

//        public static void BindDDLMaster(ListControl pDDL, string psFieldType, LIBWebBased.enDropDownListType penDropDownListType = LIBWebBased.enDropDownListType.All)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with50 = ClsLoadFieldHelper;
//            _with50.fAddSqlParameter("field_type", psFieldType);
//            _with50.fBuildDataSet("stp_wf_all_DDLMaster");
//            _with50.fBindControls(pDDL, penDropDownListType, true);
//        }

//        public static void BindDDLCustomerCat(ListControl pDDL, string psCatNumber, LIBWebBased.enDropDownListType penDropDownListType  = LIBWebBased.enDropDownListType.All)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with51 = ClsLoadFieldHelper;
//            _with51.fAddSqlParameter("CatNumber", psCatNumber);
//            _with51.fBuildDataSet("stp_wf_rss_DDLCustomerCat");
//            _with51.fBindControls(pDDL, enDropDownListType);
//        }

//        public static void BindDDLCustomerCatDesc(ListControl pDDL, string psCatNumber, LIBWebBased.enDropDownListType penDropDownListType  = LIBWebBased.enDropDownListType.All)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with52 = ClsLoadFieldHelper;
//            _with52.fAddSqlParameter("CatNumber", psCatNumber);
//            _with52.fBuildDataSet("stp_wf_rss_DDLCustomerCatDesc");
//            _with52.fBindControls(pDDL, penDropDownListType);
//        }
//        public static void BindDDLProductCat(ListControl pDDL, string psCatNumber, LIBWebBased.enDropDownListType penDropDownListType  = LIBWebBased.enDropDownListType.All)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            ClsLoadFieldHelper.fAddSqlParameter("CatNumber", psCatNumber);
//            ClsLoadFieldHelper.fBuildDataSet("stp_wf_rss_DDLProductCat");
//            ClsLoadFieldHelper.fBindControls(pDDL, penDropDownListType);
//        }
//        public static void BindDDLProductUM(ListControl pDDL, string psProductID, LIBWebBased.enDropDownListType penDropDownListType  = LIBWebBased.enDropDownListType.NoValue)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with54 = ClsLoadFieldHelper;
//            _with54.fAddSqlParameter("@Product_ID", psProductID);
//            _with54.fBuildDataSet("stp_wf_All_DDLProductUM");
//            _with54.fBindControls(pDDL, penDropDownListType);
//        }
//        public static void BindDDLCat(ListControl pDDL, string psCatCodeType, string psCatCodeNumber, LIBWebBased.enDropDownListType penDropDownListType = LIBWebBased.enDropDownListType.All)
//        {
//            // f1
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with55 = ClsLoadFieldHelper;
//            _with55.fAddSqlParameter("@CatCodeType", psCatCodeType);
//            _with55.fAddSqlParameter("@CatCodeNumber", psCatCodeNumber);

//            _with55.fBuildDataSet("stp_wf_imr_DLLCat");
//            _with55.fBindControls(pDDL, penDropDownListType);
//        }

//        public static void BindDDLFeeObject(ListControl pDDL, string psCompanyCode, string psDepartmentCode, string psFeeObjectType, int enDropDownListType)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with56 = ClsLoadFieldHelper;
//            _with56.fAddSqlParameter("@Company_Code", psCompanyCode);
//            _with56.fAddSqlParameter("@Department_Code", psDepartmentCode);
//            _with56.fAddSqlParameter("@Fee_Object_Type", psFeeObjectType);
//            _with56.fAddSqlParameter("@lang", LIBWebBased.GlobalClassHashTableHelper.msLang);
//            _with56.fBuildDataSet("stp_wf_all_DDLFeeObject");
//            _with56.fBindControls(pDDL, enDropDownListType);
//        }

//        public static void BindDDLMonth(ref ListControl pSmartDropDownList, LIBWebBased.enDropDownListType  penDropDownListType, bool pbUsingYTD = false, int piAdustMonth = 0)
//        {
//            for (int i = 1; i <= 12; i++)
//            {
//                System.Web.UI.WebControls.ListItem lListItem = new System.Web.UI.WebControls.ListItem();
//                lListItem.Value = i;
//                lListItem.Text = i;
//                pSmartDropDownList.Items.Add(lListItem);
//            }
//            nsDataSet.mDataSet.SetDDLType(ref pSmartDropDownList, penDropDownListType);
//            try
//            {
//                if (pbUsingYTD == true)
//                {
//                    pSmartDropDownList.SelectedValue = nsDateTime.mDataTime.sToYTDMonth(DateAndTime.Month(System.DateTime.Now));
//                }
//                else
//                {
//                    pSmartDropDownList.SelectedValue = DateAndTime.Month(System.DateTime.Now);
//                }

//                if (pSmartDropDownList.SelectedValue > 1)
//                {
//                    pSmartDropDownList.SelectedValue = (pSmartDropDownList.SelectedValue + piAdustMonth);
//                }

//            }
//            catch (Exception ex)
//            {
//            }
//        }

//        public static void BindDDLWeek(ref ListControl pSmartDropDownList, LIBWebBased.enDropDownListType  penDropDownListType, int psYear = null)
//        {
//            pSmartDropDownList.Items.Clear();
//            for (int i = 1; i <= 53; i++)
//            {
//                System.Web.UI.WebControls.ListItem lListItem = new System.Web.UI.WebControls.ListItem();

//                if (psYear == null)
//                {
//                    lListItem.Text = i;
//                }
//                else
//                {
//                    lListItem.Text = i.ToString() + " (" + nsDateTime.mDataTime.sGetFirstDateOfWeek(psYear, i).ToString("dd.MM.yyyy") + "-" + nsDateTime.mDataTime.sGetLastDateOfWeek(psYear, i).ToString("dd.MM.yyyy") + ")";
//                }

//                lListItem.Value = i;
//                pSmartDropDownList.Items.Add(lListItem);
//            }
//            nsDataSet.mDataSet.SetDDLType(ref pSmartDropDownList, penDropDownListType);

//            try
//            {
//                System.Globalization.CultureInfo cult_info = System.Globalization.CultureInfo.CreateSpecificCulture("zh-HK");
//                System.Globalization.Calendar cal = cult_info.Calendar;

//                pSmartDropDownList.SelectedValue = cal.GetWeekOfYear(System.DateTime.Now, cult_info.DateTimeFormat.CalendarWeekRule, cult_info.DateTimeFormat.FirstDayOfWeek);


//            }
//            catch (Exception ex)
//            {
//            }
//        }



//        public static void BindDDLYear(ref ListControl pSmartDropDownList, LIBWebBased.enDropDownListType  penDropDownListType, bool pbUsingYTD = false)
//        {
//            int liYear = DateAndTime.Year(System.DateTime.Now) + 1;
//            for (int i = 1; i <= 10; i++)
//            {
//                System.Web.UI.WebControls.ListItem lListItem = new System.Web.UI.WebControls.ListItem();
//                lListItem.Value = liYear;
//                if (pbUsingYTD)
//                {
//                    lListItem.Text = nsDateTime.mDataTime.sYTDYearDisplayFormat(liYear, true);
//                }

//                pSmartDropDownList.Items.Add(lListItem);
//                liYear -= 1;
//            }
//            nsDataSet.mDataSet.SetDDLType(ref pSmartDropDownList, penDropDownListType);
//            try
//            {
//                if (pbUsingYTD == true)
//                {
//                    pSmartDropDownList.SelectedValue = nsDateTime.mDataTime.sYTDYear((System.DateTime.Now));
//                }
//                else
//                {
//                    pSmartDropDownList.SelectedValue = DateAndTime.Year((System.DateTime.Now));
//                }

//            }
//            catch (Exception ex)
//            {
//            }
//        }

//        public static void BindDDLAccountYear(ref ListControl pSmartDropDownList, LIBWebBased.enDropDownListType  penDropDownListType)
//        {
//            mCommon.BindDDLYear(pSmartDropDownList, penDropDownListType);
//        }

//        public static void BindDDLYesNo(ref ListControl pSmartDropDownList, LIBWebBased.enDropDownListType  penDropDownListType, bool pbUse10 = false)
//        {
//            ClassHashTableHelper lClsHashTableHelper = LIBWebBased.GlobalClassHashTableHelper;
//            System.Web.UI.WebControls.ListItem lListItem = new System.Web.UI.WebControls.ListItem();
//            if (pbUse10)
//            {
//                lListItem.Value = "1";
//            }
//            else
//            {
//                lListItem.Value = "True";
//            }
//            lListItem.Text = lClsHashTableHelper.sGetHash("是");
//            System.Web.UI.WebControls.ListItem lListItem2 = new System.Web.UI.WebControls.ListItem();
//            if (pbUse10)
//            {
//                lListItem2.Value = "0";
//            }
//            else
//            {
//                lListItem2.Value = "False";
//            }
//            lListItem2.Text = lClsHashTableHelper.sGetHash("否");
//            pSmartDropDownList.Items.Add(lListItem);
//            pSmartDropDownList.Items.Add(lListItem2);
//            nsDataSet.mDataSet.SetDDLType(ref pSmartDropDownList, penDropDownListType);
//        }

//        public static void BindDDLAE(ref ListControl pSmartDropDownList, LIBWebBased.enDropDownListType  penDropDownListType)
//        {
//            ClassHashTableHelper pClsHashTableHelper = LIBWebBased.GlobalClassHashTableHelper;
//            System.Web.UI.WebControls.ListItem lListItem = new System.Web.UI.WebControls.ListItem();
//            lListItem.Value = "A";
//            lListItem.Text = pClsHashTableHelper.sGetHash("Active");
//            System.Web.UI.WebControls.ListItem lListItem2 = new System.Web.UI.WebControls.ListItem();
//            lListItem2.Value = "E";
//            lListItem2.Text = pClsHashTableHelper.sGetHash("Inactive");
//            pSmartDropDownList.Items.Add(lListItem);
//            pSmartDropDownList.Items.Add(lListItem2);
//            nsDataSet.mDataSet.SetDDLType(ref pSmartDropDownList, penDropDownListType);
//        }
//        #endregion

//        //Public Function iGridHandleNoRecord(ByVal lGirdview As GridView) As Integer
//        //    ' TM use
//        //    Dim liNoOfRecord As Integer = lGirdview.Rows.Count
//        //    ' As we insert empty row for no result, so liNoOfRecord = 1. We have to set back to 0.
//        //    If liNoOfRecord = 1 Then
//        //        If lGirdview.Rows(0).Cells.Count < 3 Then
//        //            liNoOfRecord = 0
//        //        End If
//        //    End If
//        //    Return liNoOfRecord
//        //End Function

//        public static string sAddQueryParameter(string psHeader, object psValue)
//        {
//            return "&" + psHeader.ToString() + "=" + nsWebControl.mWebControl.sGetControlValue(psValue).ToString();
//        }

//        public static string sAddQueryQuestionMark(string psURL)
//        {
//            if (psURL.Contains("?"))
//            {
//            }
//            else
//            {
//                psURL += "?";
//            }

//            return psURL;
//        }
//    }
//}
//#endregion

//// Web Based
//#region "nsClass"
//namespace nsClass
//{
//    public static class mClass
//    {

//        public static void cPageCheckLogin(ref System.Web.UI.Page pMe)
//        {
//            nsWorkFlow.mWorkFlow.CheckLoginName();
//        }

//        /// <summary>
//        /// f1 - Check User Login.
//        /// f3 - Build ClsHashTableHelper. (Translation table)
//        /// f4 - fFillHashTable. (Auto Translate all controls in page.)
//        /// f5 - add log
//        /// </summary>

//        public static void cPageLoadHelper_GuocoWeb(ref System.Web.UI.TemplateControl pMe, ref ClassHashTableHelper pClsHashTableHelper, bool pbCheckLogin = false, string psLocationOfHashTable = LIBWebBased.BLANK, string psStoredProcedureOfHashTable = LIBWebBased.BLANK, bool pbTranslatePage = true)
//        {
//            //Dim context As HttpContext = HttpContext.Current
//            //context.Response.Filter = New GZipStream(context.Response.Filter, CompressionMode.Compress)
//            //HttpContext.Current.Response.AppendHeader("Content-encoding", "gzip")
//            //HttpContext.Current.Response.Cache.VaryByHeaders("Accept-encoding") = True

//            bool lbIsPostBack = false;
//            string lsType = pMe.GetType().BaseType.BaseType.Name;
//            string lsAutoLogin = LIBWebBased.BLANK;

//            switch (lsType)
//            {
//                case "Page":
//                    Page lPage = pMe;

//                    lbIsPostBack = lPage.IsPostBack;
//                    // can remove attachment #tag, eg, upload file require refresh page, then it will keep the same position
//                    lPage.MaintainScrollPositionOnPostBack = true;
//                    lsAutoLogin = nsSQL.mSQL.oHandleNullAndNothing(lPage.Request.QueryString["AutoLogin"]);
//                    lPage.Response.AddHeader("X-UA-Compatible", "IE=8");
//                    // lPage.Response.ContentEncoding = System.Text.Encoding.UTF7

//                    if (lsAutoLogin != LIBWebBased.BLANK)
//                    {
//                        System.Web.Security.FormsAuthentication.SetAuthCookie(lsAutoLogin, true);
//                        UserControlLibrary.Lamsoon.CookieUtil.SetCookie("userName", lsAutoLogin);
//                        lPage.Request.Cookies["userName"].Value = lsAutoLogin;
//                    }

//                    break;
//                case "UserControl":
//                    System.Web.UI.UserControl lUserControl = pMe;
//                    lbIsPostBack = lUserControl.IsPostBack;
//                    lsAutoLogin = nsSQL.mSQL.oHandleNullAndNothing(lUserControl.Request.QueryString["AutoLogin"]);

//                    break;
//            }

//            // f1 - Check user login

//            if (lsAutoLogin == LIBWebBased.BLANK)
//            {
//                if (pbCheckLogin)
//                {
//                    nsWorkFlow.mWorkFlow.CheckLoginName();
//                    try
//                    {
//                        // f5 - add log
//                        HttpContext lHttpContext = HttpContext.Current;
//                        if (lHttpContext == null | lHttpContext.Request == null)
//                        {
//                        }
//                        else
//                        {
//                            if (!lbIsPostBack)
//                            {
//                                nsCommon.mCommon.PageLoginLog(LIBWebBased.gsUserName(), gsProjectCode, HttpContext.Current.Request.Url.ToString(), LIBWebBased.BLANK);
//                            }
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                    }
//                }

//            }
//            else
//            {
//            }

//            // f3 - Build ClsHashTableHelper. (Translation table)
//            switch (true)
//            {
//                case psStoredProcedureOfHashTable != LIBWebBased.BLANK:
//                    // from store procedure
//                    pClsHashTableHelper = new ClassHashTableHelper(psStoredProcedureOfHashTable, ClassHashTableHelper.enHashTableType.StoredProcedure);

//                    break;
//                case psLocationOfHashTable != LIBWebBased.BLANK:
//                    // from XML
//                    pClsHashTableHelper = new ClassHashTableHelper(psLocationOfHashTable, ClassHashTableHelper.enHashTableType.XMLFile);

//                    break;
//                case true:
//                    pClsHashTableHelper = new ClassHashTableHelper();
//                    // update the global setting for instance update STP.
//                    LIBWebBased.GlobalClassHashTableHelper = pClsHashTableHelper;

//                    break;
//            }

//            // f4 - fFillHashTable. (Auto Translate all controls in page.)
//            if (!lbIsPostBack)
//            {
//                if (pbTranslatePage)
//                {
//                    nsWebControl.mWebControl.SearchWebControl(pMe.Controls, pClsHashTableHelper.fFillHashTable);
//                }
//            }

//            // Cannot Show Grid in main page, show disable this function
//            // nsWebControl.SearchWebControl(pMe.Controls, AddressOf nsWebControl.fSetDatePicker)

//            try
//            {
//                ScriptManager.GetCurrent(pMe).AsyncPostBackTimeout = 0;

//            }
//            catch (Exception ex)
//            {
//            }
//        }

//        /// <summary>
//        /// can be remove if no place use, programmer can directly use cPageLoadHelper_GuocoWeb.
//        /// </summary>
//        public static void cHashTableHelper(ref System.Web.UI.TemplateControl pMe, ref ClassHashTableHelper pClsHashTableHelper, string psStoredProcedureOfHashTable = LIBWebBased.BLANK)
//        {
//            mClass.cPageLoadHelper_GuocoWeb(ref pMe, ref pClsHashTableHelper, false, LIBWebBased.BLANK, psStoredProcedureOfHashTable, false);
//        }

//        /// <summary>
//        /// Core Function of the GridView
//        /// for SqlDataSource binding Grid
//        /// f1 - Add Sort Icon
//        /// f2 - Add Standard Paging
//        /// This paging can only work in small amount of data. - 
//        /// Use in Main Page
//        /// </summary>
//        public static void cGridViewHelper(System.Web.UI.TemplateControl pMe, GridView pGridView)
//        {
//            ClassGridViewHelper ClsGridViewHelper = new ClassGridViewHelper();
//            var _with57 = ClsGridViewHelper;
//            _with57.SetGridView(pGridView);

//            // f1
//            if (pGridView.AllowSorting)
//            {
//                _with57.fAddSortIcon();
//            }

//            // f2
//            if (pGridView.AllowPaging)
//            {
//                _with57.fAddPaging(pMe);
//            }
//        }

//        // can be remove if no place use, programmer can directly use cGridViewHelper.
//        private static void cGridViewAddSortIcon(GridView pGridView)
//        {
//            mClass.cGridViewHelper(null, pGridView);
//        }

//        /// <summary>
//        /// Add Sort/PageIndex to Gridview, can handle extra header
//        /// </summary>
//        public static void cGridViewAddSortMethod(GridView pGridView, LIBWebBased.DFunc0 pDFunc0, Label pLabel, LIBWebBased.DFunc0 pDBuildGridHeader = null, ClassGridViewHelper.enGridViewType piGridViewType = ClassGridViewHelper.enGridViewType.NormalReport)
//        {
//            ClassGridViewHelper ClsGridViewHelper = new ClassGridViewHelper();
//            var _with58 = ClsGridViewHelper;

//            _with58.SetGridView(pGridView, piGridViewType);
//            _with58.SetSortLabel(pLabel);
//            _with58.fAddSortMethod(pDFunc0, pDBuildGridHeader);
//            _with58.fAddPageIndexChangingMethod(pDFunc0);

//            _with58.fAddAutoGeneratedColumn();
//        }

//        /// <summary>
//        /// DynamicReport
//        /// </summary>
//        public static ClassGridViewHelper cGridViewDynamicReportAddAutoGeneratedColumn(GridView pGridView, ListControl pDDLRowOption, ListControl pDDLColumnOption,LIBWebBased.DFunc3 pDFunc3sGetCellURLCode, bool pbHideEmptyColumn = true, bool pbHighLightMaximumColumn = true, ClassGridViewHelper.enGridViewType piGridViewType = ClassGridViewHelper.enGridViewType.DynamicReportWithAutoGeneratedColumn)
//        {

//            ClassGridViewHelper ClsGridViewHelper = new ClassGridViewHelper();
//            var _with59 = ClsGridViewHelper;

//            _with59.SetGridView(pGridView, piGridViewType);
//            _with59.SetHideEmptyColumn(pbHideEmptyColumn);
//            _with59.SetDDLRowColumnOption(pDDLRowOption, pDDLColumnOption);
//            _with59.SetHighLightMaximumColumn(pbHighLightMaximumColumn);

//            _with59.fAddAutoGeneratedColumn(pDFunc3sGetCellURLCode);
//            return ClsGridViewHelper;
//        }

//        /// <summary>
//        /// Setting File upload control
//        /// </summary>
//        public static void cFileUploadHelper(System.Web.UI.TemplateControl pMe, ClassFileUploadHelper pClsFileUploadHelper, FileUpload pFileUpload)
//        {
//            var _with60 = pClsFileUploadHelper;
//            _with60.SetPage(pMe);
//            _with60.SetFileUpload(pFileUpload);

//        }
//    }

//}
//#endregion

//// Web Based
//#region "nsDataSet"
//namespace nsDataSet
//{
//    public static class mDataSet
//    {

//        public static bool bExistDataSet(System.Data.DataSet pDataSet)
//        {
//            if (pDataSet == null)
//            {
//                return false;
//            }
//            else
//            {
//                if (pDataSet.Tables.Count > 0)
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//        }

//        public static void BindDataGrid(System.Data.DataSet pDataSet, System.Web.UI.WebControls.BaseDataList pDataGrid)
//        {
//            try
//            {
//                if (pDataSet.Tables[0].Rows.Count > 0)
//                {
//                    pDataGrid.DataSource = pDataSet.Tables[0].DefaultView;
//                    pDataGrid.DataBind();
//                }
//                else
//                {
//                    pDataGrid.DataSource = null;
//                    pDataGrid.DataBind();
//                }


//            }
//            catch (Exception ex)
//            {
//            }
//        }

//        /// <summary>
//        /// pass 1 para to fill Grid
//        /// </summary>
//        public static void BindGridViewSinglePara(string psFirstParameter, object psFirstParameterValue, string psStoreProcedureName, GridView pGridView)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with61 = ClsLoadFieldHelper;
//            _with61.fAddSqlParameter(psFirstParameter, psFirstParameterValue);
//            _with61.fBuildDataSet(psStoreProcedureName);
//            _with61.fBindGridView(pGridView, false);
//        }

//        /// <summary>
//        /// Function to perform grid view data bind.
//        /// </summary>
//        public static void BindGridView(System.Data.DataSet pDataSet, System.Web.UI.WebControls.GridView pGridView)
//        {
//            try
//            {
//                pGridView.EmptyDataText = nsCommon.mCommon.sEmptyDataText();
//                pGridView.DataSource = pDataSet;
//                pGridView.DataBind();

//            }
//            catch (Exception ex)
//            {
//                BindNoRecord(pGridView);
//            }
//        }

//        public static void BindGridView(System.Data.DataTable pDataTable, System.Web.UI.WebControls.GridView pGridView)
//        {
//            pGridView.DataSource = pDataTable.DefaultView;
//            pGridView.DataBind();
//        }

//        private static void BindNoRecord(System.Web.UI.WebControls.GridView pGridView)
//        {
//            DataTable lDataTable = new DataTable();
//            pGridView.EmptyDataText = nsCommon.mCommon.sEmptyDataText();
//            pGridView.DataSource = lDataTable.DefaultView;
//            pGridView.DataBind();
//            // Call GridViewAddNoRecordRow(lDataTable, pGridView, pClsHashTableHelper)
//        }

//        // old method
//        //Private Sub GridViewAddNoRecordRow(ByVal pDataTable As DataTable, _
//        //                         ByVal pGridView As System.Web.UI.WebControls.GridView, _
//        //                         ByVal pClsHashTableHelper As ClassHashTableHelper)
//        //    pGridView.DataSource = pDataTable.DefaultView
//        //    pGridView.DataBind()
//        //    Dim liColumnCount As Integer = pGridView.Columns.Count
//        //    pGridView.Rows(0).Cells.Clear()
//        //    ' Old Method
//        //    pGridView.Rows(0).Cells.Add(New TableCell)
//        //    pGridView.Rows(0).Cells(0).ColumnSpan = liColumnCount
//        //    pGridView.Rows(0).Cells(0).HorizontalAlign = HorizontalAlign.Center
//        //    pGridView.Rows(0).Cells(0).ForeColor = Drawing.Color.Green
//        //    pGridView.Rows(0).Cells(0).Text = pClsHashTableHelper.sGetHash("沒有記錄")
//        //    pGridView.Rows(0).Cells(0).Text.PadRight(pGridView.Width.Value / 2)
//        //    ' New Method
//        //    'Dim tbCell As TableCell = New TableCell
//        //    'tbCell.EnableViewState = True
//        //    'tbCell.Text = "<div class='asterisk textCenter'>" & pClsHashTableHelper.sGetHash("沒有記錄") & "</div>"
//        //    'pGridView.Rows(0).Cells.Add(tbCell)
//        //    'pGridView.Rows(0).Cells(0).ColumnSpan = liColumnCount
//        //End Sub


//        public static void BindControl(string psStoreProcedureName, ref object pControl, string psFirstField = LIBWebBased.BLANK, string psFirstValue = LIBWebBased.BLANK, string psConnectionString = LIBWebBased.BLANK, LIBWebBased.enDropDownListType  penDropDownListType = enDropDownListType.NoValue, bool pbDoTranslation = false)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with62 = ClsLoadFieldHelper;
//            // f1
//            if (psFirstField != LIBWebBased.BLANK)
//            {
//                _with62.fAddSqlParameter(psFirstField, psFirstValue);
//            }
//            // f2
//            _with62.fBuildDataSet(psStoreProcedureName, null, psConnectionString);
//            _with62.fBindControls(pControl, penDropDownListType, pbDoTranslation);
//        }

//        #region "ListControl"
//        /// <summary>
//        /// BindListControl using Stored Procedure
//        /// f1 - Set lSqlParameter
//        /// f2 - Build dataset and fill ListControl by lSqlParameter
//        /// f3 - Translation the field
//        /// </summary>

//        public static void BindListControl(string psStoreProcedureName, ref ListControl pListControl, LIBWebBased.enDropDownListType  penDropDownListType = enDropDownListType.NoValue, bool pbDoTranslation = false, string psFirstField = LIBWebBased.BLANK, string psFirstValue = LIBWebBased.BLANK, string psConnectionString = LIBWebBased.BLANK)
//        {
//            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
//            var _with63 = ClsLoadFieldHelper;
//            // f1
//            if (psFirstField != LIBWebBased.BLANK)
//            {
//                _with63.fAddSqlParameter(psFirstField, psFirstValue);
//            }
//            else
//            {
//                _with63.fAddSqlParameter("@lang", LIBWebBased.GlobalClassHashTableHelper.msLang);
//            }
//            // f2
//            _with63.fBuildDataSet(psStoreProcedureName, null, psConnectionString);
//            _with63.fBindControls(pListControl, penDropDownListType, pbDoTranslation);
//        }

//        /// <summary>
//        /// BindListControl using Dataset
//        /// </summary>
//        public static void BindListControl(System.Data.DataSet pDataset, ref ListControl pListControl, LIBWebBased.enDropDownListType  penDropDownListType = enDropDownListType.NoValue, bool pbDoTranslation = false)
//        {
//            nsDataSet.BindListControlBase(pDataset, pListControl);
//            mDataSet.SetDDLType(ref pListControl, penDropDownListType);
//            if (pbDoTranslation)
//            {
//                // f3
//                nsCommon.mCommon.fListControlTranslateDDL(pListControl);
//            }
//        }

//        /// <summary>
//        ///  BindListControl using Dataset Base
//        /// </summary>
//        private static void BindListControlBase(System.Data.DataSet pDataSet, ref ListControl pListControl)
//        {
//            // 只有第1/第2行的DATA才會成為display/value field. 
//            pListControl.DataSource = pDataSet;

//            if (pDataSet == null)
//            {
//                pListControl.Items.Clear();
//            }
//            else
//            {
//                string lsColumnName = pDataSet.Tables[0].Columns[0].Caption;
//                if (nsCommon.mCommon.bIsKeyField(lsColumnName))
//                {
//                    pListControl.DataValueField = pDataSet.Tables[0].Columns[0].Caption;
//                    pListControl.DataTextField = pDataSet.Tables[0].Columns[1].Caption;
//                }
//                else
//                {
//                    pListControl.DataValueField = pDataSet.Tables[0].Columns[1].Caption;
//                    pListControl.DataTextField = pDataSet.Tables[0].Columns[0].Caption;
//                }
//            }
//            pListControl.DataBind();
//        }

//        /// <summary>
//        /// Add Extra WebControls.ListItem to ListControl
//        /// </summary>
//        public static void SetDDLType(ref ListControl pListControl, LIBWebBased.enDropDownListType  penDropDownListType)
//        {
//            ClassHashTableHelper lClsHashTableHelper = LIBWebBased.GlobalClassHashTableHelper;
//            System.Web.UI.WebControls.ListItem lListItem = new System.Web.UI.WebControls.ListItem();

//            if (pListControl.Items.Count == 0)
//            {
//                // Have not data
//                switch (penDropDownListType)
//                {
//                    case enDropDownListType.All:
//                        lListItem.Value = "All";
//                        lListItem.Text = lClsHashTableHelper.sGetHash("All");
//                        pListControl.Items.Insert(0, lListItem);

//                        break;
//                    case enDropDownListType.BlankAndNA:
//                        pListControl.Items.Insert(0, LIBWebBased.BLANK);
//                        lListItem.Value = "NA";
//                        lListItem.Text = lClsHashTableHelper.sGetHash("N/A");
//                        pListControl.Items.Insert(pListControl.Items.Count, lListItem);

//                        break;
//                    case enDropDownListType.NA:
//                        lListItem.Value = "All";
//                        lListItem.Text = lClsHashTableHelper.sGetHash("N/A");
//                        pListControl.Items.Insert(0, lListItem);

//                        break;
//                    default:
//                        lListItem.Value = "";
//                        lListItem.Text = lClsHashTableHelper.sGetHash("沒有資料");
//                        pListControl.Items.Insert(0, lListItem);
//                        break;
//                }
//            }
//            else
//            {
//                // Have Data
//                switch (penDropDownListType)
//                {
//                    case enDropDownListType.All:
//                        lListItem.Value = "All";
//                        lListItem.Text = lClsHashTableHelper.sGetHash("All");
//                        pListControl.Items.Insert(0, lListItem);

//                        break;
//                    case enDropDownListType.NA:
//                        lListItem.Value = "All";
//                        lListItem.Text = lClsHashTableHelper.sGetHash("N/A");
//                        pListControl.Items.Insert(0, lListItem);

//                        break;
//                    case enDropDownListType.Blank:
//                        pListControl.Items.Insert(0, LIBWebBased.BLANK);

//                        break;
//                    case enDropDownListType.NoValue:

//                        break;
//                    case enDropDownListType.DDLNoOption:
//                        lListItem.Value = "DllNo";
//                        lListItem.Text = lClsHashTableHelper.sGetHash("DllNo");
//                        pListControl.Items.Insert(0, lListItem);

//                        break;
//                    case enDropDownListType.BlankAndOther:
//                        pListControl.Items.Insert(0, LIBWebBased.BLANK);
//                        lListItem.Value = "其他";
//                        lListItem.Text = lClsHashTableHelper.sGetHash("其他");
//                        pListControl.Items.Insert(pListControl.Items.Count, lListItem);

//                        break;
//                    case enDropDownListType.Other:
//                        lListItem.Value = "其他";
//                        lListItem.Text = lClsHashTableHelper.sGetHash("其他");
//                        pListControl.Items.Insert(pListControl.Items.Count, lListItem);

//                        break;
//                    case enDropDownListType.BlankAndNA:
//                        pListControl.Items.Insert(0, LIBWebBased.BLANK);
//                        lListItem.Value = "NA";
//                        lListItem.Text = lClsHashTableHelper.sGetHash("N/A");
//                        pListControl.Items.Insert(pListControl.Items.Count, lListItem);

//                        break;
//                }
//            }

//        }

//        #endregion

//    }
//}
//#endregion

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

//    public Data.DataSet fGetDataSet()
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
//    public void fBindControls(object pControl, LIBWebBased.enDropDownListType  penDropDownListType = null, bool pbDoTranslation = false)
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

//    private DFunc3 mDFunc3sGetCellURLCode;
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
//    public void fAddMasterColumn(object pHeaderText, object pColumnSpan = "1", HorizontalAlign pAlign = HorizontalAlign.Center)
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

//    public void fAddAutoGeneratedColumn(DFunc3 pDFunc3sGetCellURLCode = null)
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
//    private object BuildGridDynamicReportHeaderFooter(GridView pGridview, ListControl pDDLRowOption, ListControl pDDLColumnOption, DFunc3 pDFunc3sGetCellURLCode)
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
//    public void fAddSortMethod(DFunc0 pObject, LIBWebBased.DFunc0 pObject2BuildGridHeader = null)
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
//    public void fAddPageIndexChangingMethod(DFunc0 pObject)
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
//    void fAddSortMethod(DFunc0 pObject, LIBWebBased.DFunc0 pObject2BuildGridHeader = null);
//    void fAddPageIndexChangingMethod(DFunc0 pObject);
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
