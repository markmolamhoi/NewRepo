using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LSLIBWebBased;

public partial class ucPageHeader : System.Web.UI.UserControl
{
    public string msTitle
    {
        set
        {
            this.ltlTitle.Text = value;
        }

        get
        {
            return this.ltlTitle.Text;
        }
    }
    
    private string msReportType
    {
        get
        {
            return LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["ReportType"]).ToString();
        }
    }

    private string msReportID
    {
        get
        {
            return LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["ReportID"]).ToString();
        }
    }
    protected ClassHashTableHelper ClsHashTableHelper;
    protected void Page_Init(object sender, EventArgs e)
    {

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        //檢查登入權限+取得翻譯表
        LSLIBWebBased.nsClass.mClass.cPageLoadHelper_GuocoWeb(this, ref ClsHashTableHelper, false, "", "", true);
        if (!IsPostBack)
        {
            string lsKey;
            if (msReportID != "")
            {
                lsKey = msReportID;
            }
            else
            {
                lsKey = System.Configuration.ConfigurationManager.AppSettings["ProjectCode"];
            }
            //this.HyperLink1.NavigateUrl = LoadLanguageURL("tc");
            //this.HyperLink2.NavigateUrl = LoadLanguageURL("sc");
            //this.HyperLink3.NavigateUrl = LoadLanguageURL("en");
            this.hlUserManual.NavigateUrl = ClsHashTableHelper.sGetHash(lsKey + "_UserManual");
            this.hlSystemUpdateLog.NavigateUrl = ClsHashTableHelper.sGetHash(lsKey + "_SystemUpdateLog");
            this.lblPageHeaderTips.Text = ClsHashTableHelper.sGetHash(lsKey + "_SystemUpdateTips");

            if (this.hlUserManual.NavigateUrl == lsKey + "_UserManual")
            {
                this.hlUserManual.Visible = false;
                this.lblUserManual.Visible = false;
            }

            if (this.hlSystemUpdateLog.NavigateUrl == lsKey + "_SystemUpdateLog")
            {
                this.hlSystemUpdateLog.Visible = false;
                this.lblSystemUpdateLog.Visible = false;
            }

            if (this.lblPageHeaderTips.Text == lsKey + "_SystemUpdateTips")
            {
                this.lblPageHeaderTips.Visible = false;
            }

            try
            {
                if (HttpContext.Current.Request.Url.ToString().Contains("Account_Login.aspx"))
                {
                    ltlName.Text = "";
                }
                else
                {
                    ltlName.Text = LIBLocal.sLoadUserName(ClsHashTableHelper.msUserName);
                }


            }
            catch (Exception)
            {
                
            }
            
        }
    }


    protected string LoadLanguageURL(string psLang)
    {
        psLang = "lang=" + psLang;
        if (Request.QueryString["lang"] == "" || Request.QueryString["lang"] == null)
        {
            if (Request.Url.PathAndQuery.ToString().Contains("?"))
            {
                return Request.Url.PathAndQuery.ToString() + "&" + psLang;
            }
            else
            {
                return Request.Url.PathAndQuery.ToString() + "?" + psLang;
            }
        }
        else
        {
            return Request.Url.PathAndQuery.ToString().Replace("lang=" + ClsHashTableHelper.msLang, psLang);
        }
    }
}