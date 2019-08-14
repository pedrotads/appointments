using System;
using System.Collections.Generic;
using System.Text;

namespace Appointments.UseCases
{
    public interface IValidator<T> where T: class
    {        
        IList<Tuple<string, string>> Run(T entity);
    }
}
