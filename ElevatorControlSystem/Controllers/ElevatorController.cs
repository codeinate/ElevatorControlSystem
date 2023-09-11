using ElevatorControlSystem.Controllers.Models;
using ElevatorControlSystem.Services;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace ElevatorControlSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElevatorController : ControllerBase
    {
        ElevatorService _elevatorService;

        public ElevatorController(ElevatorService elevatorService)
        {
            _elevatorService = elevatorService;
        }

        [HttpPost("service/{floor}")]
        public ErrorOr<ElevatorResponse> EnqueueNewJob(Direction direction, int floor)
        {
            int added = _elevatorService.AddJob(direction, floor);

            return new ElevatorResponse(added);
        }

        [HttpPost("jobs/{floor}")]
        public ErrorOr<ElevatorResponse> AddElevatorJob(int floor)
        {
            _elevatorService.AddJob(floor);

            return new ElevatorResponse(floor);
        }

        [HttpGet("jobs/{floor}")]
        public ErrorOr<ElevatorResponse> GetElevatorJob(int floor)
        {
            _elevatorService.GetCurrentFloor();

            return new ElevatorResponse(floor);
        }

        //An elevator car requests all floors that it’s current passengers are servicing(e.g.to light up the buttons that show which floors the car is going to)
        [HttpGet("jobs/all")]
        public ErrorOr<IEnumerable<int>>  GetAllElevatorJobs()
        {
            return _elevatorService.GetAllJobs();
        }

        //An elevator car requests the next floor it needs to service
        [HttpGet("jobs/next")]
        public ErrorOr<ElevatorResponse> GetNextElevatorJob()
        {
            return new ElevatorResponse();
        }

        //An elevator car requests the next floor it needs to service
        [HttpPut("jobs/complete")]
        public ErrorOr<ElevatorResponse> ElevatorCompleteJob()
        {
            _elevatorService.CompleteJob();

            return new ElevatorResponse();
        }
    }
}
