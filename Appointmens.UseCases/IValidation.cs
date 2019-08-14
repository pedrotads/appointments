using System;
using System.Collections.Generic;
using System.Text;

namespace Appointments.UseCases
{
    public interface IValidation<T> where T : class
    {
        Tuple<string, string> Execute(T entity);
    }
}
