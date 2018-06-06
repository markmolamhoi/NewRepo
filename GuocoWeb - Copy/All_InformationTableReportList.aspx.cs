using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LSLIBWebBased;
using System.Data;

public partial class All_InformationTableReportList : System.Web.UI.Page
{

    protected ClassHashTableHelper ClsHashTableHelper;
    protected ClassFileUploadHelper ClsFileUploadHelper = new ClassFileUploadHelper();

    //查询内容类型
    //this report list is different because FillGridView1 get parametet is different

    #region "Standard Code: UrlParam"
    //ReportType = FolderCode
    private string msReportType
    {
        get
        {
            if (LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["FolderCode"]).ToString() == "")
            {
                return "FolderCode";
            }
            else
            {
                return this.Request.QueryString["FolderCode"];
            }
        }
    }

    private string msContentType
    {
        get
        {
            if (LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["ContenType"]).ToString() == "")
            {
                return ddlReportRowOption.SelectedValue;
            }
            else
            {
                return this.Request.QueryString["ContentType"];
            }
        }
    }

    //ReportID = PostCode
    private string msReportID
    {
        get
        {
            if (LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["PostCode"]).ToString() == "")
            {
                return null;
            }
            else
            {
                return this.Request.QueryString["PostCode"];
            }
        }
    }

    private string msYear
    {
        get
        {
            if (LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["Year"]).ToString() == "")
            {
                return ddlYear.SelectedValue;
            }
            else
            {
                return this.Request.QueryString["Year"];
            }
        }
    }

    private string msMonth
    {
        get
        {
            if (LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["Month"]).ToString() == "")
            {
                return ddlMonth.SelectedValue;
            }
            else
            {
                return this.Request.QueryString["Month"];
            }
        }
    }

    private string msWeek
    {
        get
        {
            if (LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["Week"]).ToString() == "")
            {
                return ddlWeek.SelectedValue;
            }
            else
            {
                return this.Request.QueryString["Week"];
            }
        }
    }

    private string msDivisionCode
    {
        get
        {
            if (LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["DivisionCode"]).ToString() == "")
            {
                return ddlDivision.SelectedValue;
            }
            else
            {
                return this.Request.QueryString["DivisionCode"];
            }
        }
    }

    private string msOUCode
    {
        get
        {
            if (LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["OUCode"]).ToString() == "")
            {
                return "OUCode";
            }
            else
            {
                return this.Request.QueryString["OUCode"];
            }
        }
    }

    private string msCompanyCode
    {
        get
        {
            if (LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["CompanyCode"]).ToString() == "")
            {
                return ddlCompany.SelectedValue;
            }
            else
            {
                return this.Request.QueryString["CompanyCode"];
            }
        }
    }

    private string msRegionCode
    {
        get
        {
            if (LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["RegionCode"]).ToString() == "")
            {
                return ddlRegion.SelectedValue;
            }
            else
            {
                return this.Request.QueryString["RegionCode"];
            }
        }
    }

    private string msSearchKey
    {
        get
        {
            if (LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["SearchKey"]).ToString() == "")
            {
                return txtSearchKey.Text;
            }
            else
            {
                return this.Request.QueryString["SearchKey"];
            }
        }
    }

    private string msLang
    {
        get
        {
            if (LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["Lang"]).ToString() == "")
            {
                return this.ClsHashTableHelper.msLang;
            }
            else
            {
                return this.Request.QueryString["Lang"];
            }
        }
    }
    #endregion

    #region "Standard Code: stp_wf_all_LoadInformationTable_Mapping:"
    private void LoadInformationTable_Mapping(string psReportID)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("@ReportID", psReportID);

        ClsLoadFieldHelper.fBuildDataSet("stp_wf_all_LoadInformationTable_Mapping");

        ClsLoadFieldHelper.LoadSqlField("DropDown_Key", ref lblDropDown_Key);
        ClsLoadFieldHelper.LoadSqlField("Gird_stp_Name", ref lblGird_stp_Name);
        ClsLoadFieldHelper.LoadSqlField("DDLDivisionCode", ref lblDDLDivisionCode);
        ClsLoadFieldHelper.LoadSqlField("DDLCompanyCode", ref lblDDLCompanyCode);
        ClsLoadFieldHelper.LoadSqlField("DDLRegion", ref lblDDLRegion);
        ClsLoadFieldHelper.LoadSqlField("NoOfDDL_Display", ref lblNoOfDDL_Display);

        ClsLoadFieldHelper.LoadSqlField("EnableDDLYear", ref lblEnableDDLYear);
        ClsLoadFieldHelper.LoadSqlField("EnableDDLMonth", ref lblEnableDDLMonth);
        ClsLoadFieldHelper.LoadSqlField("EnableDDLWeek", ref lblEnableDDLWeek);
        ClsLoadFieldHelper.LoadSqlField("EnableDDLContentType", ref lblEnableDDLContentType);
        ClsLoadFieldHelper.LoadSqlField("EnableSearchKey", ref lblEnableSearchKey);
        ClsLoadFieldHelper.LoadSqlField("EnableButtonExportToExcel", ref lblEnableButtonExportToExcel);
        ClsLoadFieldHelper.LoadSqlField("EnableButtonUpdate", ref lblEnableButtonUpdate);

        ClsLoadFieldHelper.LoadSqlField("EnableDateRange", ref lblEnableDateRange);

        ClsLoadFieldHelper.LoadSqlField("defaultValue_SearchKeyName", ref lbldefaultValue_SearchKeyName);
        ClsLoadFieldHelper.LoadSqlField("SearchKeyName", ref lblSearchKeyName);
        ClsLoadFieldHelper.LoadSqlField("Chart_EnableDefinition", ref lblEnableDefinition);

        ClsLoadFieldHelper.LoadSqlField("Chart_ContentType1", ref lblChart_ContentType1);
        ClsLoadFieldHelper.LoadSqlField("Chart_ContentType2", ref lblChart_ContentType2);
        ClsLoadFieldHelper.LoadSqlField("Chart_ContentType3", ref lblChart_ContentType3);
        ClsLoadFieldHelper.LoadSqlField("Chart_ConnectOracle", ref lblChart_ConnectOracle);
        ClsLoadFieldHelper.LoadSqlField("Chart_Type", ref lblChart_ChartType);

        ClsLoadFieldHelper.LoadSqlField("DDLProductCode_4", ref lblDDLProductCode_4);
        ClsLoadFieldHelper.LoadSqlField("DDLSalesmanCode_5", ref lblDDLSalesmanCode_5);
        ClsLoadFieldHelper.LoadSqlField("DDLOUCode_6", ref lblDDLOUCode_6);
        ClsLoadFieldHelper.LoadSqlField("Showing_DDL", ref lblShowing_DDL);

        ClsLoadFieldHelper.LoadSqlField("EnableGrid", ref lblEnableGrid);
        ClsLoadFieldHelper.LoadSqlField("EnableComment", ref lblEnableComment);
    }

    #endregion

    #region "Standard Code: EnableSetting: set the control visible or not"

    private object EnableSetting()
    {
        //NoOfDDL_Display

        divDivision.Visible = false;
        divCompany.Visible = false;
        divRegion.Visible = false;
        divProductCode_4.Visible = false;
        divSalesmanCode_5.Visible = false;
        divOUCode_6.Visible = false;
        divEnableComment.Visible = false;

        if (lblShowing_DDL.Text == "")
        {
            if (lblNoOfDDL_Display.Text == "0")
            {
            }
            else if (lblNoOfDDL_Display.Text == "1")
            {
                divDivision.Visible = true;
            }
            else if (lblNoOfDDL_Display.Text == "2")
            {
                divDivision.Visible = true;
                divCompany.Visible = true;
            }
            else if (lblNoOfDDL_Display.Text == "4")
            {
                divDivision.Visible = true;
                divCompany.Visible = true;
                divRegion.Visible = true;
                divProductCode_4.Visible = true;
            }
            else if (lblNoOfDDL_Display.Text == "5")
            {
                divDivision.Visible = true;
                divCompany.Visible = true;
                divRegion.Visible = true;
                divProductCode_4.Visible = true;
                divSalesmanCode_5.Visible = true;
            }
            else if (lblNoOfDDL_Display.Text == "6")
            {
                divDivision.Visible = true;
                divCompany.Visible = true;
                divRegion.Visible = true;
                divProductCode_4.Visible = true;
                divSalesmanCode_5.Visible = true;
                divOUCode_6.Visible = true;
            }
            //default
            //else if (lblNoOfDDL_Display.Text == "3")
            else
            {
                divDivision.Visible = true;
                divCompany.Visible = true;
                divRegion.Visible = true;
            }
        }
        else
        {
            string sShowing_DDL = lblShowing_DDL.Text;
            //int index = sShowing_DDL.IndexOf("1");

            if (sShowing_DDL.IndexOf("1") >= 0)
            {
                divDivision.Visible = true;
            }

            if (sShowing_DDL.IndexOf("2") >= 0)
            {
                divCompany.Visible = true;
            }

            if (sShowing_DDL.IndexOf("3") >= 0)
            {
                divRegion.Visible = true;
            }

            if (sShowing_DDL.IndexOf("4") >= 0)
            {
                divProductCode_4.Visible = true;
            }

            if (sShowing_DDL.IndexOf("5") >= 0)
            {
                divSalesmanCode_5.Visible = true;
            }

            if (sShowing_DDL.IndexOf("6") >= 0)
            {
                divOUCode_6.Visible = true;
            }
        }

        //DDLYear
        if (lblEnableDDLYear.Text == "N")
        {
            Label5.Visible = false;
            ddlYear.Visible = false;
        }
        else
        {
            Label5.Visible = true;
            ddlYear.Visible = true;
            LSLIBWebBased.nsCommon.mCommon.BindDDLYear(ddlYear, LSLIBWebBased.LIBWebBased.enDropDownListType.NoValue, false);

            //DDLWeek
            if (lblEnableDDLWeek.Text == "Y")
            {
                lblWeek.Visible = true;
                ddlWeek.Visible = true;
                LSLIBWebBased.nsCommon.mCommon.BindDDLWeek(ddlWeek, LSLIBWebBased.LIBWebBased.enDropDownListType.NoValue, Int32.Parse(ddlYear.SelectedValue.ToString()));
            }
            else
            {
                lblWeek.Visible = false;
                ddlWeek.Visible = false;
            }
        }

        //ddlMonth
        if (lblEnableDDLMonth.Text == "N")
        {
            Label7.Visible = false;
            ddlMonth.Visible = false;
        }
        else
        {
            Label7.Visible = true;
            ddlMonth.Visible = true;
            LSLIBWebBased.nsCommon.mCommon.BindDDLMonth(ddlMonth, LSLIBWebBased.LIBWebBased.enDropDownListType.NoValue, false, 0);
        }

        if (lblEnableDDLYear.Text == "N" & lblEnableDDLMonth.Text == "N")
        {
            divYearMonth.Visible = false;
        }
        else
        {
            divYearMonth.Visible = true;
        }

        //divDateRange
        if (lblEnableDateRange.Text != "Y")
        {
            divDateRange.Visible = false;
        }
        else
        {
            divDateRange.Visible = true;
        }

        //DDLContentType
        if (lblEnableDDLContentType.Text == "N")
        {
            divContentType.Visible = false;
        }
        else
        {
            divContentType.Visible = true;
            LSLIBWebBased.nsCommon.mCommon.BindDDLMaster(this.ddlReportRowOption, lblDropDown_Key.Text, LSLIBWebBased.LIBWebBased.enDropDownListType.NoValue);

            ViewExcelUploadbtn();
        }

        //SearchKey
        if (lblEnableSearchKey.Text == "N")
        {
            divSearchKey.Visible = false;
        }
        else
        {
            divSearchKey.Visible = true;
        }

        //btnExporttoExcel
        if (lblEnableButtonExportToExcel.Text == "N")
        {
            btnExporttoExcel.Visible = false;
        }
        else
        {
            btnExporttoExcel.Visible = true;
        }

        //btnUpdate
        if (lblEnableButtonUpdate.Text == "N")
        {
            btnUpdate.Visible = false;
        }
        else
        {
            btnUpdate.Visible = true;
        }

        if (lblEnableButtonExportToExcel.Text == "N" & lblEnableButtonUpdate.Text == "N")
        {
            divbtn.Visible = false;
        }
        else
        {
            divbtn.Visible = true;
        }

        //data of ddl
        if (lblDDLDivisionCode.Text == "")
        {
            //default using Division
            LSLIBWebBased.nsCommon.mCommon.BindDDL3DivisionByStaff(this.ddlDivision);
        }
        else
        {
            this.lblDivision.Text = ClsHashTableHelper.sGetHash(lblDDLDivisionCode.Text);
            LSLIBWebBased.nsDataSet.mDataSet.BindListControl("stp_wf_ebs_rss_" + lblDDLDivisionCode.Text, this.ddlDivision, LSLIBWebBased.LIBWebBased.enDropDownListType.NoValue);
        }

        if (lblDDLCompanyCode.Text == "")
        {
            //default using Company
            LSLIBWebBased.nsCommon.mCommon.BindDDLCompanyByStaff(this.ddlCompany);
        }
        else
        {
            this.lblCompany.Text = ClsHashTableHelper.sGetHash(lblDDLCompanyCode.Text);
            LSLIBWebBased.nsDataSet.mDataSet.BindListControl("stp_wf_ebs_rss_" + lblDDLCompanyCode.Text, ddlCompany, LSLIBWebBased.LIBWebBased.enDropDownListType.NoValue);
        }

        if (lblDDLRegion.Text == "")
        {
            //default using Company
            LSLIBWebBased.nsCommon.mCommon.BindDDLRegionByStaff(this.ddlRegion);
        }
        else
        {
            this.lblRegion.Text = ClsHashTableHelper.sGetHash(lblDDLRegion.Text);
            LSLIBWebBased.nsDataSet.mDataSet.BindListControl("stp_wf_ebs_rss_" + lblDDLRegion.Text, ddlRegion, LSLIBWebBased.LIBWebBased.enDropDownListType.NoValue);
        }

        if (lblDDLProductCode_4.Text == "")
        {
        }
        else
        {
            this.lblProductCode_4.Text = ClsHashTableHelper.sGetHash(lblDDLProductCode_4.Text);
            LSLIBWebBased.nsDataSet.mDataSet.BindListControl("stp_wf_ebs_rss_" + lblDDLProductCode_4.Text, DDLProductCode_4, LSLIBWebBased.LIBWebBased.enDropDownListType.NoValue);
        }

        if (lblDDLSalesmanCode_5.Text == "")
        {
        }
        else
        {
            this.lblSalesmanCode_5.Text = ClsHashTableHelper.sGetHash(lblDDLSalesmanCode_5.Text);
            LSLIBWebBased.nsDataSet.mDataSet.BindListControl("stp_wf_ebs_rss_" + lblDDLSalesmanCode_5.Text, DDLSalesmanCode_5, LSLIBWebBased.LIBWebBased.enDropDownListType.NoValue);
        }

        if (lblDDLOUCode_6.Text == "")
        {
        }
        else
        {
            this.lblOUCode_6.Text = ClsHashTableHelper.sGetHash(lblDDLOUCode_6.Text);
            LSLIBWebBased.nsDataSet.mDataSet.BindListControl("stp_wf_ebs_rss_" + lblDDLOUCode_6.Text, DDLOUCode_6, LSLIBWebBased.LIBWebBased.enDropDownListType.NoValue);
        }


        if (lblSearchKeyName.Text == "")
        {
            //default
            lblSearchKey.Text = ClsHashTableHelper.sGetHash("關鍵字");
        }
        else
        {
            lblSearchKey.Text = ClsHashTableHelper.sGetHash(lblSearchKeyName.Text);
        }

        if (lbldefaultValue_SearchKeyName.Text == "")
        {
            //default
            txtSearchKey.Text = "";
        }
        else
        {
            txtSearchKey.Text = ClsHashTableHelper.sGetHash(lbldefaultValue_SearchKeyName.Text);
        }

        //Definition
        if (lblEnableDefinition.Text == "Y")
        {
            divDefinition.Visible = true;
            lblDefinition.Text = LSLIBWebBased.nsString.mString.fStringToHTMLDisplayFormat(ClsHashTableHelper.sGetHash(msReportID + "Definition"));
        }
        else
        {
            divDefinition.Visible = false;
        }

        //EnableComment
        if (lblEnableComment.Text == "Y" && bCanViewComment() == true)
        {
            divEnableComment.Visible = true;
        }
        else
        {
            divEnableComment.Visible = false;
        }

        //get the url data
        if (msDivisionCode != null && ddlDivision.Visible == true)
        {
            this.ddlDivision.Text = msDivisionCode;
        }

        if (msYear != null && ddlYear.Visible == true)
        {
            this.ddlYear.Text = msYear;
        }

        if (msMonth != null && ddlMonth.Visible == true)
        {
            this.ddlMonth.Text = msMonth;
        }

        if (msWeek != null && ddlWeek.Visible == true)
        {
            this.ddlWeek.Text = msWeek;
        }

        return null;
    }

    private void ViewExcelUploadbtn()
    {
        string sReportName = ClsHashTableHelper.sGetHash(this.ddlReportRowOption.Text + "UploadSample");
        if (sReportName != this.ddlReportRowOption.Text + "UploadSample")
        {
            this.btnExcelUpload.Visible = true;
            LSLIBWebBased.nsCommon.mCommon.fButtonSetOpenURL(this.btnExcelUpload, "ExcelUpload.aspx?UploadType=" + this.ddlReportRowOption.Text + "&ReportID=" + msReportID);
        }
        else
        {
            this.btnExcelUpload.Visible = false;
        }
    }

    protected void ddlReportRowOption_Changed(object sender, EventArgs e)
    {
        ViewExcelUploadbtn();
    }
    #endregion

    #region "Standard Code: ReportComment"
    protected void btnAddComment_Click(object sender, EventArgs e)
    {
        if (txtComment.Text.Trim() != "")
        {
            LSLIBWebBased.ClassLoadFieldHelper ClsLoadFieldHelper = new LSLIBWebBased.ClassLoadFieldHelper();

            ClsLoadFieldHelper.fAddSqlParameter("ContentType", this.ddlReportRowOption);
            ClsLoadFieldHelper.fAddSqlParameter("DivisionCode", ddlDivision);
            ClsLoadFieldHelper.fAddSqlParameter("RegionCode", ddlRegion);
            ClsLoadFieldHelper.fAddSqlParameter("CompanyCode", ddlCompany);
            ClsLoadFieldHelper.fAddSqlParameter("OUCode", DDLOUCode_6);
            ClsLoadFieldHelper.fAddSqlParameter("SearchKey", txtSearchKey);
            ClsLoadFieldHelper.fAddSqlParameter("username", this.ClsHashTableHelper.msUserName);
            ClsLoadFieldHelper.fAddSqlParameter("Year", ddlYear);
            ClsLoadFieldHelper.fAddSqlParameter("Month", ddlMonth);
            ClsLoadFieldHelper.fAddSqlParameter("Week", ddlWeek);
            ClsLoadFieldHelper.fAddSqlParameter("ProductCode", DDLProductCode_4);
            ClsLoadFieldHelper.fAddSqlParameter("SalesmanCode", DDLSalesmanCode_5);
            ClsLoadFieldHelper.fAddSqlParameter("ReportID", msReportID);
            ClsLoadFieldHelper.fAddSqlParameter("Lang", msLang);

            ClsLoadFieldHelper.fAddSqlParameter("Comment", txtComment.Text);

            ClsLoadFieldHelper.fBuildDataSet("stp_wf_ebs_rss_Report_comment_Insert");

            txtComment.Text = "";
            FillGridViewComment();
        }
    }

    //protected void btnUpdateComment_Click(object sender, EventArgs e)
    //{
    //    FillGridViewComment();
    //}

    protected void btnShowComment_Click(object sender, EventArgs e)
    {
        if (divComment.Visible == true)
        {
            divComment.Visible = false;
            btnShowComment.Text = "Show comment";
        }
        else
        {
            divComment.Visible = true;
            btnShowComment.Text = "Hide comment";
            FillGridViewComment();
        }
    }

    public bool bCanViewComment()
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("ContentType", this.ddlReportRowOption);
        ClsLoadFieldHelper.fAddSqlParameter("DivisionCode", ddlDivision);
        ClsLoadFieldHelper.fAddSqlParameter("RegionCode", ddlRegion);
        ClsLoadFieldHelper.fAddSqlParameter("CompanyCode", ddlCompany);
        ClsLoadFieldHelper.fAddSqlParameter("OUCode", DDLOUCode_6);
        ClsLoadFieldHelper.fAddSqlParameter("SearchKey", txtSearchKey);
        ClsLoadFieldHelper.fAddSqlParameter("username", this.ClsHashTableHelper.msUserName);
        ClsLoadFieldHelper.fAddSqlParameter("Year", ddlYear);
        ClsLoadFieldHelper.fAddSqlParameter("Month", ddlMonth);
        ClsLoadFieldHelper.fAddSqlParameter("Week", ddlWeek);
        ClsLoadFieldHelper.fAddSqlParameter("ProductCode", DDLProductCode_4);
        ClsLoadFieldHelper.fAddSqlParameter("SalesmanCode", DDLSalesmanCode_5);
        ClsLoadFieldHelper.fAddSqlParameter("ReportID", msReportID);
        ClsLoadFieldHelper.fAddSqlParameter("Lang", msLang);

        ClsLoadFieldHelper.fBuildDataSet("stp_wf_ebs_rss_Report_comment_bCanViewCommentPart");
        ClsLoadFieldHelper.fBindControls(GridViewComment);

        if (ClsLoadFieldHelper.mbDataSetHasRecord)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private object FillGridViewComment()
    {

        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("ContentType", this.ddlReportRowOption);
        ClsLoadFieldHelper.fAddSqlParameter("DivisionCode", ddlDivision);
        ClsLoadFieldHelper.fAddSqlParameter("RegionCode", ddlRegion);
        ClsLoadFieldHelper.fAddSqlParameter("CompanyCode", ddlCompany);
        ClsLoadFieldHelper.fAddSqlParameter("OUCode", DDLOUCode_6);
        ClsLoadFieldHelper.fAddSqlParameter("SearchKey", txtSearchKey);
        ClsLoadFieldHelper.fAddSqlParameter("username", this.ClsHashTableHelper.msUserName);
        ClsLoadFieldHelper.fAddSqlParameter("Year", ddlYear);
        ClsLoadFieldHelper.fAddSqlParameter("Month", ddlMonth);
        ClsLoadFieldHelper.fAddSqlParameter("Week", ddlWeek);
        ClsLoadFieldHelper.fAddSqlParameter("ProductCode", DDLProductCode_4);
        ClsLoadFieldHelper.fAddSqlParameter("SalesmanCode", DDLSalesmanCode_5);
        ClsLoadFieldHelper.fAddSqlParameter("ReportID", msReportID);
        ClsLoadFieldHelper.fAddSqlParameter("Lang", msLang);

        ClsLoadFieldHelper.fBuildDataSet("stp_wf_ebs_rss_GridMaster_Report_comment");
        ClsLoadFieldHelper.fBindControls(GridViewComment);

        //this.lblNoOfRecords2.Text = (string)ClsLoadFieldHelper.iRowCountDesc();

        return null;
    }
    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {
        //檢查登入權限+取得翻譯表
        LSLIBWebBased.nsClass.mClass.cPageLoadHelper_GuocoWeb(this, ref ClsHashTableHelper, true, "", "", true);
        LoadInformationTable_Mapping(msReportID);
        this.Title = ClsHashTableHelper.sGetHash(msReportID);
        this.LSPageHeader1.msTitle = this.Title;
        //this.lblReportName.Text = this.Title;

        //LSLIBWebBased.nsClass.mClass.cGridViewAddSortMethod(this.GridView1, FillGridView1, this.lblgvSort1, null, ClassGridViewHelper.enGridViewTypeCollection.DetailReportWithAutoGeneratedColumnWithNoHeader);
        LSLIBWebBased.nsClass.mClass.cGridViewAddSortMethod(this.GridViewComment, FillGridViewComment, this.lblgvSort2, null, ClassGridViewHelper.enGridViewTypeCollection.DetailReportWithAutoGeneratedColumnWithNoHeader);

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
            EnableSetting();

            FillGridView1();
            
            lblTestingMessage.Visible = false;
            this.ddlReportRowOption.Visible = false;

        }
    }
    
    protected void btnExcelUpload_Click(object sender, EventArgs e)
    {

    }

    private object FillGridView1()
    {
        LSLIBWebBased.ClassLoadFieldHelper ClsLoadFieldHelper = new LSLIBWebBased.ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("ContentType", msContentType);
        ClsLoadFieldHelper.fAddSqlParameter("SearchKey", msSearchKey);
        ClsLoadFieldHelper.fAddSqlParameter("username", this.ClsHashTableHelper.msUserName);
        ClsLoadFieldHelper.fAddSqlParameter("DivisionCode", msDivisionCode);
        ClsLoadFieldHelper.fAddSqlParameter("CompanyCode", msCompanyCode);
        ClsLoadFieldHelper.fAddSqlParameter("RegionCode", msRegionCode);
        ClsLoadFieldHelper.fAddSqlParameter("Year", msYear);
        ClsLoadFieldHelper.fAddSqlParameter("Month", msMonth);
        ClsLoadFieldHelper.fAddSqlParameter("Week", msWeek);
        ClsLoadFieldHelper.fAddSqlParameter("ProductCode", "");
        ClsLoadFieldHelper.fAddSqlParameter("SalesmanCode", "");
        ClsLoadFieldHelper.fAddSqlParameter("OUCode", msOUCode);
        //ClsLoadFieldHelper.fAddSqlParameter("ReportID", msReportID);
        //ClsLoadFieldHelper.fAddSqlParameter("Lang", msLang);  
        
        if (lblChart_ConnectOracle.Text == "Y")
        {
            ClsLoadFieldHelper.fBuildDataSet_Oracle(lblGird_stp_Name.Text);
        }
        else
        {
            ClsLoadFieldHelper.fBuildDataSet(lblGird_stp_Name.Text);
        }
        
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView1, 0);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView2, 1);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView3, 2);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView4, 3);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView5, 4);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView6, 5);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView7, 6);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView8, 7);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView9, 8);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView10, 9);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView11, 10);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView12, 11);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView13, 12);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView14, 13);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView15, 14);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView16, 15);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView17, 16);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView18, 17);
        ClsLoadFieldHelper.fBindGridViewByDataTable(GridView19, 18);

        /* 20180119 debug use:
        DataSet lDataSet = ClsLoadFieldHelper.fGetDataSet();
        BindGridView(lDataSet.Tables[0], GridView1);
        BindGridView(lDataSet.Tables[1], GridView2);
        BindGridView(lDataSet.Tables[2], GridView3);
        BindGridView(lDataSet.Tables[3], GridView4);
        BindGridView(lDataSet.Tables[4], GridView5);
        
        */
        /*
        GridView1.Visible = true;
        GridView2.Visible = true;
        GridView3.Visible = true;
        GridView4.Visible = true;
        GridView5.Visible = true;*/
        //if (LIBWebBased.bEnableProjectFunction("RSS", "bCanViewSQLScript", this.ClsHashTableHelper.msUserName) == true)
        //{
        //    lblPrintSql.Visible = true;
        //    lblPrintSql.Text = lblGird_stp_Name.Text + " " + ClsLoadFieldHelper.fPrintSqlParameterList();
        //}
        //else
        //{
        //    lblPrintSql.Visible = false;
        //}
        LIBLocal.SetViewSQLScript( ClsLoadFieldHelper, this.ClsHashTableHelper, lblChart_ConnectOracle.Text, lblPrintSql);

        this.lblNoOfRecords.Text = (string)ClsLoadFieldHelper.iRowCountDesc();

        return null;
    }

    protected void ddlYear_Changed(object sender, EventArgs e)
    {
        LSLIBWebBased.nsCommon.mCommon.BindDDLWeek(ddlWeek, LSLIBWebBased.LIBWebBased.enDropDownListType.NoValue, Int32.Parse(ddlYear.SelectedValue.ToString()));
    }

    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        FillGridView1();
        lblTestingMessage.Visible = false;

        divComment.Visible = true;
        btnShowComment.Text = "Hide comment";
        FillGridViewComment();

    }
    protected void btnExporttoExcel_Click(object sender, EventArgs e)
    {
        LSLIBWebBased.LIBWebBased.ExportToExcelMaster(this.divData, this, FillGridView1);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}