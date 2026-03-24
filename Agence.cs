using System;
using System.Collections.Generic;

namespace tp_agence_logement
{
    public class Agence
    {
        private string nom;
        private List<Logement> logements;
        private List<Locataire> locataires;
        private List<ContratLocation> contrats;

        public Agence(string nom)
        {
            this.nom = nom;
            logements = new List<Logement>();
            locataires = new List<Locataire>();
            contrats = new List<ContratLocation>();
        }

        public void AjouterLogement(Logement logement)
        {
            if (logements.Exists(l => l.Reference == logement.Reference))
            {
                throw new InvalidOperationException("Un logement avec cette référence existe déjà.");
            }
            logements.Add(logement);
        }

        public void AjouterLocataire(Locataire locataire)
        {
            if (locataires.Exists(l => l.Id == locataire.Id))
            {
                throw new InvalidOperationException("Un locataire avec cet ID existe déjà.");
            }
            locataires.Add(locataire);
        }

        public void AjouterContrat(ContratLocation contrat)
        {
            if (!locataires.Contains(contrat.Locataire))
            {
                throw new InvalidOperationException("Le locataire n'appartient pas à l'agence.");
            }
            if (!logements.Contains(contrat.Logement))
            {
                throw new InvalidOperationException("Le logement n'appartient pas à l'agence.");
            }
            contrats.Add(contrat);
        }

        public void AfficherLogements()
        {
            Console.WriteLine("Logements:");
            foreach (var l in logements)
            {
                l.Afficher();
                Console.WriteLine();
            }
        }

        public void AfficherLocataires()
        {
            Console.WriteLine("Locataires:");
            foreach (var l in locataires)
            {
                l.Afficher();
            }
        }

        public void AfficherContrats()
        {
            Console.WriteLine("Contrats:");
            foreach (var c in contrats)
            {
                c.Afficher();
                Console.WriteLine();
            }
        }

        public void AfficherLogementsDisponibles()
        {
            Console.WriteLine("Logements disponibles:");
            foreach (var l in logements)
            {
                if (l.Disponible)
                {
                    l.Afficher();
                    Console.WriteLine();
                }
            }
        }

        // Getters for tests
        public List<Logement> Logements => logements;
        public List<Locataire> Locataires => locataires;
        public List<ContratLocation> Contrats => contrats;
    }
}