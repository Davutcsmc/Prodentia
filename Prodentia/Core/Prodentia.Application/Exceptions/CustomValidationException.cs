using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; } = [];
        public CustomValidationException(ValidationResult validationResult)
        {
            for (int i = 0; i < validationResult.Errors.Count; i++)
            {
                ValidationErrors.Add(validationResult.Errors[i].ErrorMessage);
            }
        }
    }
}
 