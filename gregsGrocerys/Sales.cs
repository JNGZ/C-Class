using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace gregsGrocerys
{
    public static class Sales
    {


        /// <summary>
        /// Method used to connect to DB 
        /// receive a string query
        /// and fill a Dataset
        /// </summary>
        /// <param name="query"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static DataSet createDAandDSandFill(string query, DataSet ds)
          {
              string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Grocery_Master.accdb;Persist Security Info=True";

              OleDbDataAdapter dbAdapter = new OleDbDataAdapter(query, conString);
              new DataSet();
              dbAdapter.Fill(ds);
              return ds;
           }

        public static void openDBConn(string conString, string query)
        {
            OleDbConnection dbConn = new OleDbConnection(conString);
            OleDbCommand dbCmd = new OleDbCommand(query, dbConn);
            dbConn.Open();
        }

        public static DataSet loadDropDownList(DataSet ds, DropDownList DropDownList)
        {
            DropDownList.DataSource = ds.Tables[0];
            DropDownList.DataTextField = "ProductDescription";
            DropDownList.DataValueField = "ProductID";
            DropDownList.DataBind();

            return ds;
        }

    }
}