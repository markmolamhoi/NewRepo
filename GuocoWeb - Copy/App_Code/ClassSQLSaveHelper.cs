using System;
using Microsoft.VisualBasic;
using System.Collections;

// Last tidy up: 20140731    independent
#region "ClassSQLSaveHelper"
/// <summary>
/// Build Update, Insert,Delete  Query, Old Style, Change to use Parameter(ClassLoadFieldHelper)
/// </summary>
public class ClassSQLSaveHelper
{

    private const string BLANK = "";
    public string TableName = BLANK;
    public string SQLExtraSelect = BLANK;

    public string SQLExtraCriteria = BLANK;
    private ArrayList SearchKeyNames = new ArrayList();

    private ArrayList SearchKeyValues = new ArrayList();
    private ArrayList FieldNames = new ArrayList();
    private ArrayList Fields = new ArrayList();

    private ArrayList FieldUniCodes = new ArrayList();

    private const string gsQUOTES = "'";
    public void AddSearchKey(string psSearchKeyName, string psSearchKeyValue)
    {
        // AddSearchKey -) add criteria fields (eg : where XXX = YYY)

        this.SearchKeyNames.Add(psSearchKeyName);
        this.SearchKeyValues.Add(psSearchKeyValue);

    }

    public void AddField(string psSQLFieldName, object psSaveValue, bool pbChineseField = false)
    {
        // AddField -) Field that we want to make change in Database (insert / update)

        psSaveValue = UpdateNull(psSaveValue);
        this.FieldNames.Add(psSQLFieldName);
        this.Fields.Add(psSaveValue);
        this.FieldUniCodes.Add(pbChineseField);

    }

    #region "3 SQL type"

    public string sGenerateSQLInsert()
    {
        string functionReturnValue = null;
        // will change to sAddFullRecordClass

        functionReturnValue = BLANK;

        // Initialize the return flag to false.

        string lsSQL = null;
        // Final SQL statement for record insertion
        string lsSQLselect = null;
        // SQL statement for Selection part
        string lsSQLUpdate = null;
        // Fields of table for SQL record insertion
        short liNumOfFields = 0;
        // Counter for looping the insertion field name

        // Prepare SQL statement.
        lsSQLselect = "Insert into " + this.TableName + " ";
        lsSQLUpdate = "(";

        //Construct the fields required for record insertion
        for (liNumOfFields = 0; liNumOfFields <= this.FieldNames.Count - 1; liNumOfFields++)
        {
            if (this.FieldNames[liNumOfFields] != BLANK)
            {
                if (lsSQLUpdate != "(")
                    lsSQLUpdate += ", ";
                lsSQLUpdate += this.FieldNames[liNumOfFields];
            }
        }

        lsSQLUpdate += ") ";
        lsSQLUpdate += "values (";

        //Construct the fields values for record insertion
        for (liNumOfFields = 0; liNumOfFields <= this.FieldNames.Count - 1; liNumOfFields++)
        {
            if (this.FieldNames[liNumOfFields] != BLANK)
            {
                if (liNumOfFields > 0)
                    lsSQLUpdate += ", ";

                if ((bool)this.FieldUniCodes[liNumOfFields] == true & this.bHasValue(this.Fields[liNumOfFields]))
                {
                    lsSQLUpdate += "N" + VarSQLString(this.Fields[liNumOfFields]);
                }
                else
                {
                    lsSQLUpdate += VarSQLString(this.Fields[liNumOfFields]);
                }
            }
        }

        lsSQLUpdate += ") ";

        // Display error messsage when no condition was specified.
        if (Strings.Trim(lsSQLUpdate) == "() values ()")
        {
            Interaction.MsgBox("No condition specified in SQL", MsgBoxStyle.OkOnly, "Record Creation Error");
            return functionReturnValue;
        }

        // Construct the full SQL statement.
        lsSQL = lsSQLselect + lsSQLUpdate;


        functionReturnValue = lsSQL;
        return functionReturnValue;

    }

    public string sGenerateSQLDelete()
    {
        string functionReturnValue = null;
        // will change to  sDeleteFullRecordClass

        functionReturnValue = BLANK;

        string lsSQL = null;
        // Final SQL statement for record deletion
        string lsSQLselect = null;
        // SQL statement for Selection part
        string lsSQLCriteria = null;
        // Deletion criteria

        short liNumOfKeys = 0;
        // Number of fields required for deletion

        // Constructing the SQL statement for record deletion.
        lsSQLselect = "Delete from " + this.TableName + " ";
        lsSQLCriteria = "Where ";

        for (liNumOfKeys = 0; liNumOfKeys <= this.SearchKeyNames.Count - 1; liNumOfKeys++)
        {
            if (liNumOfKeys > 0)
                lsSQLCriteria = lsSQLCriteria + "and ";
            lsSQLCriteria = lsSQLCriteria + this.SearchKeyNames[liNumOfKeys] + " = " + VarSQLString(this.SearchKeyValues[liNumOfKeys]) + " ";
        }
        //End If

        // Construct for the extra SQL statment of Where clause.
        if (this.SQLExtraCriteria != BLANK)
        {
            lsSQLCriteria = lsSQLCriteria + "and " + this.SQLExtraCriteria + " ";
        }

        // Display error message when no condition for record deletion.
        if (Strings.Trim(lsSQLCriteria) == "Where ")
        {
            Interaction.MsgBox("No condition specified in SQL", MsgBoxStyle.OkOnly, "Record Deletion Error");
            return functionReturnValue;
        }

        // Construct the completed SQL statement
        lsSQL = lsSQLselect + lsSQLCriteria;

        functionReturnValue = lsSQL;
        return functionReturnValue;

    }

