using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Common.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Common.Application.GeneralSettings.Create;
public sealed class CreateGeneralSettingHandler(
    ILogger<CreateGeneralSettingHandler> logger,
    [FromKeyedServices("common:generalsettings")] IRepository<GeneralSetting> repository)
    : IRequestHandler<CreateGeneralSettingCommand, CreateGeneralSettingResponse>
{
    public async Task<CreateGeneralSettingResponse> Handle(CreateGeneralSettingCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var generalsetting = GeneralSetting.Create(request.SettingName!, request.SettingValue!);
        await repository.AddAsync(generalsetting, cancellationToken);
        logger.LogInformation("generalsetting created {GeneralSettingId}", generalsetting.Id);
        return new CreateGeneralSettingResponse(generalsetting.Id);
    }
}
