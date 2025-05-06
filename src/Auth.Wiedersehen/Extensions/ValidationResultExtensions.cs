using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Wiedersehen.Extensions;

internal static class ValidationResultExtensions
{
    public static IActionResult ToBadRequest(this ValidationResult result)
    {
        return new BadRequestObjectResult(
            new
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Errors = result.Errors.Select(Shorten),
            }
        );
    }

    private static object Shorten(ValidationFailure failure)
    {
        return new
        {
            failure.PropertyName,
            failure.ErrorMessage,
        };
    }
}