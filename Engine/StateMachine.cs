﻿using System;

namespace Engine
{
    public class StateMachine
    {
        private long ticksBetweenFrames = TimeSpan.TicksPerSecond / 60;
        public long lastTimingTick = 0;

        State state;

        public long neededFPS
        {
            get
               => TimeSpan.TicksPerSecond / ticksBetweenFrames;
            set
               => ticksBetweenFrames = TimeSpan.TicksPerSecond / neededFPS;
        }

        public void SetState(State state)
        {
            this.state = state;
            this.state.Initialize();
        }

        public void Update()
        {
            state.Update();
        }

        public void Render()
        {
            state.Render();
        }

        public void Input()
        {
            state.Input();
        }

        public void Timing()
        {
            if (DateTime.Now.Ticks - lastTimingTick < TimeSpan.TicksPerSecond / neededFPS)
            {
                System.Threading.Thread.Sleep(100);//(int)(ticksBetweenFrames - DateTime.Now.Ticks - lastTimingTick));
            }
            lastTimingTick = DateTime.Now.Ticks;
        }
    }
}
