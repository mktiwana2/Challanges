using System;
using System.Collections.Generic;
using System.Text;

namespace JellyfishClassLib
{
    class Jellyfish
    {
        private int x;
        private int y;
        private static readonly object putlock = new object();
        private static Jellyfish currentJellyfish = null;
        public int X   // property
        {
            get { return x; }
        }
        public int Y   // property
        {
            get { return y; }
        }
        private Directions Direction   // property
        {
            get;
            set;
        }

        //Singleton Object creation---------------------
        private Jellyfish()
        {
        }
        public static Jellyfish CreateJellyfish(int x, int y, Directions direction)
        {

            if (currentJellyfish == null)
            {
                lock (putlock)
                {
                    if (currentJellyfish == null)
                    {
                        currentJellyfish = new Jellyfish();
                    }

                }
            }
            currentJellyfish.x = x;
            currentJellyfish.y = y; 
            currentJellyfish.Direction=direction;
            return currentJellyfish;
        }

        //Methods-----------------------------------
        public void SetJellyfishPosition(int xNew, int yNew)
        {
            x = xNew;
            y = yNew;
        }
        public void SetJellyfishOrigin(int xOrigin, int yOrigin, Directions direction)
        {
            x = xOrigin;
            y = yOrigin;
            Direction = direction;
        }
        public void TurnJellyfishRight()
        {
            switch (Direction)
            {
                case Directions.East:
                    Direction = Directions.South;
                    break;
                case Directions.West:
                    Direction = Directions.North;
                    break;
                case Directions.North:
                    Direction = Directions.East;
                    break;
                case Directions.South:
                    Direction = Directions.West;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void TurnJellyfishLeft()
        {

            switch (Direction)
            {
                case Directions.East:
                    Direction = Directions.North;
                    break;
                case Directions.West:
                    Direction = Directions.South;
                    break;
                case Directions.North:
                    Direction = Directions.West;
                    break;
                case Directions.South:
                    Direction = Directions.East;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void MoveJellyfish()
        { 
            switch (Direction)
            {
                case Directions.East:
                    x = x + 1;
                    break;
                case Directions.West:
                    x = x - 1;
                    break;
                case Directions.North:
                    y = y + 1;
                    break;
                case Directions.South:
                    y = y - 1;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public Boolean OutOfTank(int maxX, int maxY)
        {
            if (X < 0 || X > maxX || Y < 0 || Y > maxY) return true;
            else return false;
        }
        public string GetJellyfishPosition()
        {
            return x + " " + y + " " + Direction.ToString().Substring(0,1);
        }

       
    }
    public enum Directions
    {
        East,
        West,
        North,
        South,
        Invalid
    }
}
