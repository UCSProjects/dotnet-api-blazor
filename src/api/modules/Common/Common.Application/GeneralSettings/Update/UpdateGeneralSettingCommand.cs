using MediatR;

namespace FSH.Starter.WebApi.Common.Application.GeneralSettings.Update;
public sealed record UpdateGeneralSettingCommand(
    Guid Id,
    string? SettingName,
    string? SettingValue = null) : IRequest<UpdateGeneralSettingResponse>;
