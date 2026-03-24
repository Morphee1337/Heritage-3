using System;

namespace tp_agence_logement
{
    public class Studio : Logement
    {
        private bool meuble;

        public Studio(string reference, string adresse, int surface, double loyerBase, bool disponible, bool meuble)
            : base(reference, adresse, surface, loyerBase, disponible)
        {
            this.meuble = meuble;
        }

        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine($"Meublé: {meuble}");
        }

        public override double CalculerLoyer()
        {
            double loyer = base.CalculerLoyer();
            if (meuble)
            {
                loyer += 50;
            }
            return loyer;
        }
    }
}