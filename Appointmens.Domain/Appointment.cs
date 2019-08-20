using System;
using System.Collections.Generic;

namespace Appointments.Domain
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public TimeSpan End { get; set; }
        public String Name { get; set; }
        public String Place { get; set; }
        public String Details { get; set; }
        public IEnumerable<Guest> Guests { get; set; }
    }
}
