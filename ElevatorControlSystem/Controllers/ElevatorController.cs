using ElevatorControlSystem.Controllers.Models;
using ElevatorControlSystem.Services;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ElevatorControlSystem.Controllers
{
    /// <summary>
    /// Api to control an elevator
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class ElevatorController : ApiController
    {
        readonly IElevatorService _elevatorService;

        public ElevatorController(IElevatorService elevatorService)
        {
            _elevatorService = elevatorService;
        }

        /// <summary>
        /// Adds a new job with the intended direction. Designed to be used from outside the elevator.
        /// </summary>
        /// <param name="direction">The direction the user requested the elevator to go</param>
        /// <param name="floor">The floor the user is currently on</param>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpPost("service/{floor}")]
        public IActionResult EnqueueNewJob(Direction direction, int floor)
        {
            ErrorOr<bool> added = _elevatorService.AddJob(direction, floor);

            return added.Match(
                value => NoContent(),
                Problem);
        }

        /// <summary>
        /// Adds a new job from within the elevator.
        /// </summary>
        /// <param name="floor">The floor to be added to the queue</param>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpPost("jobs/{floor}")]
        public IActionResult AddElevatorJob(int floor)
        {
            ErrorOr<bool> added = _elevatorService.AddJob(floor);

            return added.Match(
                value => NoContent(),
                Problem);
        }

        /// <summary>
        /// Retrieves the current floor the elevator is on.
        /// </summary>
        /// <returns>the int value of the floor</returns>
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet("jobs/{floor}")]
        public IActionResult GetElevatorJob()
        {
            ErrorOr<int> result = _elevatorService.GetCurrentFloor();

            return result.Match(
                value => Ok(value),
                Problem);
        }

        /// <summary>
        /// Elevator car requests all floors that it’s current passengers are servicing
        /// </summary>
        /// <returns>IEnumerable<int> of all the floors</int></returns>
        [ProducesResponseType(typeof(IEnumerable<int>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet("jobs/all")]
        public IActionResult GetAllElevatorJobs()
        {
            ErrorOr<IEnumerable<int>> jobs =  _elevatorService.GetAllJobs();

            return jobs.Match(
                value => Ok(value),
                Problem);
        }

        /// <summary>
        /// Requests the next floor the elevator needs to service
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet("jobs/next")]
        public IActionResult GetNextElevatorJob()
        {
            ErrorOr<int> result = _elevatorService.GetNextJob();

            return result.Match(
                value => Ok(value),
                Problem);
        }

        /// <summary>
        /// Elevator sends a request that it has reached a floor and completed a job
        /// </summary>
        /// <param name="floor">The floor that is complete in the queue</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpDelete("jobs/complete")]
        public IActionResult ElevatorCompleteJob(int floor)
        {
            ErrorOr<bool> result = _elevatorService.CompleteJob(floor);

            return result.Match(
                value => NoContent(),
                Problem);
        }
    }
}
