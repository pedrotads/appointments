using System;
using System.Collections.Generic;
using System.Text;

namespace Appointments.UseCases
{
    public interface IValidation<T> where T : class
    {
        IList<Tuple<string, string>> Execute(T entity);
    }
}
