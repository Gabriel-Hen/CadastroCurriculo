﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace CadastroCurriculo.ModelBinders;

public class DecimalModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (context.Metadata.ModelType == typeof(decimal))
        {
            return new DecimalModelBinder();
        }

        return null;
    }
}