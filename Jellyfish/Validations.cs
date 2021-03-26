using System;
using JellyfishClassLib;

namespace Jellyfish
{
    class Validations
    {
        public bool MaxCoordinatesOK(int X, int Y)
        {
            if (X > 60 || Y > 60)
            {
                Console.WriteLine("Error-Invalid Coordinates...Try again.");
                return false;
            }
            else return true;
        }
        public bool InstructionsOK(String instructions)
        {
            if (instructions.Length > 100)
            {
                Console.WriteLine("Error-Too long instructions...Try again.");
                return false;
            }
            else return true;
        }
    }
}
