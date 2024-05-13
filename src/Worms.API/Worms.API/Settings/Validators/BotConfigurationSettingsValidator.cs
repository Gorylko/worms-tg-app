namespace Worms.API.Settings.Validators;

using FluentValidation;

public class BotConfigurationSettingsValidator : AbstractValidator<BotConfigurationSettings>
{
    public BotConfigurationSettingsValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty();
    }
}