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
    public partial class AllSales : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // USED TO USER LOGIN AND VALIDATION
            Operator user = (Operator)Session["user"];
            if (user.Roles["Default"] == null || user.Roles["Default"] == "Deny")
            {
                Response.Redirect("~/UserLogin");

            }
            else
            {
                lblInfo.Text = user.Roles["Default"];
            }
            
            // Loads All Sales into gridview
             
                string query = "SELECT * FROM qrySales";
                DataSet ds = new DataSet();
                Sales.createDAandDSandFill(query, ds);
                GridViewAllSales.DataSource = ds.Tables[0];
                GridViewAllSales.DataBind();
        }

        protected void GridViewAllSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SaleID"] = GridViewAllSales.SelectedRow.Cells[1].Text;
            Response.Redirect("EditSale");
        }
    }
}