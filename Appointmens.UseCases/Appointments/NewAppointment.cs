using System;
using Appointments.Domain;
using Appointments.Domain.Exception;
using Appointments.UseCases.Appointments.Repository;

namespace Appointments.UseCases.Appointments
{
    public class NewAppointment : INewAppointment
    {
        private readonly IAppointmentRepository _repository;
        public NewAppointment(IAppointmentRepository repository)
        {
            _repository = repository;
        }
        public Appointment New(Appointment appointment)
        {
            if (appointment.Start == null)
            {
                throw new DomainException("Start date can't be null");
            }
            if (appointment.End == null)
            {
                throw new DomainException("Start date can't be null");
            }
            return null;
        }
    }
}
