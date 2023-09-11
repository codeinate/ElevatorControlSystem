using ElevatorControlSystem.Controllers.Models;
using ElevatorControlSystem.Services;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace ElevatorControlSystem.Controllers
{
    /// <summary>
    /// Api to control an elevator
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ElevatorController : ControllerBase
    {
        readonly IElevatorService _elevatorService;

        public ElevatorController(IElevatorService elevatorService)
        {
            _elevatorService = elevatorService;
        }

        /// <summary>
        /// Adds a new job with the intended direction. Designed to be used from outside the elevator.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="floor"></param>
        /// <returns></returns>
        [HttpPost("service/{floor}")]
        public ErrorOr<ElevatorResponse> EnqueueNewJob(Direction direction, int floor)
        {
            int added = _elevatorService.AddJob(direction, floor);

            return new ElevatorResponse(added);
        }

        /// <summary>
        /// Adds a new job from within the elevator.
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        [HttpPost("jobs/{floor}")]
        public ErrorOr<ElevatorResponse> AddElevatorJob(int floor)
        {
            _elevatorService.AddJob(floor);

            return new ElevatorResponse(floor);
        }

        /// <summary>
        /// Retrieves the current floor the elevator is on.
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        [HttpGet("jobs/{floor}")]
        public ErrorOr<ElevatorResponse> GetElevatorJob(int floor)
        {
            _elevatorService.GetCurrentFloor();

            return new ElevatorResponse(floor);
        }

        /// <summary>
        /// Elevator car requests all floors that it’s current passengers are servicing
        /// </summary>
        /// <returns></returns>
        [HttpGet("jobs/all")]
        public IEnumerable<int>  GetAllElevatorJobs()
        {
            return _elevatorService.GetAllJobs();
        }

        /// <summary>
        /// requests the next floor the elevator needs to service
        /// </summary>
        /// <returns></returns>
        [HttpGet("jobs/next")]
        public ErrorOr<ElevatorResponse> GetNextElevatorJob()
        {
            return new ElevatorResponse();
        }

        /// <summary>
        /// Elevator sends a request that it has reached a floor and completed a job
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        [HttpDelete("jobs/complete")]
        public ErrorOr<ElevatorResponse> ElevatorCompleteJob(int floor)
        {
            _elevatorService.CompleteJob(floor);

            return new ElevatorResponse();
        }
    }
}
