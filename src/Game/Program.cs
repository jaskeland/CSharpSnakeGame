using SFML.Window;
using System;
using Game.Snake;
using SFML.System;
using SFML.Graphics;
using Game.Snake.Rendering;

namespace Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var window = new RenderWindow(new VideoMode(800, 600), "Gamewindow");
            window.SetFramerateLimit(60);
            window.SetKeyRepeatEnabled(false);

            window.Closed += OnClose;

            Vector2u mapSize = new Vector2u(50, 50);
            var snakeGame = new SnakeGame(mapSize);
            var snakeGameDrawable = new SnakeGameBoardDrawable(mapSize, window.Size);

            window.KeyPressed += snakeGame.OnKeyPressed;

            // Rudimentary gameloop
            var clock = new Clock();
            var timeSinceLastUpdate = clock.ElapsedTime;
            while (window.IsOpen)
            {
                window.DispatchEvents();

                snakeGame.Update();
                snakeGameDrawable.Clear();
                snakeGameDrawable.AddMap(snakeGame.Map);

                timeSinceLastUpdate = clock.ElapsedTime;

                window.Clear();
                window.Draw(snakeGameDrawable);
                window.Display();
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