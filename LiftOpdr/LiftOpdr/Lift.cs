using QueueOpdr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftOpdr
{
    public enum Door
    { 
        Closed,
        Open
    }

    public enum Direction
    { 
        Idle,
        Up,
        Down
    }

    public class Lift
    {
        public int Id { get; }
        public int CurrentFloor { get; private set; }
        public Door Door { get; private set; }
        public Direction Direction { get; private set; }
        public int? Destination { get => _floorQueue.Head?.Data; }
        public InsidePanel Panel { get; }


        private Queue _floorQueue = new Queue();

        public Lift(int id)
        {
            Id = id;
            Panel = new InsidePanel(this);
        }

        public void Update()
        {
            Door = Door.Closed;
            int? destination = _floorQueue.Head?.Data;

            if (destination == null)
                return;

            if (Direction == Direction.Idle)
            {
                if (destination > CurrentFloor)
                    Direction = Direction.Up;
                else if (destination < CurrentFloor)
                    Direction = Direction.Down;
                else if (destination == CurrentFloor)
                {
                    Direction = Direction.Idle;
                    Door = Door.Open;
                    _floorQueue.Dequeue();
                }

                return;
            }

            if (Direction == Direction.Up)
                CurrentFloor++;
            else if (Direction == Direction.Down)
                CurrentFloor--;

            if (CurrentFloor == destination)
            {
                Direction = Direction.Idle;
                Door = Door.Open;
                _floorQueue.Dequeue();
            }
        }

        public bool QueueEmpty()
        {
            if (_floorQueue.Head == null)
                return true;

            return false;
        }

        public void RequestFloor(int floor)
        {
            _floorQueue.Enqueue(floor);
        }
    }
}
