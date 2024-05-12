using FluentValidation;

namespace Worms.API.Settings.Validators;

public class BotConfigurationSettingsValidator : AbstractValidator<BotConfigurationSettings>
{
    public BotConfigurationSettingsValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty();
    }
}