using Appointments.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace Appointments.UseCases.Appointments.Validators
{
    public class StartDateIsInThePastValidation : IValidation<Appointment>
    {
        public IList<Tuple<string, string>> Execute(Appointment entity)
        {
            List<Tuple<string, string>> result = null;
            if (entity.Start < DateTime.Now)
            {
                result = new List<Tuple<string, string>>
                {
                    new Tuple<string, string>("AP03", "Start date can't be earlier than now")
                };
            }
            return result;
        }
    }
}
