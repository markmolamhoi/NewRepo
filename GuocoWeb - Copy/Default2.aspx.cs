using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LSLIBWebBased;
using System.Text;

public partial class _Default2 : System.Web.UI.Page
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
    private string msFolderCode
    {
        get
        {
            return LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["FolderCode"]).ToString();
        }
    }

    private string msReportID
    {
        get
        {
            return LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["ReportID"]).ToString();
        }
    }
    protected void Page_Init(object sender, System.EventArgs e)
    {
        //取得翻譯表
        LSLIBWebBased.nsClass.mClass.cPageLoadHelper_GuocoWeb(this, ref ClsHashTableHelper, true, "", "stp_wf_all_GetTranslationField");
        if (msFolderCode != "")
        {
            this.Title = ClsHashTableHelper.sGetHash(msFolderCode);
        }
        else
            this.Title = ClsHashTableHelper.sGetHash("報表系統");

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
        TreeView1.Nodes.Clear();
        AddNode(TreeView1.Nodes, msFolderCode);
    }
    private void AddNode(TreeNodeCollection pTreeNode, String psFolderCode)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
        ClsLoadFieldHelper.fAddSqlParameter("@Username", this.ClsHashTableHelper.msUserName);
        ClsLoadFieldHelper.fAddSqlParameter("@FolderCode", psFolderCode);
        ClsLoadFieldHelper.fBuildDataSet("stp_wf_dms_GridFolder");

        while (ClsLoadFieldHelper.bHasNextRow())
        {
            String lsFolderCode = ClsLoadFieldHelper.oLoadSqlField("FolderCode").ToString();
            TreeNode lTreeNode = new TreeNode();
            lTreeNode.Value = lsFolderCode;
            lTreeNode.Text = this.ClsHashTableHelper.sGetHash(lsFolderCode);

            AddNode(lTreeNode.ChildNodes, lTreeNode.Value);

            pTreeNode.Add(lTreeNode);

            lTreeNode.Expanded = false;


        }

    }
    
    

    private string sReportName(String psReportID, String psReportname)
    {
        String lsReportName = this.ClsHashTableHelper.sGetHash(psReportID);

        if (lsReportName != psReportID)
        {
            return lsReportName;
        }
        else
        {
            return this.ClsHashTableHelper.sGetHash(psReportname);
        }
    }


    string msListTemplate = @"<div data-role=""collapsible""  data-collapsed=""false"" ><h4>ListName</h4><ul data-role=""listview"">ListItems</ul></div>";

    String msListItemTemplate = @"<li><a href=""URLLink"" target=""_blank"">ItemName</a></li>";


}