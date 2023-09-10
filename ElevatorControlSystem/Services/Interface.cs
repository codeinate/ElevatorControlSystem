using ElevatorControlSystem.Controllers.Models;

namespace ElevatorControlSystem.Services
{
    public interface IElevatorService
    {
        public int AddFloor(Direction direction, int floor);
    }
}
