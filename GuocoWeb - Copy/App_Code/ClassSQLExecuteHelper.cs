using System;
using System.Web;

using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;



// Last tidy up: 20140731    Independent
#region "ClassSQLExecuteHelper"
/// <summary>
/// used to execute the SQL query
/// </summary>
public class ClassSQLExecuteHelper
{
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


    private string gsConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
    private const string BLANK = "";
    private ArrayList msSQLArraylist = new ArrayList();

    DbConnection mDbConnection;
    /// <summary>
    /// Add SQL into this class
    /// </summary>
    public void AddSQL(string psSQLString)
    {
        if (psSQLString != BLANK)
        {
            msSQLArraylist.Add(psSQLString);
        }
        else
        {
            //  Call MsgBoxOkOnly("It is Blank SQL.")
            Debug.Print("ClassSQLExecuteHelper - AddSQL() It is Blank SQL");
        }
    }

    /// <summary>
    /// Set the connection of this class to database,if you do not set,the default is gcnOLEDBHIS
    /// </summary>
    private void SetConnection(DbConnection pConnectionObject)
    {
        mDbConnection = pConnectionObject;
    }

    /// <summary>
    /// Execute all the SQL you added into this class.(execute all or nothing)
    /// </summary>
    public bool bExecute()
    {
        bool lbExecute = false;

        if (mDbConnection == null)
        {
            mDbConnection = this.NewDBConnection();
        }

        try
        {
            this.bCheckDBConnection(mDbConnection);

            DbCommand lDBCommand = mDbConnection.CreateCommand();

            using (lDBCommand)
            {
                try
                {
                    // Begin Transaction
                    lDBCommand.Transaction = mDbConnection.BeginTransaction();

                    for (int liSQL = 0; liSQL <= msSQLArraylist.Count - 1; liSQL++)
                    {
                        lDBCommand.CommandText = (string)msSQLArraylist[liSQL];
                        lDBCommand.ExecuteNonQuery();
                        lbExecute = true;
                    }

                    lDBCommand.Transaction.Commit();

                }
                catch (Exception ex)
                {
                    lDBCommand.Transaction.Rollback();
                    lbExecute = false;
                }
            }

        }
        catch (Exception Err)
        {
            lbExecute = false;
        }
        finally
        {
            mDbConnection.Close();
        }
        return lbExecute;
    }

    /// <summary>
    /// lazy code. to Check DBConnection of all kinds of connection in VB.Net.(prepare for future web base or other use.)
    /// </summary>
    public bool bCheckDBConnection(DbConnection pDBCon)
    {
        if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
        {
            if (pDBCon.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                if (pDBCon.State != ConnectionState.Open)
                {
                    pDBCon.Open();
                }
            }
        }

        return false;
    }

    /// <summary>
    /// build a new connection, later may use factory.
    /// </summary>
    public DbConnection NewDBConnection(string psConnectionString = BLANK)
    {
        if (psConnectionString == BLANK)
        {
            return new SqlConnection(gsConnectionString);
        }
        else
        {
            return new SqlConnection(psConnectionString);
        }

        return new SqlConnection(gsConnectionString);
    }

    /// <summary>
    /// auto handle SQLQuery or StoredProcedure by detecting the pSQLParameter.
    /// if pSQLParameter = nothing, SQLQuery
    ///     else StoredProcedure
    /// </summary>
    public System.Data.DataSet BuildDataSet(string psSQLString, SqlParameter[] pSQLParameter = null, string psConnectionString = BLANK)
    {


        System.Data.DataSet lDataSet = new System.Data.DataSet();
        DbConnection lDBConnection = this.NewDBConnection(psConnectionString);
        this.bCheckDBConnection(lDBConnection);
        DbCommand lDBCommand = lDBConnection.CreateCommand();
        try
        {
            using (lDBCommand)
            {
                lDBCommand.CommandText = psSQLString;
                lDBCommand.Transaction = null;
                lDBCommand.CommandTimeout = 0;

                if (pSQLParameter == null)
                {
                    lDBCommand.CommandType = System.Data.CommandType.Text;
                }
                else
                {
                    lDBCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    fCheckAndPrintDebugMessage(psSQLString, pSQLParameter, psConnectionString);
                    foreach (SqlParameter p in pSQLParameter)
                    {
                        lDBCommand.Parameters.Add(p);
                    }

                }

                SqlDataAdapter lSqlDataAdapter = default(SqlDataAdapter);
                lSqlDataAdapter = new SqlDataAdapter((SqlCommand)lDBCommand);
                lSqlDataAdapter.Fill(lDataSet);
                lDBCommand.Parameters.Clear();

            }
        }
        catch (Exception ex)
        {
            try
            {
                lDBCommand.Transaction.Rollback();

            }
            catch (Exception ex2)
            {
            }
        }
        finally
        {
            lDBConnection.Close();
        }
        return lDataSet;
    }

    private void fCheckAndPrintDebugMessage(string psSQLString, SqlParameter[] pSQLParameter = null, string psConnectionString = BLANK)
    {
        if (this.gbLocalTesting)
        {
            ArrayList lArraylist = new ArrayList();
            try
            {
                // Checking: Get List of STP parameter
                SqlCommand lSqlCommand = new SqlCommand();
                lSqlCommand.Connection = (SqlConnection)this.NewDBConnection(psConnectionString);
                using (lSqlCommand.Connection)
                {
                    lSqlCommand.Connection.Open();

                    lSqlCommand.CommandText = psSQLString;
                    lSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlCommandBuilder.DeriveParameters(lSqlCommand);

                    foreach (SqlParameter a in lSqlCommand.Parameters)
                    {
                        lArraylist.Add(a.ParameterName);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print("Error: " + psSQLString + ": is not STP ");
            }

            // Print error parameter
            foreach (SqlParameter p in pSQLParameter)
            {
                if (!lArraylist.Contains(p.ParameterName))
                {
                    Debug.Print("Error: " + psSQLString + ": Dont Have " + p.ParameterName);
                }
            }
        }
    }
}
#endregion





