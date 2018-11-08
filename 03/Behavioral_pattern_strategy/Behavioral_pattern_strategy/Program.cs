using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*  13)	Реализовать задачу проката оборудования.  При этом необходимо рассчитывать стоимость обслуживания в зависимости от 
        способов и условий проката. Способы и условия могут быть стандартными, льготными и штрафными. Возможно появление новых условий. 
        Необходимо реализовать конкретные алгоритмы 
        расчета для каждого сочетания предлагаемой услуги и способа ее приобретения.*/


/* Был реализован паттерн "Стратегия" потому что 
  1) есть несколько родственных классов, которые отличаются поведением. 
     Можно задать один основной класс, а разные варианты поведения вынести в отдельные классы и при необходимости их применять
  2) необходимо обеспечить выбор из нескольких вариантов алгоритмов, которые можно легко менять в зависимости от условий
  3) необходимо менять поведение объектов на стадии выполнения программы
  4) класс, применяющий определенную функциональность, ничего не должен знать о ее реализации  */

/* классы StandartRent, ConcessionaryRent, PenaltyRent реализуют интерфейс IRent */

namespace Behavioral_pattern_strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            //человек взял оборудование по льготам
            Person person = new Person(4, "Anton", "bike", new ConcessionaryRent());
            person.Rent();
            //но просрочил возврат
            person.Rentable = new PenaltyRent();
            person.Rent();

            Console.ReadLine();
        }
    }
    // интерфейс поката
    interface IRent
    {
        void Rent();
    }

    //прокат по стандартной цене
    class StandartRent : IRent
    {
        public void Rent()
        {
            Console.WriteLine("Я взял оборудование в прокат по стандартной цене");
        }
    }

    //прокат по льготной цене
    class ConcessionaryRent : IRent
    {
        public void Rent()
        {
            Console.WriteLine("Я взял оборудование в прокат по льготной цене");
        }
    }

    //прокат по штрафной цене
    class PenaltyRent : IRent
    {
        public void Rent()
        {
            Console.WriteLine("Я взял оборудование в прокат и просрочил возврат, поэтому платить буду по штрафной цене");
        }
    }

    //класс человека, который берет в прокат оборудование
    class Person
    {
        protected int days; 
        protected string person_name; 
        protected string person_equipment; 

        public Person(int num, string str1, string str2, IRent rent)
        {
            this.days = num;
            this.person_name = str1;
            this.person_equipment = str2;
            Rentable = rent;
        }
        public IRent Rentable { private get; set; }
        public void Rent()
        {
            Rentable.Rent();
        }
    }
}
