using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

// Вариант № 2
// Автор : Мудрая ИС-61

namespace exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Query query = new Query();

            string query_1 = "SELECT * FROM MOVIE WHERE MOV_YEAR>=2017";
            string query_2 = "SELECT * FROM MOVIE WHERE MOVIE_NAME='A Bad Moms Christmas'";
            string query_3 = "SELECT * FROM ( SELECT STAR_NAME, COUNT(ID_MOVIE) AMOUNT_OF_MOVIES FROM( SELECT S.STAR_NAME, ID_MOVIE FROM STAR S JOIN STAR_MOVIE SM ON SM.ID_STAR = S.ID_STAR WHERE STAR_TYPE = 'actor') I GROUP BY STAR_NAME) II WHERE AMOUNT_OF_MOVIES > 1; ";
            string query_4 = "SELECT STAR_NAME FROM STAR S JOIN STAR_MOVIE SM ON SM.ID_STAR=S.ID_STAR WHERE STAR_TYPE='director' AND SM.ID_STAR IN (SELECT ID_STAR FROM STAR_MOVIE WHERE  STAR_TYPE='actor')";

            query.select(query_1);
            query.select(query_2);
            query.select(query_3);
            query.select(query_4);
            // удаление всех фильмов до 2017 года выпуска
            query.query_5();
            // восстоновление данных
            query.anti_query_5();

            Console.Read();
        }
    }
}
