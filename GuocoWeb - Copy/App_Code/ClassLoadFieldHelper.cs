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










// Last tidy up: 20140801    Dependent >
#region "ClassLoadFieldHelper"

/// <summary>
/// To Bind dataset with Gridview/ DataGrid/ DropDownList...
/// </summary>
public class ClassLoadFieldHelper : ClassLoadFieldHelperBase
{

    public enum enDropDownListTypeCollection
    {
        NoValue = 0,
        // add nothing
        Blank = 1,
        // add "" item
        All = 2,
        // add "All" item
        DDLNoOption = 3,
        // add "No" item
        BlankAndOther = 4,
        // add "" item at first and "Other" item at the end
        Other = 5,
        // add "Other" item at the end
        NA = 6,
        // add "N/A" item
        BlankAndNA = 7
        // add "" item at first and "NA" item at the end
    }

    /// <summary>
    /// Load Sql Data to Control
    /// Can Handle DBNull error, Empty the control when no result found
    /// Can pass Control directly.
    /// </summary>
    public void LoadSqlField(string psFieldName, ref object poFieldValueControl)
    {
        try
        {
            object lsValue = null;

            try
            {
                lsValue = this.oLoadSqlField(psFieldName);
            }
            catch (Exception ex)
            {
                lsValue = this.oLoadSqlField(psFieldName);
            }
            this.SetControlValue(lsValue, ref poFieldValueControl);

        }
        catch (Exception ex)
        {
        }
    }

    public void LoadSqlField(string psFieldName, ref LSLIBWebBased.LSWebControl.LSTextBox poFieldValueControl)
    {
        object lObject = (object) poFieldValueControl;
        this.LoadSqlField(psFieldName,ref lObject);
    }
    public void LoadSqlField(string psFieldName, ref SmartTextbox poFieldValueControl)
    {
        object lObject = (object)poFieldValueControl;
        this.LoadSqlField(psFieldName, ref lObject);
    }
    public void LoadSqlField(string psFieldName, ref System.Web.UI.WebControls.TextBox poFieldValueControl)
    {
        object lObject = (object)poFieldValueControl;
        this.LoadSqlField(psFieldName, ref lObject);
    }
    public void LoadSqlField(string psFieldName, ref SmartDropDownList poFieldValueControl)
    {
        object lObject = (object)poFieldValueControl;
        this.LoadSqlField(psFieldName, ref lObject);
    }
    public void LoadSqlField(string psFieldName, ref LSDropDownList poFieldValueControl)
    {
        object lObject = (object)poFieldValueControl;
        this.LoadSqlField(psFieldName, ref lObject);
    }
    public void LoadSqlField(string psFieldName, ref DropDownList poFieldValueControl)
    {
        object lObject = (object)poFieldValueControl;
        this.LoadSqlField(psFieldName, ref lObject);
    }
    public void LoadSqlField(string psFieldName, ref ListBox poFieldValueControl)
    {
        object lObject = (object)poFieldValueControl;
        this.LoadSqlField(psFieldName, ref lObject);
    }
    public void LoadSqlField(string psFieldName, ref RadioButtonList poFieldValueControl)
    {
        object lObject = (object)poFieldValueControl;
        this.LoadSqlField(psFieldName, ref lObject);
    }
    public void LoadSqlField(string psFieldName, ref LSCheckboxList poFieldValueControl)
    {
        object lObject = (object)poFieldValueControl;
        this.LoadSqlField(psFieldName, ref lObject);
    }
    public void LoadSqlField(string psFieldName, ref LSLIBWebBased.LSWebControl.LSDatePicker poFieldValueControl)
    {
        object lObject = (object)poFieldValueControl;
        this.LoadSqlField(psFieldName, ref lObject);
    }
    public void LoadSqlField(string psFieldName, ref DatePicker poFieldValueControl)
    {
        object lObject = (object)poFieldValueControl;
        this.LoadSqlField(psFieldName, ref lObject);
    }
    public void LoadSqlField(string psFieldName, ref Label poFieldValueControl)
    {
        object lObject = (object)poFieldValueControl;
        this.LoadSqlField(psFieldName, ref lObject);
    }
    public void LoadSqlField(string psFieldName, ref Literal poFieldValueControl)
    {
        object lObject = (object)poFieldValueControl;
        this.LoadSqlField(psFieldName, ref lObject);
    }
    public void LoadSqlField(string psFieldName, ref CheckBox poFieldValueControl)
    {
        object lObject = (object)poFieldValueControl;
        this.LoadSqlField(psFieldName, ref lObject);
    }

