using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gregsGrocerys
{
    
    public partial class AllProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            gregsGrocerys.Operator user = (gregsGrocerys.Operator)Session["user"];
            if (user.Roles["Default"] == null || user.Roles["Default"] == "Deny")
            {
                Response.Redirect("~/UserLogin");

            }
            else
            {
                lblInfo.Text = user.Roles["Default"];
            }


            {
                string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Grocery_Master.accdb;Persist Security Info=True";

                OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT * FROM tblProducts", conString);
                DataSet ds = new DataSet();
                dbAdapter.Fill(ds);
                GridViewAllProducts.DataSource = ds.Tables[0];
                GridViewAllProducts.DataBind();
            }
        }
        protected void GridViewAllProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["productid"] = GridViewAllProducts.SelectedRow.Cells[1].Text;
            Response.Redirect("EditProduct");
        }
    }
}
  
