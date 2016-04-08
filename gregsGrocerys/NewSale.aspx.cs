using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Databases;


namespace gregsGrocerys
{
    public partial class NewSale : System.Web.UI.Page
    {
        public static DataSet ds;
        string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Grocery_Master.accdb;Persist Security Info=True";
        public DateTime dateTime { get; set; }

        private void Page_Load(object sender, EventArgs e)
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

            // Loads products into drop down list
            if (!IsPostBack)
            {
                OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT * FROM tblProducts", conString);
                DataSet ds = new DataSet();
                dbAdapter.Fill(ds);
                DropDownList1.DataSource = ds.Tables[0];
                DropDownList1.DataTextField = "ProductDescription";
                DropDownList1.DataValueField = "ProductID";
                DropDownList1.DataBind();

            }

            //Used to display users ID
            lblUserID.Text = user.ID.ToString();


        }

        /// <summary>
        /// Changes the product selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(DropDownList1.SelectedValue);
            DataRow[] found = ds.Tables[0].Select("ProductID = " + id);
            txtSalePrice.Text = found[0][2].ToString();
        }

        /// <summary>
        /// Adds a new Sale Line Item to the new Sale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddLineItem_Click(object sender, EventArgs e)
        {

            // PART 1 - If there is no current sale id to work from create a new sale.
            if (lblSaleID.Text == "")
            {
                try
                {
                lblSaleID.Text = utils.createNewSale(lblUserID.Text, completeBox.Checked).ToString();
                }
                catch
                { };
            }

            // PART 2 - Add Sale Line Item to the given SALE ID 
            utils.createSaleWithID(DropDownList1.SelectedValue, lblSaleID.Text, txtSalePrice.Text, txtSaleQty.Text);

            // PART 3 - Load that Sale Line Item to the Grid View on Page 
            LineItemGrid.DataSource = utils.loadToGridView(lblSaleID.Text);
            LineItemGrid.DataBind();

        }
    }
}

