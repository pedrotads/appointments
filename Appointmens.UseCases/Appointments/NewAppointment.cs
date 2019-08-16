using System;
using System.Text;
using Appointments.Domain;
using Appointments.Domain.Exception;
using Appointments.UseCases.Appointments.Repository;
using Appointments.UseCases.Appointments.Validators;

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
            Appointment result = null;
            var appointmentsValidator = new AppointmentsValidator();
            var errors = appointmentsValidator.Run(appointment);
            if (errors != null)
            {
                string ErrorMessage = appointmentsValidator.GetErrors(errors);
                throw new DomainException(ErrorMessage.ToString());
            }
            else
            {
                _repository.NewAppointment(appointment);
            }
            return result;
        }
    }
}
