using ElevatorControlSystem.Controllers.Models;
using ElevatorControlSystem.ServiceErrors;
using ErrorOr;

namespace ElevatorControlSystem.Services
{
    public class ElevatorService : IElevatorService
    {

        private static readonly int topFloor = 30;

        private static readonly int bottomFloor = -5;

        private Direction currentDirection = Direction.Up;

        private int currentFloor = 0;

        private readonly List<int> upJobs = new();
        
        private readonly List<int> downJobs = new();

        public ErrorOr<bool> AddJob(Direction direction, int floor)
        {
            var added = addJobToQueue(direction, floor);

            if (added == null) return Errors.Elevator.OutofRange;

            return true;
        }

        public ErrorOr<bool> AddJob(int floor)
        {
            return AddJob(currentDirection, floor);
        }

        public ErrorOr<int> GetCurrentFloor()
        {
            return currentFloor;
        }

        // TODO: Implement other error handling
        public ErrorOr<int> GetNextJob()
        {
            List<int> allJobs = combineAllJobs();

            Random rnd = new();

            return allJobs[rnd.Next(allJobs.Count)];
        }

        public ErrorOr<IEnumerable<int>> GetAllJobs()
        {
            return combineAllJobs();
        }

        private List<int> combineAllJobs()
        {
            List<int> allJobs = new();

            allJobs.AddRange(upJobs);
            allJobs.AddRange(downJobs);

            return allJobs;
        }

        public ErrorOr<bool> CompleteJob(int floor)
        {
            List<int> jobs = GetDirection();

            currentFloor = floor;

            return jobs.Remove(floor);
        }

        private int? addJobToQueue(Direction direction, int floor)
        {
            if (floor > topFloor || floor < bottomFloor)
            {
                return null;
            }

            List<int> jobs = GetDirection(direction);
            jobs.Add(floor);

            return floor;
        }

        private List<int> GetDirection(Direction? direction = null)
        {
            direction ??= currentDirection;

            return direction switch
            {
                Direction.Down => downJobs,
                _ => upJobs,
            };
        }
    }
}
