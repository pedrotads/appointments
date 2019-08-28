using Appointments.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointments.UseCases.Appointments.Validators
{
    public class AppointmentsValidator : BaseValidator<Appointment>
    {
        public AppointmentsValidator()
        {
            validators = new List<IValidation<Appointment>>
            {
                new NameIsNullValidation(),
                new StartDateValidationIsMinValue(),
                new StartDateIsInThePastValidation()
            };
        }
    }
}
