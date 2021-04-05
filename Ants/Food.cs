using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;

namespace Ants
{
    class FoodSource
    {
        public List<Food> Foods { get; }
        public Vector2f Position;
        public int Amount;

        private readonly Vector2f _size = new Vector2f(25, 25);

        public FoodSource()
        {
            var rand = new Random();
            Foods = new List<Food>();
            Amount = rand.Next(100);

            Position = new Vector2f(rand.Next(Program.WindowWidth - 100) + 50,
                rand.Next(Program.WindowHeight - 100) + 50);

            for (var i = 0; i < Amount; i++)
            {
                var xPos = Utilities.Map(rand.Next(50), 0, 50, Position.X - (0.5f * _size.X), Position.X + (0.5f * _size.X));
                var yPos = Utilities.Map(rand.Next(50), 0, 50, Position.Y - (0.5f * _size.Y), Position.Y + (0.5f * _size.Y));
                Foods.Add(new Food(xPos, yPos));
            }

            bool Remove(Food food)
            {
                return Foods.Remove(food);
            }
        }
    }

    class Food
    {
        public CircleShape Shape;

        public Food(float x, float y)
        {
            var rand = new Random();
            Shape = new CircleShape(2)
            {
                Position = new Vector2f(x, y),
                FillColor = Color.Green,
                OutlineColor = Color.Black
            };
        }
    }
}