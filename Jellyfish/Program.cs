using System;
using JellyfishClassLib;

namespace Jellyfish
{
    class Program
    {
        static void Main(string[] args)
        {

            int initialPositionX = 0;
            int initialPositionY = 0;
            string instructionString = "";
            string direction = "";
            Validations validate = new Validations();
            IRemoteControl remote = new RemoteControl();
            FishTank fishTank = new FishTank();

        starting:
            Console.WriteLine("Please Enter the Upper-Right Corner Coordinates of Tank.");
            string inputTankSize = Console.ReadLine();
            try
            {
                fishTank.SetTankSize( Convert.ToInt32(inputTankSize.Substring(0, inputTankSize.IndexOf(" "))),Convert.ToInt32(inputTankSize.Substring(inputTankSize.IndexOf(" ") + 1)));            }
            catch (Exception e)
            {
                Console.WriteLine("Error-Wrong input Format.Try again.\n");
                goto starting;
            }

            if (!validate.MaxCoordinatesOK(fishTank.Width,fishTank.Height)) goto starting;




            enterPosition:
            Console.WriteLine("\nPlease Enter JellyFish Position and Instructions:-");
            string inputLine = Console.ReadLine();
            try
            {
                string[] subStr = inputLine.Split(" ");
                initialPositionX = Convert.ToInt32(subStr[0]);
                initialPositionY = Convert.ToInt32(subStr[1]);
                direction = subStr[2];
                instructionString = subStr[3];
            }
            catch (Exception e)
            {
                Console.WriteLine("Error-Wrong input Format.Try again.");
                goto enterPosition;
            }


            if (!validate.InstructionsOK(instructionString)) goto enterPosition;
            if (!validate.MaxCoordinatesOK(initialPositionX, initialPositionY)) goto enterPosition;


            remote.SetJellyfishOrigin(initialPositionX, initialPositionY , direction);

            Console.WriteLine(remote.GetJellyfishFinalPosition(fishTank, instructionString));

            goto enterPosition;
        }

    }
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

