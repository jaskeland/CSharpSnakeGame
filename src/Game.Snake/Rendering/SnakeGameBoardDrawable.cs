using SFML.Graphics;
using SFML.System;
using System;

namespace Game.Snake.Rendering
{
    public class SnakeGameBoardDrawable : Drawable
    {
        private readonly ListOfDrawables _map;
        private readonly float _tileWidth;
        private readonly float _tileHeight;

        public SnakeGameBoardDrawable(Vector2u mapSize, Vector2u windowDimensions)
        {
            _map = new ListOfDrawables();
            _tileWidth = windowDimensions.X / mapSize.X;
            _tileHeight = windowDimensions.Y / mapSize.Y;
        }

        public void AddMap(TileContent[,] tiles)
        {
            for (uint x = 0; x < tiles.GetLength(0); x++)
            {
                for (uint y = 0; y < tiles.GetLength(1); y++)
                {
                    AddTile(tiles[x, y], new Vector2u(x, y));
                }
            }
        }

        public void AddTile(TileContent tile, Vector2u coordinate)
        {
            _map.Add(CreateDrawable(tile, new Vector2f(_tileWidth, _tileHeight), new Vector2f(_tileWidth * coordinate.X, _tileHeight * coordinate.Y)));
        }

        private static Drawable CreateDrawable(TileContent tile, Vector2f size, Vector2f position)
        {
            return tile switch
            {
                TileContent.Food => ColouredTile(size, position, Color.Yellow, Color.Black),
                TileContent.Empty => ColouredTile(size, position, Color.White, Color.Black),
                TileContent.SnakeBody => ColouredTile(size, position, Color.Blue, Color.Blue),
                TileContent.SnakeHead => ColouredTile(size, position, Color.Blue, Color.Magenta),
                TileContent.SnakeTail => ColouredTile(size, position, Color.Blue, Color.Cyan),
                _ => throw new ArgumentOutOfRangeException(nameof(tile), tile, null)
            };
        }

        private static Drawable ColouredTile(Vector2f size, Vector2f position, Color fillColor, Color outlineColor)
        {
            return new RectangleShape(size)
            {
                FillColor = fillColor,
                OutlineColor = outlineColor,
                OutlineThickness = (size.X + size.Y) / 20,
                Position = position
            };
        }

        public void Draw(RenderTarget target, RenderStates states) => _map.Draw(target, states);

        public void Clear() => _map.Clear();
    }
}