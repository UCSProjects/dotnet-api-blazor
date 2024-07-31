using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Common.Domain.Events;

namespace FSH.Starter.WebApi.Common.Domain;
public class GeneralSetting : AuditableEntity, IAggregateRoot
{
    public string SettingName { get; private set; } = default!;
    public string SettingValue { get; private set; } = default!;

    public static GeneralSetting Create(string settingname, string settingvalue)
    {
        var generalsetting = new GeneralSetting
        {
            SettingName = settingname,
            SettingValue = settingvalue
        };

        generalsetting.QueueDomainEvent(new GeneralSettingCreated() { GeneralSetting = generalsetting });

        return generalsetting;
    }
    public GeneralSetting Update(string? settingname, string settingvalue)
    {
        if (settingname is not null && SettingName?.Equals(settingname, StringComparison.OrdinalIgnoreCase) is not true) SettingName = settingname;
        if (settingvalue is not null && SettingValue?.Equals(settingvalue, StringComparison.OrdinalIgnoreCase) is not true) SettingValue = settingvalue;

        this.QueueDomainEvent(new GeneralSettingUpdated() { GeneralSetting = this });
        return this;
    }

    public static GeneralSetting Update(Guid id, string settingname, string settingvalue)
    {
        var generalsetting = new GeneralSetting
        {
            Id = id,
            SettingName = settingname,
            SettingValue = settingvalue
        };

        generalsetting.QueueDomainEvent(new GeneralSettingUpdated() { GeneralSetting = generalsetting });

        return generalsetting;
    }
}
