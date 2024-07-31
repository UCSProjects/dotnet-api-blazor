using FluentValidation;

namespace FSH.Starter.WebApi.Common.Application.GeneralSettings.Create;
public class CreateGeneralSettingCommandValidator : AbstractValidator<CreateGeneralSettingCommand>
{
    public CreateGeneralSettingCommandValidator()
    {
        RuleFor(p => p.SettingName).NotEmpty().MinimumLength(2).MaximumLength(200);
        RuleFor(p => p.SettingValue).NotEmpty().MinimumLength(1);
    }
}
