using ElevatorControlSystem.Controllers.Models;
using ErrorOr;

namespace ElevatorControlSystem.Services
{
    public interface IElevatorService
    {
        ErrorOr<bool> AddJob(Direction direction, int floor);

        ErrorOr<bool> AddJob(int floor);

        ErrorOr<int> GetCurrentFloor();

        ErrorOr<int> GetNextJob();

        IEnumerable<int> GetAllJobs();

        ErrorOr<bool> CompleteJob(int floor);
    }
}