    public object iRowCountDesc()
    {
        try
        {
            return mClsHashTableHelper.sGetHash("總數") + ":" + this.iRowCount();
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    #region "GridViewRow Related"

    protected GridViewRow mGridViewRow;
    private void SetGridViewRow(GridViewRow pGridViewRow)
    {
        this.mGridViewRow = pGridViewRow;
    }

    public void fAddSqlParameterFromGridViewRow(string psFieldName, bool pBlankThenNull = false)
    {
        try
        {
            WebControl lWebControl = (WebControl)mGridViewRow.FindControl(psFieldName);

            if (lWebControl != null)
            {
                this.fAddSqlParameter(psFieldName, lWebControl, false, pBlankThenNull);
            }
            // End If

        }
        catch (Exception ex)
        {
        }
    }

    public void LoadSqlFieldIntoGridViewRow(GridViewRow lGridViewRow, bool pbShowNumber = false)
    {
        // Aim   : Load Sql Value into control in GridViewRow in auto mode (No need to do manual mapping of fieldname/controlname)
        // Limit : ControlName in GridViewRow = ColumnName in Sql
        // Result: ControlName.text = Column.Value
        if (mbDataSetHasRecord == true)
        {
            foreach (System.Data.DataColumn lColumn in mdrRow.Table.Columns)
            {
                object lObject = lGridViewRow.FindControl(lColumn.Caption);

                if (lObject == null)
                {
                }
                else
                {
                    LoadSqlField(lColumn.Caption, ref lObject);
                }
            }
        }
    }
    #endregion

    #region "BindGridView, listControl, Control"
    /// <summary>
    /// Handle ListControl, GridView, DataGrid
    /// </summary>
    public void fBindControls(object pControl, enDropDownListTypeCollection penDropDownListType = enDropDownListTypeCollection.NoValue, bool pbDoTranslation = false)
    {
        if (pControl is ListControl)
        {
            ListControl lControl1 = (ListControl)pControl;
            this.BindListControl(base.mDataSet, lControl1, penDropDownListType, pbDoTranslation);
        }

        if (pControl is GridView)
        {
            GridView lControl2 = (GridView)pControl;
            this.BindGridView(base.mDataSet, lControl2);
        }

        if (pControl is DataGrid)
        {
            DataGrid lControl3 = (DataGrid)pControl;
            this.BindDataGrid(base.mDataSet, lControl3);
        }

    }
    /// <summary>
    /// 由 Dataset > Gridview
    /// </summary>
    public void fBindGridView(System.Web.UI.WebControls.GridView pGridView, bool pKeepLog = true)
    {
        KeepLog(pKeepLog);
        this.fBindControls(pGridView);

    }

    private void KeepLog(bool pKeepLog)
    {
        try
        {

            if (pKeepLog)
            {
                this.PageFunctionLog(this.gsUserName, gsProjectCode, HttpContext.Current.Request.RawUrl, this.fPrintSqlParameterList(), this.msStoreProcedureName, BLANK, BLANK, BLANK);
            }
        }
        catch (Exception ex)
        {
        }
    }

    #endregion

    #region "BindListControl Source"

    public void BindListControl(string psStoreProcedureName, ListControl pListControl, enDropDownListTypeCollection penDropDownListType = enDropDownListTypeCollection.NoValue, bool pbDoTranslation = false, string psFirstField = BLANK, string psFirstValue = BLANK, string psConnectionString = BLANK)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
        var _with1 = ClsLoadFieldHelper;
        // f1
        if (psFirstField != BLANK)
        {
            _with1.fAddSqlParameter(psFirstField, psFirstValue);
        }
        else
        {
            _with1.fAddSqlParameter("@lang", mClsHashTableHelper.msLang);
        }
        // f2
        _with1.fBuildDataSet(psStoreProcedureName, null, psConnectionString);
        _with1.fBindControls(pListControl, penDropDownListType, pbDoTranslation);
    }

