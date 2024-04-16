using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRobotica.Controller
{
    internal enum ControllerAxis
    {
        LeftX           = 0x00,
        LeftY           = 0x01,
        LeftTrigger     = 0x02,
        RightX          = 0x03,
        RightY          = 0x04,
        RightTrigger    = 0x05,
        DPadX           = 0x06,
        DPadY           = 0x07
    }
}
