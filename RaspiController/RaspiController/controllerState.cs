using System;
namespace XboxControllerTest
{
    /// <summary>
    /// Abstraction used by the linuxXboxController to check the indivdual state of each button and axis between updates.
    /// </summary>
    public class controllerState
    {
        public bool[] buttons = new bool[0x0B];
        public short[] axis = new short[0x09];

        //Get the state of a button via enumerator.
        public bool getButtonState(xButtons button)
        {
            bool output = false;
            try
            {
                output = buttons[(byte)button];
            }
            catch { }
            return output;
        }

        //Get the state of an axis via enumerator.
        public short getAxisState(xEvents _axis)
        {
            short output = 0;
            try
            {
                output = axis[(byte)_axis];
            }
            catch { }
            return output;
        }

        public controllerState()
        {

        }
    }
}