    public void BindListControl(System.Data.DataSet pDataset, ListControl pListControl, enDropDownListTypeCollection penDropDownListType = enDropDownListTypeCollection.NoValue, bool pbDoTranslation = false)
    {
        this.BindListControlBase(pDataset, pListControl);
        this.SetDDLType(pListControl, penDropDownListType);
        if (pbDoTranslation)
        {
            // f3
            foreach (System.Web.UI.WebControls.ListItem lListItem in pListControl.Items)
            {
                lListItem.Text = mClsHashTableHelper.sGetHash((lListItem.Text));
            }
        }
    }

    /// <summary>
    ///  BindListControl using Dataset Base
    /// </summary>
    private void BindListControlBase(System.Data.DataSet pDataSet, ListControl pListControl)
    {
        // 只有第1/第2行的DATA才會成為display/value field. 
        pListControl.DataSource = pDataSet;

        if (pDataSet == null)
        {
            pListControl.Items.Clear();
        }
        else
        {
            string lsColumnName = pDataSet.Tables[0].Columns[0].Caption;
            if (this.bIsKeyField(lsColumnName))
            {
                pListControl.DataValueField = pDataSet.Tables[0].Columns[0].Caption;
                pListControl.DataTextField = pDataSet.Tables[0].Columns[1].Caption;
            }
            else
            {
                pListControl.DataValueField = pDataSet.Tables[0].Columns[1].Caption;
                pListControl.DataTextField = pDataSet.Tables[0].Columns[0].Caption;
            }
        }
        pListControl.DataBind();
    }

    public void SetDDLType(ListControl pListControl, enDropDownListTypeCollection penDropDownListType)
    {
        System.Web.UI.WebControls.ListItem lListItem = new System.Web.UI.WebControls.ListItem();

        if (pListControl.Items.Count == 0)
        {
            // Have not data
            switch (penDropDownListType)
            {
                case enDropDownListTypeCollection.All:
                    lListItem.Value = "All";
                    lListItem.Text = mClsHashTableHelper.sGetHash("All");
                    pListControl.Items.Insert(0, lListItem);

                    break;
                case enDropDownListTypeCollection.BlankAndNA:
                    pListControl.Items.Insert(0, BLANK);
                    lListItem.Value = "NA";
                    lListItem.Text = mClsHashTableHelper.sGetHash("N/A");
                    pListControl.Items.Insert(pListControl.Items.Count, lListItem);

                    break;
                case enDropDownListTypeCollection.NA:
                    lListItem.Value = "All";
                    lListItem.Text = mClsHashTableHelper.sGetHash("N/A");
                    pListControl.Items.Insert(0, lListItem);

                    break;
                default:
                    lListItem.Value = "";
                    lListItem.Text = mClsHashTableHelper.sGetHash("沒有資料");
                    pListControl.Items.Insert(0, lListItem);
                    break;
            }
        }
        else
        {
            // Have Data
            switch (penDropDownListType)
            {
                case enDropDownListTypeCollection.All:
                    lListItem.Value = "All";
                    lListItem.Text = mClsHashTableHelper.sGetHash("All");
                    pListControl.Items.Insert(0, lListItem);

                    break;
                case enDropDownListTypeCollection.NA:
                    lListItem.Value = "All";
                    lListItem.Text = mClsHashTableHelper.sGetHash("N/A");
                    pListControl.Items.Insert(0, lListItem);

                    break;
                case enDropDownListTypeCollection.Blank:
                    pListControl.Items.Insert(0, BLANK);

                    break;
                case enDropDownListTypeCollection.NoValue:

                    break;
                case enDropDownListTypeCollection.DDLNoOption:
                    lListItem.Value = "DllNo";
                    lListItem.Text = mClsHashTableHelper.sGetHash("DllNo");
                    pListControl.Items.Insert(0, lListItem);

                    break;
                case enDropDownListTypeCollection.BlankAndOther:
                    pListControl.Items.Insert(0, BLANK);
                    lListItem.Value = "Other";
                    lListItem.Text = mClsHashTableHelper.sGetHash("其他");
                    pListControl.Items.Insert(pListControl.Items.Count, lListItem);

                    break;
                case enDropDownListTypeCollection.Other:
                    lListItem.Value = "Other";
                    lListItem.Text = mClsHashTableHelper.sGetHash("其他");
                    pListControl.Items.Insert(pListControl.Items.Count, lListItem);

                    break;
                case enDropDownListTypeCollection.BlankAndNA:
                    pListControl.Items.Insert(0, BLANK);
                    lListItem.Value = "NA";
                    lListItem.Text = mClsHashTableHelper.sGetHash("N/A");
                    pListControl.Items.Insert(pListControl.Items.Count, lListItem);

                    break;
            }
        }

    }
    #endregion

