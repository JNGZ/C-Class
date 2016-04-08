using Databases;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gregsGrocerys
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Grocery_Master.accdb;Persist Security Info=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            Operator user = (Operator)Session["user"];
            if (user.Roles["Default"] == null || user.Roles["Default"] == "Deny")
            {
                Response.Redirect("~/UserLogin");
            }
            else
            {
                lblInfo.Text = user.Roles["Default"];
            }

            if (IsPostBack) return;       
                try
                {
                    string query = "SELECT * FROM tblProducts WHERE ProductID = " + Session["productid"];

                    OleDbConnection dbConn = new OleDbConnection(conString);
                    OleDbCommand dbCmd = new OleDbCommand(query, dbConn);
                    dbConn.Open();
                    using (OleDbDataReader dbReader = dbCmd.ExecuteReader())
                    {
                        dbReader.Read();
                        lblID.Text = dbReader["ProductID"].ToString();
                        txtDescription.Text = dbReader["ProductDescription"].ToString();
                        txtPrice.Text = dbReader["ProductPrice"].ToString();
                    }
                    dbConn.Close();
                }
                catch
                {
                    lblID.Text = "0";
                }

        }

#region Buttons
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string query = "";

                    if (lblID.Text == "0")
                    {
                        // INSERT
                        query = string.Format("INSERT INTO tblProducts (ProductDescription, ProductPrice) VALUES (\"{0}\", {1})", txtDescription.Text, txtPrice.Text);
                    }
                    else
                    {
                        // UPDATE
                        query = string.Format("UPDATE tblProducts SET ProductDescription=\"{0}\", ProductPrice={1} WHERE ProductID = {2}", txtDescription.Text, txtPrice.Text, lblID.Text);
                    }

            utils.openConnection(query);
            Response.Redirect("AllProducts");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "";
            query = string.Format("DELETE FROM tblProducts WHERE ProductID= " + Session["productid"]);
            utils.openConnection(query);
            Response.Redirect("AllProducts");
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            lblID.Text = "0";
            txtPrice.Text = "";
            txtDescription.Text = "";
        }
#endregion
    }
}