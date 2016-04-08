using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace gregsGrocerys
{
    public class Operator
    {
        // Public fields
        public int ID { get; set;}
        public string OperatorName { get; set; }
        public string OperatorPin { get; set; }
        public Dictionary<string, string> Roles { get; set; }

        public static object Identity { get; set; }
        
        public const string CONNECTION_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Grocery_Master.accdb;Persist Security Info=True";

        private string id;

        public Operator()
        {
            this.Roles = new Dictionary<string, string>();     
        }

        public Operator(string OperatorName, string OperatorPin)
        {
            OleDbConnection conn = new OleDbConnection(CONNECTION_STRING);

            string query = string.Format("SELECT * FROM qryUserPermissions WHERE OperatorName = \"{0}\" AND OperatorPin =\"{1}\"" , OperatorName, OperatorPin);

            OleDbCommand cmd = new OleDbCommand(query, conn);
            conn.Open();

            OleDbDataReader reader = cmd.ExecuteReader();

            this.Roles = new Dictionary<string, string>();

            while (reader.Read())
            {
                this.ID = int.Parse(reader.GetValue(0).ToString());
                this.OperatorName = reader.GetString(1);
                this.OperatorPin = reader.GetString(2);
                this.Roles[reader.GetString(3)] = reader.GetString(4);
            }

            conn.Close();
        }

        public static bool ValidUser(string OperatorName, string OperatorPin)
        {
            OleDbConnection conn = new OleDbConnection(CONNECTION_STRING);

            string query = string.Format("SELECT TOP 1 * FROM tblOperators Where tblOperators.OperatorName = \"{0}\" AND tblOperators.OperatorPin = \"{1}\"", OperatorName, OperatorPin);
            OleDbCommand cmd = new OleDbCommand(query, conn);
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var hasRows = reader.HasRows;
            conn.Close();

            return hasRows;

        }

        public Operator(int Id)
        {
            OleDbConnection conn = new OleDbConnection(CONNECTION_STRING);

            string query = string.Format("SELECT * FROM qryUserPermissions WHERE OperatorID = \"{0}\" ", ID);
            OleDbCommand cmd = new OleDbCommand(query, conn);
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                this.ID = int.Parse(reader.GetValue(0).ToString());
            }

            conn.Close();
        }

        public Operator(string id)
        {
            this.id = id;
        }
    }
}