using Appointments.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace Appointments.UseCases.Appointments.Validators
{
    public class NameIsNullValidation : IValidation<Appointment>
    {
        public IList<Tuple<string, string>> Execute(Appointment entity)
        {
            IList<Tuple<string, string>> result = null;
            if (string.IsNullOrEmpty(entity.Name))
            {
                result = new List<Tuple<string, string>>()
                {
                    new Tuple<string, string>("AP01", "Name can't is null or empty")
                };
            }
            return result;
        }
    }
}
