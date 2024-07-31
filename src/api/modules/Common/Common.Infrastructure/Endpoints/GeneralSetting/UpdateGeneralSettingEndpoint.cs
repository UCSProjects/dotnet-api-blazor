using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Common.Application.GeneralSettings.Update;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Common.Infrastructure.Endpoints.GeneralSetting;
public static class UpdateGeneralSettingEndpoint
{
    internal static RouteHandlerBuilder MapGeneralSettingUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateGeneralSettingCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateGeneralSettingEndpoint))
            .WithSummary("update a general setting")
            .WithDescription("update a general setting")
            .Produces<UpdateGeneralSettingResponse>()
            .RequirePermission("Permissions.GeneralSettings.Update")
            .MapToApiVersion(1);
    }
}
