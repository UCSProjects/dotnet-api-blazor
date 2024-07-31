using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Common.Application.GeneralSettings.Get;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Common.Infrastructure.Endpoints.GeneralSetting;
public static class GetGeneralSettingEndpoint
{
    internal static RouteHandlerBuilder MapGetGeneralSettingEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetGeneralSettingRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetGeneralSettingEndpoint))
            .WithSummary("gets generalsetting by id")
            .WithDescription("gets general setting by id")
            .Produces<GeneralSettingResponse>()
            .RequirePermission("Permissions.GeneralSettings.View")
            .MapToApiVersion(1);
    }
}