    #region "Functions"
    private void BindDataGrid(System.Data.DataSet pDataSet, System.Web.UI.WebControls.BaseDataList pDataGrid)
    {
        try
        {
            if (pDataSet.Tables[0].Rows.Count > 0)
            {
                pDataGrid.DataSource = pDataSet.Tables[0].DefaultView;
                pDataGrid.DataBind();
            }
            else
            {
                pDataGrid.DataSource = null;
                pDataGrid.DataBind();
            }


        }
        catch (Exception ex)
        {
        }
    }

    public void BindGridView(System.Data.DataTable pDataTable, System.Web.UI.WebControls.GridView pGridView)
    {
        pGridView.DataSource = pDataTable.DefaultView;
        pGridView.DataBind();
    }

    public void BindGridView(System.Data.DataSet pDataSet, System.Web.UI.WebControls.GridView pGridView)
    {
        try
        {
            pGridView.EmptyDataText = this.sEmptyDataText();
            pGridView.DataSource = pDataSet;
            pGridView.DataBind();

        }
        catch (Exception ex)
        {
            this.BindNoRecord(pGridView);
        }
    }

    private void BindNoRecord(System.Web.UI.WebControls.GridView pGridView)
    {
        DataTable lDataTable = new DataTable();
        pGridView.EmptyDataText = this.sEmptyDataText();
        pGridView.DataSource = lDataTable.DefaultView;
        pGridView.DataBind();
    }

    private string sEmptyDataText()
    {
        return ("<div style=\"text-align:center ; color:Red;\">" + mClsHashTableHelper.sGetHash("沒有記錄") + "</div>");
    }
    #endregion

}

/// <summary>
/// This class aim at simplified the loading and saving steps between user interface and Database.
/// Can execute Stored procedure/SQL
/// Can use in all window/web base programming.
/// Can build dataSet
/// Can Load data from dataSet, single row / multi rows
/// Store the parameter Field and Value in hashtable for further uses (eg.Passing data). 
/// </summary>
public abstract class ClassLoadFieldHelperBase : ClassLoadFieldHelperBaseCommonFunction
{
    protected HashTableHelper mClsHashTableHelper = new HashTableHelper(true);
    private ClassSQLExecuteHelper mClsSQLExecuteHelper = new ClassSQLExecuteHelper();
    private List<string> mListParameterName = new List<string>();
    private List<object> mListParameterValue = new List<object>();
    private List<bool> mListParameterInOut = new List<bool>();

    private Hashtable mHashTable = new Hashtable();
    protected DataRow mdrRow;

    public string sLoadStoredProcedureName()
    {
        return msStoreProcedureName;
    }

    protected string msStoreProcedureName = BLANK;
    private System.Data.DataSet _mDataSet;
    protected System.Data.DataSet mDataSet
    {
        get { return _mDataSet; }
        private set
        {
            if (this.bExistDataSet(value))
            {
                _mDataSet = value;
            }
            if (this.bExistDataSet(_mDataSet))
            {
                if (iRowCount() > 0)
                {
                    mdrRow = _mDataSet.Tables[0].Rows[0];
                    mbDataSetHasRecord = true;
                }
            }
        }
    }

    private SqlParameter[] _mSqlParameter = null;
    protected SqlParameter[] mSqlParameter
    {
        get
        {
            if (_mSqlParameter == null)
            {
                if (mListParameterName.Count > 0)
                {
                    int liNoOfParameter = mListParameterName.Count - 1;
                    SqlParameter[] lSqlParameter = new SqlParameter[liNoOfParameter + 1];
                    for (int i = 0; i <= liNoOfParameter; i++)
                    {
                        lSqlParameter[i] = new SqlParameter(mListParameterName[i], mListParameterValue[i]);
                        if (mListParameterInOut[i] == true)
                        {
                            lSqlParameter[i].Direction = ParameterDirection.InputOutput;
                        }
                    }
                    _mSqlParameter = lSqlParameter;
                }
            }
            return _mSqlParameter;
        }
        private set
        {
            if (value == null)
            {
            }
            else
            {
                this._mSqlParameter = value;
            }
        }
    }

