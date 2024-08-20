using System.Collections.Generic;

namespace Core.Extensions;

internal static class IDictionaryExtensions
{
    public static bool MergeAttribute(
        this IDictionary<string, string> attributes,
        string key,
        string value
    )
    {
        if (attributes.ContainsKey(key))
        {
            return false;
        }

        attributes.Add(key, value);

        return true;
    }
}