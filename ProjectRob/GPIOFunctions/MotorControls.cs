using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Unosquare.PiGpio.NativeEnums;
using Unosquare.PiGpio.NativeMethods;

namespace ProjectRobotica.GPIOFunctions
{
    internal class MotorControls
    {
        private Unosquare.PiGpio.NativeEnums.SystemGpio pin18 = SystemGpio.Bcm18;
        private Unosquare.PiGpio.NativeEnums.SystemGpio pin12 = SystemGpio.Bcm12;
        private Unosquare.PiGpio.NativeEnums.SystemGpio pin13 = SystemGpio.Bcm13;
        private Unosquare.PiGpio.NativeEnums.SystemGpio pin19 = SystemGpio.Bcm19;
        public void MotorsInit()
        {
            Setup.GpioInitialise();
            IO.GpioSetMode(pin18, PinMode.Alt5);
            IO.GpioSetMode(pin12, PinMode.Alt0);
            IO.GpioSetMode(pin19, PinMode.Alt5);
            IO.GpioSetMode(pin13, PinMode.Alt0);
        }
        public void MotorsForward(uint speed)
        {
            IO.GpioWrite(pin13, false);
            IO.GpioWrite(pin12, false);
            Pwm.GpioHardwarePwm(pin18, 1000, speed);
            Pwm.GpioHardwarePwm(pin19, 1000, speed);
        }

        public void MotorsBackward(uint speed)
        {
            IO.GpioWrite(pin18, false);
            IO.GpioWrite(pin19, false);
            Pwm.GpioHardwarePwm(pin12, 1000, speed);
            Pwm.GpioHardwarePwm(pin13, 1000, speed);
        }
        public void MotorsLeft(uint speed)
        {
            IO.GpioWrite(pin13, false);
            IO.GpioWrite(pin18, false);
            Pwm.GpioHardwarePwm(pin19, 1000, speed);
            Pwm.GpioHardwarePwm(pin12, 1000, speed);
        }
        public void MotorsRight(uint speed)
        {
            IO.GpioWrite(pin12, false);
            IO.GpioWrite(pin19, false);
            Pwm.GpioHardwarePwm(pin18, 1000, speed);
            Pwm.GpioHardwarePwm(pin13, 1000, speed);
        }
        public void MotorsForwardCurve(uint speed1, uint speed2)
        {
            IO.GpioWrite(pin13, false);
            IO.GpioWrite(pin12, false);
            Pwm.GpioHardwarePwm(pin18, 1000, speed1);
            Pwm.GpioHardwarePwm(pin19, 1000, speed2);
        }
        public void DontMove()
        {
            IO.GpioWrite(pin12, false);
            IO.GpioWrite(pin18, false);
            IO.GpioWrite(pin13, false);
            IO.GpioWrite(pin19, false);
        }
    }
}