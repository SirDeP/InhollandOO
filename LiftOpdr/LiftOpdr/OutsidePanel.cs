using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftOpdr
{
    public class OutsidePanel
    {
        private readonly LiftSystem _system;
        public int Floor { get; }

        public OutsidePanel(LiftSystem system, int floor)
        {
            _system = system;
            Floor = floor;
        }

        public void RequestLift()
        {
            _system.RequestLift(Floor);
        }

        public void Emergency()
        {
            _system.Emergency();
        }
    }
}
