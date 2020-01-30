using SFML.System;
using System;

namespace Game.Snake
{
    public class SnakeGame
    {
        public Vector2i MapSize { get; }
        public Vector2i SnakeHeadPosition { get; private set; }

        private TileContent[,] _map;

        public SnakeGame(Vector2i mapSize)
        {
            if (mapSize.X <= 0 || mapSize.Y <= 0)
            {
                throw new ArgumentException("Map size must be a positive number", nameof(mapSize));
            }

            MapSize = mapSize;
            SnakeHeadPosition = mapSize / 2;
            _map = new TileContent[mapSize.X, mapSize.Y];
            SetTile(SnakeHeadPosition, TileContent.SnakeHead);
        }

        public void Update()
        {
        }

        public void SetDirection(SnakeDirection direction)
        {
        }

        private void SetTile(Vector2i coordinate, TileContent content)
        {
            if (coordinate.X < 0 || coordinate.Y < 0 || coordinate.X > MapSize.X || coordinate.Y > MapSize.Y)
            {
                return;
            }
            _map[coordinate.X, coordinate.Y] = content;
        }

        private void MoveSnake()
        {
        }
    }
}