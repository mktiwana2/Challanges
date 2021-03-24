using System;
using System.Collections.Generic;

namespace JellyfishClassLib
{

    public class TrackJellyfish : ITrackJellyfish
    {


        //Variables--------------------------------
        private static readonly object putlock = new object();
        private static TrackJellyfish currentJellyfish = null;
        private Coordinates currentPosition = new Coordinates();
        private Coordinates tankSize = new Coordinates();
        private List<Coordinates> liLostFishCood = new List<Coordinates>() { };
        private Directions jfDirection;
        private string instructionString = "";
        private bool lost = false;

        //Singleton Object creation---------------------
        private TrackJellyfish()
        {
        }
        public static TrackJellyfish CreateJellyfish(Coordinates initialPosition, Coordinates maxTankSize, string inputInstructionString, string direction)
        {

            if (currentJellyfish == null)
            {
                lock (putlock)
                {
                    if (currentJellyfish == null)
                    {
                        currentJellyfish = new TrackJellyfish();
                    }

                }
            }

            currentJellyfish.currentPosition = initialPosition;
            currentJellyfish.tankSize = maxTankSize;
            currentJellyfish.instructionString = inputInstructionString;
            currentJellyfish.SetJellyfishDirection(direction);
            return currentJellyfish;

        }

        //Methods---------------------------------------
        private void SetJellyfishDirection(string direction)
        {
            switch (direction)
            {
                case "E":
                    jfDirection = Directions.E;
                    break;
                case "W":
                    jfDirection = Directions.W;
                    break;
                case "N":
                    jfDirection = Directions.N;
                    break;
                case "S":
                    jfDirection = Directions.S;
                    break;
                default:
                    Console.WriteLine("Error-Wrong Direction.Try again.");
                    jfDirection = Directions.Invalid;
                    break;
            }
        }
        Coordinates MoveJellyfish()
        {
            Coordinates newPosition = new Coordinates();
            newPosition = currentPosition;

            switch (jfDirection)
            {
                case Directions.E:
                    newPosition.X = newPosition.X + 1;
                    break;
                case Directions.W:
                    newPosition.X = newPosition.X - 1;
                    break;
                case Directions.N:
                    newPosition.Y = newPosition.Y + 1;
                    break;
                case Directions.S:
                    newPosition.Y = newPosition.Y - 1;
                    break;
                default:
                    throw new NotImplementedException();
            }
            if (newPosition.OutOfRange(tankSize.X, tankSize.Y))
            {

                if (liLostFishCood.Exists(obj => obj.X == currentPosition.X & obj.Y == currentPosition.Y))
                {
                    newPosition = currentPosition;
                }
                else
                {
                    lost = true;
                    liLostFishCood.Add(currentPosition);
                }
            }
            else currentPosition = newPosition;


            return newPosition;
        }
        public string GetJellyfishPosition()
        {
            if (jfDirection == Directions.Invalid) return "Error: Invalid Jellyfish direction..Try again.";

            Coordinates newPosition = new Coordinates();
            char[] charArr = instructionString.ToCharArray();

            foreach (char instruction in charArr)
            {
                if (instruction == 'F' & !lost)
                {
                    newPosition = MoveJellyfish();

                }
                else if (instruction == 'R')
                {
                    switch (jfDirection)
                    {
                        case Directions.E:
                            jfDirection = Directions.S;
                            break;
                        case Directions.W:
                            jfDirection = Directions.N;
                            break;
                        case Directions.N:
                            jfDirection = Directions.E;
                            break;
                        case Directions.S:
                            jfDirection = Directions.W;
                            break;
                        default:
                            throw new NotImplementedException();
                    }

                }
                else if (instruction == 'L')
                {
                    switch (jfDirection)
                    {
                        case Directions.E:
                            jfDirection = Directions.N;
                            break;
                        case Directions.W:
                            jfDirection = Directions.S;
                            break;
                        case Directions.N:
                            jfDirection = Directions.W;
                            break;
                        case Directions.S:
                            jfDirection = Directions.E;
                            break;
                        default:
                            throw new NotImplementedException();
                    }

                }
            }

            if (!lost) return currentPosition.X + " " + currentPosition.Y + " " + jfDirection;
            else
            {
                lost = false;
                return currentPosition.X + " " + currentPosition.Y + " " + jfDirection + " LOST";
            }


        }

        //enums---------------------------------
        enum Directions
        {
            E,
            W,
            N,
            S,
            Invalid
        }
    }


}