    public string sGenerateSQLUpdate()
    {
        string functionReturnValue = null;
        // will change to  sUpdateFullRecordClass
        functionReturnValue = BLANK;

        string lsSQL = null;
        // Final SQL statement for update
        string lsSQLselect = BLANK;
        // SQL statement for selection part
        string lsSQLUpdate = null;
        // SQL statement for "Set" update fields.
        string lsSQLCriteria = null;
        short liNumOfFields = 0;
        short liNumOfKeys = 0;

        //Construct SQL statement for update
        lsSQLselect = lsSQLselect + "Update " + this.TableName + " ";

        lsSQLUpdate = "Set ";

        // Construct the number of fields required to update on lsSQLUpdate string

        for (liNumOfFields = 0; liNumOfFields <= this.FieldNames.Count - 1; liNumOfFields++)
        {

            if (this.FieldNames[liNumOfFields] != BLANK)
            {
                if (lsSQLUpdate != "Set ")
                    lsSQLUpdate += ", ";
                if ((bool)this.FieldUniCodes[liNumOfFields] == true & this.Fields[liNumOfFields].ToString() != BLANK)
                {
                    lsSQLUpdate += this.FieldNames[liNumOfFields] + " = N" + VarSQLString(this.Fields[liNumOfFields]) + " ";
                }
                else
                {
                    lsSQLUpdate += this.FieldNames[liNumOfFields] + " = " + VarSQLString(this.Fields[liNumOfFields]) + " ";
                }
            }
        }

        // Display the error message when no condition was selected for update
        if (Strings.Trim(lsSQLUpdate) == "Set")
        {
            Interaction.MsgBox("No criteria specified in SQL", MsgBoxStyle.OkOnly, "Update Full Record");
            return functionReturnValue;
        }

        //Construct where clause for the SQL data manipulation
        lsSQLCriteria = "Where ";

        for (liNumOfKeys = 0; liNumOfKeys <= this.SearchKeyNames.Count - 1; liNumOfKeys++)
        {
            if (liNumOfKeys > 0)
                lsSQLCriteria = lsSQLCriteria + "and ";
            lsSQLCriteria = lsSQLCriteria + this.SearchKeyNames[liNumOfKeys] + " = " + VarSQLString(this.SearchKeyValues[liNumOfKeys]) + " ";
        }
        //End If

        // Construct for the SQL extra criteria condition
        if (this.SQLExtraCriteria != BLANK)
        {
            lsSQLCriteria = lsSQLCriteria + "and " + this.SQLExtraCriteria + " ";
        }

        if (Strings.Trim(lsSQLCriteria) == "Where")
        {
            Interaction.MsgBox("No criteria specified in SQL", MsgBoxStyle.OkOnly, "Update Error");
            return functionReturnValue;
        }

        // Construct the final SQL statement.
        lsSQL = lsSQLselect + lsSQLUpdate + lsSQLCriteria;

        functionReturnValue = lsSQL;
        return functionReturnValue;

    }

    private object UpdateNull(object pObject)
    {
        // 2010-04-19 - I guess to handle insert blank to number.
        if (object.ReferenceEquals(pObject, System.DBNull.Value))
        {
            return System.DBNull.Value;
        }
        else
        {
            if (Strings.Trim((string)pObject) == BLANK)
            {
                return System.DBNull.Value;
            }
            else
            {
                return pObject;
            }
        }
    }

    public string VarSQLString(object pObject)
    {
        // Initialize the temporary string buffer
        string lsSQLString = BLANK;

        switch (Information.VarType(pObject))
        {
            case VariantType.Empty:
                lsSQLString = gsQUOTES + gsQUOTES;

                break;
            case VariantType.Null:
                lsSQLString = "NULL";

                break;
            case VariantType.Integer:
            case VariantType.Long:
            case VariantType.Double:
            case VariantType.Currency:
            case VariantType.Decimal:
                lsSQLString = Strings.Format(pObject);

                break;
            case VariantType.Date:
                lsSQLString = gsQUOTES + Convert.ToDateTime(pObject).ToString("yyyy/MM/dd HH:mm:ss") + gsQUOTES;

                break;
            case VariantType.String:
                lsSQLString = gsQUOTES + sDoubleChar((string)pObject, gsQUOTES) + gsQUOTES;

                break;
            case VariantType.Boolean:
                lsSQLString = Strings.Format(((bool)pObject ? 1 : 0));
                break;
            default:
                lsSQLString = gsQUOTES + gsQUOTES;

                break;
        }
        return lsSQLString;
    }

    private string sDoubleChar(string psTarget, string psChar)
    {
        return psTarget.Replace(psChar, psChar + psChar);
    }

    public bool bHasValue(object pObject)
    {
        if (Information.IsDBNull(pObject))
        {
            return false;
        }
        else if (pObject == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    #endregion

}
#endregion
