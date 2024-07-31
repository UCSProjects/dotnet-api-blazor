using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Common.Domain.Events;
public sealed record GeneralSettingUpdated : DomainEvent
{
    public GeneralSetting? GeneralSetting { get; set; }
}
