using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_pattern_builder
{
    abstract class DoughBuilder
    {
        public Dough Dough { get; private set; }
        public void CreateDough()
        {
            Dough = new Dough();
        }
        public abstract void SetFlour();
        public abstract void SetSugar();
        public abstract void SetAdditives();
        public abstract void SetEggs();
        public abstract void SetMilk();
    }
}
