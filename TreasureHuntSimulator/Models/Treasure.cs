using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHuntSimulator.Models
{
    public class Treasure
    {
        public int X { get; }
        public int Y { get; }
        public int Count { get; private set; }

        public Treasure(int x, int y, int count)
        {
            X = x;
            Y = y;
            Count = count;
        }

        public void Collect()
        {
            if (Count > 0)
                Count--;
        }
    }
}

