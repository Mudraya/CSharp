using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Вариант № 13 (всего было 9 => 13-9=4)
4)	Разработать структуру данных для хранения информации о проектах, выполняемых на предприятии.  
Для проекта хранится информация: шифр проекта, наименование проекта, 
стоимость работ для выполнения проекта, дата начала проекта и дата окончания проекта, 
список лиц, участвующих в проекте.   
 */

/*
 В программе реализовано 3 класса :
 * Класс проэкт
 * Класс работник
 * Класс для хранения связей между сущностями
 * 
 * С помощью библиотеки LINQ to Objects было реализовано 8 запросов :
 *  1.	Вывести перечень всех проэктов
 *  2.	Вывести перечень работников, которые работают над прэктами, у которых должность начинается с "middle"
 *  3.	Вывести перечень всех работников и проэктов, над которыми они работают
 *  4.	Вывести всех работников, сгруппировав данные по должностям
 *  5.	Выведите список проэктов, в которых хотя бы у одного работника фамилия начинается с буквы «S»
 *  6.	Вывести все проэкты в отсортированном по стоимости виде
 *  7.	Вывести все проэкты у которых цена выше 3000 у.е.
 *  8.	Вывод списка работников без третьего по списку работника 
 */

namespace linq
{
    class Program
    {
        /// <summary>         
        /// Класс данных проэктов        
        /// </summary>         

        public class ProjectData
        {
            /// <summary>             
            /// Ключ
            /// </summary> 
            public int id;

            /// <summary>             
            /// Имя
            /// </summary>             
            public string name;

            /// <summary>             
            /// Стоимость проэкта             
            /// </summary>            
            public int cost;

            /// <summary>             
            /// Дата начала работы над проэктом             
            /// </summary>            
            public string startDate;

            /// <summary>             
            /// Дата окончания работы над проэктом             
            /// </summary>            
            public string endDate;

            /// <summary>             
            /// Конструктор             
            /// </summary>             
            public ProjectData(int i, string n, int c, string sd, string ed)
            {
                this.id = i;
                this.name = n;
                this.cost = c;
                this.startDate = sd;
                this.endDate = ed;
            }

            /// <summary>            
            /// Приведение к строке       
            /// </summary>     
            public override string ToString()
            {
                return "(id=" + this.id.ToString() + "; name=" + this.name + "; cost=" + this.cost + "; start date=" + this.startDate + "; end date=" + this.endDate + ")";
            }
        }

        /// <summary>         
        /// Класс данных работников        
        /// </summary>         

        public class WorkerData
        {
            /// <summary>             
            /// Ключ
            /// </summary> 
            public int id;

            /// <summary>             
            /// Должность
            /// </summary>             
            public string position;

            /// <summary>             
            /// Имя             
            /// </summary>            
            public string name;

            /// <summary>             
            /// Конструктор             
            /// </summary>             
            public WorkerData(int i, string n, string p)
            {
                this.id = i;
                this.name = n;
                this.position = p;
            }

            /// <summary>            
            /// Приведение к строке       
            /// </summary>     
            public override string ToString()
            {
                return "(id=" + this.id.ToString() + "; name=" + this.name + "; position=" + this.position + ")";
            }
        }

        /// <summary>         
        /// Класс для сравнения данных о проэктах         
        /// </summary>     
        public class DataEqualityComparerProjects : IEqualityComparer<ProjectData>
        {
            public bool Equals(ProjectData x, ProjectData y)
            {
                bool Result = false;
                if (x.id == y.id && x.name == y.name && x.cost == y.cost && x.startDate == y.startDate && x.endDate == y.endDate)
                    Result = true;
                return Result;
            }
            public int GetHashCode(ProjectData obj)
            {
                return obj.id;
            }
        }

        /// <summary>         
        /// Связь между обьектами     
        /// </summary>       
        public class DataLink
        {
            public int d1;
            public int d2;
            public DataLink(int i1, int i2)
            {
                this.d1 = i1;
                this.d2 = i2;
            }
        }

        //Пример данных   
        static List<ProjectData> PD = new List<ProjectData>()
        {
            new ProjectData(1, "Big Project", 4000, "05.09.18", "05.12.18"),
            new ProjectData(2, "Small Project", 300, "06.09.18", "26.09.18"),
            new ProjectData(3, "Medium Project", 2400, "07.09.18", "07.10.18"),
            new ProjectData(4, "Some Project", 3200, "08.09.18", "28.10.18")
        };
        static List<WorkerData> WD = new List<WorkerData>()
        {
            new WorkerData(1, "Petrova Anna", "team lead"),
            new WorkerData(2, "Sidorov Dmitry", "junior developer"),
            new WorkerData(3, "Ivan Kotejkin", "middle developer"),
            new WorkerData(4, "Ekaterina Andreeva", "BA"),
            new WorkerData(5, "Georgij Dartan'jan", "middle developer")
        };


