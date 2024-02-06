using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtelierTread
{
    internal class ExempleCollision
    {
        private class RessourcePartagee
        {

            //thread safe avec verrou

            //public int Compteur { get; private set; }
            //private readonly object verrou = new();

            //public void Incrementer()
            //{
            //    lock (verrou)
            //        Compteur++;
            //}

            // thread safe avec opérations atomiques.
            private int compteur;
            public int GetCompteur()
            {
                return compteur;
            }
            public void Incrementer()
            {
                Interlocked.Increment(ref compteur);
            }
        }
        private RessourcePartagee ressource = new();
        public const int NB_THREADS = 15;
        public const int NB_INCREMENTATIONS = 1_000_000;


        public void DemarrerExempleCollision()
        {
            Task[] tasks = new Task[NB_THREADS];
            for (int i = 0; i < tasks.Length; i++)
                tasks[i] = Task.Run(MethodeConcurrente);
            Task.WaitAll(tasks);
            Console.WriteLine($"\nCompteur = {ressource.GetCompteur()}");
        }

        public void MethodeConcurrente()
        {
            for (int i = 0; i < NB_INCREMENTATIONS; i++)
            {
                ressource.Incrementer();
            }
        }

    }
}
