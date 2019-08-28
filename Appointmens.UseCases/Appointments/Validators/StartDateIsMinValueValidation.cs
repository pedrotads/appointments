using Appointments.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace Appointments.UseCases.Appointments.Validators
{
    public class StartDateValidationIsMinValue : IValidation<Appointment>
    {
        public IList<Tuple<string, string>> Execute(Appointment entity)
        {
            List<Tuple<string, string>> result = null;
            if (entity.Start == DateTime.MinValue)
            {
                result = new List<Tuple<string, string>>
                {
                    new Tuple<string, string>("AP02", "Start date can't is Empty")
                };
            }
            return result;
        }
    }
}
