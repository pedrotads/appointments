using Appointments.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointments.UseCases.Appointments.Validators
{
    public class AppointmentsValidator : BaseValidator<Appointment>, IValidator<Appointment>
    {
        public AppointmentsValidator()
        {
            _validators = new List<IValidation<Appointment>>();
            _validators.Add(new NameValidation());
            _validators.Add(new StartDateValidation());
        }
        
        public new IList<Tuple<string, string>> Run(Appointment entity)
        {
            return base.Run(entity);
        }
    }
}
