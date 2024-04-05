using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftOpdr
{
    public class InsidePanel
    {
        private readonly Lift _lift;

        public InsidePanel(Lift lift)
        {
            _lift = lift;
        }

        public void RequestFloor(int floor)
        { 
            Console.WriteLine($"Lift {_lift.Id} got a request for floor {floor}.");
            _lift.RequestFloor(floor);
        }
    }
}
