using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    class Submarine
    {
        public int Depth { get { return -position.y; } }
        public int HorizontalPosition { get { return this.position.x; } }

        private Coordinate position;
        private int aim;

        public Submarine(int startingX, int startingDepth, int startingAim)
        {
            this.position = new Coordinate() { x = startingX, y = -startingDepth };
            this.aim = startingAim;
        }

        public void MoveSub(Coordinate[] commands)
        {
            foreach(Coordinate command in commands)
            {
                if (command.x == 0)
                {
                    this.aim += command.y;
                }
                else
                {
                    // move horizontally
                    this.position.x += command.x;

                    // change depth
                    this.position.y += this.aim * command.x;
                }
            }
        }
    }
}
