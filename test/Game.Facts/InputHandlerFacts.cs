using SFML.Window;
using System;
using System.Linq;
using Xunit;

namespace Game.Facts
{
    public class InputHandlerFacts
    {
        [Fact]
        public void Raised_key_events_are_retrievable()
        {
            var keyEvent = new KeyEvent
            {
                Code = Keyboard.Key.A
            };

            var inputHandler = new InputHandler();
            inputHandler.OnKeyPressed(null, new KeyEventArgs(keyEvent));

            Assert.True(inputHandler.IsKeyPressed(Keyboard.Key.A), "inputHandler.IsKeyPressed(Keyboard.Key.A)");
            Assert.Equal(Keyboard.Key.A, inputHandler.AllPressedKeys().First());
        }

        [Fact]
        public void Raised_key_events_are_cleared_on_key_release()
        {
            var keyEvent = new KeyEvent
            {
                Code = Keyboard.Key.A
            };

            var inputHandler = new InputHandler();
            inputHandler.OnKeyPressed(null, new KeyEventArgs(keyEvent));
            inputHandler.OnKeyReleased(null, new KeyEventArgs(keyEvent));

            Assert.False(inputHandler.IsKeyPressed(Keyboard.Key.A), "inputHandler.IsKeyPressed(Keyboard.Key.A)");
            Assert.Empty(inputHandler.AllPressedKeys());
        }
    }
}