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

            Assert.Equal(expectedX, snakeGame.Head.X);
            Assert.Equal(expectedY, snakeGame.Head.Y);
        }

        [Fact]
        public void Can_move_snake_with_single_segment()
        {
            var snakeGame = new SnakeGame(new Vector2u(10, 10));

            snakeGame.SetDirection(SnakeDirection.Down);
            snakeGame.Update();

            Assert.Equal(TileContent.SnakeHead, snakeGame.Map[5, 6]);
            Assert.Equal(TileContent.Empty, snakeGame.Map[5, 5]);
        }

        [Fact]
        public void Can_add_food()
        {
            var snakeGame = new SnakeGame(new Vector2u(10, 10));

            snakeGame.AddFood(1);

            Assert.Single(snakeGame.Map, TileContent.Food);
        }

        [Fact]
        public void Flooding_board_with_food_does_not_overwrite_snake_head()
        {
            var snakeGame = new SnakeGame(new Vector2u(3, 3));
            snakeGame.AddFood(100);

            Assert.Single(snakeGame.Map, TileContent.SnakeHead);
        }
    }
}