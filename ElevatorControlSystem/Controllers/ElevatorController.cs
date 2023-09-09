using Microsoft.AspNetCore.Mvc;

namespace ElevatorControlSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElevatorController : ControllerBase
    {
        [HttpGet(Name = "GetElevator")]
        public string Get()
        {
            return "this test was successful";
        }
    }
}
