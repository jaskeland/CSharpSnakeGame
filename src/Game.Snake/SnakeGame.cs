using SFML.System;
using System;

namespace Game.Snake
{
    public class SnakeGame
    {
        public SnakeGame(Vector2u mapSize, int randomSeed = 0)
        {
            if (mapSize.X <= 0 || mapSize.Y <= 0)
            {
                throw new ArgumentException("Map size must be greater than [0,0]", nameof(mapSize));
            }

            MapSize = mapSize;
            _map = new TileContent[mapSize.X, mapSize.Y];

            _snakeBody = new SnakeBody(mapSize / 2);
            _random = randomSeed == 0 ? new Random() : new Random(randomSeed);

            SetTile(_snakeBody.Head, TileContent.SnakeHead);
        }

        public Vector2u MapSize { get; }

        public Vector2u Head => _snakeBody.Head;

        public TileContent[,] Map => (TileContent[,])_map.Clone();

        private readonly TileContent[,] _map;
        private readonly SnakeBody _snakeBody;
        private Random _random;
        private SnakeDirection _currentDirection;

        public void Update()
        {
            if (!IsInsideBounds(_snakeBody.Head.AddSnakeDirection(_currentDirection)))
            {
                return;
            }

            SetTile(_snakeBody.Tail, TileContent.Empty);
            _snakeBody.Move(_currentDirection);

            foreach (var segment in _snakeBody.BodySegments)
            {
                SetTile(segment, TileContent.SnakeBody);
            }

            SetTile(_snakeBody.Head, TileContent.SnakeHead);
        }

        public void SetDirection(SnakeDirection direction)
        {
            _currentDirection = direction;
        }

        private void SetTile(Vector2u coordinate, TileContent content)
        {
            if (coordinate.X > MapSize.X || coordinate.Y > MapSize.Y)
            {
                return;
            }
            _map[coordinate.X, coordinate.Y] = content;
        }

        private bool IsInsideBounds(Vector2u coordinate)
        {
            return coordinate.X < MapSize.X && coordinate.Y < MapSize.Y;
        }
    }
}