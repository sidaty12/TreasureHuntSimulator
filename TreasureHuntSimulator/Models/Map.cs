using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHuntSimulator.Models
{
    public class Map
    {
        public int Width { get; }
        public int Height { get; }
        public List<Mountain> Mountains { get; } = new List<Mountain>();
        public List<Treasure> Treasures { get; } = new List<Treasure>();
        public List<Adventurer> Adventurers { get; } = new List<Adventurer>();

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool IsMountain(int x, int y)
        {
            return Mountains.Any(m => m.X == x && m.Y == y);
        }

        public Treasure? GetTreasureAt(int x, int y)
        {
            return Treasures.FirstOrDefault(t => t.X == x && t.Y == y);
        }

        public void AddMountain(int x, int y)
        {
            Mountains.Add(new Mountain(x, y));
        }

        public void AddTreasure(int x, int y, int count)
        {
            Treasures.Add(new Treasure(x, y, count));
        }

        public void AddAdventurer(Adventurer adventurer)
        {
            Adventurers.Add(adventurer);
        }
    }
}
