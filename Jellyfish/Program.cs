using System;
using JellyfishLib;

namespace Jellyfish
{
    class Program
    {
        static void Main(string[] args)
        {


            Coordinates tankSize = new Coordinates();
            Coordinates initialPosition = new Coordinates();
            string instructionString = "";
            string direction = "";
            Validations validate = new Validations();

        starting:
            Console.WriteLine("Please Enter the Upper-Right Corner Coordinates of Tank.");
            string inputTankSize = Console.ReadLine();
            try
            {
                tankSize.X = Convert.ToInt32(inputTankSize.Substring(0, inputTankSize.IndexOf(" ")));
                tankSize.Y = Convert.ToInt32(inputTankSize.Substring(inputTankSize.IndexOf(" ") + 1));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error-Wrong input Format.Try again.\n");
                goto starting;
            }

            if (!validate.MaxCoordinatesOK(tankSize)) goto starting;




            enterPosition:
            Console.WriteLine("\nPlease Enter JellyFish Position and Instructions:-");
            string inputLine = Console.ReadLine();
            try
            {
                string[] subStr = inputLine.Split(" ");
                initialPosition.X = Convert.ToInt32(subStr[0]);
                initialPosition.Y = Convert.ToInt32(subStr[1]);
                direction = subStr[2];
                instructionString = subStr[3];
            }
            catch (Exception e)
            {
                Console.WriteLine("Error-Wrong input Format.Try again.");
                goto enterPosition;
            }


            if (!validate.InstructionsOK(instructionString)) goto enterPosition;
            if (!validate.MaxCoordinatesOK(initialPosition)) goto enterPosition;


            ITrackJellyfish trackJellyFish = TrackJellyfish.CreateJellyfish(initialPosition, tankSize, instructionString, direction);

            Console.WriteLine(trackJellyFish.GetJellyfishPosition());

            goto enterPosition;
        }

    }
}

