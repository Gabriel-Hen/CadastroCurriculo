using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CadastroCurriculo.ModelBinders;

public class OnlyNumbersBinder : IModelBinder
{
    private readonly Regex regex = new("[^0-9]", RegexOptions.Compiled);

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        var value = valueProviderResult.FirstValue;

        if (string.IsNullOrEmpty(value))
        {
            return Task.CompletedTask;
        }

        bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

        var valor = regex.Replace(value, "");
        bindingContext.Result = ModelBindingResult.Success(valor.Trim());

        return Task.CompletedTask;
    }
}