﻿using SFML.System;
using SFML.Graphics;

namespace Agario
{
    class Food
    {
        Vector2f position;
        Color color;

        public Food(Vector2f position, Color color)
        {
            this.position = position;
            this.color = color;
        }
    }
}