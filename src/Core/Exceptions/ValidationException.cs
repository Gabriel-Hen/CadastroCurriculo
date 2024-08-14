using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Exceptions;

public class ValidationException : Exception
{
    public ValidationResult ValidationResult { get; }

    public ValidationException(ValidationResult validationResult)
    {
        ValidationResult = validationResult;
    }

    public ValidationException(ValidationFailure failure)
    {
        ValidationResult = new ValidationResult(new ValidationFailure[] { failure });
    }

    public ValidationException(string propertyName, string errorMessage)
    {
        ValidationResult = new ValidationResult(new ValidationFailure[] {
            new ValidationFailure(propertyName, errorMessage)
        });
    }

    public List<string> GetErrorMessages()
    {
        return ValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
    }
}