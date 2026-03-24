// See https://aka.ms/new-console-template for more information
using tp_agence_logement;

Console.WriteLine("=== Test Logement ===");

// Test valide
try
{
    Logement logement = new Logement("L1", "Paris", 50, 600.0, true);
    logement.Afficher();
    Console.WriteLine($"Loyer calculé: {logement.CalculerLoyer()} €");
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur: {ex.Message}");
}

// Test invalide: surface <= 0
try
{
    Logement logementInvalide = new Logement("L2", "Lyon", 0, 500.0, true);
    logementInvalide.Afficher();
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur surface: {ex.Message}");
}

// Test invalide: loyer < 0
try
{
    Logement logementInvalide2 = new Logement("L3", "Lille", 40, -100.0, true);
    logementInvalide2.Afficher();
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur loyer: {ex.Message}");
}

Console.WriteLine("\n=== Test Classes Dérivées ===");

// Studio
try
{
    Studio studio = new Studio("S1", "Paris", 20, 500.0, true, true);
    studio.Afficher();
    Console.WriteLine($"Loyer calculé: {studio.CalculerLoyer()} €");
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur Studio: {ex.Message}");
}

// Appartement
try
{
    Appartement appartement = new Appartement("A1", "Lyon", 60, 800.0, true, 3);
    appartement.Afficher();
    Console.WriteLine($"Loyer calculé: {appartement.CalculerLoyer()} €");
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur Appartement: {ex.Message}");
}

// Maison
try
{
    Maison maison = new Maison("M1", "Lille", 100, 1200.0, true, 50);
    maison.Afficher();
    Console.WriteLine($"Loyer calculé: {maison.CalculerLoyer()} €");
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur Maison: {ex.Message}");
}

// Test invalide Appartement: nombrePieces < 1
try
{
    Appartement appartementInvalide = new Appartement("A2", "Marseille", 50, 700.0, true, 0);
    appartementInvalide.Afficher();
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur Appartement pièces: {ex.Message}");
}

// Test invalide Maison: surfaceJardin < 0
try
{
    Maison maisonInvalide = new Maison("M2", "Toulouse", 80, 1000.0, true, -10);
    maisonInvalide.Afficher();
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur Maison jardin: {ex.Message}");
}

Console.WriteLine("\n=== Test Polymorphisme ===");

List<Logement> logements = new List<Logement>();

logements.Add(new Studio("S1", "Paris", 20, 500.0, true, true));
logements.Add(new Appartement("A1", "Lyon", 60, 800.0, true, 3));
logements.Add(new Maison("M1", "Lille", 100, 1200.0, true, 50));

foreach (Logement l in logements)
{
    l.Afficher();
    Console.WriteLine($"Loyer: {l.CalculerLoyer()} €\n");
}

Console.WriteLine("=== Test Locataire ===");

Locataire alice = new Locataire(1, "Alice", "0123456789");
Locataire bob = new Locataire(2, "Bob", "0987654321");
Locataire ines = new Locataire(3, "Inès", "0567891234");

alice.Afficher();
bob.Afficher();
ines.Afficher();
