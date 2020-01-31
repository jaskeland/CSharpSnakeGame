using SFML.System;
using Xunit;

namespace Game.Snake.Facts
{
    public class SnakeGameFacts
    {
        [Theory]
        [InlineData(3, 3, 1, 1)]
        [InlineData(5, 3, 2, 1)]
        [InlineData(12, 7, 6, 3)]
        public void Snake_head_is_initialized_at_center_of_board(uint sizeX, uint sizeY, uint expectedX, uint expectedY)
        {
            var snakeGame = new SnakeGame(new Vector2u(sizeX, sizeY));

            Assert.Equal(expectedX, snakeGame.SnakeBody.Head.X);
            Assert.Equal(expectedY, snakeGame.SnakeBody.Head.Y);
        }
    }
}