    private bool _mbDataSetHasRecord = false;
    public bool mbDataSetHasRecord
    {
        get { return _mbDataSetHasRecord; }
        private set { _mbDataSetHasRecord = value; }
    }

    #region "SQLParameter and HashTable related"
    /// <summary>
    /// Add field into SQLParameter.
    /// Can pass Control/Value directly as poFieldValueControl.
    /// Handle all kinds of controls.
    /// </summary>
    public void fAddSqlParameter(string psParameterName, object poParameterValueControl, bool pbIsInOut = false, bool pBlankThenNull = false, bool pBlankThenNotAdd = false, bool pbToNumber = false, bool pbHandleMultiOption = false)
    {
        object lsValue = this.sGetControlValue(poParameterValueControl, pBlankThenNull);

        if (pBlankThenNotAdd)
        {
            if (this.oHandleNullAndNothing(lsValue) == BLANK)
            {
                return;
            }
        }

        if (pbHandleMultiOption)
        {
            lsValue = "," + lsValue;
        }

        if (pbToNumber)
        {
            lsValue = this.sToNumber(lsValue);
        }

        this.AddSqlParameter(psParameterName, lsValue, pbIsInOut);

    }

    /// <summary>
    /// Add SQL parameter.
    /// </summary>

    private void AddSqlParameter(string psFieldName, object poFieldValue, bool pbIsInOut = false)
    {
        mHashTable.Add(sFixedFieldName(psFieldName), poFieldValue);
        mListParameterName.Add(sFixedFieldName(psFieldName));
        mListParameterValue.Add(poFieldValue);
        mListParameterInOut.Add(pbIsInOut);
    }

    /// <summary>
    /// Auto Fill @ into Filedname if @ does not exist.
    /// </summary>
    private string sFixedFieldName(string psFieldName)
    {
        if (psFieldName.IndexOf("@") >= 0)
        {
            return psFieldName;
        }
        else
        {
            return "@" + psFieldName;
        }
    }

    /// <summary>
    /// For debug use, easily copy to SQL and execute.
    /// </summary>
    public string fPrintSqlParameterList()
    {
        string lsString = BLANK;
        foreach (SqlParameter lsValue in mSqlParameter)
        {
            lsString += lsValue.ToString() + "='" + lsValue.Value + "'" + ",";
        }

        if (lsString != BLANK)
        {
            lsString = lsString.Substring(0, lsString.Length - 1);
        }
        return lsString;
    }

    public object fGetHashFieldValue(string psFieldName)
    {
        return mClsHashTableHelper.sGetHash(sFixedFieldName(psFieldName), mHashTable);

    }

    public void fSetHashFieldValue(string psFieldName, string psFieldValue)
    {
        mHashTable[sFixedFieldName(psFieldName)] = psFieldValue;
    }

    /// <summary>
    /// Get whole SQL parameter.
    /// </summary>
    public SqlParameter[] fGetSqlParameter()
    {
        return mSqlParameter;
    }
    #endregion

