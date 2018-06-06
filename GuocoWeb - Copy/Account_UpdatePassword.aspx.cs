using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LSLIBWebBased;
using System.Data;
using System.Web.Security;
using System.Text.RegularExpressions;

public partial class Account_UpdatePassword : System.Web.UI.Page
{

    protected string strEmailIP = System.Configuration.ConfigurationManager.AppSettings["EmailIP"];

    private string msReturnURL
    {
        get
        {
            if (LSLIBWebBased.nsSQL.mSQL.oHandleNullAndNothing(this.Request.QueryString["ReturnURL"]) == LSLIBWebBased.LIBWebBased.BLANK)
            {
                return "";
            }
            else
            {
                return this.Request.QueryString["ReturnURL"];
            }

        }
    }

    protected ClassHashTableHelper ClsHashTableHelper;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }

        //檢查登入權限+取得翻譯表
        LSLIBWebBased.nsClass.mClass.cPageLoadHelper_GuocoWeb(this, ref ClsHashTableHelper, false, "", "", true);
        this.Title = ClsHashTableHelper.sGetHash(ClsHashTableHelper.mClassMyConfiguration.msPostCode);
        this.ucPageHeader1.msTitle = this.Title;

        if (Request.QueryString["IsFristLogin"] == "Yes")
        {
            LSLIBWebBased.nsScript.mScript.Alert(this, "Frist Login,Please update password .", false);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpdatePassword_Click(object sender, EventArgs e)
    {

        if (bCanUpdatePassword(txtUsername.Text, txtPassword.Text, txtNewPassword.Text, txtNewPassword_Confirm.Text))
        {
            LIBLocal.UpdatePassword(txtUsername.Text, txtNewPassword.Text, "update");

            Response.Redirect("Account_Login.aspx");//修改密码后，登出
        }

    }

    // administrator  reset password
    protected void btnResetPassword_Click(object sender, EventArgs e)
    {

        //if is User modify VerificationCode
        if (bCanResetPassword(txtUsername_Reset.Text, txtVerificationCode.Text))
        {
            if (bIsExistsEmail(txtUsername_Reset.Text))
            {
                //todo, Reset Password
                //if is User modify Password
                string lsRandomPassword = LIBLocal.sLoadRandomPassword(8, 7);
                this.txtOrignalPassword.Text = lsRandomPassword;
                LIBLocal.UpdatePassword(txtUsername_Reset.Text, lsRandomPassword, "reset");

                LSLIBWebBased.nsScript.mScript.Alert(this, "Finished to reset password.", false);
                //todo, email password to user.
            }

        }
        else  
        {
            //if is Admin modify Password
        }
    }

    protected void btnsend_Click(object sender, EventArgs e)
    {

        string lsRandomVcode = LIBLocal.sLoadRandomPassword(4, 3);

        // insert psVerificationCode
        if (bIsExistsEmail(txtUsername_Reset.Text))
        {
            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
            ClsLoadFieldHelper.fAddSqlParameter("@username", txtUsername_Reset.Text);
            ClsLoadFieldHelper.fAddSqlParameter("@VerificationCode", lsRandomVcode);
            ClsLoadFieldHelper.fBuildDataSet("stp_wf_account_UpdateVerificationCode");

            LIBLocal.SendMailnew(txtUsername_Reset.Text, "", "", "密码重置验证码", lsRandomVcode, "", "", strEmailIP, "", "");
        }
    }

    #region"Password Rule"
    //给密码计算分数，从而判断密码的强度
    //密码手册  
    //密码长度不能小于8位
    //密码必须使用字母、数字的组合
    //定期修改密码，一般密码的使用周期是一个季度
    //新密码，不能与前9个已使用的密码相同
    private int CheckPasswordGrade(string pwd)
    {
        string[] reg = { "[0-9]", "[a-z]", "[A-Z]", "[\\\\W_]" };
        int score = 0;
        int repeatCount = 0;
        string prevChar = "";
        System.Text.RegularExpressions.Regex regex;
        int len = 0;
        len = pwd.Length;
        score += (len >= 18) ? 18 : len;
        for (int i = 0; i <= reg.Length - 1; i++)
        {
            regex = new Regex(reg[i]);
            if (regex.IsMatch(pwd))
            {
                score += 4;
            }

            if (regex.IsMatch(pwd) & regex.Matches(pwd).Count >= 2)
            {
                score += 2;
            }

            if (regex.IsMatch(pwd) & regex.Matches(pwd).Count >= 5)
            {
                score += 4;
            }
        }

        for (int i = 0; i <= pwd.Length - 1; i++)
        {
            if (pwd.Substring(i, 1) == prevChar)
            {
                repeatCount += 1;
            }
            else
            {
                prevChar = pwd.Substring(i, 1);
            }
        }

        score -= repeatCount * 1;
        return score;
    }

    //检查密码是否同时 由数字 字母组成
    private bool CheckPwdLetterAndNumber(string pwd)
    {
        System.Text.RegularExpressions.Regex regNumber = new System.Text.RegularExpressions.Regex("[0-9]");
        System.Text.RegularExpressions.Regex regLetter = new System.Text.RegularExpressions.Regex("[a-zA-Z]");
        if (regNumber.IsMatch(pwd) & regLetter.IsMatch(pwd))
        {
            return true;
        }

        return false;
    }

    #endregion

    public bool bIsExistsEmail(String psUserCode)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
        ClsLoadFieldHelper.fAddSqlParameter("@username", psUserCode);
        ClsLoadFieldHelper.fBuildDataSet("stp_wf_account_bIsExistsEmail");

        if (ClsLoadFieldHelper.mbDataSetHasRecord)
        {
            LSLIBWebBased.nsScript.mScript.Alert(this, ClsLoadFieldHelper.oLoadSqlField("Result").ToString(), false);
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool bCanResetPassword(String psUsername, String psVerificationCode)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("@username", psUsername);
        ClsLoadFieldHelper.fAddSqlParameter("@VerificationCode", psVerificationCode);

        ClsLoadFieldHelper.fBuildDataSet("stp_wf_account_bCanResetPassWord");

        if (ClsLoadFieldHelper.mbDataSetHasRecord)
        {
            LSLIBWebBased.nsScript.mScript.Alert(this, ClsLoadFieldHelper.oLoadSqlField("Result").ToString(), false);
            return false;
        }
        else
        {
            return true;
        }
    }


    public bool bCanUpdatePassword(String psUsername, String psPassword, String psNewPassword, String psNewPassword_Confirm)
    {
        ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();

        ClsLoadFieldHelper.fAddSqlParameter("@username", psUsername);
        ClsLoadFieldHelper.fAddSqlParameter("@Password", LIBLocal.sLoadPasswordHashValue(psUsername, psPassword));
        ClsLoadFieldHelper.fAddSqlParameter("@NewPassword", LIBLocal.sLoadPasswordHashValue(psUsername, psNewPassword));
        ClsLoadFieldHelper.fAddSqlParameter("@NewPassword_Confirm", LIBLocal.sLoadPasswordHashValue(psUsername, psNewPassword_Confirm));
        ClsLoadFieldHelper.fAddSqlParameter("@Password_nt", LIBLocal.sLoadPasswordHashValue(psUsername, psNewPassword));


        //if (this.txtUserCode.Enabled == true)
        //{
        //    //todo, Reset Password
        //    string lsRandomPassword = LIBLocal.sLoadRandomPassword(8, 7);
        //    LIBLocal.UpdatePassword(txtUserCode.Text, lsRandomPassword);
        //    //todo, email password to user.
        //}

        ClsLoadFieldHelper.fBuildDataSet("stp_wf_account_bCanUpdatePassword");

        if (ClsLoadFieldHelper.mbDataSetHasRecord)
        {
            LSLIBWebBased.nsScript.mScript.Alert(this, ClsLoadFieldHelper.oLoadSqlField("Result").ToString(), false);
            return false;
        }
        else
        {
            return true;
        }
    }

  
}