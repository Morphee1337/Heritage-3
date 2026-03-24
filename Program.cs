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
