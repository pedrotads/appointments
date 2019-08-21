using Appointments.Domain;
using Appointments.Gateway.Database.Appointments.Mapper;
using Appointments.UseCases.Appointments.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointments.UnityTests.Repository.Mocks
{
    public class AppointmentRepositoryMock : IAppointmentRepository
    {
        public Appointment NewAppointment(Appointment appointment)
        {
            var appointmentModel = appointment.toAppointmentModel();
            appointmentModel.Id = 1;
            return appointmentModel.fromAppointmentModel();
        }
    }
}
