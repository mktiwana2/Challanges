using System;
using System.Collections.Generic;
using System.Text;

namespace JellyfishClassLib
{
    public class RemoteControl : IRemoteControl
    {
        //variables--------------
        Jellyfish jellyfish;
        bool lostJellyfish = false;
        private List<JellyfishScent> liJellyfishScents = new List<JellyfishScent>() { };

        //methods--------------------
        public void SetJellyfishOrigin(int x,int y, string direction)
        {
            jellyfish = Jellyfish.CreateJellyfish(x,y, GetDirection(direction));
            lostJellyfish = false;
        }
        private Directions GetDirection(string direction)
        {
            Directions jfDirection;
            switch (direction)
            {
                case "E":
                    jfDirection = Directions.East;
                    break;
                case "W":
                    jfDirection = Directions.West;
                    break;
                case "N":
                    jfDirection = Directions.North;
                    break;
                case "S":
                    jfDirection = Directions.South;
                    break;
                default:
                    Console.WriteLine("Error-Wrong Direction.Try again.");
                    jfDirection = Directions.Invalid;
                    break;
            }
            return jfDirection;
        }

        public string GetJellyfishFinalPosition(FishTank fishTank, string instructionString)
        {
            //if (jellyfish.Direction == Directions.Invalid) return "Error: Invalid Jellyfish direction..Try again.";
             
            char[] charArr = instructionString.ToCharArray();

            foreach (char instruction in charArr)
            {
                
                if (instruction == 'R')
                {
                    jellyfish.TurnJellyfishRight();

                }
                else if (instruction == 'L')
                {
                    jellyfish.TurnJellyfishLeft();

                }
                else if (instruction == 'F' & !lostJellyfish)
                {

                    int oldPositionX = jellyfish.X;
                    int oldPositionY = jellyfish.Y;

                    jellyfish.MoveJellyfish();

                    if (jellyfish.OutOfTank(fishTank.Width, fishTank.Height))
                    {
                        jellyfish.SetJellyfishPosition(oldPositionX, oldPositionY); 

                        if (!liJellyfishScents.Exists(obj => obj.X == jellyfish.X & obj.Y == jellyfish.Y))
                        {
                            lostJellyfish = true;
                            JellyfishScent scent = new JellyfishScent(jellyfish.X, jellyfish.Y);
                            liJellyfishScents.Add(scent);
                        }
                    }
                }
            }

            string finalPosition = jellyfish.GetJellyfishPosition();

            if (!lostJellyfish) return finalPosition;
            else return finalPosition + " LOST";
            


        }

    }
}
