using System.Runtime.Serialization;

namespace OnlineBookStore.Exceptions
{
    public class NoBooksAvailableException : Exception
    {
        string msg = "";
        public NoBooksAvailableException()
        {
            msg = "No Books are Available.";
        }
        public override string Message => msg;
    }
}