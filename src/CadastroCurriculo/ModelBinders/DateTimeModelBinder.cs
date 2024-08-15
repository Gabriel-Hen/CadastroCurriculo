using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace CadastroCurriculo.ModelBinders;

public class DateTimeModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        var firstValue = valueProviderResult.FirstValue;

        if (string.IsNullOrEmpty(firstValue))
        {
            return Task.CompletedTask;
        }

        bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

        if (!DateTime.TryParse(firstValue, out DateTime valor))
        {
            bindingContext.ModelState.TryAddModelError(
                bindingContext.ModelName,
                "Data inválida."
            );

            return Task.CompletedTask;
        }

        bindingContext.Result = ModelBindingResult.Success(valor);

        return Task.CompletedTask;
    }
}