using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureHuntSimulator.Models;

namespace TreasureHuntSimulator.Tests
{
    public class AdventurerTests
    {
        [Fact]
        public void Adventurer_ShouldMoveCorrectly_AvoidingMountainsAndCollectingTreasures()
        {
            // Arrange
            var map = new Map(5, 5);
            map.AddMountain(2, 1);
            map.AddTreasure(2, 4, 2);
            map.AddTreasure(1, 3, 4);
            var indiana = new Adventurer("Indiana", 2, 2, 'S', "AADADA", map);

            // Act
            indiana.ExecuteMovement();

            // Assert
            // Position finale après les mouvements
            Assert.Equal(1, indiana.X);
            Assert.Equal(3, indiana.Y);
            Assert.Equal('N', indiana.Orientation);

            // Vérification des trésors collectés
            Assert.Equal(2, indiana.TreasuresCollected);

            // Vérification des trésors restants sur la carte
            var remainingTreasureAt2_4 = map.GetTreasureAt(2, 4);
            var remainingTreasureAt1_3 = map.GetTreasureAt(1, 3);
            Assert.Equal(1, remainingTreasureAt2_4.Count);
            Assert.Equal(3, remainingTreasureAt1_3.Count);
        }

        [Fact]
        public void Adventurer_ShouldBeBlockedByMountain_AndNotMove()
        {
            // Arrange
            var map = new Map(5, 5);
            map.AddMountain(2, 1);
            var lara = new Adventurer("Lara", 1, 1, 'E', "AAD", map);

            // Act
            lara.ExecuteMovement();

            // Assert
            // Lara est bloquée par la montagne et ne doit pas avancer
            Assert.Equal(1, lara.X);
            Assert.Equal(1, lara.Y); // Reste sur la position initiale
            Assert.Equal('S', lara.Orientation); // Après les rotations
            Assert.Equal(0, lara.TreasuresCollected); // Pas de trésors collectés
        }
    }

}
