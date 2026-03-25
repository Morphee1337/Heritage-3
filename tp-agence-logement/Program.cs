using tp_agence_logement;

Console.WriteLine("Test Logement");

try
{
    Logement logement = new Logement("L1", "Paris", 50, 600.0, true);
    logement.Afficher();
    Console.WriteLine($"Loyer calculé: {logement.CalculerLoyer()} euros");
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur: {ex.Message}");
}

try
{
    Logement logementInvalide = new Logement("L2", "Lyon", 0, 500.0, true);
    logementInvalide.Afficher();
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur surface: {ex.Message}");
}

try
{
    Logement logementInvalide2 = new Logement("L3", "Lille", 40, -100.0, true);
    logementInvalide2.Afficher();
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur loyer: {ex.Message}");
}

Console.WriteLine("\nTest Classes Dérivées");

try
{
    Studio studio = new Studio("S1", "Paris", 20, 500.0, true, true);
    studio.Afficher();
    Console.WriteLine($"Loyer calculé: {studio.CalculerLoyer()} euros");
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur Studio: {ex.Message}");
}

try
{
    Appartement appartement = new Appartement("A1", "Lyon", 60, 800.0, true, 3);
    appartement.Afficher();
    Console.WriteLine($"Loyer calculé: {appartement.CalculerLoyer()} euros");
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur Appartement: {ex.Message}");
}

try
{
    Maison maison = new Maison("M1", "Lille", 100, 1200.0, true, 50);
    maison.Afficher();
    Console.WriteLine($"Loyer calculé: {maison.CalculerLoyer()} euros");
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur Maison: {ex.Message}");
}

try
{
    Appartement appartementInvalide = new Appartement("A2", "Marseille", 50, 700.0, true, 0);
    appartementInvalide.Afficher();
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur Appartement pièces: {ex.Message}");
}

try
{
    Maison maisonInvalide = new Maison("M2", "Toulouse", 80, 1000.0, true, -10);
    maisonInvalide.Afficher();
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur Maison jardin: {ex.Message}");
}

Console.WriteLine("\nTest Polymorphisme");

List<Logement> logements = new List<Logement>();

logements.Add(new Studio("S1", "Paris", 20, 500.0, true, true));
logements.Add(new Appartement("A1", "Lyon", 60, 800.0, true, 3));
logements.Add(new Maison("M1", "Lille", 100, 1200.0, true, 50));

foreach (Logement l in logements)
{
    l.Afficher();
    Console.WriteLine($"Loyer: {l.CalculerLoyer()} euros\n");
}

Console.WriteLine("Test Locataire");

Locataire alice = new Locataire(1, "Alice", "0123456789");
Locataire bob = new Locataire(2, "Bob", "0987654321");
Locataire ines = new Locataire(3, "Inès", "0567891234");

alice.Afficher();
bob.Afficher();
ines.Afficher();

Console.WriteLine("\nTest ContratLocation");

Studio studio2 = new Studio("S1", "Paris", 20, 500.0, true, true);
Maison maison2 = new Maison("M1", "Lille", 100, 1200.0, true, 50);

try
{
    ContratLocation contrat1 = new ContratLocation(101, alice, studio2, 5);
    contrat1.Afficher();
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur contrat studio: {ex.Message}");
}

try
{
    ContratLocation contrat2 = new ContratLocation(102, bob, maison2, 3);
    contrat2.Afficher();
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur contrat maison: {ex.Message}");
}

try
{
    ContratLocation contratInvalide = new ContratLocation(103, ines, new Appartement("A1", "Lyon", 60, 800.0, true, 3), 0);
    contratInvalide.Afficher();
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur durée: {ex.Message}");
}

try
{
    ContratLocation contratRelou = new ContratLocation(104, ines, studio2, 2);
    contratRelou.Afficher();
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur relouer: {ex.Message}");
}

Console.WriteLine("\nTest Agence");

Agence agence = new Agence("Agence Immobilière");

try
{
    agence.AjouterLogement(new Studio("S1", "Paris", 20, 500.0, true, true));
    agence.AjouterLogement(new Maison("M1", "Lille", 100, 1200.0, true, 50));
    agence.AjouterLogement(new Appartement("A1", "Lyon", 60, 800.0, true, 3));
    Console.WriteLine("Logements ajoutés.");
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur ajout logement: {ex.Message}");
}

try
{
    agence.AjouterLogement(new Studio("S1", "Paris", 20, 500.0, true, true));
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur duplicate logement: {ex.Message}");
}

try
{
    agence.AjouterLocataire(alice);
    agence.AjouterLocataire(bob);
    agence.AjouterLocataire(ines);
    Console.WriteLine("Locataires ajoutés.");
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur ajout locataire: {ex.Message}");
}

try
{
    agence.AjouterLocataire(new Locataire(1, "Dup", "000"));
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur duplicate locataire: {ex.Message}");
}

try
{
    agence.AjouterContrat(new ContratLocation(101, alice, agence.Logements[0], 5));
    agence.AjouterContrat(new ContratLocation(102, bob, agence.Logements[1], 3));
    agence.AjouterContrat(new ContratLocation(103, ines, agence.Logements[2], 7));
    Console.WriteLine("Contrats ajoutés.");
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur ajout contrat: {ex.Message}");
}

try
{
    agence.AjouterContrat(new ContratLocation(104, new Locataire(4, "Unknown", "000"), agence.Logements[0], 1));
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur contrat locataire inconnu: {ex.Message}");
}

try
{
    agence.AjouterContrat(new ContratLocation(105, alice, new Maison("M2", "Toulouse", 80, 1000.0, true, 20), 1));
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur contrat logement inconnu: {ex.Message}");
}

agence.AfficherLogements();
agence.AfficherLocataires();
agence.AfficherContrats();

Console.WriteLine("\nLogements Disponibles");
agence.AfficherLogementsDisponibles();

Console.WriteLine("\nTest métier: modification loyer après contrat");

Logement testLogement = new Studio("S2", "Test", 25, 600.0, true, false);
agence.AjouterLogement(testLogement);

ContratLocation testContrat = new ContratLocation(106, alice, testLogement, 2);
agence.AjouterContrat(testContrat);

Console.WriteLine("Avant modification:");
testContrat.Afficher();

testLogement.LoyerBase = 700.0;

Console.WriteLine("Après modification du loyer du logement:");
testContrat.Afficher();
Console.WriteLine("Le contrat conserve le tarif journalier mémorisé.");

Console.WriteLine("\nTest Casting et is");

foreach (Logement l in agence.Logements)
{
    if (l is Maison m)
    {
        Console.WriteLine($"Maison {m.Reference}: Surface jardin {m.SurfaceJardin} m²");
    }
    if (l is Studio s)
    {
        Console.WriteLine($"Studio {s.Reference}: Meublé {s.Meuble}");
    }
    if (l is Appartement a)
    {
        Console.WriteLine($"Appartement {a.Reference}: Nombre de pièces {a.NombrePieces}");
    }
}

Console.WriteLine("\nTest ToString()");

Console.WriteLine(alice);
Console.WriteLine(agence.Logements[0]);
