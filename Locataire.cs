using System;

namespace tp_agence_logement
{
    public class Locataire
    {
        private int id;
        private string nom;
        private string telephone;

        public Locataire(int id, string nom, string telephone)
        {
            this.id = id;
            this.nom = nom;
            this.telephone = telephone;
        }

        public void Afficher()
        {
            Console.WriteLine($"ID: {id}, Nom: {nom}, Téléphone: {telephone}");
        }

        // Getters for later use
        public int Id => id;
        public string Nom => nom;
    }
}