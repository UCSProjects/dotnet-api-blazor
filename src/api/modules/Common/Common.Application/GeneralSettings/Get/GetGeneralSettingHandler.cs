using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Common.Domain;
using FSH.Starter.WebApi.Common.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Common.Application.GeneralSettings.Get;
public sealed class GetGeneralSettingHandler(
    [FromKeyedServices("common:generalsettings")] IReadRepository<GeneralSetting> repository,
    ICacheService cache)
    : IRequestHandler<GetGeneralSettingRequest, GeneralSettingResponse>
{
    public async Task<GeneralSettingResponse> Handle(GetGeneralSettingRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"generalsetting:{request.Id}",
            async () =>
            {
                var generalsettingItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (generalsettingItem == null) throw new GeneralSettingNotFoundException(request.Id);
                return new GeneralSettingResponse(generalsettingItem.Id, generalsettingItem.SettingName, generalsettingItem.SettingValue);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
