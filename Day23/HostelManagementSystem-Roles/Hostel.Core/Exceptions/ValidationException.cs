

namespace Hostel.Core.Exceptions
{
    public class ValidationException : Exception
    {
        // password length or when password does not meet business needs like not using special characters etc..
        public IDictionary<string, string> Errors { get; }
        public ValidationException(IDictionary<string, string> errors) : base("Validation Failed") {
            Errors = errors;
        } 
    }
}
