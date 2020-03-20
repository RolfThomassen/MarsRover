using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Modules
{
    class Mars
    {
        public int MaxX;
        public int MaxY;
        public List<Rover> Rovers = new List<Rover>();

        public Mars()
        {
        }

        public Mars(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }
    }
}
