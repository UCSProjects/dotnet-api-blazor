using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Common.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Common.Infrastructure.Persistence;
internal sealed class CommonDbInitializer(
    ILogger<CommonDbInitializer> logger,
    CommonDbContext context) : IDbInitializer
{
    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        if ((await context.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
        {
            await context.Database.MigrateAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] applied database migrations for common module", context.TenantInfo!.Identifier);
        }
    }

    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        const string SettingName = "UserLimitation";
        const string SettingValue = "1000";
        if (await context.GeneralSettings.FirstOrDefaultAsync(t => t.SettingName == SettingName, cancellationToken).ConfigureAwait(false) is null)
        {
            var generalsetting = GeneralSetting.Create(SettingName, SettingValue);
            await context.GeneralSettings.AddAsync(generalsetting, cancellationToken);
            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] seeding default common data", context.TenantInfo!.Identifier);
        }
    }
}
