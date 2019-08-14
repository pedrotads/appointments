using Appointments.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace Appointments.UseCases.Appointments.Validators
{
    public class StartDateValidation : IValidation<Appointment>
    {
        public Tuple<string, string> Execute(Appointment entity)
        {
            Tuple<string, string> result = null;
            if (entity.Start == null)
            {
                result = new Tuple<string, string>("AP02", "Start date can't is null");
            }
            return result;
        }
    }
}
