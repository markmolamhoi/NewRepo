using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Security.Cryptography;
using System.Windows.Forms;

public partial class Account_Login : System.Web.UI.Page
{

    protected string strupdatePassWord = System.Configuration.ConfigurationManager.AppSettings["updatePassWord"];

    private string msReturnURL
    {
        get
        {
            if (LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["ReturnURL"]) == LSLIBWebBased.LIBWebBased.BLANK)
            {
                return "";
            }
            else
            {
                return this.Request.QueryString["ReturnURL"];
            }

        }
    }

  
    public string msLogout
    {
        get
        {
            if ((Request.QueryString["Logout"] == null))
            {
                return "";
            }
            else
            {
                return Request.QueryString["Logout"];
            }

        }
    }
    string msLSuser = "";
    public string msUser
    {
        get
        {
            try
            {
                if ((Request.QueryString["User"] == null))
                {
                    return msLSuser;
                }
                else
                {
                    return Request.QueryString["User"];
                }

            }
            catch (Exception ex)
            {
                return "";
            }

        }
    }
    public string miLoginSeq
    {
        get
        {
            try
            {
                if ((Request.QueryString["LoginSeq"] == null))
                {
                    return "0";
                }
                else
                {
                    return Request.QueryString["LoginSeq"];
                }

            }
            catch (Exception ex)
            {
                return "0";
            }

        }
    }
    public string msRoot
    {
        get
        {
            try
            {
                if ((Request.QueryString["Root"] == null))
                {
                    if ((HttpContext.Current.Request.Url.ToString().ToLower().IndexOf(".com") > -1))
                    {
                        return ".com";
                    }
                    else
                    {
                        return ".lsgp";
                    }

                }
                else
                {
                    return Request.QueryString["Root"];
                }

            }
            catch (Exception ex)
            {
                return "";
            }

        }
    }

    protected LSLIBWebBased.ClassHashTableHelper ClsHashTableHelper;

    protected void Page_Init(object sender, EventArgs e)
    {

        //Todo Done, ToCheck Done, Single sign out seem no use.
        if ((msLogout != ""))
        {
            //Response.Cookies["LS"].Expires = DateTime.Now.AddYears(-30);
            //SingleSignOn(true);
        }

        //Todo Done, ToCheck Done, Sign Out when user enter this page.
        if (!IsPostBack)
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Cookies.Set(new HttpCookie(HttpContext.Current.Server.UrlEncode("userName"), ""));
        }

        //Todo, try rewrite the cPageLoadHelper_GuocoWeb,ClsHashTableHelper in LIBLocal, dont use library.
        //取得翻譯表
        LSLIBWebBased.nsClass.mClass.cPageLoadHelper_GuocoWeb(this, ref ClsHashTableHelper, false, "", "stp_wf_all_GetTranslationField");
       // this.Title = this.ClsHashTableHelper.sGetHash("內聯網-登入");
        this.Title = this.ClsHashTableHelper.sGetHash("Intranet - Login");
        this.ucPageHeader1.msTitle = this.Title;
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LSLIBWebBased.nsCommon.mCommon.fButtonSetOpenURL(this.btnUpdatePassword, "Account_UpdatePassword.aspx?&PostCode=Account_001&FolderCode=RootFolder_MyAccount");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //Todo Done, ToCheck Done, Login function
        if (bCanLogin(txtUsername.Text, txtPassword.Text))
        {

            LIBLocal.SetCookie(txtUsername.Text);

            //Lamsoon .Net 1.1 login.
            //SingleSignOn();

            if (bIsFirstLogin(txtUsername.Text))
            {
                if (bLoginReminder(txtUsername.Text) == false)
                {
                    //  login Reminder
                    //javascript
                    LSLIBWebBased.nsScript.mScript.Alert(this, "The password has expired,Please reset Password.", false);

                    //DialogResult dr = MessageBox.Show("密碼即將過期，是否進入密碼修改界面？", "密碼提示框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    //if (dr == DialogResult.OK)
                    //{
                    //    // Yes Update
                    //    //Response.Redirect("updatePassWord");
                    //    Response.Redirect("Account_UpdatePassword.aspx");
                    //}
                    //else
                    //{
                    // No goto Default.aspx
                    //if (!(Request.QueryString["ReturnUrl"] == null))
                    //{
                    //    Response.Redirect(Request.QueryString["ReturnUrl"]);
                    //}
                    //else
                    //{
                    //    Response.Redirect((System.Configuration.ConfigurationManager.AppSettings["defaultPage"]));
                    //}
                    //}
                    //}
                    //else
                    //{
                    // No goto Default.aspx
                }


                if (!(Request.QueryString["ReturnUrl"] == null))
                {
                    Response.Redirect(Request.QueryString["ReturnUrl"]);
                }
                else
                {
                    Response.Redirect((System.Configuration.ConfigurationManager.AppSettings["defaultPage"]));
                }

            }
            else
            {
                //is first login
                Response.Redirect("Account_UpdatePassword.aspx?&PostCode=Account_001&FolderCode=RootFolder_MyAccount&IsFristLogin=Yes");
            }

        }
        else
        {
            lblReminder.ForeColor = System.Drawing.Color.Red;
            lblReminder.Text = ClsHashTableHelper.sGetHash("loginFailed");
            lblReminder.Visible = true;
        }
    }
    
    
    public bool bCanLogin(String psUsername, String psPassword)
    {

        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("@username", psUsername);
        ClsLoadFieldHelper.fAddSqlParameter("@Password", LIBLocal.sLoadPasswordHashValue(psUsername, psPassword));

        ClsLoadFieldHelper.fBuildDataSet("stp_wf_account_bCanLogin");

        if (ClsLoadFieldHelper.mbDataSetHasRecord)
        {
            LSLIBWebBased.nsScript.mScript.Alert(this, ClsLoadFieldHelper.oLoadSqlField("Result").ToString(), false);
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool bIsFirstLogin(String psUsername)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("@username", psUsername);

        ClsLoadFieldHelper.fBuildDataSet("stp_wf_account_bIsFirstLogin");

        if (ClsLoadFieldHelper.mbDataSetHasRecord)
        {
            LSLIBWebBased.nsScript.mScript.Alert(this, ClsLoadFieldHelper.oLoadSqlField("Result").ToString(), false);
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool bLoginReminder(String psUsername)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("@username", psUsername);

        ClsLoadFieldHelper.fBuildDataSet("stp_wf_account_bLoginReminder");

        if (ClsLoadFieldHelper.mbDataSetHasRecord)
        {
            LSLIBWebBased.nsScript.mScript.Alert(this, ClsLoadFieldHelper.oLoadSqlField("Result").ToString(), false);
            return false;
        }
        else
        {
            return true;
        }
    }

    #region SingleSignOn
    private void SingleSignOn(bool bLogOut = false)
    {
        string lsRedirectURL = "";
        // Warning!!! Optional parameters not supported
        if ((msReturnURL != ""))
        {
            lsRedirectURL = ("&ReturnUrl=" + msReturnURL);
        }

        string lsUser = "";
        if ((txtUsername.Text == ""))
        {
            lsUser = HioDecrypt(HttpUtility.UrlDecode(msUser));
        }
        else
        {
            lsUser = txtUsername.Text;
        }

        string lsParameter = "";
        if (bLogOut)
        {
            lsParameter = "logout=out";
            HttpContext.Current.Response.Cookies.Set(new HttpCookie(HttpContext.Current.Server.UrlEncode("userName"), ""));
        }
        else
        {
            lsParameter = ("User=" + HttpUtility.UrlEncode(HioEncrypt(lsUser)));
        }

        string lsURL = "";
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
        ClsLoadFieldHelper.fAddSqlParameter("LoginSeq", miLoginSeq);
        ClsLoadFieldHelper.fBuildDataSet("stp_wf_account_SSO_GridDomainMaster");
        // With...
        while (ClsLoadFieldHelper.bHasNextRow())
        {
            lsURL = ClsLoadFieldHelper.oLoadSqlField("Domain") + "login.aspx?";
            string lsSubDomainURL = lsURL
                        + lsParameter
                        + lsRedirectURL
                        + "&LoginSeq=" + ClsLoadFieldHelper.oLoadSqlField("LoginSeq").ToString()
                        + "&Root=" + msRoot 
                        + "&isMobile=" + this.Request.QueryString["isMobile"];
            try
            {
                if ((HttpContext.Current.Request.Url.ToString().ToLower().IndexOf(msRoot) > -1 && lsURL.ToLower().IndexOf(msRoot) > -1) 
                    || (HttpContext.Current.Request.Url.ToString().ToLower().IndexOf("local") > -1 || HttpContext.Current.Request.Url.ToString().ToLower().IndexOf("10.1.0.39") > -1)
                    )
                {
                    Response.Redirect(lsSubDomainURL);
                }

            }
            catch (Exception ex)
            {
            }

        }

        if ((msReturnURL == ""))
        {
            if ((HttpContext.Current.Request.Url.ToString().ToLower().IndexOf(".com") > -1))
            {
                Response.Redirect(sBackUpReturnURL("4", Request["isMobile"]));
            }
            else
            {
                Response.Redirect(sBackUpReturnURL("1", Request["isMobile"]));
            }

        }
        else if (LSLIBWebBased.nsNetwork.mNetwork.bURLIsValid(msReturnURL, lsUser))
        {
            Response.Redirect(msReturnURL);
        }
        else if ((HttpContext.Current.Request.Url.ToString().ToLower().IndexOf(".com") > -1))
        {
            Response.Redirect(sBackUpReturnURL("4", Request["isMobile"]));
        }
        else
        {
            Response.Redirect(sBackUpReturnURL("1", Request["isMobile"]));
        }

    }
    private string sBackUpReturnURL(string psLoginSeq, string IsMobile)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("LoginSeq", psLoginSeq);
        ClsLoadFieldHelper.fBuildDataSet("stp_wf_account_SSO_LoadDomainBackUpReturnURL");


        if ((IsMobile == "Y"))
        {
            return ClsLoadFieldHelper.oLoadSqlField("Domain").ToString() + "lsportal/MobileMain.aspx";
        }
        else
        {
            return ClsLoadFieldHelper.oLoadSqlField("BackUpReturnUrl").ToString();
        }

    }

    public string HioDecrypt(string psString, string psKey = "Default")
    {
        psString =LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(psString).ToString();
        // Warning!!! Optional parameters not supported
        try
        {
            TripleDESCryptoServiceProvider cryptDES3 = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider cryptMD5Hash = new MD5CryptoServiceProvider();
            if ((psKey != "Default"))
            {
                cryptDES3.Key = cryptMD5Hash.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(psKey));
            }
            else
            {
                cryptDES3.Key = cryptMD5Hash.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes("LSWFLS"));
            }

            cryptDES3.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = cryptDES3.CreateDecryptor();
            byte[] buff = System.Convert.FromBase64String(psString);
            return System.Text.ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
        }
        catch (Exception ex)
        {
            return "";
        }

    }

    public string HioEncrypt(string psString, string psKey = "Default")
    {
        TripleDESCryptoServiceProvider cryptDES3 = new TripleDESCryptoServiceProvider();
        // Warning!!! Optional parameters not supported
        MD5CryptoServiceProvider cryptMD5Hash = new MD5CryptoServiceProvider();
        if ((psKey != "Default"))
        {
            cryptDES3.Key = cryptMD5Hash.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(psKey));
        }
        else
        {
            cryptDES3.Key = cryptMD5Hash.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes("LSWFLS"));
        }

        cryptDES3.Mode = CipherMode.ECB;
        ICryptoTransform desdencrypt = cryptDES3.CreateEncryptor();
        System.Text.ASCIIEncoding MyASCIIEncoding = new System.Text.ASCIIEncoding();
        byte[] buff = System.Text.ASCIIEncoding.ASCII.GetBytes(psString);
        return System.Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
    }
    #endregion



}