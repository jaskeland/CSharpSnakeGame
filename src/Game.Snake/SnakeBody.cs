using System.Collections.Generic;
using System.Linq;
using SFML.System;

namespace Game.Snake
{
    public class SnakeBody
    {
        public SnakeBody(Vector2u head)
        {
            _bodySegments = new List<Vector2u> { head };
            _desiredLength = 1;
        }

        public Vector2u Head => _bodySegments[0];
        public IReadOnlyCollection<Vector2u> BodySegments => _bodySegments.AsReadOnly();

        private readonly List<Vector2u> _bodySegments;
        private uint _desiredLength;

        public bool Move(SnakeDirection direction)
        {
            var newHeadPosition = _bodySegments[0].AddSnakeDirection(direction);
            if (_bodySegments.Any(coordinate => coordinate.Equals(newHeadPosition)))
            {
                // When the head collides with the body we cant move
                return false;
            }

            if (_desiredLength > _bodySegments.Count)
            {
                var segmentsToGrow = _desiredLength - _bodySegments.Count;
                for (var i = 0; i < segmentsToGrow; i++)
                {
                    _bodySegments.Add(_bodySegments[^1]);
                }
            }

            // Move every segment except the head to its parents position, starting from the tail
            for (var i = _bodySegments.Count; i > 1; i--)
            {
                _bodySegments[i - 1] = _bodySegments[i - 2];
            }

            // We can now move the head
            _bodySegments[0] = newHeadPosition;

            return true;
        }

        public void Grow()
        {
            _desiredLength++;
        }
    }
}