using Microsoft.AspNetCore.Mvc;

namespace ControleUsuariosApi.Middleware;

public sealed class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Erro ao processar a requisição.");
            await EscreverRespostaAsync(context, exception);
        }
    }

    private static async Task EscreverRespostaAsync(HttpContext context, Exception exception)
    {
        var (statusCode, title) = exception switch
        {
            KeyNotFoundException => (StatusCodes.Status404NotFound, "Recurso não encontrado"),
            InvalidOperationException => (StatusCodes.Status409Conflict, "Conflito de dados"),
            _ => (StatusCodes.Status500InternalServerError, "Erro interno do servidor")
        };

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/problem+json";

        var problem = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = statusCode == StatusCodes.Status500InternalServerError
                ? "Ocorreu um erro inesperado."
                : exception.Message
        };

        await context.Response.WriteAsJsonAsync(problem);
    }
}