        static List<DataLink> lnk = new List<DataLink>()
        {
            new DataLink(1, 1),
            new DataLink(1, 2),
            new DataLink(1, 3),
            new DataLink(1, 4),
            new DataLink(1, 5),
            new DataLink(2, 1),
            new DataLink(2, 3),
            new DataLink(3, 1),
            new DataLink(3, 2),
            new DataLink(3, 3),
            new DataLink(4, 1),
            new DataLink(4, 2),
            new DataLink(4, 5)
        };

        static void Main(string[] args)
        {
            // 1.	Вывести перечень всех проэктов
            Console.WriteLine("1.	Вывести перечень всех проэктов");
            var q1 = from x in PD
                     select x;
            foreach (var x in q1)
                Console.WriteLine(x);
            Console.WriteLine("\n\n");


            // 2.	Вывести перечень работников, которые работают над прэктами, у которых должность начинается с "middle"
            Console.WriteLine("2.	Вывести перечень работников, которые работают над прэктами, у которых должность начинается с 'm'");
            var q2 = from x in WD
                     where x.position.Substring(0,1)=="m" 
                     select x;
            foreach (var x in q2)
                Console.WriteLine(x);
            Console.WriteLine("\n\n");


            // 3.	Вывести перечень всех работников и проэктов, над которыми они работают
            Console.WriteLine("3.	Вывести перечень всех работников и проэктов, над которыми они работают");
            var q3 = from p in PD
                     join l in lnk on p.id equals l.d1
                     join w in WD on l.d2 equals w.id
                     select new {WorkerName = w.name, ProjectName = p.name};
            foreach (var i in q3)
                Console.WriteLine("{0} <-> {1}", i.WorkerName, i.ProjectName);
            Console.WriteLine("\n\n");


            // 4.	Вывести всех работников, сгруппировав данные по должностям
            Console.WriteLine("4.	Вывести всех работников, сгруппировав данные по должностям");
            var q4 = from w in WD
                     group w by w.position into pos
                     select new { Key = pos.Key, Values = pos };
            foreach (var x in q4)
            {
                Console.WriteLine(x.Key);
                foreach (var y in x.Values)
                    Console.WriteLine("   " + y);
            }
            Console.WriteLine("\n\n");


            // 5.	Выведите список проэктов, в которых хотя бы у одного работника фамилия начинается с буквы «S».
            Console.WriteLine("5.	Выведите список проэктов, в которых хотя бы у одного работника фамилия начинается с буквы «S»");
            var q5 = from p in PD
                     join l in lnk on p.id equals l.d1
                     join w in WD on l.d2 equals w.id
                     where w.name.Substring(0,1)=="S"
                     select new { ProjectName = p.name };
            foreach (var i in q5)
                Console.WriteLine(i.ProjectName);
            Console.WriteLine("\n\n");
           

            // 6.	Вывести все проэкты в отсортированном по стоимости виде
            Console.WriteLine("6.	Вывести все проэкты в отсортированном по стоимости виде");
            var q6 = from p in PD
                     orderby p.cost 
                     select p;
            foreach (var x in q6)
                Console.WriteLine(x);
            Console.WriteLine("\n\n");


            // 7.	Вывести все проэкты у которых цена выше 3000 у.е.; 
            Console.WriteLine("7.	Вывести все проэкты у которых цена выше 3000 у.е.");
            var q7 = from p in PD
                      group p by p.cost into cost
                      where cost.Any(p => p.cost > 3000)
                      select new { Key = cost.Key, Values = cost };
            foreach (var x in q7)
            {
                Console.WriteLine(x.Key);
                foreach (var y in x.Values)
                    Console.WriteLine("   " + y);
            }
            Console.WriteLine("\n\n");


            // 8.	Вывод списка работников без третьего по списку работника 
            Console.WriteLine("8.	Вывод списка работников без третьего по списку работника");
            foreach (var i in WD.Take(2).Concat(WD.Skip(3)))
                Console.WriteLine(i);
            Console.WriteLine("\n\n");
            Console.ReadLine();

        }
    }
}
