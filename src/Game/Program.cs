using SFML.Window;
using System;

namespace Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var window = new Window(new VideoMode(800, 600), "Gamewindow");
            window.SetFramerateLimit(60);
            window.SetKeyRepeatEnabled(false);

            window.Closed += OnClose;
            var inputHandler = new InputHandler();

            window.KeyPressed += inputHandler.OnKeyPressed;
            window.KeyReleased += inputHandler.OnKeyReleased;

            while (window.IsOpen)
            {
                window.DispatchEvents();
                if (inputHandler.IsKeyPressed(Keyboard.Key.Enter))
                {
                    Console.WriteLine("Pressed the enter key. Writing all pressed keys:");
                    foreach (var item in inputHandler.AllPressedKeys())
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }

        public static void OnClose(object? sender, EventArgs args)
        {
            if (sender == null)
                throw new NullReferenceException("Window is null in OnClose event handler");

            ((Window)sender).Close();
        }
    }
}