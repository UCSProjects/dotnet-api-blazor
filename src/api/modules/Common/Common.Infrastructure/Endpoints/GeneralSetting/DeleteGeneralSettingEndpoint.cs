using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Common.Application.GeneralSettings.Delete;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Common.Infrastructure.Endpoints.GeneralSetting;
public static class DeleteGeneralSettingEndpoint
{
    internal static RouteHandlerBuilder MapGeneralSettingDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
             {
                 await mediator.Send(new DeleteGeneralSettingCommand(id));
                 return Results.NoContent();
             })
            .WithName(nameof(DeleteGeneralSettingEndpoint))
            .WithSummary("deletes general setting by id")
            .WithDescription("deletes general setting by id")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.GeneralSettings.Delete")
            .MapToApiVersion(1);
    }
}
