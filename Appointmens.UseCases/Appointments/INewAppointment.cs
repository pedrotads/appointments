using Appointments.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointments.UseCases.Appointments
{
    interface INewAppointment
    {
        Appointment New(Appointment appointment);
    }
}
