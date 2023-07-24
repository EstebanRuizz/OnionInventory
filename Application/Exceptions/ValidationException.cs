using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }
        public ValidationException(IEnumerable<string> errors) : this()
        {
            Errors.AddRange(errors);
        }
        public ValidationException() : base("One or more Errors of Validation")
        {
            Errors = new List<string>();
        }
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var fail in failures)
            {
                Errors.Add(fail.ErrorMessage);
            }
        }
    }
}
