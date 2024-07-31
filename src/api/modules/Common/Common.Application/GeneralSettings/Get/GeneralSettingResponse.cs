namespace FSH.Starter.WebApi.Common.Application.GeneralSettings.Get;
public sealed record GeneralSettingResponse(Guid? Id, string SettingName, string SettingValue);