    #region "DataSet and DataTable related"
    /// <summary>
    /// Execute the STP and return the result as a Dataset
    /// </summary>
    public System.Data.DataSet fBuildDataSet(string psStoreProcedureName, SqlParameter[] pSqlParameter = null, string psConnectionString = BLANK, bool pbAddLog = true)
    {


        msStoreProcedureName = psStoreProcedureName;
        this.mSqlParameter = pSqlParameter;
        System.Data.DataSet lDataSet = mClsSQLExecuteHelper.BuildDataSet(psStoreProcedureName, this.fGetSqlParameter(), psConnectionString);

        mDataSet = lDataSet;
        try
        {
            if (this.gbLocalTesting)
            {
                Debug.Print("STP's Paramaterlist: " + psStoreProcedureName + " " + this.fPrintSqlParameterList());
                // NotSet3Lang
            }

        }
        catch (Exception ex)
        {
        }

        if (pbAddLog)
        {
            AddLog();
        }
        return lDataSet;

    }
    public void AddLog()
    {
        LSLIBWebBased.ClassMyConfiguration mMyConfiguration = new LSLIBWebBased.ClassMyConfiguration();

        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
        ClsLoadFieldHelper.fAddSqlParameter("@username", mMyConfiguration.gsUserName);
        ClsLoadFieldHelper.fAddSqlParameter("@URL", mMyConfiguration.sLoadURL);
        ClsLoadFieldHelper.fAddSqlParameter("@AbsolutePath", mMyConfiguration.sLoadAbsolutePath);
        ClsLoadFieldHelper.fAddSqlParameter("@UserIPAddress", mMyConfiguration.sLoadUserIPAddress.ToString());
        ClsLoadFieldHelper.fAddSqlParameter("@UserHostName", mMyConfiguration.sLoadUserHostName);
        ClsLoadFieldHelper.fAddSqlParameter("@StoredProcedureName", msStoreProcedureName);

        ClsLoadFieldHelper.fAddSqlParameter("@FolderCode", mMyConfiguration.msFolderCode);
        ClsLoadFieldHelper.fAddSqlParameter("@PostCode", mMyConfiguration.msPostCode);
        ClsLoadFieldHelper.fAddSqlParameter("@ReportType", mMyConfiguration.msReportType);
        ClsLoadFieldHelper.fAddSqlParameter("@ReportID", mMyConfiguration.msReportID);


        ClsLoadFieldHelper.fBuildDataSet("stp_wf_all_log_InsertAuditLog",null,"",false);

    }
    /// <summary>
    /// Build Table from MDX and pass into this class for further use
    /// </summary>
    public void SetDataTable(DataTable pDataTable = null)
    {
        System.Data.DataSet lDataset = new System.Data.DataSet();
        lDataset.Tables.Add(pDataTable);
        mDataSet = lDataset;
    }

    /// <summary>
    /// Pass in dataset for further use
    /// </summary>
    public void SetDataSet(System.Data.DataSet pDataset = null)
    {
        mDataSet = pDataset;
    }

    public System.Data.DataSet fGetDataSet()
    {
        return mDataSet;
    }

