using Core.Attributes.Validations;
using Core.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Core.Attributes.Validation;

public class CpfAttribute : ValidationAttribute, IClientModelValidator
{
    public CpfAttribute()
    {
        if (string.IsNullOrEmpty(ErrorMessage))
        {
            ErrorMessage = "CPF inválido";
        }
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        context.Attributes.MergeAttribute("data-cpf", "true");
        context.Attributes.MergeAttribute("data-val-cpf", ErrorMessage);
    }

    public override bool IsValid(object value)
    {
        if (value == null)
        {
            return true;
        }

        return value is string cpf && CpfValidation.Cpf(cpf);
    }
}