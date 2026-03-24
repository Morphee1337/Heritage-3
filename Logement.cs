using System;

namespace tp_agence_logement
{
    public class Logement
    {
        protected string reference;
        protected string adresse;
        protected int surface;
        protected double loyerBase;
        protected bool disponible;

        public string Reference => reference;

        public bool Disponible { get => disponible; set => disponible = value; }

        public double LoyerBase { get => loyerBase; set { if (value >= 0) loyerBase = value; } }

        public Logement(string reference, string adresse, int surface, double loyerBase, bool disponible)
        {
            if (surface <= 0)
            {
                throw new ArgumentException("La surface doit être strictement positive.");
            }
            if (loyerBase < 0)
            {
                throw new ArgumentException("Le loyer de base ne peut pas être négatif.");
            }
            this.reference = reference;
            this.adresse = adresse;
            this.surface = surface;
            this.loyerBase = loyerBase;
            this.disponible = disponible;
        }

        public virtual void Afficher()
        {
            Console.WriteLine($"Référence: {reference}, Adresse: {adresse}, Surface: {surface} m², Loyer de base: {loyerBase} €, Disponible: {disponible}");
        }

        public virtual double CalculerLoyer()
        {
            return loyerBase;
        }
    }
}