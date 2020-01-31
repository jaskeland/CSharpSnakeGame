using SFML.Window;
using System;
using Game.Snake;
using SFML.System;

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

            var snakeGame = new SnakeGame(new Vector2u(10, 10));

            // Rudimentary gameloop
            var clock = new Clock();
            var timeSinceLastUpdate = clock.ElapsedTime;
            while (window.IsOpen)
            {
                window.DispatchEvents();

                if (clock.ElapsedTime - timeSinceLastUpdate > Time.FromMilliseconds(100))
                {
                    Console.Clear();
                    snakeGame.Update();

                    for (int y = 0; y < snakeGame.Map.GetLength(1); y++)
                    {
                        for (int x = 0; x < snakeGame.Map.GetLength(0); x++)
                        {
                            Console.Write($"[{snakeGame.Map[x, y]}]");
                        }
                        Console.Write("\n");
                    }

                    timeSinceLastUpdate = clock.ElapsedTime;
                }
                if (inputHandler.IsKeyPressed(Keyboard.Key.Space))
                {
                }

                if (inputHandler.IsKeyPressed(Keyboard.Key.Left))
                {
                    snakeGame.SetDirection(SnakeDirection.Left);
                }
                if (inputHandler.IsKeyPressed(Keyboard.Key.Right))
                {
                    snakeGame.SetDirection(SnakeDirection.Right);
                }
                if (inputHandler.IsKeyPressed(Keyboard.Key.Up))
                {
                    snakeGame.SetDirection(SnakeDirection.Up);
                }
                if (inputHandler.IsKeyPressed(Keyboard.Key.Down))
                {
                    snakeGame.SetDirection(SnakeDirection.Down);
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