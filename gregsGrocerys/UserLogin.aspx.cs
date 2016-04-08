using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gregsGrocerys
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var valid = gregsGrocerys.Operator.ValidUser(txtUserName.Text, txtPassword.Text);

            if (valid)
            {
                gregsGrocerys.Operator user = new Operator(txtUserName.Text, txtPassword.Text);
                Session["user"] = user;
                Response.Redirect("~/Default");

            }
            else
            {
                lblInfo.ForeColor = System.Drawing.Color.Red;
                lblInfo.Text = "Invalid user credentials.";
            }
        }
    }
}