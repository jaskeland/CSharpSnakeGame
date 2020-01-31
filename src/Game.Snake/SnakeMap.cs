using System;
using System.Collections.Generic;
using System.Linq;
using SFML.System;

namespace Game.Snake
{
    public class SnakeMap
    {
        public SnakeMap(Vector2u mapSize, int randomSeed = 0)
        {
            MapSize = mapSize;
            _random = randomSeed == 0 ? new Random() : new Random(randomSeed);
            _map = new TileContent[mapSize.X, mapSize.Y];
        }

        public Vector2u MapSize { get; }

        private readonly Random _random;
        private readonly TileContent[,] _map;

        public TileContent this[uint x, uint y]
        {
            get => _map[x, y];
            set => _map[x, y] = value;
        }

        public TileContent[,] AsReadOnly()
        {
            return (TileContent[,])_map.Clone();
        }

        public void AddFoodAtRandomLocation(uint amountToAdd)
        {
            var hasEmptyTiles = _map.Cast<TileContent>().Any(tile => tile == TileContent.Empty);
            if (!hasEmptyTiles)
            {
                return;
            }

            var emptySpots = GetCoordinatesForEmptyTiles().ToList();

            for (var i = 0; i < amountToAdd; i++)
            {
                if (!emptySpots.Any())
                {
                    break;
                }

                var nextEmptyIndex = _random.Next(0, emptySpots.Count - 1);
                var newFoodCoordinate = emptySpots[nextEmptyIndex];

                _map[newFoodCoordinate.X, newFoodCoordinate.Y] = TileContent.Food;
                emptySpots.Remove(newFoodCoordinate);
            }
        }

        public void SetTile(Vector2u coordinate, TileContent content)
        {
            if (!IsInsideBounds(coordinate))
            {
                return;
            }
            _map[coordinate.X, coordinate.Y] = content;
        }

        public bool IsInsideBounds(Vector2u coordinate)
        {
            return coordinate.X < MapSize.X && coordinate.Y < MapSize.Y;
        }

        public bool ContainsFood(Vector2u coordinate)
        {
            return IsInsideBounds(coordinate) && _map[coordinate.X, coordinate.Y].HasFlag(TileContent.Food);
        }

        private IEnumerable<Vector2u> GetCoordinatesForEmptyTiles()
        {
            for (uint x = 0; x < MapSize.X; x++)
            {
                for (uint y = 0; y < MapSize.Y; y++)
                {
                    if (_map[x, y] == TileContent.Empty)
                        yield return new Vector2u(x, y);
                }
            }
        }
    }
}