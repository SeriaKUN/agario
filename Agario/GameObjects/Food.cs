﻿using System;
using SFML.System;
using SFML.Graphics;

namespace Agario.GameObjects
{
    class Food
    {
        public Vector2f position { get; private set; }
        public CircleShape shape { get; private set; }
        public const float radius = 5;

        public Food(Vector2f position, Color color)
        {
            this.position = position;
            shape = new CircleShape(radius);
            shape.FillColor = color;
            shape.Position = position;
        }
    }
}