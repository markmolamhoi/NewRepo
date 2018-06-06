using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LSLIBWebBased;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected ClassHashTableHelper ClsHashTableHelper;

    protected ClassFileUploadHelper ClsFileUploadHelper = new ClassFileUploadHelper();

    public string msUsername
    {
        get
        {
            if (LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["Username"]) == "")
            {
                return ClsHashTableHelper.msUserName;
            }
            else
                return this.Request.QueryString["Username"];
        }
    }

    private string msPostCode
    {
        get
        {
            return LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["PostCode"]).ToString();
        }
    }
    protected void Page_Init(object sender, System.EventArgs e)
    {
        //取得翻譯表
        LSLIBWebBased.nsClass.mClass.cPageLoadHelper_GuocoWeb(this, ref ClsHashTableHelper, true, "", "stp_wf_all_GetTranslationField");

        if (ClsHashTableHelper.mClassMyConfiguration.msSystemCode == "")
        {
            Response.Redirect((System.Configuration.ConfigurationManager.AppSettings["defaultPage"]));
        }

        if (ClsHashTableHelper.mClassMyConfiguration.msSystemCode != "")
        {
            this.Title = ClsHashTableHelper.sGetHash(ClsHashTableHelper.mClassMyConfiguration.msSystemCode);
        }
        else
            this.Title = ClsHashTableHelper.sGetHash("GuocoWeb");

        this.ucPageHeader1.msTitle = this.Title;

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BuildTree();

        }
    }

    private void BuildTree()
    {
        //AddFolder(msFolderCode);
        this.ltlMenu.Text = sLoadFolderList(ClsHashTableHelper.mClassMyConfiguration.msFolderCode, ClsHashTableHelper.mClassMyConfiguration.msSystemCode);
    }

    protected int miNumberOfPost;
    private String sLoadFolderList(string psFolderCode,string psSystemCode)
    {

        StringBuilder lsTreeFolderList = new StringBuilder();
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
        ClsLoadFieldHelper.fAddSqlParameter("@UserCode", this.ClsHashTableHelper.msUserName);
        ClsLoadFieldHelper.fAddSqlParameter("@FolderCode", psFolderCode);
        ClsLoadFieldHelper.fAddSqlParameter("@SystemCode", psSystemCode);
        ClsLoadFieldHelper.fBuildDataSet("stp_wf_dms_GridFolder",null,"",false);
        
        while (ClsLoadFieldHelper.bHasNextRow())
        {
            String lsFolderCode = ClsLoadFieldHelper.oLoadSqlField("FolderCode").ToString(); ;
            String lsFolderList = "FolderList"+ lsFolderCode;
            String lsPostList = "PostList" + lsFolderCode;

            string lsFolderTemplate = msFolderTemplate;
            lsFolderTemplate = lsFolderTemplate.Replace("FolderList", lsFolderList).ToString();
            lsFolderTemplate = lsFolderTemplate.Replace("PostList", lsPostList).ToString();

            lsTreeFolderList.Append(lsFolderTemplate);

            miNumberOfPost = 0;
            lsTreeFolderList.Replace(lsPostList, sLoadFolderPostList(lsFolderCode).ToString());

            lsTreeFolderList.Replace("FolderName", ClsLoadFieldHelper.oLoadSqlField("FolderShortName").ToString()) ;

            lsTreeFolderList.Replace(lsFolderList, sLoadFolderList(ClsLoadFieldHelper.oLoadSqlField("FolderCode").ToString(), ClsLoadFieldHelper.oLoadSqlField("SystemCode").ToString()) );

        }
        return lsTreeFolderList.ToString();
    }

    private String sLoadFolderPostList(string psFolderCode)
    {
        StringBuilder lsFolderPostList = new StringBuilder();
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
        ClsLoadFieldHelper.fAddSqlParameter("@UserCode", this.ClsHashTableHelper.msUserName);
        ClsLoadFieldHelper.fAddSqlParameter("@FolderCode", psFolderCode);
        ClsLoadFieldHelper.fBuildDataSet("stp_wf_dms_GridFolderPost",null,"",false);
        while (ClsLoadFieldHelper.bHasNextRow())
        {
            miNumberOfPost = miNumberOfPost + 1;
            String lsNavigateUrl = this.ClsHashTableHelper.sExchangeURL(LIBLocal.sLoadPostURL(ClsLoadFieldHelper.oLoadSqlField("URL").ToString()
                , ClsLoadFieldHelper.oLoadSqlField("PostCode").ToString()
                , ClsLoadFieldHelper.oLoadSqlField("FolderCode").ToString()
                ) 
                );

            lsFolderPostList.Append(msFolderPostTemplate);
            lsFolderPostList.Replace("URLLink", lsNavigateUrl);
            lsFolderPostList.Replace("PostName", ClsLoadFieldHelper.oLoadSqlField("PostShortName").ToString());

        }
        return lsFolderPostList.ToString();

    }


    private string sReportName(String psReportID , String psReportname){
        String lsReportName = this.ClsHashTableHelper.sGetHash(psReportID);

        if (lsReportName != psReportID){
            return lsReportName;
        }
        else {
            return this.ClsHashTableHelper.sGetHash(psReportname);
        }
    }

    string msFolderTemplate = @"<div data-role=""collapsible-set""> <div data-role=""collapsible""  data-collapsed=""true"" data-theme=""c""><h4>FolderName</h4><ul data-role=""listview"">PostList</ul>FolderList</div></div>";

    String msFolderPostTemplate = @"<li><a href=""URLLink"" target=""_blank"" data-filtertext=""PostName"" > PostName</a></li>";
}