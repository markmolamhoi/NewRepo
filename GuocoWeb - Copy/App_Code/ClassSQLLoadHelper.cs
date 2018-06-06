using Microsoft.VisualBasic;
using System.Collections;

// Last tidy up: 20140731    Independent
#region "ClassSQLLoadHelper"
/// <summary>
/// Build Select Query, Old Style, Change to use Parameter(ClassLoadFieldHelper)
/// </summary>
public class ClassSQLLoadHelper
{
    // class record loading


    private const string BLANK = "";
    public string SQLString = BLANK;

    public string TableName = BLANK;
    public string SQLExtraSelect = BLANK;

    public string SQLExtraCriteria = BLANK;
    public string SQLOrder = BLANK;

    public string SQLGroupBy = BLANK;

    private ArrayList RequiredFields = new ArrayList();
    /// <summary>
    /// Field name that we want to select
    /// </summary>
    /// <param name="psSQLFieldName">Name of the SQLField.</param>
    public void AddRequiredField(string psSQLFieldName)
    {
        // AddRequiredField -) 
        this.RequiredFields.Add(psSQLFieldName);
    }

    /// <summary>
    /// Generate select SQL
    /// </summary>
    public string sGenerateSQLSelect()
    {
        string functionReturnValue = null;
        functionReturnValue = BLANK;
        string lsSQLSelect = null;
        // SQL statement for Selection part
        string lsSQLCriteria = null;
        // SQL criteria
        string lsSQLOrder = null;
        // SQL ordering sequence

        short liNumReqFields = 0;
        // Counter for the number of fields
        string lsFieldsRequired = BLANK;
        // Fields of table for SQL statement

        // Constructing the SQL statement for record retrieval fields.
        for (liNumReqFields = 0; liNumReqFields <= this.RequiredFields.Count - 1; liNumReqFields++)
        {
            if (liNumReqFields > 0)
            {
                lsFieldsRequired += ", ";
            }
            lsFieldsRequired += this.RequiredFields[liNumReqFields];
        }

        // Construct SQL statement with using retrieval fields variable lsFieldsRequired.
        lsSQLSelect = "Select " + lsFieldsRequired + " From " + this.TableName + " ";
        // Construct SQL statement with extra SQL select statement.
        if (this.SQLExtraSelect != BLANK)
        {
            lsSQLSelect += this.SQLExtraSelect + " ";
        }

        // Initialize the SQL Criteria to [Where].
        lsSQLCriteria = "Where ";

        //Construct SQL extra criteria statement.
        if (this.SQLExtraCriteria != BLANK)
        {
            if (Strings.Trim(lsSQLCriteria) != "Where")
            {
                lsSQLCriteria += "and ";
            }
            lsSQLCriteria += this.SQLExtraCriteria + " ";
        }

        //Remove the  [Where] in lsSQLCriteria when there is no filtering condition.
        if (Strings.Trim(lsSQLCriteria) == "Where")
        {
            lsSQLCriteria = BLANK;
        }

        lsSQLOrder = BLANK;
        // Construct Group by SQL statement. (Avoid of using this)
        if (Strings.Trim(this.SQLGroupBy) != BLANK)
        {
            lsSQLOrder = " Group by " + this.SQLGroupBy;
        }

        // Construct Order by SQL statement.
        if (Strings.Trim(this.SQLOrder) != BLANK)
        {
            lsSQLOrder += " Order by " + this.SQLOrder;
        }

        //Final SQL statement construction.
        this.SQLString = lsSQLSelect + lsSQLCriteria + lsSQLOrder;

        functionReturnValue = this.SQLString;
        return functionReturnValue;

    }

}
#endregion