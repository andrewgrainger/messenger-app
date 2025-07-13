using FluentValidation.Results;

namespace Messenger.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public Dictionary<string, string[]> Errors { get; }
    
    public ValidationException() : base("One or more validation error(s) occurred")
    {
        Errors = [];
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(x => x.PropertyName, x => x.ErrorMessage)
            .ToDictionary(x => x.Key, x => x.ToArray());
    }
}
