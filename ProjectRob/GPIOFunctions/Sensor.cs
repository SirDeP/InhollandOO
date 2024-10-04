using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unosquare.PiGpio.NativeEnums;
using Unosquare.PiGpio.NativeMethods;

namespace ProjectRob.GPIOFunctions
{
    internal class Sensor
    {
        public SystemGpio Pin { get; }
        public Sensor(int pin) 
        {
            this.Pin = (SystemGpio)pin;
            IO.GpioSetMode(this.Pin, PinMode.Input);
        }

        public bool State()
        {
            bool state = IO.GpioRead(this.Pin);
            return state;
        }
    }
}
