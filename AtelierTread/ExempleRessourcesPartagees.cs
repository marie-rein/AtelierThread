using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtelierTread
{
    internal class ExempleRessourcesPartagees
    {
        private static string phrase = "";
        private static readonly Random random = new();
        public const int NB_LETTRES = 5;
        private static readonly object verrouA = new();
        private static readonly object verrouB = new();
        private static readonly object verrou = new();

        public static void RunExempleRessourcePartagee()
        {
            Stopwatch timer = Stopwatch.StartNew();
            Task a = Task.Run(MethodeA);
            Task b = Task.Run(MethodeB);
            Task c = Task.Run(MethodeC);
            Task.WaitAll(a, b,c);
            Console.WriteLine($"\nPhrase = {phrase}");
            Console.WriteLine($"{timer.ElapsedMilliseconds:#0} ms");
        }
        public static void MethodeA()
        {
            lock (verrouA)
            {
                for (int i = 0; i < NB_LETTRES; i++)
                {
                    Thread.Sleep(random.Next(500));
                    Console.Write(".");
                    phrase += "A";
                }
            }
               
        }
        public static void MethodeB()
        {
            lock (verrouB)
            {
                for (int i = 0; i < NB_LETTRES; i++)
                {
                    Thread.Sleep(random.Next(500));
                    Console.Write(".");
                    phrase += "B";
                }
            }
               
        }

        public static void MethodeC()
        {
            lock (verrou)
            {
                for (int i = 0; i <= 10; i++)
                {
                    Thread.Sleep(random.Next(700));
                    Console.Write(".");
                    phrase += "C";
                }
            }
           
        }
    }
}
