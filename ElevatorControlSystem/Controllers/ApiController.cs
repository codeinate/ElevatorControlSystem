using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace ElevatorControlSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Any(e => e.Type == ErrorType.Unexpected))
            {
                return Problem();
            }

            Error firstError = errors[0];

            int statusCode = firstError.Type switch
            {
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: firstError.Description);
        }
    }
}
