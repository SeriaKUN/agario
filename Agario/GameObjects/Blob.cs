﻿using SFML.System;
using SFML.Graphics;
using Agario.States;

namespace Agario.GameObjects
{
    class Blob
    {
        public Vector2f position;
        public CircleShape shape;

        private float mass;
        private float radius;

        public float Mass
        {
            get { return mass; }
            set
            {
                radius = (float)Math.Sqrt(value / Math.PI) * 10;
                mass = value;
            }
        }
        public float Radius
        {
            get { return radius; }
            set
            {
                mass = (float)Math.PI * value * value / 10;
                radius = value;
            }
        }

        public Blob(Vector2f position, int mass, Color color)
        {
            this.position = position;
            Mass = mass;
            shape = new CircleShape(Radius);
            shape.FillColor = color;
        }

        public void Move(Vector2f move)
        {
            position += move;
        }

        public bool TryEat(Food food)
        {
            if (DistanceTo(food.position) > radius - Food.radius)
                return false;
            Mass++;
            shape.Radius = Radius;
            return true;
        }

        public bool TryEat(Blob player)
        {
            if (player == this)
                return false;

            if (player.mass > mass * 0.95)

                if (DistanceTo(player.position) > radius - player.radius)
                    return false;

            Mass += player.mass;
            shape.Radius = radius;

            return true;
        }

        public float DistanceTo(Vector2f otherPosition)
        {
            float differenceX = position.X - otherPosition.X;
            float differenceY = position.Y - otherPosition.Y;

            float distanceToOtherPosition = (float)Math.Sqrt(differenceX * differenceX + differenceY * differenceY);
            return distanceToOtherPosition;
        }
    }
}