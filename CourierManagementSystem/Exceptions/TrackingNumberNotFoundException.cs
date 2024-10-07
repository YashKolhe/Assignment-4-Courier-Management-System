using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Exceptions
{
    internal class TrackingNumberNotFoundException:Exception
    {
        public TrackingNumberNotFoundException(string message) : base(message) { }

    }
}
