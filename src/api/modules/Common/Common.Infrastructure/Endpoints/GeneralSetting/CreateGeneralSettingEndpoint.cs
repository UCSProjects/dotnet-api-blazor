using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Common.Application.GeneralSettings.Create;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Common.Infrastructure.Endpoints.GeneralSetting;
public static class CreateGeneralSettingEndpoint
{
    internal static RouteHandlerBuilder MapGeneralSettingCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateGeneralSettingCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateGeneralSettingEndpoint))
            .WithSummary("creates a generalsetting")
            .WithDescription("creates a generalsetting")
            .Produces<CreateGeneralSettingResponse>()
            .RequirePermission("Permissions.GeneralSettings.Create")
            .MapToApiVersion(1);
    }
}
