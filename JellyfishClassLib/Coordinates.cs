using System;
using System.Collections.Generic;
using System.Text;

namespace JellyfishClassLib
{


    public struct Coordinates
    {

        public int X   // property
        {
            get;
            set;
        }
        public int Y   // property
        {
            get;
            set;
        }
        public Boolean OutOfRange(int maxX, int maxY)
        {
            if (X < 0 || X > maxX || Y < 0 || Y > maxY) return true;
            else return false;
        }

    }
}
