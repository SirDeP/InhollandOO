using QueueOpdr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftOpdr
{
    public enum RequestResult
    { 
        Ok,
        InvalidFloor,
        Locked
    }

    public class LiftSystem
    {
        public int FloorCount { get; }
        public bool Locked { get; private set; } = false;
        public List<OutsidePanel> Panels { get; } = new List<OutsidePanel>();

        private readonly List<Lift> _lifts = new List<Lift>();
        private readonly Queue _requestQueue = new Queue();

        public LiftSystem(int floorCount, int liftCount)
        {
            FloorCount = floorCount;
            for (int i = 0; i < floorCount; i++)
            { 
                Panels.Add(new OutsidePanel(this, i));
            }

            for (int i = 0; i < liftCount; i++)
            {
                _lifts.Add(new Lift(i));
            }
        }

        public void UpdateLifts()
        {
            foreach (var lift in _lifts) 
            {
                lift.Update();
            }
        }

        public RequestResult RequestLift(int currentFloor)
        {
            if (currentFloor > FloorCount || currentFloor < 0)
                return RequestResult.InvalidFloor;

            if (Locked)
                return RequestResult.Locked;

            _requestQueue.Enqueue(currentFloor);
            return RequestResult.Ok;
        }

        public void FindLifts()
        {
            int? currentFloor = _requestQueue.Head?.Data;
            if (currentFloor == null)
                return;

            var availableLifts = _lifts.Where(lift => lift.Direction == Direction.Idle && lift.QueueEmpty());
            var closestLift = availableLifts.FirstOrDefault();

            if (closestLift == null)
            {
                Console.WriteLine($"Floor {currentFloor} is waiting for a lift...");
                return;
            }

            int difference = Math.Abs(closestLift.CurrentFloor - currentFloor.Value);
            foreach (var lift in availableLifts)
            {
                int currentDifference = Math.Abs(currentFloor.Value - lift.CurrentFloor);

                if (currentDifference < difference)
                {
                    closestLift = lift;
                    difference = currentDifference;
                }
            }

            Console.WriteLine($"Lift ID {closestLift.Id} is going to floor {currentFloor}");
            closestLift.RequestFloor(currentFloor.Value);
            _requestQueue.Dequeue();
        }

        public void Emergency()
        {
            Locked = true;
            foreach (var lift in _lifts)
            {
                lift.RequestFloor(0);
            }
        }

        public bool LiftsIdle()
        {
            foreach (var lift in _lifts)
            {
                if (!lift.QueueEmpty())
                    return false;
            }

            return true;
        }

        public InsidePanel? GetOpenLift()
        {
            foreach (var lift in _lifts)
            {
                if (lift.Door == Door.Open)
                    return lift.Panel;
            }

            return null;
        }

        public OutsidePanel GetOutsidePanel(int floor)
        {
            return Panels[floor];
        }

        public void PrintLifts()
        {
            foreach (var lift in _lifts)
            {
                Console.WriteLine($"Lift ID: {lift.Id}");
                Console.WriteLine($"    - Current Floor: {lift.CurrentFloor}");
                if (lift.QueueEmpty())
                    Console.WriteLine($"    - Status: No destination");
                else
                    Console.WriteLine($"    - Status: {lift.CurrentFloor} -> {lift.Destination}");
                Console.WriteLine($"    - Door: {lift.Door}");
                Console.WriteLine($"    - Direction: {lift.Direction}\n");
            }
        }
    }
}
