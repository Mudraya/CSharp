using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_pattern_builder
{
    class Baker
    {
        public Dough Bake(DoughBuilder doughBuilder)
        {
            doughBuilder.CreateDough();
            doughBuilder.SetFlour();
            doughBuilder.SetSugar();
            doughBuilder.SetAdditives();
            doughBuilder.SetEggs();
            doughBuilder.SetMilk();
            return doughBuilder.Dough;
        }
    }
}
