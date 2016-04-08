using Databases;
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
    public partial class EditSale : System.Web.UI.Page
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

            //try
            //{
            //    DataSet ds = new DataSet();
            //    Sales.loadDropDownList(ds, DropDownList2);
            //}
            //catch { };


            if (IsPostBack) return;
            try
            {

                string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Grocery_Master.accdb;Persist Security Info=True";

                string query = "SELECT * FROM qrySaleLines WHERE SaleID = " + Session["SaleID"];

                OleDbDataAdapter dbAdapter = new OleDbDataAdapter(query, conString);
                DataSet ds = new DataSet();
                dbAdapter.Fill(ds);
                LineItemGrid.DataSource = ds.Tables[0];
                LineItemGrid.DataBind();
            }
            catch
            {
             
            }


            if (!IsPostBack)
            {
                //OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT * FROM tblProducts", conString);
                //DataSet ds2 = new DataSet();3.
                //dbAdapter.Fill(ds2);
                //DropDownList2.DataSource = ds2.Tables[0];
                //DropDownList2.DataTextField = "ProductDescription";
                //DropDownList2.DataValueField = "ProductID";
                //DropDownList2.DataBind();

            }

        }


        //protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int id = int.Parse(DropDownList2.SelectedValue);
        //    DataRow[] found = ds2.Tables[0].Select("ProductID = " + id);
        //    txtSalePrice.Text = found[0][2].ToString();
        //}





        protected void btnAddLineItem_Click(object sender, EventArgs e)
        {

            // PART 2 - Add Sale Line Item to the given SALE ID 
            //utils.createSaleWithID(DropDownList2.SelectedValue, lblSaleID.Text, txtSalePrice.Text, txtSaleQty.Text);

            // PART 3 - Load that Sale Line Item to the Grid View on Page 
            LineItemGrid.DataSource = utils.loadToGridView(lblSaleID.Text);
            LineItemGrid.DataBind();
        }

        protected void GetSelectedRecords(object sender, EventArgs e)
        {

            foreach (GridViewRow row in LineItemGrid.Rows)
            {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);

                    if (chkRow.Checked == true)
                    {
                        Session["SaleLineID"] = row.Cells[1].Text;
                        lblRow.Text = Session["SaleLineID"].ToString();
                        string query = "";
                        query = string.Format("DELETE FROM tblSaleLines WHERE SaleLineID= " + Session["SaleLineID"]);
                        utils.openConnection(query);
                    }
            }

            Response.Redirect("EditSale");
        }

    }
}