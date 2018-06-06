using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LSLIBWebBased;
using System.Data;


public partial class Page_NoRight : System.Web.UI.Page
{
    protected ClassHashTableHelper ClsHashTableHelper;
    protected ClassFileUploadHelper ClsFileUploadHelper = new ClassFileUploadHelper();
    
    protected void Page_Init(object sender, EventArgs e)
    {
        //檢查登入權限+取得翻譯表
        LSLIBWebBased.nsClass.mClass.cPageLoadHelper_GuocoWeb(this, ref ClsHashTableHelper, false, "", "", true);

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        lblMessage.Text = this.ClsHashTableHelper.mClassMyConfiguration.msReportType;
    }


    protected void btnClose_Click(object sender, EventArgs e)
    {
        LSLIBWebBased.nsScript.mScript.CloseWindow(this, true);
    }
}