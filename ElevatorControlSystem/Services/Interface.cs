using ElevatorControlSystem.Controllers.Models;

namespace ElevatorControlSystem.Services
{
    public interface IElevatorService
    {
        public int AddJob(Direction direction, int floor);
    }
}
