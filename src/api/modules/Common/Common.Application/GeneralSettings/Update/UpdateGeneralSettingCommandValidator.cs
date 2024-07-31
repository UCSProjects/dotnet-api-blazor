using FluentValidation;

namespace FSH.Starter.WebApi.Common.Application.GeneralSettings.Update;
public class UpdateGeneralSettingCommandValidator : AbstractValidator<UpdateGeneralSettingCommand>
{
    public UpdateGeneralSettingCommandValidator()
    {
        RuleFor(p => p.SettingName).NotEmpty().MinimumLength(2).MaximumLength(200);
        RuleFor(p => p.SettingValue).NotEmpty().MinimumLength(1);
    }
}
