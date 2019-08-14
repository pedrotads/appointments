using System;
using System.Collections.Generic;
using System.Text;

namespace Appointments.UseCases
{
    public abstract class BaseValidator<T> where T: class
    {
        internal IList<IValidation<T>> _validators;

        public IList<Tuple<string, string>> Run(T entity)
        {
            IList<Tuple<string, string>> result = new List<Tuple<string, string>>();
            if (_validators.Count != 0)
            {
                foreach (IValidation<T> item in _validators)
                {
                    var validationResult = item.Execute(entity);
                    if (validationResult != null)
                    {
                        result.Add(validationResult);
                    }
                }
            }
            return result;
        }
    }
}
