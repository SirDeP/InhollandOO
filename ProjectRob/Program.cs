//using ProjectRobotica.Controller;
//using Linux.Bluetooth;
using static System.Net.Mime.MediaTypeNames;
using Unosquare.PiGpio;
using Unosquare.PiGpio.NativeEnums;
using Unosquare.PiGpio.NativeMethods;
using ProjectRobotica.GPIOFunctions;
using Microsoft.VisualBasic;

using Dapper;
using MySqlConnector;
using ProjectRob.Models;
using System.Net.Http.Json;
using System.Diagnostics;
using ProjectRob.GPIOFunctions;
using ProjectRobotica.Controller;


namespace ProjectRobotica
{
    internal class Program
    {
        static public CoordModel coords = new();
        //static private string url = "http://10.3.141.1:5000/api/Coords";
        static private HttpClient client = new();
        public static async Task Main(string[] args)
        {
            try
            {
                MotorControls motorControls = new MotorControls();
                motorControls.MotorsInit();
                var pin = SystemGpio.Bcm17;
                IO.GpioSetMode(pin, PinMode.Input);

                Sensor Sensor_Left_1 = new(04);
                Sensor Sensor_Left_2 = new(05);
                Sensor Sensor_Left_3 = new(15);
                Sensor Sensor_Right_1 = new(27);
                Sensor Sensor_Right_2 = new(24);
                Sensor Sensor_Right_3 = new(17);
                Sensor Sensor_Center = new(22);
                Sensor Sensor_Bumper_Left = new(20); // Bumperlinks
                Sensor Sensor_Bumper_Right = new(21); // Bumperrechts
                Sensor KILLBUTTON = new(26); // Exit button

                IO.GpioSetPullUpDown(Sensor_Center.Pin, GpioPullMode.Down);

                uint speed = 500000;
                coords.x = 0;
                coords.y = 0;
                var response = await client.GetAsync($"http://10.3.141.1:5000/api/Coords/Create/{coords.x}/{coords.y}");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Update succesvol.");
                }
                else
                {
                    Console.WriteLine($"Fout: {response.StatusCode}");
                    Console.WriteLine($"Response: {content}");
                }
                bool eersteMuurGevonden = false;
                bool controller = false;
                Direction direction = new Direction();
                direction = Direction.North;
                var timer = new Stopwatch();
                bool timerReadyToStart = true;
                PS4Controller pscontroller = new("/dev/input/js0", false);
                await client.DeleteAsync("http://10.3.141.1:5000/api/Coords");
                while (true)
                {
                    while (controller == true)
                    {
                        //Setup.GpioInitialise();
                        if (KILLBUTTON.State() == true)
                        {
                            // Stop Motors:
                            motorControls.DontMove();
                            controller = true;
                            await client.DeleteAsync("http://10.3.141.1:5000/api/Coords");
                        }
                        
                        if (await pscontroller.UpdateAsync())
                        {
                            if (pscontroller.state.GetAxisState(ControllerAxis.DPadY) == -32767)
                            {
                                motorControls.MotorsForward(speed);
                            }
                            else if (pscontroller.state.GetAxisState(ControllerAxis.DPadY) == 32767)
                            {
                                motorControls.MotorsBackward(speed);
                            }
                            else if (pscontroller.state.GetAxisState(ControllerAxis.DPadX) == -32767)
                            {
                                motorControls.MotorsLeft(speed);
                            }
                            else if (pscontroller.state.GetAxisState(ControllerAxis.DPadX) == 32767)
                            {
                                motorControls.MotorsRight(speed);
                            }
                            else if (pscontroller.state.GetButtonState(ControllerButtons.Circle) == true)
                            {
                                speed = 500000;
                            }
                            else if (pscontroller.state.GetButtonState(ControllerButtons.Triangle) == true)
                            {
                                speed = 750000;
                            }
                            else if (pscontroller.state.GetButtonState(ControllerButtons.Square) == true)
                            {
                                speed = 950000;
                            }
                            else if (pscontroller.state.GetButtonState(ControllerButtons.Cross) == true)
                            {
                                speed = 250000;
                            }

                            else if (pscontroller.state.GetButtonState(ControllerButtons.PSMenu) == true)
                            {
                                await client.DeleteAsync("http://10.3.141.1:5000/api/Coords");
                                eersteMuurGevonden = false;
                                controller = false;
                            }
                            else if (pscontroller.state.GetButtonState(ControllerButtons.Options) == true)
                            {
                                // Stop Motors:
                                motorControls.DontMove();
                                // Terminate GPIO I/O pins:
                                Setup.GpioTerminate();
                                throw new Exception("Exiting\n\n");
                            }
                            else
                            {
                                motorControls.DontMove();
                            }
                        }
                        
                    }
                    while (controller == false) // BUMPALGORITHM
                    {

                        if (KILLBUTTON.State() == true)
                        {
                            Console.WriteLine("1");
                            // Stop Motors:
                            motorControls.DontMove();
                            controller = true;
                            await client.DeleteAsync("http://10.3.141.1:5000/api/Coords");
                        }

                        if (eersteMuurGevonden == false)
                        {
                            motorControls.MotorsForward(500000);
                            // beide bumpers
                            if (Sensor_Bumper_Left.State() == true && Sensor_Bumper_Right.State() == true)
                            {
                                motorControls.MotorsBackward(500000);
                                Thread.Sleep(150);
                                motorControls.MotorsLeft(700000);
                                Thread.Sleep(700);
                                motorControls.DontMove();
                                eersteMuurGevonden = true;
                                await client.GetAsync($"http://10.3.141.1:5000/api/Coords/Create/{coords.x}/{coords.y}");
                                //break;
                            }
                            // alleen rechter bumper
                            else if (Sensor_Bumper_Left.State() == false && Sensor_Bumper_Right.State() == true)
                            {
                                motorControls.MotorsBackward(500000);
                                Thread.Sleep(150);
                                motorControls.MotorsLeft(700000);
                                Thread.Sleep(400);
                                motorControls.DontMove();
                                eersteMuurGevonden = true;
                                await client.GetAsync($"http://10.3.141.1:5000/api/Coords/Create/{coords.x}/{coords.y}");
                                //break;
                            }
                            // alleen left bumper
                            else if (Sensor_Bumper_Left.State() == true && Sensor_Bumper_Right.State() == false)
                            {
                                motorControls.MotorsBackward(500000);
                                Thread.Sleep(150);
                                motorControls.MotorsLeft(700000);
                                Thread.Sleep(1100);
                                motorControls.DontMove();
                                eersteMuurGevonden = true;
                                await client.GetAsync($"http://10.3.141.1:5000/api/Coords/Create/{coords.x}/{coords.y}");
                            }
                        }
                        else if (eersteMuurGevonden == true)
                        {

                            if (KILLBUTTON.State() == true)
                            {
                                Console.WriteLine("2");
                                // Stop Motors:
                                motorControls.DontMove();
                                controller = true;
                                await client.DeleteAsync("http://10.3.141.1:5000/api/Coords");
                            }
                            if (timer.Elapsed.TotalSeconds > 5)
                            {
                                motorControls.MotorsBackward(700000);
                                Thread.Sleep(350);
                                motorControls.MotorsLeft(800000);
                                Thread.Sleep(200);
                                motorControls.MotorsForward(800000);
                                Thread.Sleep(300);
                                timer.Reset();
                                timer.Start();
                            }
                            else if (Sensor_Bumper_Right.State() == true)
                            {
                                if (timerReadyToStart == false)
                                {
                                    timer.Stop();
                                    TimeSpan timeTaken = timer.Elapsed;
                                    Console.WriteLine(timeTaken.TotalSeconds);
                                    if (timeTaken.TotalSeconds >= 1.7 && Sensor_Right_2.State() != true)
                                    {
                                        direction += 1;
                                        if (direction > Direction.Left)
                                            direction = Direction.North;
                                        Console.WriteLine(direction);
                                    }
                                    else if (timeTaken.TotalSeconds < 0.2)
                                    {
                                        direction -= 1;
                                        if (direction < Direction.North)
                                            direction = Direction.Left;
                                        Console.WriteLine(direction);
                                    }
                                    timer.Reset();
                                    timerReadyToStart = true;
                                }

                                motorControls.MotorsBackward(700000);
                                Thread.Sleep(350);
                                motorControls.MotorsLeft(800000);
                                Thread.Sleep(200);
                                motorControls.MotorsForward(800000);
                                Thread.Sleep(300);
                                await Addcoord(direction);
                                // if tree met sensor
                                //await client.GetAsync($"http://10.3.141.1:5000/api/Coords/Create/{x}/{y}");
                            }
                            //else if (IO.GpioRead(Sensor_Bumper_Right) == true)

                            else
                            {
                                if (timerReadyToStart == true)
                                {
                                    timer.Start();
                                    timerReadyToStart = false;
                                }
                                motorControls.MotorsForwardCurve(700000, 300000);
                                //B: Run stuff you want timed
                            }

                        }
                    }
                }

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public static async Task Addcoord(Direction _direction)
        {

            if (_direction == Direction.Left)
            {
                coords.x--;
            }
            else if (_direction == Direction.Right)
            {
                coords.x++;
            }
            else if (_direction == Direction.North)
            {
                coords.y++;
            }
            else if (_direction == Direction.South)
            {
                coords.y--;
            }
            await client.GetAsync($"http://10.3.141.1:5000/api/Coords/Create/{coords.x}/{coords.y}");
        }
    }
}