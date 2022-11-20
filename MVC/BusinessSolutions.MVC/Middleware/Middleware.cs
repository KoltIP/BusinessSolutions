using BusinessSolution.Shared.Exceptions;
using BusinessSolution.Shared.Extentions;
using FluentValidation;
using System.Text.Json;

namespace BusinessSolutions.MVC.Middleware;

public class Middleware
{
    readonly RequestDelegate next;
    public Middleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        ErrorResponse response = null;
        try
        {
            await next.Invoke(context);
        }
        catch (ValidationException e)
        {
            response = e.ToErrorResponse();
        }
        catch (ProcessException e)
        {
            response = e.ToErrorResponse();
        }
        catch (Exception e)
        {
            response = e.ToErrorResponse();
        }        
        finally
        {
            if (!(response is null))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                await context.Response.StartAsync();
                await context.Response.CompleteAsync();
            }
        }
    }
}
