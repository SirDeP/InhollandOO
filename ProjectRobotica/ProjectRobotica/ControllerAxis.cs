using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRobotica
{
    internal enum ControllerAxis
    {
        LeftY = 0x01,
        LeftX = 0x00,
        LeftTrigger = 0x02,
        RightY = 0x04,
        RightX = 0x03,
        RightTrigger = 0x05,
        DPadX = 0x06,
        DPadY = 0x07
    }
}
