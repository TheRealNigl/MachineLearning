using System;
using EncogCSharp.Models;

namespace EncogCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-----------------------" + "Encog ML Introduction " + "---------------");
            EncogMLIntroduction encog = new EncogMLIntroduction();
            encog.Run();
            Console.WriteLine("----------------------------------------------------------------------\n");
            Console.WriteLine("Testing The four other function:");
            TestEncogAnalyst test = new TestEncogAnalyst();
            test.TestIrisRegressionFF();
            Console.WriteLine("---------------------------------");
            Console.ReadLine();
        }
    }
}
