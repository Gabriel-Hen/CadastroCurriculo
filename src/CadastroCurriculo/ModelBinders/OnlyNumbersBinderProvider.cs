using Core.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace CadastroCurriculo.ModelBinders;

public class OnlyNumbersBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var propertyName = context.Metadata.PropertyName;
        var property = context.Metadata.ContainerType?.GetProperty(propertyName);

        if (property != null)
        {
            var attributes = (Attribute[])property.GetCustomAttributes(typeof(OnlyNumbersAttribute), false);

            if (attributes?.Any() ?? false)
            {
                return new OnlyNumbersBinder();
            }
        }

        return null;
    }
}