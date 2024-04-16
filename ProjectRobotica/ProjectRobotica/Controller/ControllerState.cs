using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRobotica.Controller
{
    internal class ControllerState
    {

        public bool[] buttons = new bool[0x0D];
        public short[] axis = new short[0x08];

        public ControllerState()
        {
            axis[2] = -32767; // Preset triggers released
            axis[5] = -32767;
        }

        public bool GetButtonState(ControllerButtons button)
        {
            return buttons[(byte)button];
        }

        public short GetAxisState(ControllerAxis Axis)
        {
            return axis[(byte)Axis];
        }

        public void Print()
        {
            for (int i = 0; i < axis.Length; i++)
            {
                string temp = string.Format(" a{0}:{1}", Convert.ToString(i), Convert.ToString(axis[i]).PadRight(6));
                Console.Write(temp);
            }
            for (int i = 0; i < buttons.Length; i++)
            {
                Console.Write(" b" + i + ":" + Convert.ToSByte(buttons[i])); // Enum.GetName(typeof(ControllerButtons), i)
            }

            Console.Write("\r");

        }
    }
}
