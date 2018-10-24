using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_pattern_builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Baker baker = new Baker();

        Console.WriteLine("Что бы испечь шоколадный бисквит нужно:");
        ChocolateDoughBuilder builder = new ChocolateDoughBuilder();
        Dough ChocolateDough = baker.Bake(builder);
        Console.WriteLine(ChocolateDough.ToString());

        Console.WriteLine("Что бы испечь ванильный бисквит нужно:");
        VanillaDoughBuilder builder2 = new VanillaDoughBuilder();
        Dough VanillaDough = baker.Bake(builder2);
        Console.WriteLine(VanillaDough.ToString());
 
        Console.Read();

        }
    }
}
