using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _01_UserAuthentication_01_02_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string ps = Session["OTP"].ToString();
        if (txtOTP.Value == Session["OTP"].ToString())
        {
            MembershipUser u = Membership.GetUser(Session["EmailID"].ToString());
            u = Membership.GetUser(Session["EmailID"].ToString());
            //u.ChangePassword(u.ResetPassword(txtPassword.Value),);
            if (txtPassword.Value == txtConfirmPass.Value)
            {
                string pass = txtPassword.Value;
             string password=   u.ResetPassword();
                u.ChangePassword(password, pass);
                Membership.UpdateUser(u);
                Response.Redirect("../01_UserAuthentication/01_01_Default.aspx");
            }
            else {
                txtError.InnerText = "Invalid Password";
            }
        }
        else {
            txtError.InnerText = "Invalid OTP";
        }
    }
}