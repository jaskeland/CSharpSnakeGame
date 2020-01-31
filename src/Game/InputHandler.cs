using SFML.Window;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Game
{
    /// <summary>
    /// Stores key pressed events and removes them when the key is released.
    /// </summary>
    public class InputHandler
    {
        private readonly HashSet<KeyEventArgs> _pressedKeys;

        public InputHandler()
        {
            _pressedKeys = new HashSet<KeyEventArgs>(new KeyEventArgsComparer());
        }

        public void OnKeyPressed(object? sender, KeyEventArgs args)
        {
            var sameKeyPressedWithNewModifiers = _pressedKeys.Add(args);

            if (!sameKeyPressedWithNewModifiers)
            {
                return;
            }

            if (!_pressedKeys.TryGetValue(args, out var oldArgs))
            {
                return;
            }

            if (!StrictComparison(oldArgs, args))
            {
                return;
            }

            _pressedKeys.Remove(oldArgs);
            _pressedKeys.Add(args);
        }

        public IEnumerable<Keyboard.Key> AllPressedKeys()
        {
            return _pressedKeys.Select(keyArgs => keyArgs.Code);
        }

        public bool IsKeyPressed(Keyboard.Key key)
        {
            return _pressedKeys.Any(keyArgs => keyArgs.Code == key);
        }

        public void OnKeyReleased(object? sender, KeyEventArgs args)
        {
            _pressedKeys.Remove(args);
        }

        private static bool StrictComparison(KeyEventArgs x, KeyEventArgs y)
        {
            return x.Equals(y)
                && x.Alt == y.Alt
                && x.Control == y.Control
                && x.Shift == y.Shift
                && x.System == y.System;
        }

        private class KeyEventArgsComparer : IEqualityComparer<KeyEventArgs>
        {
            public bool Equals([AllowNull] KeyEventArgs x, [AllowNull] KeyEventArgs y)
            {
                return x.Code == y.Code;
            }

            public int GetHashCode([DisallowNull] KeyEventArgs obj)
            {
                return obj.Code.GetHashCode();
            }
        }
    }
}