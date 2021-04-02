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
        private float xScale = 0.05f;
        private float yScale = 0.05f;

        public Ant()
        {
            Texture texture =
                new Texture("E:\\OneDrive - Tennessee Tech University\\Programming\\C#\\Ants\\Ants\\ant.png");

            Sprite = new Sprite(texture);
            Sprite.Scale = new Vector2f(xScale, yScale);

            var rand = new Random();
            var randX = rand.Next(200, 600);
            var randY = rand.Next(200, 400);
            Console.WriteLine($"{randX}, {randY}");
            Sprite.Position = new Vector2f(randX, randY);
        }

        public Ant(int posX, int posY)
        {
            try
            {
                Texture texture =
                    new Texture("E:\\OneDrive - Tennessee Tech University\\Programming\\C#\\Ants\\Ants\\ant.png");

                Sprite = new Sprite(texture);
                Sprite.Scale = new Vector2f(xScale, yScale);
                Sprite.Position = new Vector2f(posX, posY);
            }
            catch (Exception e)
            {
                Console.WriteLine($"\ne.ToString:\n {e.ToString()}\n\n");
            }
        }

        public void Move()
        {
            var rand = new Random();
            Sprite.Position = new Vector2f(Sprite.Position.X + rand.Next(-5, 6), Sprite.Position.Y + rand.Next(-5, 6));
        }
    }
}