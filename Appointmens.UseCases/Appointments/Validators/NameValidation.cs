using Appointments.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace Appointments.UseCases.Appointments.Validators
{
    public class NameValidation : IValidation<Appointment>
    {
        public Tuple<string, string> Execute(Appointment entity)
        {
            Tuple<string, string> result = null;
            if (string.IsNullOrEmpty(entity.Name))
            {
                result = new Tuple<string, string>("AP01", "Name can't is null");
            }
            return result;
        }
    }
}
