using System.Runtime.Serialization;

namespace EventManagement.Exceptions
{
    public class NoEventsAvailableException : Exception
    {
        string msg = "";
        public NoEventsAvailableException()
        {
            msg = "No Events taking place.";
        }
        public override string Message => msg;
    }
}