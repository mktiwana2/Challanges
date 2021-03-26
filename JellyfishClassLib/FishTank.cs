using System;
using System.Collections.Generic;
using System.Text;

namespace JellyfishClassLib
{
    public class FishTank
    {
        private int width;
        private int height;
        public int Width   // property
        {
            get { return width; }
        }
        public int Height   // property
        {
            get { return height; }
        }

        public void SetTankSize(int x, int y)
        {
            width = x;
            height = y;
        }
    }
}
