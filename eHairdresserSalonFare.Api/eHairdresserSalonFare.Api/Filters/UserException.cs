using System;

namespace eHairdresserSalonFare.Api.Filters
{
    public class UserException:Exception
    {
        public UserException(string message) : base(message)
        {}
    }
}
