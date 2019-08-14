using System;
using System.Collections.Generic;
using System.Text;

namespace Appointments.Gateway.Database.Appointments.Model
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTimeOffset End { get; set; }
        public String Name { get; set; }
        public String Place { get; set; }
        public String Details { get; set; }
        public IEnumerable<GuestModel> Guests { get; set; }
    }
}
