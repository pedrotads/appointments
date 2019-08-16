using System;
using System.Collections.Generic;
using System.Text;

namespace Appointments.UseCases
{
    public abstract class BaseValidator<T>: IValidator<T> where T: class
    {
        internal IList<IValidation<T>> _validators;

        public IList<Tuple<string, string>> Run(T entity)
        {
            List<Tuple<string, string>> result = null;
            if (_validators.Count != 0)
            {
                foreach (IValidation<T> item in _validators)
                {
                    var validationResult = item.Execute(entity);
                    if (validationResult != null)
                    {
                        if (result == null)
                        {
                            result = new List<Tuple<string, string>>();
                        }
                        result.AddRange(validationResult);
                    }
                }
            }
            return result;
        }
        public string GetErrors(IList<Tuple<string, string>> errors)
        {
            var ErrorMessage = new StringBuilder();
            foreach (Tuple<string, string> item in errors)
            {
                ErrorMessage.AppendLine(item.Item1 + " - " + item.Item2);
            }
            return ErrorMessage.ToString();
        }
    }
}
