using Core;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace CadastroCurriculo.ModelBinders;

public class PesquisaModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var pesquisa = new Pesquisa();

        if (TryGetValue(bindingContext, "start", out StringValues offset))
        {
            pesquisa.Offset = TryParseToIntOrDefault(offset) ?? 0;
        }

        if (TryGetValue(bindingContext, "length", out StringValues limite))
        {
            pesquisa.Limite = TryParseToIntOrDefault(limite) ?? 20;
        }

        if (TryGetValue(bindingContext, "search[value]", out StringValues termo))
        {
            pesquisa.Termo = termo.ToString();
        }

        if (TryGetValue(bindingContext, "order[0][dir]", out StringValues ordenacao))
        {
            pesquisa.Ordenacao = ordenacao.ToString();
        }

        if (TryGetValue(bindingContext, "order[0][column]", out StringValues coluna))
        {
            var index = TryParseToIntOrDefault(coluna);

            if (index != null && TryGetValue(bindingContext, $"columns[{index}][name]", out StringValues ordenacaoPor))
            {
                pesquisa.OrdenarPor = ordenacaoPor.ToString();
            }
        }

        bindingContext.Result = ModelBindingResult.Success(pesquisa);

        return Task.CompletedTask;
    }

    private static int? TryParseToIntOrDefault(StringValues value)
    {
        if (int.TryParse(value, out int output))
        {
            return output;
        }

        return default;
    }

    private static bool TryGetValue(
        ModelBindingContext bindingContext,
        string key,
        out StringValues offset
    )
    {
        return bindingContext.HttpContext.Request.Query.TryGetValue(key, out offset);
    }
}