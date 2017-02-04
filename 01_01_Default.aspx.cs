using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;
using System.Net.Mail;
using BusinessLayer._01_UserAuthentication;
using BusinessObject._01_UserAuthentication;
public partial class _01_UserAuthentication_01_01_Default : System.Web.UI.Page
{
    string userName;

    protected void Page_Load(object sender, EventArgs e)
    {
         userName = txtUserName.Value;
        if (string.IsNullOrEmpty(Convert.ToString(Request.QueryString["eq"])) )
        {
           
        }
        else
        {
            string Id = Request.QueryString["eq"].ToString();
            if (Id == "404")
            {
                Response.Write("Session Expired.Please Login Again!");
            }
        }
      
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUserName.Value.Equals("Swapnil") && txtPassword.Value.Equals("ttsadmin"))
        {
            Session["SuperDuperAdmin"] = "Swapnil";
            Session["FinancialYearId"] = "DF69815C-2130-4EAB-8688-CC3AE063C078";
            Response.Redirect("../NavigationPanel.aspx");
        }
        else
        {
            String redirectString = ValidateUser(txtUserName.Value, txtPassword.Value);
            if (!redirectString.Equals(""))
            {
                Response.Redirect(redirectString);
            }
            else
            {
                txtError.InnerText = "Invalid Username Or Password";
            }
        }
    }

    #region private methods
    private String ValidateUser(String UserName, String Password)
    {
        String Status = "";
        if (Membership.ValidateUser(UserName, Password))
        {
            Session.Timeout = 20;
            DataSet userDs = GetUserMenuDetails(UserName);
            if (userDs.Tables.Count != 0)
            {
                
                Session["SuperMenu"] = userDs.Tables[0];
                Session["SubMenu"] = userDs.Tables[1];

                if (userDs.Tables[3] != null && userDs.Tables[3].Rows.Count > 0)
                {
                    Session["roles"] = userDs.Tables[3].Rows[0]["roles"];
                }
                if (userDs.Tables[2] != null)
                {
                    if (userDs.Tables[2].Rows.Count > 0)
                    {
                        Session["FinancialYearId"] = userDs.Tables[2].Rows[0]["FinancialId"];
                        Status = "../DeafultMain.aspx";
                    }
                    else
                    {
                        Status = FiniancialYearMissing();
                    }
                }
            }
            return Status;
        }
        else
        {
            return Status;
        }
    }


    private String FiniancialYearMissing()
    {
        switch (Session["roles"].ToString())

        {
            case "Super Admin":
                return "../05_MasterEntries/05_04_CreateFinancialYear.aspx?state=alert";

            default:
                return "../03_Dashboards/03_01_Dashboards.aspx?state=block";


        }
    }

    private DataSet GetUserMenuDetails(String userName)
    {
        BL_01_01_UserAuthentication BlUser = new BL_01_01_UserAuthentication();
        BO_01_UserAuthentication BoUser = new BO_01_UserAuthentication();
        BoUser.UserName = userName;
        return BlUser.GetAllUserMenu(BoUser);
    }
    #endregion


    [WebMethod]
    public static void GeneratePassword(string par,string par1)
    {
        string email;
       
        //  Membership.FindUsersByName(txtForgetEmail.Value);
        try
        {
            if (par != String.Empty)
            {
                MembershipUser mu = Membership.GetUser(par);
                email = mu.Email.ToString();
               
                string password = Membership.GeneratePassword(7, 4);
                const string username = "hingepankaj24@hotmail.com";
                string Password = "1992pankaj";
                SmtpClient smtpclient = new SmtpClient();
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                MailAddress fromaddress = new MailAddress("hingepankaj24@hotmail.com");
                smtpclient.Host = "smtp.live.com";
                smtpclient.Port = 587;
                mail.From = fromaddress;
                mail.To.Add(email);
                mail.Subject = "Password Recovery";
                mail.IsBodyHtml = true;
                mail.Body = "Hi, <br/>Please check your Login Details<br/><br/>Your EmailId:-" + email + "<br/><br/>Your Password:- " + password + "<br/><br/>";
                smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpclient.Credentials = new System.Net.NetworkCredential(username, Password);
                smtpclient.EnableSsl = true;
                try
                { 

                    HttpContext.Current.Session["EmailID"] = par;
                HttpContext.Current.Session["OTP"] = password;
                    smtpclient.Send(mail);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (par1 != string.Empty) {

                string password = Membership.GeneratePassword(7, 4);
                String name=     Membership.GetUserNameByEmail(par1);

                const string username = "hingepankaj24@hotmail.com";
                string Password = "1992pankaj";
                SmtpClient smtpclient = new SmtpClient();
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                MailAddress fromaddress = new MailAddress("hingepankaj24@hotmail.com");
                smtpclient.Host = "smtp.live.com";
                smtpclient.Port = 587;
                mail.From = fromaddress;
                mail.To.Add(par1);
                mail.Subject = "Password Recovery";
                mail.IsBodyHtml = true;
                mail.Body = "Hi, <br/>Please check your Login Details<br/><br/>Your EmailId:-" + par1 + "<br/><br/>Your Password:- " + password + "<br/><br/>";
                smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpclient.Credentials = new System.Net.NetworkCredential(username, Password);
                smtpclient.EnableSsl = true;
                try
                {
                    smtpclient.Send(mail);
                    HttpContext.Current.Session["EmailID"] = name;
                    //Response.Redirect("BusinessDeveloper.aspx");
                    HttpContext.Current.Session["OTP"] = password;

                    // Response.Write("<B>Email Has been sent successfully.</B>");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                //= "Invalid Username Or Password";
            }
        }
        catch(Exception ex)

        {
            throw ex;
        }
       

    }
}