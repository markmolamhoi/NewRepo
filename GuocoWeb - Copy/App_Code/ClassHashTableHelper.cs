using System;
using System.Web;

using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using UserControlLibrary.Lamsoon;
using AjaxControlToolkit;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;




// Last tidy up: 20140801    Dependent some class
#region "HashTableHelper"
/// <summary>
/// Contains Useful objects of the page.
/// f1 - sGetHash, to get the HashValue in mHashtable
/// f2 - msLang, to store the selected Language of the page(tc/sc/en).
/// f3 - fAddValidator, auto add requiredFieldValidator into parent panel of the target control.
/// f4 - msUserName, to store Login User ID.
/// </summary>
public class HashTableHelper
{
    // Private mRequest As System.Web.HttpRequest = HttpContext.Current.Request
    private string msDefaultLang = ConfigurationManager.AppSettings["DefaultLang"];
    // private ClassLoadFieldHelper mClsLoadFieldHelper;
    private const string BLANK = "";
    private const string msHashTableStpName = "stp_wf_all_GetTranslationField";
    private const bool msShowNotUsedHashKey = true;
    private int msRequiredFieldValidatorCounter = 1;
    private delegate object DFunc1(object pObject);

    private Hashtable _mHashtable;
    public Hashtable mHashtable
    {
        get { return _mHashtable; }
        private set { _mHashtable = value; }
    }

    // f2
    public string msLang
    {
        get
        {

            try
            {
                HttpContext lHttpContext = HttpContext.Current;
                if ((lHttpContext.Request.QueryString["lang"] != null))
                {
                    // f1
                    lHttpContext.Session["Lang"] = lHttpContext.Request.QueryString["lang"];
                }
                else if (lHttpContext.Session["Lang"] != BLANK)
                {
                    // f2
                }
                else
                {
                    // f3
                    lHttpContext.Session["Lang"] = msDefaultLang;
                }

                return (string)lHttpContext.Session["Lang"];

            }
            catch (Exception ex)
            {
                return msDefaultLang;
            }

        }
    }

    // f4
    public string msUserName
    {
        get
        {
            if (HttpContext.Current.Request.Cookies["userName"] == null)
            {
                return BLANK;
            }
            return HttpContext.Current.Request.Cookies["userName"].Value;
        }
    }

    // f1
    /// <summary>
    /// Get HashValue based on psHashKey
    /// </summary>
    public string sGetHash(object psHashKey)
    {
        return this.sGetHash(psHashKey, this.mHashtable);
    }


