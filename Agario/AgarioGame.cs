﻿using Engine;
using Agario.States;
using SFML.Window;
using SFML.Graphics;

namespace /*it's a me, */Agario
{
    class AgarioGame : Game
    {
        public static Random random = new Random();
        public static RenderWindow window = new RenderWindow(new VideoMode(750, 750), "Agario");

        protected override void SetStartingState()
        {
            SetState(new Playing());
        }
    }
}
