

using System.Formats.Asn1;
using System.Runtime.InteropServices;
using Unosquare.PiGpio;
using Unosquare.PiGpio.NativeEnums;
using Unosquare.PiGpio.NativeMethods;

namespace PrjRobotica_Motors
{

    internal class Program
    {
        //[DllImport("libpigpio.so", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gpioHardwarePWM")]
        //private static extern ResultCode GpioHardwarePWM(UserGpio userGpio, uint PWMFreq, uint PWMDuty);
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.ReadLine();
            Setup.GpioInitialise();
            var pin18 = SystemGpio.Bcm18;
            var pin12 = SystemGpio.Bcm12;


            var pin2 = SystemGpio.Bcm02;
            var pin3 = SystemGpio.Bcm03;
            var pin4 = SystemGpio.Bcm04;
            var pin14 = SystemGpio.Bcm14;
            var pin15 = SystemGpio.Bcm15;
            var pin17 = SystemGpio.Bcm17;
            var pin27 = SystemGpio.Bcm27;
            var pin22 = SystemGpio.Bcm22;
            var pin23 = SystemGpio.Bcm23;
            var pin24 = SystemGpio.Bcm24;

            IO.GpioSetMode(pin2 , PinMode.Input);
            IO.GpioSetMode(pin3 , PinMode.Input);
            IO.GpioSetMode(pin4 , PinMode.Input);
            IO.GpioSetMode(pin14, PinMode.Input);
            IO.GpioSetMode(pin15, PinMode.Input);
            IO.GpioSetMode(pin17, PinMode.Input);
            IO.GpioSetMode(pin27, PinMode.Input);
            IO.GpioSetMode(pin22, PinMode.Input);
            IO.GpioSetMode(pin23, PinMode.Input);
            IO.GpioSetMode(pin24, PinMode.Input);

            
            Setup.GpioTerminate();
        }
    }
}
