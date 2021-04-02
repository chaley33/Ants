using System;
using System.Collections;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Ants
{
    class Program
    {
        private static List<Ant> _antsList;
        public static RenderWindow window;
        public const int WindowWidth = 800;
        public const int WindowHeight = 600;
        static void Main(string[] args)
        {
            _antsList = new List<Ant>();
            GenerateAnts(10);
            // var window = new Window(new VideoMode(800, 600), "My window");
            window = new RenderWindow(new VideoMode(WindowWidth, WindowHeight), "My window");
            window.Closed += new EventHandler(OnClose);
            window.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(MouseButtonPressed);

            while (window.IsOpen)
            {
                window.Clear();
                foreach (var ant in _antsList)
                {
                    ant.Move();
                    window.Draw(ant.Sprite);
                }
                window.DispatchEvents();
                window.Display();
            }
        }

        static void OnClose(object sender, EventArgs e)
        {
            Console.WriteLine("\n\nExiting...\n\n");
            window.Close();
        }

        static void MouseButtonPressed(object sender, MouseButtonEventArgs mouse)
        {
            _antsList.Add(new Ant(mouse.X, mouse.Y));
            Console.WriteLine("\nMouse Button Pressed!\n");
        }

        static void GenerateAnts(int count)
        {
            for (var i = 0; i < count; i++)
            {
                _antsList.Add(new Ant());
            }
        }
    }
}