using ElevatorControlSystem.Controllers.Models;

namespace ElevatorControlSystem.Services
{
    public interface IElevatorService
    {
        /// <summary>
        /// Adds a job to the elevator tasks. Takes a direction from outside the elevator
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="floor"></param>
        /// <returns></returns>
        int AddJob(Direction direction, int floor);

        int AddJob(int floor);

        int GetCurrentFloor();

        int GetNextJob();

        IEnumerable<int> GetAllJobs();

        bool CompleteJob(int floor);
    }
}
