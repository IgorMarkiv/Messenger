using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IgorMarkiv.Messanger
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string username = inputUsername.Text;
            string password = inputPassword.Text;
            try
            {
                DBHelper.LoginManager.login(username, password);
                Response.Redirect("Default.aspx", false); HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch( Exception E)
            {
                Response.Redirect("LoginPage.aspx");
            }
            
        }
    }
}