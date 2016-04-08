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
    public partial class AddOperator : System.Web.UI.Page
    {

        string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Grocery_Master.accdb;Persist Security Info=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblOpID.Text = "0";

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

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string query = "";

            if (lblOpID.Text == "0")
            {
                // insert
                query = string.Format("INSERT INTO tblOperators (OperatorName, OperatorPin, OperatorSales, OperatorAdmin) VALUES (\"{0}\", {1}, {2}, {3})", txtOperatorName.Text, txtOperatorPin.Text, CheckBoxOpSales.Checked, CheckBoxOpAdmin.Checked);

                lblUserAddPrompt.Text = "User" + " " + txtOperatorName.Text + " has been added.";
            }
            else
            {
                // update
                //query = string.Format("UPDATE tblProducts SET ProductDescription=\"{0}\", ProductPrice={1} WHERE ProductID = {2}", txtDescription.Text, txtPrice.Text, lblID.Text);
            }

            OleDbConnection dbConn = new OleDbConnection(conString);
            OleDbCommand dbCmd = new OleDbCommand(query, dbConn);
            dbConn.Open();
            dbCmd.ExecuteNonQuery();
            dbConn.Close();


            // Response.Redirect("AllProducts");
        }
    }
}