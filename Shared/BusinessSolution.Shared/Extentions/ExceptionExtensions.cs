using BusinessSolution.Shared.Exceptions;
using FluentValidation.Results;

namespace BusinessSolution.Shared.Extentions;

public static class ExceptionExtensions
{
    public static ErrorResponse ToErrorResponse(this ValidationResult data)
    {
        var res = new ErrorResponse()
        {
            Message = "",
            FieldErrors = data.Errors.Select(x =>
            {
                var elems = x.ErrorMessage.Split('&');
                var errorName = elems[0];
                var errorMessage = elems.Length > 0 ? elems[1] : errorName;
                return new ErrorResponseFieldInfo()
                {
                    FieldName = x.PropertyName,
                    Message = errorMessage,
                };
            })
        };

        return res;
    }

    public static ErrorResponse ToErrorResponse(this ProcessException data)
    {
        var res = new ErrorResponse()
        {
            Message = data.Message
        };

        return res;
    }

    public static ErrorResponse ToErrorResponse(this Exception data)
    {
        var res = new ErrorResponse()
        {
            ErrorCode = -1,
            Message = data.Message
        };

        return res;
    }
}
