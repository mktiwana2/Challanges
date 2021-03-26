using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JellyfishClassLib;

namespace JellyFishUnitTest
{
    [TestClass]
    public class Jellyfish_TrackTest
    {
        [TestMethod]
        public void Jellyfish_TrackJellyfish_TrackTest()
        {
            int initialPositionX = 0;
            int initialPositionY = 0;
            string instructionString = "";
            string direction = "";
            FishTank fishTank = new FishTank();
            IRemoteControl remote = new RemoteControl();

            fishTank.SetTankSize(5, 3);
            initialPositionX = 3;
            initialPositionY = 2;
            instructionString = "FRRFLLFFRRFLL";
            direction = "N";

            remote.SetJellyfishOrigin(initialPositionX, initialPositionY, direction);
            string val = remote.GetJellyfishFinalPosition(fishTank, instructionString);

            initialPositionX = 0;
            initialPositionY = 3;
            instructionString = "LLFFFLFLFL";
            direction = "W";


            remote.SetJellyfishOrigin(initialPositionX, initialPositionY, direction);

            Assert.AreEqual("2 3 S", remote.GetJellyfishFinalPosition(fishTank, instructionString));

        }

    }
}
