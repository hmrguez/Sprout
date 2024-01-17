using Application.Authentication.Commands.Register;
using Application.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest>? validator = null)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : IErrorOr
{
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        if(validator is null)
            return await next();
        
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
            return await next();

        var errors = validationResult.Errors
            .Select(failure => Error.Validation(
                failure.PropertyName, 
                failure.ErrorMessage))
            .ToList();

        return (dynamic)errors;
    }
}