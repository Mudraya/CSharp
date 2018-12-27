using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace exam
{
    class SqlConn
    {
        public static SqlConnection Connection()
        {
            string connectionString = "Data Source=WIN-M5N1RD4JQMT;Initial Catalog=movies;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
