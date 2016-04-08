using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gregsGrocerys
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // USED TO USER LOGIN AND VALIDATION
            gregsGrocerys.Operator user = (gregsGrocerys.Operator)Session["user"];
            if (user.Roles["Default"] == null || user.Roles["Default"] == "Deny")
            {
                Response.Redirect("~/UserLogin");

            }
            else
            {
                lblInfo.Text = user.Roles["Default"];
            }
        }
    }
}