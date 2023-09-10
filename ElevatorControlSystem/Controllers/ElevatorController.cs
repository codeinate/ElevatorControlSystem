using ElevatorControlSystem.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElevatorControlSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElevatorController : ControllerBase
    {
        [HttpPost("service/{floor}")]
        public ElevatorResponse EnqueueNewJob(Direction direction, int floor)
        {
            // if direction = current, add to current queue
            //return new int() { Floor = 1 };
            return new ElevatorResponse(floor);
        }

        //A person requests that they be brought to a floor
        [HttpPost("job/{floor}")]
        public ElevatorResponse AddElevatorJob(int floor)
        {
            return new ElevatorResponse(floor);
        }

        //An elevator car requests all floors that it’s current passengers are servicing(e.g.to light up the buttons that show which floors the car is going to)
        [HttpGet("jobs/all")]
        public int[] GetAllElevatorJobs()
        {
            return new[] { 0, 1, 2 };
        }

        //An elevator car requests the next floor it needs to service
        [HttpGet("jobs/next")]
        public ElevatorResponse GetNextElevatorJob()
        {
            return new ElevatorResponse();
        }

        //An elevator car requests the next floor it needs to service
        [HttpPut("jobs/complete")]
        public ElevatorResponse ElevatorCompleteJob()
        {
            return new ElevatorResponse();
        }
    }
}
