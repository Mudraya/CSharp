using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

/* 13)   Програмне забезпечення « Бібліотека» . Для кожної бібліотеки в базі даних міститься наступна інформація : номер бібліотеки ; 
адреса ; кількість зареєстрованих читачів ; загальний розмір фонду (загальна кількість всіх книг , журналів тощо ) ; 
розмір фонду загального користування; список читальних залів; кількість місць у кожному читальному залі ; розмір фонду кожного читального залу; 
кількість книг на абонементі ; перелік періодичних видань, котрі виписуються ( для кожного видання - індекс , назва та ціна ) ; 
перелік платних послуг ( назва послуги і розцінка ) . 
Розцінки за платні послуги однакові для всіх бібліотек.*/

namespace laba5
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=WIN-M5N1RD4JQMT;Initial Catalog=libraries;Integrated Security=True";
            string sql = "SELECT * FROM LIBRARIES";
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();
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
                connection.Open();

            string sqlExpression = "INSERT INTO LIBRARIES (ID_LIBRARY, LIBRARY_ADRESS, TOTAL_READERS, TOTAL_BOOKS, TOTAL_USE_BOOKS) VALUES (4, 'Kiev, Grishka ul. 22', 199, 3154, 3377)";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
            Console.WriteLine("Добавлено объектов: {0}", number);

            // Создаем объект DataAdapter
            SqlDataAdapter adapter2 = new SqlDataAdapter(sql, connection);
            // Создаем объект Dataset
            DataSet ds2 = new DataSet();
            // Заполняем Dataset
            adapter2.Fill(ds2);
            // Отображаем данные
            i = 1;
            foreach (DataTable thisTable in ds2.Tables)
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
                }
            }
            //connection.Open();
            string sqlExpression2 = "UPDATE LIBRARIES SET TOTAL_READERS=200 WHERE ID_LIBRARY=4";
            SqlCommand command2 = new SqlCommand(sqlExpression2, connection);
            int number2 = command2.ExecuteNonQuery();
            Console.WriteLine("Обновлено объектов: {0}", number2);

            SqlDataAdapter adapter3 = new SqlDataAdapter(sql, connection);
            // Создаем объект Dataset
            DataSet ds3 = new DataSet();
            // Заполняем Dataset
            adapter3.Fill(ds3);
            // Отображаем данные
            i = 1;
            foreach (DataTable thisTable in ds3.Tables)
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
                }
            }
            string sqlExpression3 = "DELETE  FROM LIBRARIES WHERE ID_LIBRARY=4";
            SqlCommand command3 = new SqlCommand(sqlExpression3, connection);
            int number3 = command3.ExecuteNonQuery();
            Console.WriteLine("Удалено объектов: {0}", number3);

            SqlDataAdapter adapter4 = new SqlDataAdapter(sql, connection);
            // Создаем объект Dataset
            DataSet ds4 = new DataSet();
            // Заполняем Dataset
            adapter4.Fill(ds4);
            // Отображаем данные
            i = 1;
            foreach (DataTable thisTable in ds4.Tables)
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
                }
            }
            }

            Console.Read();
        }

    }
}
