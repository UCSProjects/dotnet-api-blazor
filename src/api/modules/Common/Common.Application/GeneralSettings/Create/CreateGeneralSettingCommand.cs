using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.Common.Application.GeneralSettings.Create;
public sealed record CreateGeneralSettingCommand(
    [property: DefaultValue("UserLimit")] string? SettingName,
    [property: DefaultValue("{FieldValue:100}")] string? SettingValue = null) : IRequest<CreateGeneralSettingResponse>;
