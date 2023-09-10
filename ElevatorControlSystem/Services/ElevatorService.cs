using ElevatorControlSystem.Controllers.Models;

namespace ElevatorControlSystem.Services
{
    public class ElevatorService : IElevatorService
    {
        private static readonly int topFloor = 30;

        private static readonly int currentFloor = 0;

        private static readonly List<int> upJobs = new();
        
        private static readonly List<int> downJobs = new();

        public int AddFloor(Direction direction, int floor)
        {
            if (direction == Direction.Up)
            {
                upJobs.Add(floor);
            }
            else
            {
                downJobs.Add(floor);
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