    public int iRowCount()
    {
        try
        {
            return mDataSet.Tables[0].Rows.Count;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    protected int miCurrentRow = 0;
    /// <summary>
    /// if has next row, keep on reading.
    /// </summary>
    public bool bHasNextRow()
    {
        if (mbDataSetHasRecord)
        {
            if (miCurrentRow <= mDataSet.Tables[0].Rows.Count - 1)
            {
                mdrRow = mDataSet.Tables[0].Rows[miCurrentRow];
                miCurrentRow = miCurrentRow + 1;
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// if has next row, keep on reading, + filtering
    /// </summary>
    public bool bHasNextRow(string psFilter)
    {
        DataRow[] lDataRow = mDataSet.Tables[0].Select(psFilter);
        if (mbDataSetHasRecord)
        {
            if (miCurrentRow <= lDataRow.Length - 1)
            {
                mdrRow = lDataRow[miCurrentRow];
                miCurrentRow = miCurrentRow + 1;
                return true;
            }
        }
        return false;
    }
    #endregion

    #region "Get/ Load data from Dataset/DataTable"
    public object oLoadSqlFieldByIndex(int psFieldIndex)
    {
        if (mbDataSetHasRecord == true)
        {
            return this.oHandleDBNull(mdrRow[psFieldIndex]);
        }
        else
        {
            return BLANK;
        }
    }

    public object oLoadSqlField(string psFieldName)
    {
        if (mbDataSetHasRecord == true)
        {
            return this.oHandleDBNull(mdrRow[psFieldName]);
        }
        else
        {
            return BLANK;
        }
    }
    #endregion

}

public class ClassLoadFieldHelperBaseCommonFunction
{
    #region "Variable"
    public const string BLANK = "";
    public string gsProjectCode
    {
        get { return ConfigurationManager.AppSettings["ProjectCode"]; }
    }
    public string gsUserName
    {
        get
        {
            if (gsUserNameCookie == null)
            {
                return BLANK;
            }
            return gsUserNameCookie.Value.ToString();
        }
    }
    public HttpCookie gsUserNameCookie
    {
        get { return HttpContext.Current.Request.Cookies["userName"]; }
    }
    public bool gbLocalTesting
    {
        get
        {
            try
            {
                return HttpContext.Current.Request.Url.ToString().Contains("localhost");
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    public bool gbTestingServer
    {
        get { return HttpContext.Current.Request.Url.ToString().Contains("hktest01"); }
    }

    #endregion

    #region "Common Function"
    /// <summary>
    /// return Nothing when DBNull.
    /// </summary>
    public object oHandleDBNull(object pObject)
    {
        if (Information.IsDBNull(pObject))
        {
            return null;
        }
        else
        {
            return pObject;
        }
    }
    public object oHandleNullAndNothing(object pObject)
    {
        if (pObject == null | Information.IsDBNull(pObject))
        {
            return "";
        }
        else
        {
            return pObject;
        }
    }
    public bool bExistDataSet(System.Data.DataSet pDataSet)
    {
        if (pDataSet == null)
        {
            return false;
        }
        else
        {
            if (pDataSet.Tables.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool bIsKeyField(string psColumnName)
    {
        if (psColumnName == "DataValueField" | psColumnName.ToLower().Contains("id") | psColumnName.ToLower().Contains("key"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void PageFunctionLog(object psUsername, object psProjectCode, object lsUrl, object psRemark, object psFunctionCode, object psRegionCode, object psCityCode, object psDivisionCode)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
        var _with2 = ClsLoadFieldHelper;
        _with2.fAddSqlParameter("@LoginBy", psUsername);
        _with2.fAddSqlParameter("@ProjectCode", psProjectCode);
        _with2.fAddSqlParameter("@Url", lsUrl);
        _with2.fAddSqlParameter("@Remark", psRemark);
        _with2.fAddSqlParameter("@FunctionCode", psFunctionCode);
        _with2.fAddSqlParameter("@RegionCode", psRegionCode);
        _with2.fAddSqlParameter("@CityCode", psCityCode);
        _with2.fAddSqlParameter("@DivisionCode", psDivisionCode);
        _with2.fBuildDataSet("stp_wf_all_log_UpdatePageFunction");
    }

    public object sToNumber(object psNumber)
    {
        try
        {
            if (psNumber.ToString() == BLANK)
            {
                return 0;
            }
            else
            {
                // return 0 when "All"
                double ldTestNumberUse = Convert.ToDouble(psNumber.ToString().Replace(",", ""));
                return ldTestNumberUse;
            }
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
    public void SetControlValue(object psValue, ref object poControl)
    {
        switch (poControl.GetType().Name)
        {
            case "LSTextbox":
                LSLIBWebBased.LSWebControl.LSTextBox lControl1 = (LSLIBWebBased.LSWebControl.LSTextBox)poControl;
                lControl1.Text = Convert.ToString(psValue);

                break;
            case "SmartTextbox":
                SmartTextbox lControl2 = (SmartTextbox)poControl;
                lControl2.Text = Convert.ToString(psValue);

                break;
            case "TextBox":
                System.Web.UI.WebControls.TextBox lControl3 = (System.Web.UI.WebControls.TextBox)poControl;
                lControl3.Text = Convert.ToString(psValue);

                break;
            case "SmartDropDownList":
            case "LSDropDownList":
            case "DropDownList":
            case "ListBox":
            case "RadioButtonList":
                ListControl lControl4 = (ListControl)poControl;
                // when old data is not exists in DDL, add it to DDL.
                if (lControl4.Items.FindByValue(Convert.ToString(psValue)) == null)
                {
                    lControl4.ClearSelection();
                    System.Web.UI.WebControls.ListItem lListItem = new System.Web.UI.WebControls.ListItem(Convert.ToString(psValue), Convert.ToString(psValue));
                    lControl4.Items.Add(lListItem);
                    lControl4.SelectedValue = Convert.ToString(psValue);
                }
                else
                {
                    lControl4.SelectedValue = Convert.ToString(psValue);
                }

                break;
            case "SmartCheckboxList":
            case "LSCheckboxList":
                ListControl lControl5 = (ListControl)poControl;
                this.fCheckBoxListSetSelectedValueList(lControl5, Convert.ToString(psValue));

                break;
            case "LSDatePicker":
                LSLIBWebBased.LSWebControl.LSDatePicker lControl6 = (LSLIBWebBased.LSWebControl.LSDatePicker)poControl;
                // when Date format is not valid, set to blank.
                try
                {
                    lControl6.Text = Convert.ToDateTime(this.oHandleNullAndNothing(psValue)).ToString();
                }
                catch (Exception ex)
                {
                    lControl6.Text = BLANK;
                }

                break;
            case "DatePicker":
                DatePicker lControl7 = (DatePicker)poControl;
                // when Date format is not valid, set to blank.
                try
                {
                    lControl7.Text = Convert.ToDateTime(this.oHandleNullAndNothing(psValue)).ToString();
                }
                catch (Exception ex)
                {
                    lControl7.Text = BLANK;
                }

                break;
            case "Label":
                Label lControl8 = (Label)poControl;
                lControl8.Text = Convert.ToString(psValue);

                break;
            case "Literal":
                Literal lControl9 = (Literal)poControl;
                lControl9.Text = Convert.ToString(psValue);

                break;
            case "CheckBox":
                CheckBox lControl10 = (CheckBox)poControl;
                lControl10.Checked = Convert.ToBoolean(psValue);

                break;
            default:
                poControl = psValue;

                break;
        }
    }
    public object sGetControlValue(object poFieldValueControl, bool pBlankThenNull = false)
    {
        object lsValue = BLANK;
        object lsObject = this.oHandleNullAndNothing(poFieldValueControl);

        switch (lsObject.GetType().Name)
        {
            case "TextBox":
                System.Web.UI.WebControls.TextBox lControl1 = (System.Web.UI.WebControls.TextBox)lsObject;
                lsValue = lControl1.Text;

                break;
            case "SmartTextbox":
                SmartTextbox lControl2 = (SmartTextbox)lsObject;
                lsValue = lControl2.Text;

                break;
            // Debug.Print("SiteMapPath")
            case "SmartDropDownList":
            case "DropDownList":
                ListControl lControl3 = (ListControl)lsObject;
                lsValue = lControl3.SelectedValue;

                break;
            case "SmartCheckboxList":
                ListControl lControl4 = (ListControl)lsObject;
                lsValue = this.fCheckBoxListGetSelectedValues(lControl4);

                break;
            case "DatePicker":
                DatePicker lControl5 = (DatePicker)lsObject;
                lsValue = lControl5.Text;
                if (lControl5.Text == BLANK)
                {
                    lsValue = DBNull.Value;
                }
                else
                {
                    lsValue = Convert.ToDateTime(lControl5.Text).ToString("yyyy/MM/dd").ToString();
                }

                break;
            case "Label":
                Label lControl6 = (Label)lsObject;
                lsValue = lControl6.Text;

                break;
            case "Literal":
                Literal lControl7 = (Literal)lsObject;
                lsValue = lControl7.Text;

                break;
            case "CheckBox":
                CheckBox lControl8 = (CheckBox)lsObject;
                lsValue = lControl8.Checked;

                break;
            case "DropDownCheckList":
                DropDownCheckList lControl9 = (DropDownCheckList)lsObject;
                lsValue = this.fCheckBoxListGetSelectedValues(lControl9);

                break;
            default:
                if (poFieldValueControl == null)
                {
                    lsValue = DBNull.Value;
                }
                else
                {
                    lsValue = poFieldValueControl;
                }

                break;
        }

        if (pBlankThenNull)
        {
            if (lsValue.ToString() == BLANK)
            {
                lsValue = DBNull.Value;
            }
        }
        return lsValue;
    }

    public string fCheckBoxListGetSelectedValues(ListControl pListControl)
    {
        string chkstring = ",";
        foreach (System.Web.UI.WebControls.ListItem item in pListControl.Items)
        {
            if (item.Selected)
            {
                chkstring += item.Value + ",";
            }
        }
        return chkstring;
    }

    public void fCheckBoxListSetSelectedValueList(ListControl pListControl, string itemlist)
    {
        int i = 0;
        int j = 0;
        string[] item = Strings.Split(itemlist, ",");
        for (j = 0; j <= pListControl.Items.Count - 1; j++)
        {
            pListControl.Items[j].Selected = false;
        }
        for (i = 0; i <= item.Length - 1; i++)
        {
            for (j = 0; j <= pListControl.Items.Count - 1; j++)
            {
                if (item[i] == pListControl.Items[j].Value)
                {
                    pListControl.Items[j].Selected = true;
                }
            }

        }
    }
    #endregion
}

#endregion

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================

