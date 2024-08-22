using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureHuntSimulator.Models;

namespace TreasureHuntSimulator.Tests
{
    public class InvalidInputTests
    {
        [Fact]
        public void Adventurer_ShouldThrowException_WhenStartingOnMountain()
        {
            // Arrange
            var map = new Map(5, 5);
            map.AddMountain(2, 2);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                new Adventurer("Indiana", 2, 2, 'S', "AADADA", map));
            Assert.Equal("L'aventurier Indiana ne peut pas commencer en (2, 2) car il y a une montagne.", exception.Message);
        }
    }

}
