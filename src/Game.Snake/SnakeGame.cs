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

            _map = new SnakeMap(mapSize, randomSeed);

            _snakeBody = new SnakeBody(mapSize / 2);

            _map.SetTile(_snakeBody.Head, TileContent.SnakeHead);
        }

        public Vector2u Head => _snakeBody.Head;

        public TileContent[,] Map => _map.AsReadOnly();

        private readonly SnakeMap _map;
        private readonly SnakeBody _snakeBody;
        private SnakeDirection _currentDirection;

        public void Update()
        {
            var newHeadPosition = _snakeBody.Head.AddSnakeDirection(_currentDirection);
            if (!_map.IsInsideBounds(newHeadPosition))
            {
                return;
            }

            if (_map.ContainsFood(newHeadPosition))
            {
                _snakeBody.Grow();
                _map.SetTile(newHeadPosition, TileContent.Empty);
            }

            _map.SetTile(_snakeBody.Tail, TileContent.Empty);
            _snakeBody.Move(_currentDirection);

            foreach (var segment in _snakeBody.BodySegments)
            {
                _map.SetTile(segment, TileContent.SnakeBody);
            }

            _map.SetTile(_snakeBody.Head, TileContent.SnakeHead);
        }

        public void SetDirection(SnakeDirection direction)
        {
            _currentDirection = direction;
        }

        public void AddFood(uint amountToAdd)
        {
            _map.AddFoodAtRandomLocation(amountToAdd);
        }
    }
}