using System.Diagnostics;

namespace AtelierTread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImprimerInfoThread();
            Stopwatch timer = Stopwatch.StartNew();

            // les methodes synchrones

            //Console.WriteLine("Début des méthodes une après l'autre");
            //CuireDuPain();
            //EcouterLaRadio();
            //FaireUnCasseTete();
            //Console.WriteLine("Fin des méthodes une après l’autre");
            //Console.WriteLine($"Il s'est écoulé {timer.ElapsedMilliseconds:#0} ms");

            // les methodes asynchrones avec thread

            Console.WriteLine("Debut des methodes en parallele");
            Task pain = Task.Run(PreparerPate);
            Task reposer = pain.ContinueWith(antecedent => ReposerPate());
            Task radio = Task.Run(EcouterLaRadio);
            //Task casseTete = Task.Run(FaireUnCasseTete);
            Task cuirePain = reposer.ContinueWith(antecedent => CuireDuPain());
            Task casseTete = pain.ContinueWith(antecedent => FaireUnCasseTete());

            Task.WaitAll(pain, radio, casseTete);
            Console.WriteLine("Fin des methodes en parallèle");
            Console.WriteLine($"Il s'est écoulé {timer.ElapsedMilliseconds:#0} ms");

            //partages des ressources
            // ExempleRessourcesPartagees.RunExempleRessourcePartagee();

            //collision           
            //new ExempleCollision().DemarrerExempleCollision();
            //Console.WriteLine($"Il s'est écoulé {timer.ElapsedMilliseconds:#0} ms");

            //DeadLocks

            //ExempleDeadLock.RunExempleDeadLock();
            //Console.WriteLine($"Il s'est écoulé {timer.ElapsedMilliseconds:#0} ms");

        }


        public static void ReposerPate()
        {
            Console.WriteLine("La pate se repose...");
            ImprimerInfoThread();
            Thread.Sleep(3000); // On simule 3 secondes de temps de calcul
            Console.WriteLine("La pate est bien reposer et prete");
        }
        public static void PreparerPate()
        {
            Console.WriteLine("La pate se prépare...");
            ImprimerInfoThread();
            Thread.Sleep(3000); // On simule 3 secondes de temps de calcul
            Console.WriteLine("La pate est prete");
        }
        public static void CuireDuPain()
        {
            Console.WriteLine("Le pain cuit...");
            ImprimerInfoThread();
            Thread.Sleep(3000); // On simule 3 secondes de temps de calcul
            Console.WriteLine("Le pain est cuit");
        }
        public static void EcouterLaRadio()
        {
            Console.WriteLine("Commencer à écouter la radio...");
            ImprimerInfoThread();
            Thread.Sleep(20000); // On simule 2 secondes de temps de calcul
            Console.WriteLine("Fin de l'écoute de la radio");
        }
        public static void FaireUnCasseTete()
        {
            Console.WriteLine("Commencer le casse-tête...");
            ImprimerInfoThread();
            Thread.Sleep(1000); // On simule 1 seconde de temps de calcul
            Console.WriteLine("Le casse-tête est terminé");
        }
        public static void ImprimerInfoThread()
        {
            Thread t = Thread.CurrentThread;
            Console.WriteLine($"ID : {t.ManagedThreadId} , " +
            $"Priorité : {t.Priority}, " +
            $"Est background : {t.IsBackground}, " +
            $"Nom : {t.Name ?? "Aucun"}.");
        }

    }

}