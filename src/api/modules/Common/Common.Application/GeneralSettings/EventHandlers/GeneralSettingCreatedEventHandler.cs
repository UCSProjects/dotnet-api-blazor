using FSH.Starter.WebApi.Common.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Common.Application.GeneralSettings.EventHandlers;

public class GeneralSettingCreatedEventHandler(ILogger<GeneralSettingCreatedEventHandler> logger) : INotificationHandler<GeneralSettingCreated>
{
    public async Task Handle(GeneralSettingCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling general setting created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling general setting created domain event..");
    }
}

