using MediatR;
using FluentValidation;
using CodeCampRestora.Application.Exceptions;

namespace CodeCampRestora.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var validationResult = await Task.WhenAll(
            _validators.Select(validator => validator.ValidateAsync(request)));

        var errors = validationResult
            .Where(validationResult => !validationResult.IsValid)
            .SelectMany(validationResult => validationResult.Errors)
            .Select(validationFailure => (
                propertyName: validationFailure.PropertyName,
                errorMessage: validationFailure.ErrorMessage
            ))
            .ToList();

        if (errors.Any()) throw new ApplicationValidationException(errors);

        return await next();
    }
}
