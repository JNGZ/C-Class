using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Databases;

namespace gregsGrocerys
{
    public partial class NewProduct : Page
    {
        string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Grocery_Master.accdb;Persist Security Info=True";

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

            // DB CONNECTION BEGINS HERE
            if (IsPostBack) return;

            OleDbConnection dbConn = new OleDbConnection(conString);

            try
            {
                OleDbCommand dbCmd = new OleDbCommand("SELECT * FROM tblProducts WHERE ProductID = " + Session["productid"], dbConn);
                dbConn.Open();
                using (OleDbDataReader dbReader = dbCmd.ExecuteReader())
                {
                    dbReader.Read();
                    lblID.Text = dbReader["ProductID"].ToString();
                    txtDescription.Text = dbReader["ProductDescription"].ToString();
                    txtPrice.Text = dbReader["ProductPrice"].ToString();
                }
            }
            catch
            {
                lblID.Text = "0";
            }

            dbConn.Close();
        }

        #region BUTTONS
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string query = "";

                    if (lblID.Text == "0")
                    {
                        // insert
                        query = string.Format("INSERT INTO tblProducts (ProductDescription, ProductPrice) VALUES (\"{0}\", {1})", txtDescription.Text, txtPrice.Text);
                    }
                    else
                    {
                        // update
                        query = string.Format("UPDATE tblProducts SET ProductDescription=\"{0}\", ProductPrice={1} WHERE ProductID = {2}", txtDescription.Text, txtPrice.Text, lblID.Text);
                    }

            utils.openConnection(query);
            Response.Redirect("AllProducts");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string query = string.Format("DELETE FROM tblProducts WHERE ProductID= " + Session["productid"]);
            utils.openConnection(query);
            Response.Redirect("AllProducts");
        }
        #endregion
    }
}