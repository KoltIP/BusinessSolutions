using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSolution.Shared.Exceptions;

public class ProcessException : Exception
{
    public ProcessException()
    {
    }

    public ProcessException(string message) : base(message)
    {
    }

    public ProcessException(Exception inner) : base(inner.Message, inner)
    {
    }

    public ProcessException(string message, Exception inner) : base(message, inner)
    {
    }

    public ProcessException(string code, string message) : base(message)
    {
        Code = code;
    }

    public ProcessException(string code, string message, Exception inner) : base(message, inner)
    {
        Code = code;
    }

    public string Code { get; }
    public string Name { get; }
    public static void ThrowIf(Func<bool> predicate, string message)
    {
        if (predicate.Invoke())
            throw new ProcessException(message);
    }
}
