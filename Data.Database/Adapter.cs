using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        const string consKeyDefaultCnnString = "ConnStringExpress";
        public SqlConnection sqlConn { get; set; }
        protected void OpenConnection()
        {
          
          string var = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            sqlConn = new SqlConnection(var);
            sqlConn.Open();
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
