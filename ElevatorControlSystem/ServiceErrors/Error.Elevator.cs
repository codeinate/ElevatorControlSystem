using ErrorOr;

namespace ElevatorControlSystem.ServiceErrors
{
    public static class Errors
    {
        public static class Elevator
        {
            public static Error OutofRange => Error.NotFound(
                code: "Floor out of range",
                description: "The request is out of range");

        }
    }
}
