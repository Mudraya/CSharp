using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_pattern_builder
{
    class ChocolateDoughBuilder : DoughBuilder
    {
        public override void SetFlour()
        {
            this.Dough.Flour = new Flour { Name = "Пшеничнаяя мука" };
        }

        public override void SetSugar()
        {
            this.Dough.Sugar = new Sugar { Name = "Коричневый сахар" };
        }

        public override void SetEggs()
        {
            this.Dough.Eggs = new Eggs { Name = "Куриные яйца" };
        }

        public override void SetAdditives()
        {
            this.Dough.Additives = new Additives { Name = "Какао" };
        }

        public override void SetMilk()
        {
            this.Dough.Milk = new Milk();
        }
    }

}
