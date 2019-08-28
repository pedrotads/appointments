using Appointments.Domain;
using Appointments.Gateway.Database.Appointments.Mapper;
using Appointments.UseCases.Appointments.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointments.Gateway.Database.Appointments.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public Appointment NewAppointment(Appointment appointment)
        {
            var appointmentModel = appointment.ToAppointmentModel();
            appointmentModel.Id = 1;
            return appointmentModel.FromAppointmentModel();
        }
    }
}
