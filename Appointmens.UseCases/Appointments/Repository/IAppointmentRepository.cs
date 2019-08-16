using Appointments.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointments.UseCases.Appointments.Repository
{
    public interface IAppointmentRepository
    {
        Appointment NewAppointment(Appointment appointment);
    }
}
