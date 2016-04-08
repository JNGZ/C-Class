using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databases;
using System.Web;

namespace Databases
{
    public static class utils 
    {   

        public static string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Grocery_Master.accdb;Persist Security Info=True";

        /// <summary>
        /// Used to open DB connection and send SQL query 
        /// Execute the Query
        /// Then close the connection
        /// </summary>
        /// <param name="query"></param>
        public static void openConnection(string query)
        {
            OleDbConnection dbConn = new OleDbConnection(conString);
            OleDbCommand dbCmd = new OleDbCommand(query, dbConn);
            dbConn.Open();
            dbCmd.ExecuteNonQuery();
            dbConn.Close();
        }

        /// <summary>
        /// Creates a new SALE ID if there isn't one to work from.
        /// There must be a SALE ID to be able to add line items in a new sale.
        /// This method is used in NewSales.aspx.cs page in the first part of an 
        /// IF statement under the btnAddLineItem_Click event
        /// </summary>
        /// <param name="lblUserID"></param>
        /// <param name="completeBox"></param>
        /// <returns></returns>
        public static int createNewSale(string lblUserID, bool completeBox)
        {
            string query = "";
            string query2 = "";

            query = string.Format("INSERT INTO tblSales (SaleTime, OperatorID, Complete) VALUES (\"{0}\", {1}, {2})", DateTime.Now, lblUserID, completeBox);

            //second query for pulling most recently created ID
            query2 = string.Format("SELECT @@Identity");
            int ID;

            OleDbConnection dbConn = new OleDbConnection(conString);
            OleDbCommand dbCmd = new OleDbCommand(query, dbConn);
            dbConn.Open();

            dbCmd.ExecuteNonQuery();
            dbCmd.CommandText = query2;
            ID = (int)dbCmd.ExecuteScalar();
            dbConn.Close();

            //Populate label text with most recent created sale id 
            return ID;
        }

        /// <summary>
        /// Adds a new Sale Line Item to an already established SALE ID
        /// This method is used in NewSale.aspx.cs page within the btnAddLineItem_Click event
        /// -- after the inital logic to see if a SALE ID exists.
        /// </summary>
        /// <param name="DropDownList1"></param>
        /// <param name="lblSaleID"></param>
        /// <param name="txtSalePrice"></param>
        /// <param name="txtSaleQty"></param>
        public static void createSaleWithID( string DropDownList1, string lblSaleID, string txtSalePrice, string txtSaleQty)
        {

            string query = "";

            int ProductID = int.Parse(DropDownList1);
            int saleID = int.Parse(lblSaleID);
            int linePrice = int.Parse(txtSalePrice);
            int qty = int.Parse(txtSaleQty);

            try
            {
                query = string.Format("INSERT INTO tblSaleLines (ProductID, SaleID, LinePrice, LineQuantity) VALUES ({0},{1},{2},{3})", ProductID, saleID, linePrice, qty);

                OleDbConnection dbConn = new OleDbConnection(conString);
                OleDbCommand dbCmd = new OleDbCommand(query, dbConn);
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                dbConn.Close();
            }
            catch { };
        }

        /// <summary>
        /// This method is used to load the Sale Line Items to the grid view on the New Sale page.
        /// </summary>
        /// <param name="lblSaleID"></param>
        /// <returns></returns>
        public static DataTable loadToGridView(string lblSaleID)
        {            
                OleDbConnection dbConn = new OleDbConnection(conString);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
                OleDbCommand command;
                
                command = new OleDbCommand("SELECT * FROM tblSaleLines" + " WHERE SaleID = ?", dbConn);
                command.Parameters.AddWithValue("SaleID", lblSaleID);
                dataAdapter.SelectCommand = command;

                DataSet ds = new DataSet();    
                dataAdapter.Fill(ds);

                return ds.Tables[0];
        }

    }
}

