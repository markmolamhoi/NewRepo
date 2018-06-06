using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LIBLocal2
/// </summary>

public static class LIBLocal2
{
    public static void BindDDLSystemFolder_WithAllChildren(UserControlLibrary.Lamsoon.SmartDropDownList pDropDownList, string psSystemCode)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
        //ClsLoadFieldHelper.fAddSqlParameter("@UserCode", this.ClsHashTableHelper.msUserName);
        ClsLoadFieldHelper.fAddSqlParameter("@SystemCode", psSystemCode);
        ClsLoadFieldHelper.fBuildDataSet("stp_wf_dms_DDLSystemFolder_WithAllChildren");

        if (psSystemCode == "All")
        {
            ClsLoadFieldHelper.fBindControls(pDropDownList,ClassLoadFieldHelper.enDropDownListTypeCollection.All);

        }
        else
        {
            ClsLoadFieldHelper.fBindControls(pDropDownList);

        }


    }

}