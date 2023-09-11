using ElevatorControlSystem.Controllers.Models;

namespace ElevatorControlSystem.Services
{
    public class ElevatorService : IElevatorService
    {
        private static readonly int topFloor = 30;

        private static readonly int currentFloor = 0;

        private static readonly Direction direction = Direction.Up;

        private static readonly List<int> upJobs = new();
        
        private static readonly List<int> downJobs = new();

        public int AddJob(int floor)
        {
            return AddJob(direction, floor);
        }

        public int AddJob(Direction direction, int floor)
        {
            return addJobToQueue(direction, floor);
        }

        private static int addJobToQueue(Direction direction, int floor)
        {
            if (floor > topFloor)
            {
                return -1;
            }

            switch (direction)
            {
                case Direction.Up:
                    upJobs.Add(floor);
                    break;
                case Direction.Down:
                    downJobs.Add(floor);
                    break;
            }

            return floor;
        }

        public int GetNextJob()
        {
            return currentFloor;
        }

        public IEnumerable<int> GetAllJobs()
        {
            List<int> allJobs = new();

            allJobs.AddRange(upJobs);
            allJobs.AddRange(downJobs);

            return allJobs.Distinct();
        }

        public bool CompleteJob()
        {
            return true;
        }
    }
}