    public string sGetHash(object psHashKey, Hashtable pHashTable)
    {
        try
        {
            psHashKey = this.oHandleNullAndNothing(psHashKey);
            string lsHashKey = psHashKey.ToString().ToLower();
            if (lsHashKey == BLANK)
            {
                // Debug.Print(psHashKey)
                return BLANK;
            }
            else
            {
                if ((string)pHashTable[lsHashKey] != BLANK)
                {
                    return pHashTable[lsHashKey].ToString();
                }
                else if ((string)pHashTable[psHashKey] != BLANK)
                {
                    return pHashTable[psHashKey].ToString();
                }
                else
                {
                    if (msShowNotUsedHashKey)
                    {
                        Debug.Print("NoTranslation:" + psHashKey);
                        // NotSet3Lang
                    }
                    return psHashKey.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            return psHashKey.ToString();
        }
    }

    private object oHandleNullAndNothing(object pObject)
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
    //f7

    public object fFillHashTable(object pControl1)
    {
        Control pControl = (Control)pControl1;

        switch (pControl.GetType().Name)
        {
            case "LinkButton":
                LinkButton lControl1 = (LinkButton)pControl;
                lControl1.Text = this.sGetHash(lControl1.Text);

                break;
            case "CheckBox":
                CheckBox lControl2 = (CheckBox)pControl;
                lControl2.Text = this.sGetHash(lControl2.Text);

                break;
            case "Button":
                Button lControl3 = (Button)pControl;
                lControl3.Text = this.sGetHash(lControl3.Text);
                if (lControl3.ID == "btnDeleteRecord")
                {
                    lControl3.OnClientClick = "return confirm('" + this.sGetHash("你確定要刪除嗎?") + "');";
                }

                break;
            case "Label":
                Label lControl4 = (Label)pControl;
                lControl4.Text = this.sGetHash(lControl4.Text);

                break;
            case "Literal":
                if (pControl.Visible == true)
                {
                    Literal lControl5 = (Literal)pControl;
                    lControl5.Text = this.sGetHash(lControl5.Text);
                }

                break;
            case "RequiredFieldValidator":
                RequiredFieldValidator lControl6 = (RequiredFieldValidator)pControl;
                lControl6.ErrorMessage = this.sGetHash(lControl6.ErrorMessage);

                break;
            case "RegularExpressionValidator":
                RegularExpressionValidator lControl7 = (RegularExpressionValidator)pControl;
                lControl7.ErrorMessage = this.sGetHash(lControl7.ErrorMessage);
                lControl7.ValidationExpression = this.sGetHash(lControl7.ValidationExpression);

                break;
            case "TextBoxWatermarkExtender":
                TextBoxWatermarkExtender lControl8 = (TextBoxWatermarkExtender)pControl;
                lControl8.WatermarkText = this.sGetHash(lControl8.WatermarkText);

                break;
            case "GridView":
                GridView lControl9 = (GridView)pControl;
                this.fGridViewSetHeader(lControl9);
                lControl9.ToolTip = this.sGetHash(lControl9.ToolTip);

                break;
            case "DataGrid":
                DataGrid lControl10 = (DataGrid)pControl;
                foreach (System.Web.UI.WebControls.DataGridColumn pColumn in lControl10.Columns)
                {
                    pColumn.HeaderText = this.sGetHash(pColumn.HeaderText);
                }


                break;
            //Case "TextBoxWatermarkExtender"
            //    Dim lControl11 As TextBoxWatermarkExtender = DirectCast(pControl, TextBoxWatermarkExtender)
            //    lControl11.WatermarkText = ClsHashTableHelper.sGetHash(lControl11.WatermarkText)

            //Case "CollapsiblePanelExtender"
            //    Dim lControl12 As CollapsiblePanelExtender = DirectCast(pControl, CollapsiblePanelExtender)
            //    lControl12.CollapsedText = ClsHashTableHelper.sGetHash(lControl12.CollapsedText)
            //    lControl12.ExpandedText = ClsHashTableHelper.sGetHash(lControl12.ExpandedText)

            case "SiteMapPath":
                SiteMapPath lControl13 = (SiteMapPath)pControl;
                Debug.Print("SiteMapPath");

                break;
            case "SiteMapNodeItem":
                SiteMapNodeItem lControl14 = (SiteMapNodeItem)pControl;
                Debug.Print("SiteMapNodeItem");

                break;
            case "HyperLink":
                HyperLink lControl15 = (HyperLink)pControl;
                lControl15.Text = this.sGetHash(lControl15.Text);

                break;
            case "DatePicker":
                DatePicker lControl16 = (DatePicker)pControl;
                lControl16.Clearable = true;

                break;
        }
        return true;

    }

    private void fGridViewSetHeader(GridView pGrid)
    {
        foreach (System.Web.UI.WebControls.DataControlField pColumn in pGrid.Columns)
        {
            if (pColumn.HeaderText == "Role")
            {
                // fit UserControlLibrary2010
                return;
            }

            pColumn.HeaderText = this.sGetHash(pColumn.HeaderText);
            pColumn.FooterText = pColumn.HeaderText;

            pColumn.FooterStyle.BackColor = System.Drawing.Color.LightSkyBlue;

            // Dynamic set SortExpression.
            switch (pColumn.GetType().Name.ToString())
            {
                case "BoundField":
                    if (pColumn is BoundField)
                    {
                        BoundField lColumnField = (BoundField)pColumn;
                        if (pColumn.SortExpression == BLANK)
                        {
                            // pColumn.SortExpression = lColumnField.DataField
                        }
                        lColumnField.HtmlEncode = false;
                    }

                    break;
                case "HyperLinkField":
                    if (pColumn is HyperLinkField)
                    {
                        HyperLinkField lColumnField = (HyperLinkField)pColumn;
                        if (pColumn.SortExpression == BLANK)
                        {
                            // pColumn.SortExpression = lColumnField.DataTextField
                        }
                    }

                    break;
                case "TemplateField":
                    break;
                // Dim lColumnField As TemplateField = DirectCast(pColumn, TemplateField)

            }
        }
    }
    #region "New"
    /// <summary>
    /// And pass the built pHashtable into this class.
    /// </summary>
    public HashTableHelper(Hashtable pHashtable)
    {
        this.mHashtable = pHashtable;
    }

    public HashTableHelper()
    {
    }
    public HashTableHelper(bool bUseDefaultTranslationTable)
    {
        this.mHashtable = this.BuildHashTable(msLang, msHashTableStpName);
    }
    
    public HashTableHelper(string psString, enHashTableCollection pHashTableType)
    {
        switch (pHashTableType)
        {
            case enHashTableCollection.StoredProcedure:
                this.mHashtable = this.BuildHashTable(msLang, psString);

                break;

        }
    }

    private Hashtable BuildHashTable(string psLang, string psStoredProcedure)
    {
        return null;

        //Hashtable lHashTable = new Hashtable();
        //mClsLoadFieldHelper = new ClassLoadFieldHelper();
        //var _with1 = mClsLoadFieldHelper;
        //_with1.fAddSqlParameter("@lang", psLang);
        //System.Data.DataSet lDataSet = _with1.fBuildDataSet(psStoredProcedure);
        //int liKeyIndex = 0;
        //int liTextIndex = 1;
        //try
        //{
        //    if (this.bIsKeyField(lDataSet.Tables(0).Columns(1).Caption))
        //    {
        //        liKeyIndex = 1;
        //        liTextIndex = 0;
        //    }

        //}
        //catch (Exception ex)
        //{
        //}
        //while (_with1.bHasNextRow)
        //{
        //    lHashTable.Add(_with1.oLoadSqlFieldByIndex(liKeyIndex).ToString().ToLower, _with1.oLoadSqlFieldByIndex(liTextIndex));
        //}
        //return lHashTable;
    }
    private bool bIsKeyField(string psColumnName)
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
    public enum enHashTableCollection
    {
        StoredProcedure,
        XMLFile
    }

    #endregion

    #region "For Checking HashTable"
    public void PrintAllHashValue()
    {
        foreach (object lKey in this.mHashtable.Keys)
        {
            Debug.Print(this.mHashtable[lKey].ToString());
        }
    }

    public void PrintAllHashKey()
    {
        foreach (object lKey in mHashtable.Keys)
        {
            Debug.Print(lKey.ToString());
        }
    }
    #endregion

    #region "fAddValidator"
    /// <summary>
    /// Web base only
    /// f3 - Add validator to all SmartTextbox and SmartDropDownList in pPage, 
    /// it is based on value of their ValidationGroup.
    /// </summary>
    public void fAddValidator(System.Web.UI.TemplateControl pMe)
    {
        this.SearchWebControlGrowing(pMe.Controls, this.AddValidator);
    }
    private void SearchWebControlGrowing(System.Web.UI.ControlCollection pControls, DFunc1 pDFunc1)
    {
        for (int i = 0; i <= pControls.Count - 1; i++)
        {
            Control lcControl = pControls[i];
            if (lcControl.Controls.Count > 0)
            {
                pDFunc1(lcControl);
                this.SearchWebControlGrowing(lcControl.Controls, pDFunc1);
            }
            else
            {
                pDFunc1(lcControl);
            }
        }
    }

    private object AddValidator(object pControl1)
    {
        Control pControl = (Control)pControl1;

        string lsControlName = pControl.GetType().Name;

        switch (lsControlName)
        {

            case "SmartDropDownList":
            case "SmartTextbox":
            case "TextBox":
            case "SmartRadioButtonList":
            case "SmartCheckboxList":
            case "CheckBoxList":
            case "FileUpload":

                string lsValidationGroup = BLANK;

                switch (lsControlName)
                {
                    case "SmartDropDownList":
                        SmartDropDownList lControl1 = (SmartDropDownList)pControl1;
                        lsValidationGroup = lControl1.ValidationGroup;
                        break;
                    case "SmartTextbox":
                        SmartTextbox lControl2 = (SmartTextbox)pControl1;
                        lsValidationGroup = lControl2.ValidationGroup;
                        break;
                    case "TextBox":
                        System.Web.UI.WebControls.TextBox lControl3 = (System.Web.UI.WebControls.TextBox)pControl1;
                        lsValidationGroup = lControl3.ValidationGroup;
                        break;
                    case "SmartCheckboxList":
                        SmartCheckboxList lControl4 = (SmartCheckboxList)pControl1;
                        lsValidationGroup = lControl4.ValidationGroup;
                        break;
                    case "SmartRadioButtonList":
                        SmartRadioButtonList lControl5 = (SmartRadioButtonList)pControl1;
                        lsValidationGroup = lControl5.ValidationGroup;
                        break;
                    case "CheckBoxList":
                        break;
                    case "FileUpload":

                        break;

                }

                if (lsValidationGroup != BLANK)
                {
                    if (!lsValidationGroup.StartsWith("not"))
                    {
                        RequiredFieldValidator lRequiredFieldValidator = new RequiredFieldValidator();
                        lRequiredFieldValidator.SetFocusOnError = true;
                        lRequiredFieldValidator.ValidationGroup = lsValidationGroup;
                        lRequiredFieldValidator.ControlToValidate = pControl.ID;
                        lRequiredFieldValidator.Display = ValidatorDisplay.Dynamic;
                        lRequiredFieldValidator.ErrorMessage = this.sGetHash("不能為空");
                        lRequiredFieldValidator.ID = "rfv" + pControl.ID + msRequiredFieldValidatorCounter;
                        msRequiredFieldValidatorCounter += 1;

                        pControl.Parent.Controls.Add(lRequiredFieldValidator);
                    }
                }
                break;
        }
        return true;
    }

    #endregion

}
#endregion









