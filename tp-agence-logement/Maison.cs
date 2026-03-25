using System;

namespace tp_agence_logement
{
    public class Maison : Logement
    {
        private int surfaceJardin;

        public Maison(string reference, string adresse, int surface, double loyerBase, bool disponible, int surfaceJardin)
            : base(reference, adresse, surface, loyerBase, disponible)
        {
            if (surfaceJardin < 0)
            {
                throw new ArgumentException("Une maison doit avoir une surface de jardin positive ou nulle.");
            }
            this.surfaceJardin = surfaceJardin;
        }

        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine($"Surface jardin: {surfaceJardin} m²");
        }

        public int SurfaceJardin => surfaceJardin;
    }
}