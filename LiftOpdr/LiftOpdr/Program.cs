using System.Data;
using System.Runtime.CompilerServices;

namespace LiftOpdr
{
    internal class Program
    {
        private static LiftSystem _system = new LiftSystem(4, 2);
        private static InsidePanel? _panel = null;

        static void Main(string[] args)
        {
            string? command = string.Empty;
            while (command != "q")
            {
                Console.Write("Enter command: ");
                command = Console.ReadLine();
                switch (command)
                {
                    // Next cycle
                    case "n":
                    case "next":
                        Update();
                        break;

                    // Continue until all lifts are idle
                    case "ci":
                    case "continue idle":
                        while (!_system.LiftsIdle())
                        {
                            Update();
                        }
                        break;

                    // Continue until a door is open
                    case "cd":
                    case "continue door":
                        while (_panel == null)
                        {
                            Update();
                        }
                        break;

                    // Request lift from outside
                    case "ro":
                    case "request outside":
                        Console.Write("Enter current floor: ");
                        int currentFloor = Convert.ToInt32(Console.ReadLine());
                        _system.GetOutsidePanel(currentFloor).RequestLift();
                        break;

                    // Request floor from inside
                    case "ri":
                    case "request inside":
                        if (_panel == null)
                        {
                            Console.WriteLine("There is currently no lift open.");
                            break;
                        }

                        Console.Write("Enter floor: ");
                        int floor = Convert.ToInt32(Console.ReadLine());
                        _panel.RequestFloor(floor);
                        break;

                }
            }
        }
        private static void Update()
        {
            Console.Clear();
            _system.FindLifts();
            _system.UpdateLifts();
            _system.PrintLifts();
            _panel = _system.GetOpenLift();
        }

    }
}
