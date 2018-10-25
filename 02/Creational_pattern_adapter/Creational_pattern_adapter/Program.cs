using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  13)	Реализовать задачу «Учащиеся учебного заведения». 
//  В качестве учебного заведения могут выступать как школы, так и университеты.
//  Определить способы обучения и возможности его продолжения. 

//  Автор - Мудрая Анастасия ІС-61

namespace Creational_pattern_adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // подросток
            Teenager teenager = new Teenager();
            // ходит в школу
            School school = new School();
            // и учится в школе
            Console.WriteLine("Учусь в школе:");
            teenager.Studing(school);
            // но дальше ему надо приспособиться к учебе в университете
            University university = new University();
            // используем адаптер
            IStudSch uniToSchool = new UniToSchoolAdapter(university);
            // продолжаем учиться
            Console.WriteLine("\nУчусь в университете:");
            teenager.Studing(uniToSchool);

            Console.Read();
        }
    }
    // интерфейс университета
    interface IStudUni
    {
        void learning();
        void perspective();
    }
    // класс университет
    class University : IStudUni
    {
        public void learning()
        {
            Console.WriteLine("Я хожу на лекции, выполняю лабораторные и пишу курсовые работы");
        }
        public void perspective()
        {
            Console.WriteLine("После этого я найду высокооплачиваемую работу");
        }
    }
    // класс подросток
    class Teenager
    {
        public void Studing(IStudSch school)
        {
            school.learning();
            school.perspective();
        }
    }
    // интерфейс школы
    interface IStudSch
    {
        void learning();
        void perspective();
    }
    // класс школа
    class School : IStudSch
    {
        public void learning()
        {
            Console.WriteLine("Я хожу на уроки и выполняю домашние задание");
        }
        public void perspective()
        {
            Console.WriteLine("После этого я смогу поступить в хороший ВУЗ");
        }
    }
    // Адаптер от школы к IStudUni
    class UniToSchoolAdapter : IStudSch
    {
        University university;
        public UniToSchoolAdapter(University u)
        {
            university = u;
        }

        public void learning()
        {
            university.learning();
        }
        public void perspective()
        {
            university.perspective();
        }
    }
}
