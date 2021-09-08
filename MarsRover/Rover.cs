using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        private int direction = 0;
        public int Direction
        {
            get
            {
                return direction;
            }
            set
            {
                direction = value;
                if (direction < 0)
                    direction = 3;
                else
                direction %= 4;
            }
        }

    }


}
