using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Core.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValidationErrors { get; private set; }
        public ValidationException(List<ValidationFailure> result)
        {
            ValidationErrors = new List<string>();
            foreach (var item in result)
                ValidationErrors.Add(item.ErrorMessage);
        }
    }
}
