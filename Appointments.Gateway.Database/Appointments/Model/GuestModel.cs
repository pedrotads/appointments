using System;

namespace Appointments.Gateway.Database.Appointments.Model
{
    public class GuestModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public GuestStatusModel Status { get; set; }
    }
}