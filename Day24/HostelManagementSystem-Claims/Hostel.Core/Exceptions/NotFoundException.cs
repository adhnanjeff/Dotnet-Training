

namespace Hostel.Core.Exceptions
{
    public class NotFoundException : Exception
    {

        // When trying to fetch, update or delete an object that is not available
        public NotFoundException(string message) : base(message) { }
    }
}
