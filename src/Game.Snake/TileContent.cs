using System;

namespace Game.Snake
{
    [Flags]
    public enum TileContent
    {
        Empty = 0,
        Food = 1 << 0,
        SnakeHead = 1 << 1,
        SnakeBody = 1 << 2,
        SnakeTail = 1 << 3
    }
}