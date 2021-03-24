using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JellyfishLib;

namespace JellyfishUnitTests
{
    [TestClass]
    public class Jellyfish_Scent
    {
        [TestMethod]
       

        public void Jellyfish_TrackJellyfish_ScentTest()
        {
            Coordinates tankSize = new Coordinates();
            Coordinates initialPosition = new Coordinates();
            string instructionString = "";
            string direction = "";

            tankSize.X = 5;
            tankSize.Y = 3;
            initialPosition.X = 3;
            initialPosition.Y = 2;
            instructionString = "FRRFLLFFRRFLL";
            direction = "N";

            ITrackJellyfish trackJellyFish = TrackJellyfish.CreateJellyfish(initialPosition, tankSize, instructionString, direction);
            string val = trackJellyFish.GetJellyfishPosition();

            initialPosition.X = 0;
            initialPosition.Y = 3;
            instructionString = "LLFFFLFLFL";
            direction = "W";

            ITrackJellyfish trackJellyFish2 = TrackJellyfish.CreateJellyfish(initialPosition, tankSize, instructionString, direction);

            Assert.AreEqual("2 3 S", trackJellyFish2.GetJellyfishPosition());

        }
    }
}
