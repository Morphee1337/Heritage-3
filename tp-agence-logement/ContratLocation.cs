using System;

namespace tp_agence_logement
{
    public class ContratLocation
    {
        private int numero;
        private Locataire locataire;
        private Logement logement;
        private int nombreJours;
        private double tarifJournalier;

        public ContratLocation(int numero, Locataire locataire, Logement logement, int nombreJours)
        {
            if (nombreJours <= 0)
            {
                throw new ArgumentException("La durée d'un contrat doit être strictement positive.");
            }
            if (!logement.Disponible)
            {
                throw new InvalidOperationException("Le logement n'est pas disponible.");
            }
            this.numero = numero;
            this.locataire = locataire;
            this.logement = logement;
            this.nombreJours = nombreJours;
            this.tarifJournalier = logement.CalculerLoyer();
            logement.Disponible = false;
        }

        public double CalculerMontantTotal()
        {
            return nombreJours * tarifJournalier;
        }

        public void Afficher()
        {
            Console.WriteLine($"Contrat {numero}: {locataire.Nom} loue {logement.GetType().Name} pendant {nombreJours} jours à {tarifJournalier} €/jour");
            Console.WriteLine($"Montant total: {CalculerMontantTotal()} €");
        }

        public Logement Logement => logement;
        public Locataire Locataire => locataire;
    }
}
