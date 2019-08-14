using System;
using System.Collections.Generic;
using System.Text;

namespace Appointments.Domain.Exception
{
    public class DomainException : System.Exception
    {
        public DomainException(string businessMessage) : base(businessMessage)
        { }
    }
}
