using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Common.Application.GeneralSettings.Get;
using FSH.Starter.WebApi.Common.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace FSH.Starter.WebApi.Common.Application.GeneralSettings.Search;
public sealed class SearchGeneralSettingsHandler(
    [FromKeyedServices("common:generalsettings")] IReadRepository<GeneralSetting> repository)
    : IRequestHandler<SearchGeneralSettingsCommand, PagedList<GeneralSettingResponse>>
{
    public async Task<PagedList<GeneralSettingResponse>> Handle(SearchGeneralSettingsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new EntitiesByPaginationFilterSpec<GeneralSetting, GeneralSettingResponse>(request.filter);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<GeneralSettingResponse>(items, request.filter.PageNumber, request.filter.PageSize, totalCount);
    }
}

