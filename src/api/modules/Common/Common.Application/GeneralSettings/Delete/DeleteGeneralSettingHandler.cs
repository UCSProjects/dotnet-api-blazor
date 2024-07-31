using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Common.Domain;
using FSH.Starter.WebApi.Common.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Common.Application.GeneralSettings.Delete;
public sealed class DeleteGeneralSettingHandler(
    ILogger<DeleteGeneralSettingHandler> logger,
    [FromKeyedServices("common:generalsettings")] IRepository<GeneralSetting> repository)
    : IRequestHandler<DeleteGeneralSettingCommand>
{
    public async Task Handle(DeleteGeneralSettingCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var generalsetting = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = generalsetting ?? throw new GeneralSettingNotFoundException(request.Id);
        await repository.DeleteAsync(generalsetting, cancellationToken);
        logger.LogInformation("generalsetting with id : {GeneralSettingId} deleted", generalsetting.Id);
    }
}
