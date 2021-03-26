using System;
using System.Collections.Generic;
using System.Text;

namespace JellyfishClassLib
{
    public class JellyfishScent
    {
        private int x;
        private int y;
        public JellyfishScent(int scentX, int scentY)
        {
            x = scentX;
            y = scentY;
        }
        public int X   // property
        {
            get { return x; }
        }
        public int Y   // property
        {
            get { return y; }
        }
    }
}
