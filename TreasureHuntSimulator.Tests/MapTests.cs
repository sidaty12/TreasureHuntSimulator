using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureHuntSimulator.Models;

namespace TreasureHuntSimulator.Tests
{
    public class MapTests
    {
        [Fact]
        public void Map_ShouldBeCreated_WithCorrectDimensionsAndElements()
        {
            // Arrange
            var map = new Map(5, 5);
            map.AddMountain(2, 1);
            map.AddTreasure(1, 3, 4);
            map.AddTreasure(2, 4, 2);

            // Act
            bool hasMountain = map.IsMountain(2, 1);
            var treasureAt1_3 = map.GetTreasureAt(1, 3);
            var treasureAt2_4 = map.GetTreasureAt(2, 4);

            // Assert
            Assert.Equal(5, map.Width);
            Assert.Equal(5, map.Height);
            Assert.True(hasMountain);
            Assert.NotNull(treasureAt1_3);
            Assert.Equal(4, treasureAt1_3.Count);
            Assert.NotNull(treasureAt2_4);
            Assert.Equal(2, treasureAt2_4.Count);
        }
        [Fact]
        public void Adventurer_ShouldNotMoveOutsideMapBounds()
        {
            // Arrange
            var map = new Map(3, 3);
            var indiana = new Adventurer("Indiana", 0, 0, 'N', "A", map);

            // Act
            indiana.ExecuteMovement();

            // Assert
            // Vérifier que l'aventurier ne sort pas de la carte
            Assert.InRange(indiana.X, 0, map.Width - 1);
            Assert.InRange(indiana.Y, 0, map.Height - 1);
        }
    }
}
