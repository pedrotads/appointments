using System;

namespace Appointments.Domain
{
    public class Guest
    {
        public int Id { get; set; }
        public String Name  { get; set; }
        public GuestStatus Status { get; set; }
    }
}