using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;

namespace Ants
{
    class Ant
    {
        public Sprite Sprite { get; }
        public int Moves;

        private Vector2f velocity;
        private Vector2f acceleration;

        private float xScale = 0.001f;
        private float yScale = 0.001f;
        private float spriteScale = 0.05f;

        public Vector2f targetPosition;

        public bool debug = false;

        public Ant()
        {
            Texture texture =
                new Texture("E:\\OneDrive - Tennessee Tech University\\Programming\\C#\\Ants\\Ants\\ant.png");

            Sprite = new Sprite(texture)
            {
                Scale = new Vector2f(spriteScale, spriteScale)
            };

            var rand = new Random();
            var randX = rand.Next(0, Program.WindowWidth);
            var randY = rand.Next(0, Program.WindowHeight);
            // Console.WriteLine($"{randX}, {randY}");
            Sprite.Position = new Vector2f(randX, randY);

            targetPosition = FindNewPosition();
            Console.WriteLine($"Target Position: {targetPosition.X}, {targetPosition.Y}");
        }

        public Ant(int posX, int posY)
        {
            try
            {
                var texture =
                    new Texture("E:\\OneDrive - Tennessee Tech University\\Programming\\C#\\Ants\\Ants\\ant.png");

                Sprite = new Sprite(texture)
                {
                    Scale = new Vector2f(xScale, yScale),
                    Position = new Vector2f(posX, posY)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine($"\ne.ToString:\n {e}\n\n");
            }
        }

        public void Move()
        {
            var roundedSpriteX = (int) Math.Round(Sprite.Position.X);
            var roundedSpriteY = (int) Math.Round(Sprite.Position.Y);
            var roundedTargetX = (int) Math.Round(targetPosition.X);
            var roundedTargetY = (int) Math.Round(targetPosition.Y);

            if (roundedSpriteX < roundedTargetX)
                MoveBy(1, 0);
            else if (roundedSpriteX > roundedTargetX)
                MoveBy(-1, 0);
            if (roundedSpriteY < roundedTargetY)
                MoveBy(0, 1);
            else if (roundedSpriteY > roundedTargetY)
                MoveBy(0, -1);

            CheckSurroundings();

            Edges();

            if (debug)
            {
                Console.WriteLine($"rsx, rtx: {roundedSpriteX}, {roundedTargetX}");
                Console.WriteLine($"rsy, rty: {roundedSpriteY}, {roundedTargetY}");
            }

            if (roundedSpriteX == roundedTargetX && roundedSpriteY == roundedTargetY)
            {
                targetPosition = FindNewPosition();
            }
        }

        public void MoveBy(float x, float y)
        {
            Sprite.Position = new Vector2f(Sprite.Position.X + x, Sprite.Position.Y + y);
        }

        private void Edges()
        {
            var position = new Vector2f(Sprite.Position.X, Sprite.Position.Y);

            if (Sprite.Position.X > Program.WindowWidth)
            {
                position.X = 0;
            }
            else if (position.X < 0)
            {
                position.X = Program.WindowWidth;
            }

            if (position.Y > Program.WindowHeight)
            {
                position.Y = 0;
            }
            else if (position.Y < 0)
            {
                position.Y = Program.WindowHeight;
            }

            Sprite.Position = position;
        }

        private Vector2f FindNewPosition()
        {
            var rand = new Random();
            float x, y;

            do
            {
                x = Utilities.Map((float) rand.NextDouble(), 0, 1, Sprite.Position.X + Program.WindowWidth * 0.15f * -1f,
                    Sprite.Position.X + Program.WindowWidth * 0.15f);
            } while (x < 0 || x > Program.WindowWidth);

            do
            {
                y = Utilities.Map((float) rand.NextDouble(), 0, 1, Sprite.Position.Y + Program.WindowHeight * 0.15f * -1f,
                    Sprite.Position.Y + Program.WindowWidth * 0.15f);
            } while (y < 0 || y > Program.WindowHeight);

            return new Vector2f(x, y);
        }

        private void CheckSurroundings()
        {
            foreach (var foodSource in Program.FoodSources)
            {
                var xDiff = foodSource.Position.X - Sprite.Position.X;
                var yDiff = foodSource.Position.Y - Sprite.Position.Y;
                if (Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2)) < 50)
                {
                    targetPosition = foodSource.Position;
                }
            }
        }
    }
}