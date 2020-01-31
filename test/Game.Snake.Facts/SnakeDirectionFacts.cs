using SFML.System;
using Xunit;

namespace Game.Snake.Facts
{
    public class SnakeDirectionFacts
    {
        [Theory]
        [InlineData(10, 10, SnakeDirection.None, 10, 10)]
        [InlineData(10, 10, SnakeDirection.Down, 10, 11)]
        [InlineData(10, 10, SnakeDirection.Left, 9, 10)]
        [InlineData(10, 10, SnakeDirection.Right, 11, 10)]
        [InlineData(10, 10, SnakeDirection.Up, 10, 9)]
        public void Updating_vector_with_direction_behaves_as_expected(uint startX, uint startY, SnakeDirection direction, uint expectedX, uint expectedY)
        {
            var vector = new Vector2u(startX, startY);
            vector = vector.AddSnakeDirection(direction);

            Assert.Equal(expectedX, vector.X);
            Assert.Equal(expectedY, vector.Y);
        }
    }
}