using System.Linq;
using SFML.System;
using Xunit;

namespace Game.Snake.Facts
{
    public class SnakeBodyFacts
    {
        [Fact]
        public void Can_grow_snake()
        {
            var snake = new SnakeBody(new Vector2u(10, 10));

            snake.Grow();

            Assert.Single(snake.BodySegments);

            snake.Move(SnakeDirection.Down);

            Assert.Equal(2, snake.BodySegments.Count);
        }

        [Fact]
        public void Segments_are_updated_correctly_when_moving()
        {
            var snake = new SnakeBody(new Vector2u(10, 10));
            snake.Grow();
            snake.Grow();

            snake.Move(SnakeDirection.Left);
            snake.Move(SnakeDirection.Up);

            var segments = snake.BodySegments.ToArray();

            Assert.Equal(new Vector2u(9, 9), segments[0]);
            Assert.Equal(new Vector2u(9, 10), segments[1]);
            Assert.Equal(new Vector2u(10, 10), segments[2]);
        }
    }
}