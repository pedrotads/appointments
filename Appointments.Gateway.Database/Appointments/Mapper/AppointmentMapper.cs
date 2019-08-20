using Appointments.Domain;
using Appointments.Gateway.Database.Appointments.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Appointments.Gateway.Database.Appointments.Mapper
{
    public static class AppointmentMapper
    {
        public static AppointmentModel toAppointmentModel(this Appointment appointment)
        {
            return new AppointmentModel()
            {
                Name = appointment.Name,
                Details = appointment.Details,
                Id = appointment.Id,
                Start = appointment.Start,
                End = appointment.End,
                Place = appointment.Place,
                Guests = appointment.Guests.Select(g =>
                  new GuestModel()
                  {
                      Id = g.Id,
                      Name = g.Name,
                      Status = (GuestStatusModel)(int)g.Status,
                  }).ToList()
            };
        }

        public static Appointment fromAppointmentModel(this AppointmentModel appointmentModel)
        {
            return new Appointment()
            {
                Name = appointmentModel.Name,
                Details = appointmentModel.Details,
                Id = appointmentModel.Id,
                Start = appointmentModel.Start,
                End = appointmentModel.End,
                Place = appointmentModel.Place,
                Guests = appointmentModel.Guests.Select(g =>
                 new Guest()
                 {
                     Id = g.Id,
                     Name = g.Name,
                     Status = (GuestStatus)(int)g.Status
                 }
                ).ToList()
            };
        }
    }
}