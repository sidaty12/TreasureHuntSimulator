using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureHuntSimulator.Models;

namespace TreasureHuntSimulator.Utilities
{
    public static class FileHandler
    {
        public static Map LoadMapFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            Map? map = null;

            foreach (var line in lines)
            {
                if (line.StartsWith("#")) continue; // Ignorer les commentaires

                var parts = line.Split('-').Select(p => p.Trim()).ToArray();
                switch (parts[0])
                {
                    case "C":
                        int width = int.Parse(parts[1]);
                        int height = int.Parse(parts[2]);
                        map = new Map(width, height);
                        break;
                    case "M":
                        if (map != null)
                        {
                            int mx = int.Parse(parts[1]);
                            int my = int.Parse(parts[2]);
                            map.AddMountain(mx, my);
                        }
                        break;
                    case "T":
                        if (map != null)
                        {
                            int tx = int.Parse(parts[1]);
                            int ty = int.Parse(parts[2]);
                            int treasureCount = int.Parse(parts[3]);
                            map.AddTreasure(tx, ty, treasureCount);
                        }
                        break;
                    case "A":
                        if (map != null)
                        {
                            string name = parts[1];
                            int ax = int.Parse(parts[2]);
                            int ay = int.Parse(parts[3]);
                            char orientation = char.Parse(parts[4]);
                            string sequence = parts[5];
                            var adventurer = new Adventurer(name, ax, ay, orientation, sequence,map);
                            map.AddAdventurer(adventurer);
                        }
                        break;
                }
            }

            return map ?? throw new Exception("Les dimensions de la carte n'ont pas été définies correctement.");
        
    }

        public static void WriteOutputToFile(Map map, string filePath)
        {
            List<string> lines = new List<string>
            {
                $"C - {map.Width} - {map.Height}"
            };

            foreach (var mountain in map.Mountains)
            {
                lines.Add($"M - {mountain.X} - {mountain.Y}");
            }

            foreach (var treasure in map.Treasures.Where(t => t.Count > 0))
            {
                lines.Add($"T - {treasure.X} - {treasure.Y} - {treasure.Count}");
            }

            foreach (var adventurer in map.Adventurers)
            {
                lines.Add($"A - {adventurer.Name} - {adventurer.X} - {adventurer.Y} - {adventurer.Orientation} - {adventurer.TreasuresCollected}");
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}
