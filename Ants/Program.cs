using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SimplexNoise;

namespace Ants
{
    internal class Program
    {
        public static List<Ant> AntsList;
        public static List<FoodSource> FoodSources;

        public static RenderWindow window;
        public const int WindowWidth = 800;
        public const int WindowHeight = 600;
        public static bool Debug = false;

        private static void Main(string[] args)
        {
            AntsList = new List<Ant>();
            FoodSources = new List<FoodSource>();
            GenerateAnts(10);
            GenerateFoodSources(3);
            window = new RenderWindow(new VideoMode(WindowWidth, WindowHeight), "My window");
            window.Closed += OnClose;
            window.MouseButtonPressed += MouseButtonPressed;
            window.SetFramerateLimit(30);

            while (window.IsOpen)
            {
                window.Clear();

                foreach (var foodSource in FoodSources)
                {
                    foreach (var food in foodSource.Foods)
                    {
                        window.Draw(food.Shape);
                    }
                }

                foreach (var ant in AntsList)
                {
                    ant.Move();
                    window.Draw(ant.Sprite);

                    if (Debug)
                    {
                        var targetPosition = ant.targetPosition;
                        var targetShape = new RectangleShape(new Vector2f(10, 10));
                        targetShape.Position = targetPosition;
                        window.Draw(targetShape);
                    }
                }

                AntsList[0].debug = false;

                window.DispatchEvents();
                window.Display();
            }
        }

        private static void OnClose(object sender, EventArgs e)
        {
            Console.WriteLine("\n\nExiting...\n\n");
            window.Close();
        }

        private static void MouseButtonPressed(object sender, MouseButtonEventArgs mouse)
        {
            AntsList.Add(new Ant(mouse.X, mouse.Y));
            Console.WriteLine("\nMouse Button Pressed!\n");
        }

        private static void GenerateAnts(int count)
        {
            for (var i = 0; i < count; i++)
            {
                AntsList.Add(new Ant());
            }
        }

        private static void GenerateFoodSources(int count)
        {
            for (var i = 0; i < count; i++)
            {
                FoodSources.Add(new FoodSource());
            }
        }
    }
}