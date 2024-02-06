using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtelierTread
{
    internal class ExempleDeadLock
    {
        public static string phrase = "";
        public static readonly Random random = new();
        public static readonly object verrou1 = new();
        public static readonly object verrou2 = new();
        public const int NB_LETTRES = 50;


        public static void RunExempleDeadLock()
        {
            Task a = Task.Run(MethodeA);
            Task b = Task.Run(MethodeB);
            Task.WaitAll(a, b);
            Console.WriteLine($"\nPhrase {(phrase.Length)} = {phrase}");
        }

        public static void MethodeA()
        {
            lock (verrou1)
            {
                Thread.Sleep(1);
                lock (verrou2)
                {
                    for (int i = 0; i < NB_LETTRES; i++)
                    {
                        Thread.Sleep(random.Next(100));
                        Console.Write(".");
                        phrase += "A";
                    }
                }
            }
        }
        public static void MethodeB()
        {
            lock (verrou2)
            {
                Thread.Sleep(1);
                lock (verrou1)
                {
                    for (int i = 0; i < NB_LETTRES; i++)
                    {
                        Thread.Sleep(random.Next(100));
                        Console.Write(".");
                        phrase += "B";
                    }
                }
            }
        }
    }
}
