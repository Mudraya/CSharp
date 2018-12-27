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
    class Query
    {
        public void select(string s)
        {
            SqlConnection connection = SqlConn.Connection();
            using (connection)
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(s, connection);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);
                // Отображаем данные
                int i = 1;
                foreach (DataTable thisTable in ds.Tables)
                {
                    foreach (DataRow row in thisTable.Rows)
                    {
                        Console.WriteLine("#{0} ", i);
                        i++;
                        foreach (DataColumn column in thisTable.Columns)
                        {
                            Console.WriteLine("{0} - {1} ", column, row[column]);
                        }
                        Console.WriteLine("\n");
                        connection.Close();
                    }
                }
            }
        }


        public void query_5()
        {
            SqlConnection connection = SqlConn.Connection();
            string sql_d = "DELETE FROM STAR_MOVIE WHERE ID_MOVIE IN (SELECT ID_MOVIE FROM MOVIE WHERE MOV_YEAR < 2017)";
            string sql_dd = "DELETE FROM MOVIE WHERE MOV_YEAR < 2017";
            string sql = "SELECT * FROM MOVIE";
            SqlCommand command = new SqlCommand(sql_d, connection);
            SqlCommand command2 = new SqlCommand(sql_dd, connection);
            using (connection)
            {
                connection.Open();
                int number = command.ExecuteNonQuery();
                int number2 = command2.ExecuteNonQuery();

                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);
                // Отображаем данные
                int i = 1;
                foreach (DataTable thisTable in ds.Tables)
                {
                    foreach (DataRow row in thisTable.Rows)
                    {
                        Console.WriteLine("#{0} ", i);
                        i++;
                        foreach (DataColumn column in thisTable.Columns)
                        {
                            Console.WriteLine("{0} - {1} ", column, row[column]);
                        }
                        Console.WriteLine("\n");
                        connection.Close();
                    }
                }

            }
        }

        public void anti_query_5()
        {
            SqlConnection connection = SqlConn.Connection();
            string sql_1 = "INSERT INTO MOVIE(ID_MOVIE, MOVIE_NAME, MOV_YEAR, COUNTRY) VALUES(3, 'Django unchained', 2012, 'USA')";
            string sql_2 = "INSERT INTO STAR_MOVIE(ID_STAR, ID_MOVIE, STAR_TYPE) VALUES(3, 3, 'actor')";
            string sql_3 = "INSERT INTO STAR_MOVIE(ID_STAR, ID_MOVIE, STAR_TYPE) VALUES(3, 3, 'director')";
            SqlCommand command = new SqlCommand(sql_1, connection);
            SqlCommand command2 = new SqlCommand(sql_2, connection); 
            SqlCommand command3 = new SqlCommand(sql_3, connection);
            using (connection)
            {
                connection.Open();
                int number = command.ExecuteNonQuery();
                int number2 = command2.ExecuteNonQuery();
                int number3 = command3.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}
