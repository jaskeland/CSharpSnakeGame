using System.Linq;
using SFML.System;
using Xunit;

namespace Game.Snake.Facts
{
    public class SnakeMapFacts
    {
        [Fact]
        public void Can_add_food_to_map()
        {
            var map = new SnakeMap(new Vector2u(10, 10));
            map.AddFoodAtRandomLocation(1);

            Assert.Single(map.AsReadOnly(), TileContent.Food);
        }

        [Fact]
        public void Adding_too_much_food_fills_map()
        {
            var map = new SnakeMap(new Vector2u(3, 3));
            map.AddFoodAtRandomLocation(100);

            Assert.Equal(9, map.AsReadOnly().LongLength);
            foreach (var tile in map.AsReadOnly())
            {
                Assert.Equal(TileContent.Food, tile);
            }
        }
    }
}