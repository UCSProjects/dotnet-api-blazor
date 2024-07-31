using Finbuckle.MultiTenant;
using FSH.Starter.WebApi.Common.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Starter.WebApi.Common.Infrastructure.Persistence.Configurations;
internal sealed class GeneralSettingConfiguration : IEntityTypeConfiguration<GeneralSetting>
{
    public void Configure(EntityTypeBuilder<GeneralSetting> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.SettingValue).HasMaxLength(200);
        builder.Property(x => x.SettingValue).HasMaxLength(8000);
    }
}
