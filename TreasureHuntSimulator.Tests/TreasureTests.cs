using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureHuntSimulator.Models;

namespace TreasureHuntSimulator.Tests
{
    public class TreasureTests
    {
        [Fact]
        public void Adventurer_ShouldCollectAllTreasuresOnHisPath()
        {
            // Arrange
            var map = new Map(5, 5);
            map.AddTreasure(2, 4, 2);
            map.AddTreasure(1, 3, 4);
            var indiana = new Adventurer("Indiana", 2, 2, 'S', "AADADA", map);

            // Act
            indiana.ExecuteMovement();

            // Assert
            // Vérification des trésors collectés
            Assert.Equal(2, indiana.TreasuresCollected);
        }

        [Fact]
        public void Adventurer_ShouldNotCollectTreasure_IfNotMoving()
        {
            // Arrange
            var map = new Map(5, 5);
            map.AddTreasure(2, 4, 2);
            var indiana = new Adventurer("Indiana", 2, 4, 'N', "G", map); // Tourne mais ne bouge pas

            // Act
            indiana.ExecuteMovement();

            // Assert
            // Vérification qu'aucun trésor n'est collecté
            Assert.Equal(0, indiana.TreasuresCollected);
            Assert.Equal(2, map.GetTreasureAt(2, 4).Count); // Trésor toujours présent
        }
    }

}
