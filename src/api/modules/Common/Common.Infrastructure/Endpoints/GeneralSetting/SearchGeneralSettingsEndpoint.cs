using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Common.Application.GeneralSettings.Get;
using FSH.Starter.WebApi.Common.Application.GeneralSettings.Search;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Common.Infrastructure.Endpoints.GeneralSetting;

public static class SearchGeneralSettingsEndpoint
{
    internal static RouteHandlerBuilder MapGetGeneralSettingListEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async (ISender mediator, [FromBody] PaginationFilter filter) =>
            {
                var response = await mediator.Send(new SearchGeneralSettingsCommand(filter));
                return Results.Ok(response);
            })
            .WithName(nameof(SearchGeneralSettingsEndpoint))
            .WithSummary("Gets a list of GeneralSettings")
            .WithDescription("Gets a list of GeneralSettings with pagination and filtering support")
            .Produces<PagedList<GeneralSettingResponse>>()
            .RequirePermission("Permissions.GeneralSettings.View")
            .MapToApiVersion(1);
    }
}

