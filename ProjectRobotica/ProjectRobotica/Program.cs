using System.ComponentModel.Design;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectRobotica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PS4Controller controller = new("/dev/input/js0", true);
            PS4Controller controller = new("/dev/input/js0", false);
            while (true)
            {
                //if (controller.update())
                //{
                //    //Uncomment the code below to have raw bytes printed to console after each update is detected

                //    //Convert the bytes to a string and print them
                //    string hex = BitConverter.ToString(controller.deviceBytes.ToArray());
                //    Console.WriteLine(hex);
                //}
                controller.update();
                //Console.WriteLine(controller.state.GetButtonState(ControllerButtons.PSMenu));
                controller.Print();
            }
        }
    }
}
