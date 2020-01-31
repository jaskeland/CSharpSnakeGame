using System;
using SFML.System;

namespace Game.Snake
{
    public static class Vector2UExtensions
    {
        public static Vector2u AddSnakeDirection(this Vector2u vector, SnakeDirection direction)
        {
            return direction switch
            {
                SnakeDirection.None => vector,
                SnakeDirection.Up => vector - new Vector2u(0, 1),
                SnakeDirection.Right => vector + new Vector2u(1, 0),
                SnakeDirection.Down => vector + new Vector2u(0, 1),
                SnakeDirection.Left => vector - new Vector2u(1, 0),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }
}