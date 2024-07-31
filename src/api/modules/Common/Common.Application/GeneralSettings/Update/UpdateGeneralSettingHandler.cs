using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Common.Domain;
using FSH.Starter.WebApi.Common.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Common.Application.GeneralSettings.Update;
public sealed class UpdateGeneralSettingHandler(
    ILogger<UpdateGeneralSettingHandler> logger,
    [FromKeyedServices("common:generalsettings")] IRepository<GeneralSetting> repository)
    : IRequestHandler<UpdateGeneralSettingCommand, UpdateGeneralSettingResponse>
{
    public async Task<UpdateGeneralSettingResponse> Handle(UpdateGeneralSettingCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var generalsetting = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = generalsetting ?? throw new GeneralSettingNotFoundException(request.Id);
        var updatedGeneralSetting = generalsetting.Update(request.SettingName, request.SettingValue);
        await repository.UpdateAsync(updatedGeneralSetting, cancellationToken);
        logger.LogInformation("generalsetting with id : {GeneralSettingId} updated.", generalsetting.Id);
        return new UpdateGeneralSettingResponse(generalsetting.Id);
    }
}
