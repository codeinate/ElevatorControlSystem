using ElevatorControlSystem.Controllers.Models;

namespace ElevatorControlSystem.Services
{
    public class ElevatorService : IElevatorService
    {
        private static readonly int topFloor = 30;

        private static readonly int currentFloor = 0;

        private static readonly Direction currentDirection = Direction.Up;

        private static readonly List<int> upJobs = new();
        
        private static readonly List<int> downJobs = new();

        public int AddJob(int floor)
        {
            return AddJob(currentDirection, floor);
        }

        public int AddJob(Direction direction, int floor)
        {
            return addJobToQueue(direction, floor);
        }

        public int GetCurrentFloor()
        {
            return currentFloor;
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

        public bool CompleteJob(int floor)
        {
            List<int> jobs = GetDirection();

            return jobs.Remove(floor);
        }

        private static int addJobToQueue(Direction direction, int floor)
        {
            if (floor > topFloor)
            {
                return -1;
            }

            List<int> jobs = GetDirection(direction);
            jobs.Add(floor);

            return floor;
        }

        private static List<int> GetDirection(Direction? direction = null)
        {
            direction ??= currentDirection;

            switch (direction)
            {
                case Direction.Down:
                    return downJobs;
                case Direction.Up:
                default: 
                    return upJobs;
            }
        }
    }
}
