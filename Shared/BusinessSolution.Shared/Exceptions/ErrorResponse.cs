namespace BusinessSolution.Shared.Exceptions;

public class ErrorResponse
{
    public int ErrorCode { get; set; }
    public string Message { get; set; }
    public IEnumerable<ErrorResponseFieldInfo> FieldErrors { get; set; }
}
