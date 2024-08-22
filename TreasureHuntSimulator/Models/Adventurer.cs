using System;

namespace TreasureHuntSimulator.Models
{
    public class Adventurer
    {
        public string Name { get; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Orientation { get; private set; }
        public string MovementSequence { get; }
        public int TreasuresCollected { get; private set; } = 0;
        private readonly Map _map;

        public Adventurer(string name, int x, int y, char orientation, string movementSequence, Map map)
        {
            Name = name;
            X = x;
            Y = y;
            Orientation = orientation;
            MovementSequence = movementSequence;
            _map = map;

            // Vérification si l'aventurier commence sur une montagne
            if (_map.IsMountain(X, Y))
            {
                throw new ArgumentException($"L'aventurier {name} ne peut pas commencer en ({X}, {Y}) car il y a une montagne.");
            }
        }

        public void ExecuteMovement()
        {
            foreach (var move in MovementSequence)
            {
                int previousX = X;
                int previousY = Y;
                Console.WriteLine($"{Name} is about to move. Current Position: ({X}, {Y}), Orientation: {Orientation}");

                switch (move)
                {
                    case 'A':
                        MoveForward();
                        break;
                    case 'G':
                        TurnLeft();
                        break;
                    case 'D':
                        TurnRight();
                        break;
                }

                Console.WriteLine($"{Name} moved. New Position: ({X}, {Y}), Orientation: {Orientation}");

                // Collecter un trésor uniquement si l'aventurier a changé de position
                if (X != previousX || Y != previousY)
                {
                    // Ramassage du trésor après le mouvement
                    var treasure = _map.GetTreasureAt(X, Y);
                    if (treasure != null && treasure.Count > 0)
                    {
                        treasure.Collect();
                        TreasuresCollected++;
                        Console.WriteLine($"{Name} collected a treasure at ({X}, {Y}). Treasures collected: {TreasuresCollected}. Remaining treasures at this spot: {treasure.Count}");
                    }
                }
            }
        }

        private void MoveForward()
        {
            int newX = X;
            int newY = Y;

            switch (Orientation)
            {
                case 'N':
                    newY--;
                    break;
                case 'S':
                    newY++;
                    break;
                case 'E':
                    newX++;
                    break;
                case 'O':
                    newX--;
                    break;
            }

            // Vérifiez que le nouvel emplacement est dans les limites de la carte et n'est pas une montagne
            if (newX >= 0 && newX < _map.Width && newY >= 0 && newY < _map.Height && !_map.IsMountain(newX, newY))
            {
                X = newX;
                Y = newY;
            }
            else
            {
                Console.WriteLine($"{Name} cannot move to ({newX}, {newY}) - blocked or out of bounds.");
            }
        }

        private void TurnLeft()
        {
            Orientation = Orientation switch
            {
                'N' => 'O',
                'O' => 'S',
                'S' => 'E',
                'E' => 'N',
                _ => Orientation
            };
        }

        private void TurnRight()
        {
            Orientation = Orientation switch
            {
                'N' => 'E',
                'E' => 'S',
                'S' => 'O',
                'O' => 'N',
                _ => Orientation
            };
        }
    }
}
