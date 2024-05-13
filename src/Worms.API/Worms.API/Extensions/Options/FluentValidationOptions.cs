namespace Worms.API.Extensions.Options;

using FluentValidation;
using Microsoft.Extensions.Options;

public class FluentValidationOptions<TOptions> : IValidateOptions<TOptions>
    where TOptions : class
{
    private readonly IServiceProvider _serviceProvider;
    private readonly string? _name;

    public FluentValidationOptions(string? name, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _name = name;
    }

    public ValidateOptionsResult Validate(string? name, TOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        if (_name is not null && _name != name)
        {
            return ValidateOptionsResult.Skip;
        }

        using var scope = _serviceProvider.CreateScope();

        var targetValidator = scope.ServiceProvider.GetService<IValidator<TOptions>>();

        var result = targetValidator?.Validate(options);
        if (result is null || result.IsValid)
        {
            return ValidateOptionsResult.Success;
        }

        var typeName = options.GetType().Name;

        var errors = result.Errors.Select(error =>
            $"Validation failed for '{typeName}.{error.PropertyName}'. Error: '{error.ErrorMessage}'.");

        return ValidateOptionsResult.Fail(errors);
    }
}