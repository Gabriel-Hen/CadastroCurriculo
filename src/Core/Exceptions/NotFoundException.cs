using System;

namespace Core.Exceptions;

public class NotFoundException : Exception
{
    public string Key { get; }

    public NotFoundException(string key, string errorMessage) : base(errorMessage)
    {
        Key = key;
    }
}