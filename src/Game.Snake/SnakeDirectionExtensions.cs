namespace Game.Snake
{
    public static class SnakeDirectionExtensions
    {
        public static bool IsOpposite(this SnakeDirection direction, SnakeDirection otherDirection)
        {
            return direction switch
            {
                SnakeDirection.Up => otherDirection == SnakeDirection.Down,
                SnakeDirection.Right => otherDirection == SnakeDirection.Left,
                SnakeDirection.Down => otherDirection == SnakeDirection.Up,
                SnakeDirection.Left => otherDirection == SnakeDirection.Right,
                _ => false,
            };
        }
    }
}