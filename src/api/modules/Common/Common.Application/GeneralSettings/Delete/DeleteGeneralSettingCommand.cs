using MediatR;

namespace FSH.Starter.WebApi.Common.Application.GeneralSettings.Delete;
public sealed record DeleteGeneralSettingCommand(
    Guid Id) : IRequest;
