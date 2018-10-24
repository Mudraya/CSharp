using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_pattern_builder
{
    class Dough
    {
        public Flour Flour { get; set; }
        public Sugar Sugar { get; set; }
        public Milk Milk { get; set; }
        public Eggs Eggs { get; set; }
        public Additives Additives { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Flour != null)
                sb.Append(Flour.Name + "\n");
            if (Sugar != null)
                sb.Append(Sugar.Name + "\n");
            if (Eggs != null)
                sb.Append(Eggs.Name + "\n");
            if (Milk != null)
                sb.Append("Молоко \n");
            if (Additives != null)
                sb.Append(Additives.Name + " \n");
            return sb.ToString();
        }

    }
}
