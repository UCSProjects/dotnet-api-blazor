using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Common.Application.GeneralSettings.Get;
using MediatR;

namespace FSH.Starter.WebApi.Common.Application.GeneralSettings.Search;

public record SearchGeneralSettingsCommand(PaginationFilter filter) : IRequest<PagedList<GeneralSettingResponse>>;
