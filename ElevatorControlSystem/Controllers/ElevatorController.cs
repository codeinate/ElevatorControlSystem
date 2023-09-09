using ElevatorControlSystem.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElevatorControlSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElevatorController : ControllerBase
    {
        [HttpPost(Name = "service/{floor}")]
        public ElevatorResponse EnqueueNewJob(RequestCaller requestCaller, Direction direction, int Floor)
        {
            // if direction = current, add to current queue
            return new ElevatorResponse() { Floor = 1 };
        }

        //A person requests that they be brought to a floor
        [HttpPost(Name = "job/{floor}")]
        public ElevatorResponse AddElevatorJob(string floor)
        {
            return new ElevatorResponse();
        }

        //An elevator car requests all floors that it’s current passengers are servicing(e.g.to light up the buttons that show which floors the car is going to)
        [HttpGet(Name = "jobs/all")]
        public ElevatorResponse GetAllElevatorJobs()
        {
            return new ElevatorResponse();
        }

        //An elevator car requests the next floor it needs to service
        [HttpGet(Name = "jobs/next")]
        public ElevatorResponse GetAllNextElevatorJob()
        {
            return new ElevatorResponse();
        }

        //An elevator car requests the next floor it needs to service
        [HttpPut(Name = "jobs/complete")]
        public ElevatorResponse ElevatorCompleteJob()
        {
            return new ElevatorResponse();
        }
    }
}
