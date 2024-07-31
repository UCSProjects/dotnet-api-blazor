using Carter;
using Common.Infrastructure.Endpoints.GeneralSetting;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using FSH.Starter.WebApi.Common.Domain;
using FSH.Starter.WebApi.Common.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Common.Infrastructure;
public static class CommonModule
{
    public class Endpoints : CarterModule
    {
        public Endpoints() : base("common") { }
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var generalsettingGroup = app.MapGroup("generalsettings").WithTags("generalsettings");
            generalsettingGroup.MapGeneralSettingCreationEndpoint();
            generalsettingGroup.MapGetGeneralSettingEndpoint();
            generalsettingGroup.MapGetGeneralSettingListEndpoint();
            generalsettingGroup.MapGeneralSettingUpdateEndpoint();
            generalsettingGroup.MapGeneralSettingDeleteEndpoint();
        }
    }
    public static WebApplicationBuilder RegisterCommonServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Services.BindDbContext<CommonDbContext>();
        builder.Services.AddScoped<IDbInitializer, CommonDbInitializer>();
        builder.Services.AddKeyedScoped<IRepository<GeneralSetting>, CommonRepository<GeneralSetting>>("common:generalsettings");
        builder.Services.AddKeyedScoped<IReadRepository<GeneralSetting>, CommonRepository<GeneralSetting>>("common:generalsettings");
        return builder;
    }
    public static WebApplication UseCommonModule(this WebApplication app)
    {
        return app;
    }
}
