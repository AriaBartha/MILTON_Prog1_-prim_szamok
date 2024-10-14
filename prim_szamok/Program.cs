using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prim_szamok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A program kiírja a prím számokat 2-től a megadott számig, majd ezt a listát elmenti a Dokumentumok mappába prim_szamok.txt néven.");
            Console.Write("Kérlek add meg a számot, ameddig szeretnéd látni a prím számokat: ");
            int maxNumber = int.Parse(Console.ReadLine());
            while (maxNumber <= 1)
            {
                Console.Write("1-et vagy annál kisebb számot nem adhatsz meg! Kérlek próbálkozz újra: ");
                maxNumber = int.Parse(Console.ReadLine());
            }

            List<int> listOfPrimes = new List<int>();
            Console.WriteLine("Prím számok {0}-ig: ", maxNumber);
            for (int i = 2; i <= maxNumber; i++)
            {
                if (isPrime(i))
                {
                    Console.WriteLine(i);
                    listOfPrimes.Add(i);
                }
            }

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "prim_szamok.txt"))) 
            {
                foreach (int i in listOfPrimes)
                {
                    outputFile.WriteLine(i);
                }
            }
            Console.ReadLine();
        }

        private static bool isPrime(int number)
        {
           
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) 
                {
                    return false;
                }
            }
            return true;
        }
    }
}
