using TreasureHuntSimulator.Models;
using TreasureHuntSimulator.Utilities;


// Chemin vers les fichiers d'entrée et de sortie
string inputFilePath = "input.txt";
string outputFilePath = "output.txt";

// Charger la carte et les aventuriers depuis le fichier d'entrée
Map map = FileHandler.LoadMapFromFile(inputFilePath);

// Exécuter la simulation
foreach (var adventurer in map.Adventurers)
{
    adventurer.ExecuteMovement();
}


// Afficher le résultat dans la console
foreach (var adventurer in map.Adventurers)
{
    Console.WriteLine($"Aventurier {adventurer.Name} termine en ({adventurer.X}, {adventurer.Y}) orienté {adventurer.Orientation} avec {adventurer.TreasuresCollected} trésors collectés.");
}
// Écrire les résultats dans le fichier de sortie
FileHandler.WriteOutputToFile(map, outputFilePath);
