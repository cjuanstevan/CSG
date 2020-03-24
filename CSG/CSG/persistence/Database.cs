using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.persistence
{
    class Database
    {
        private static OdbcConnection conn = new OdbcConnection();

        public static void Connect()
        {
            string cc = "Driver={SQL Server};Server=DESKTOP-0FO6JF8\\SQLEXPRESS;Database=CSG;";
            conn.ConnectionString = cc;
            conn.Open();
        }

        public static void Disconnect()
        {
            conn.Close();
        }

        public static OdbcConnection GetConn()
        {
            return conn;
        }
    }
}
