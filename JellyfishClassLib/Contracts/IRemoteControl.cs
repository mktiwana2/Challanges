using System;
using System.Collections.Generic;
using System.Text;

namespace JellyfishClassLib
{
    public interface IRemoteControl
    {
        void SetJellyfishOrigin(int x, int y, string direction);
        string GetJellyfishFinalPosition(FishTank fishTank, string instructionString);
    }
}
