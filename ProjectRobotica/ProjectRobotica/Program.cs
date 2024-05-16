using ProjectRobotica.Controller;
//using Linux.Bluetooth;
using static System.Net.Mime.MediaTypeNames;
using Unosquare.PiGpio;
using Unosquare.PiGpio.NativeEnums;
using Unosquare.PiGpio.NativeMethods;
using ProjectRobotica.GPIOFunctions;


namespace ProjectRobotica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MotorControls motorControls = new MotorControls();
                PS4Controller controller = new("/dev/input/js0", false);
                motorControls.MotorsInit();
                //PS4Controller controller = new("/dev/input/js0", false);
                var pin = SystemGpio.Bcm17;
                IO.GpioSetMode(pin, PinMode.Input);


                Console.WriteLine("Hello, World!");
                Console.ReadLine();
                Setup.GpioInitialise();
                var pin18 = SystemGpio.Bcm18;
                var pin12 = SystemGpio.Bcm12;


                var pin5 = SystemGpio.Bcm05;
                var pin6 = SystemGpio.Bcm06;
                var pin4 = SystemGpio.Bcm04;
                var pin14 = SystemGpio.Bcm14;
                var pin15 = SystemGpio.Bcm15;
                var pin17 = SystemGpio.Bcm17;
                var pin27 = SystemGpio.Bcm27;
                var pin22 = SystemGpio.Bcm22;
                var pin23 = SystemGpio.Bcm23;
                var pin24 = SystemGpio.Bcm24;

                var pin16 = SystemGpio.Bcm16;

                IO.GpioSetMode(pin5, PinMode.Input);
                //IO.GpioSetMode(pin6, PinMode.Input);
                IO.GpioSetMode(pin4, PinMode.Input);
                //IO.GpioSetMode(pin14, PinMode.Input);
                IO.GpioSetMode(pin15, PinMode.Input);
                IO.GpioSetMode(pin17, PinMode.Input);
                IO.GpioSetMode(pin27, PinMode.Input);
                IO.GpioSetMode(pin22, PinMode.Input);
                //IO.GpioSetMode(pin23, PinMode.Input);
                IO.GpioSetMode(pin24, PinMode.Input);
                IO.GpioSetPullUpDown(pin22, GpioPullMode.Down);
                //IO.GpioSetPullUpDown(pin2, GpioPullMode.Down);

                IO.GpioSetMode(pin16, PinMode.Input);

                SystemGpio[] systemGpio =
                [
                    pin5, // 0 x
                    //pin6, // 1 //
                    pin4, // 2 x
                    //pin14,// 3 // 
                    pin15,// 4 x
                    pin17,// 5 x 
                    pin27,// 6 x
                    pin22,// 7 x
                    //pin23,// 8 //
                    pin24,// 9 x
                    pin16,
                ];

                uint speed = 500000;
                while (true)
                {
                    //if (IO.GpioRead(pin))
                    //{
                    //    Console.Write("Y\r");
                    //}else
                    //{
                    //    Console.Write("N\r");
                    //}
                    for (int i = 0; i < systemGpio.Length; i++)
                    {
                        string temp = string.Format(" a{0}:{1}", Convert.ToString(i), Convert.ToString(IO.GpioRead(systemGpio[i])).PadRight(6));
                        Console.Write(temp);
                    }
                    Console.Write("\r");


                    if (controller.Update())
                    {
                        //Standard = 32767
                        //controller.Print();
                        if (controller.state.GetAxisState(ControllerAxis.DPadY) == -32767)
                        {
                            motorControls.MotorsForward(speed);
                        }
                        else if (controller.state.GetAxisState(ControllerAxis.DPadY) == 32767)
                        {
                            motorControls.MotorsBackward(speed);
                        }
                        else if (controller.state.GetAxisState(ControllerAxis.DPadX) == -32767)
                        {
                            motorControls.MotorsLeft(speed);
                        }
                        else if (controller.state.GetAxisState(ControllerAxis.DPadX) == 32767)
                        {
                            motorControls.MotorsRight(speed);
                        }
                        else if (controller.state.GetButtonState(ControllerButtons.Circle) == true)
                        {
                            speed = 500000;
                        }
                        else if (controller.state.GetButtonState(ControllerButtons.Triangle) == true)
                        {
                            speed = 750000;
                        }
                        else if (controller.state.GetButtonState(ControllerButtons.Square) == true)
                        {
                            speed = 950000;
                        }
                        else if (controller.state.GetButtonState(ControllerButtons.Cross) == true)
                        {
                            speed = 250000;
                        }

                        else if (controller.state.GetButtonState(ControllerButtons.PSMenu) == true)
                        {
                            Setup.GpioTerminate();
                            throw new Exception("Exit");
                        }
                        else
                        {
                            motorControls.DontMove();
                        }


                        //    //Uncomment the code below to have raw bytes printed to console after each update is detected

                        //    //Convert the bytes to a string and print them
                        //    string hex = BitConverter.ToString(controller.deviceBytes.ToArray());
                        //    Console.WriteLine(hex);
                    }
                    //Console.WriteLine(controller.state.GetButtonState(ControllerButtons.PSMenu));


                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
