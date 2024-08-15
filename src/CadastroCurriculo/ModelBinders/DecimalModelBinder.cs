using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace CadastroCurriculo.ModelBinders;

public class DecimalModelBinder : IModelBinder
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

        if (!decimal.TryParse(firstValue, out decimal valor))
        {
            bindingContext.ModelState.TryAddModelError(
                bindingContext.ModelName,
                "Valor inválido."
            );

            return Task.CompletedTask;
        }

        bindingContext.Result = ModelBindingResult.Success(valor);

        return Task.CompletedTask;
    }
}