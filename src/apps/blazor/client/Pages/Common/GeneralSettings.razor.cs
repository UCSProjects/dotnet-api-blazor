using FSH.Starter.Blazor.Client.Components.EntityTable;
using FSH.Starter.Blazor.Infrastructure.Api;
using FSH.Starter.Blazor.Shared;
using Mapster;
using Microsoft.AspNetCore.Components;

namespace FSH.Starter.Blazor.Client.Pages.Common;

public partial class GeneralSettings
{
    [Inject]
    protected IApiClient _client { get; set; } = default!;

    protected EntityServerTableContext<GeneralSettingResponse, Guid, GeneralSettingViewModel> Context { get; set; } = default!;

    private EntityTable<GeneralSettingResponse, Guid, GeneralSettingViewModel> _table = default!;

    protected override void OnInitialized() =>
        Context = new(
            entityName: "GeneralSetting",
            entityNamePlural: "GeneralSettings",
            entityResource: FshResources.GeneralSettings,
            fields: new()
            {
                new(genset => genset.Id,"Id", "Id"),
                new(genset => genset.SettingName,"SettingName", "SettingName"),
                new(genset => genset.SettingValue, "SettingValue", "SettingValue"),
            },
            enableAdvancedSearch: true,
            idFunc: genset => genset.Id!.Value,
            searchFunc: async filter =>
            {
                var generalsettingFilter = filter.Adapt<PaginationFilter>();

                var result = await _client.SearchGeneralSettingsEndpointAsync("1", generalsettingFilter);
                return result.Adapt<PaginationResponse<GeneralSettingResponse>>();
            },
            createFunc: async prod =>
            {
                await _client.CreateGeneralSettingEndpointAsync("1", prod.Adapt<CreateGeneralSettingCommand>());
            },
            updateFunc: async (id, prod) =>
            {
                await _client.UpdateGeneralSettingEndpointAsync("1", id, prod.Adapt<UpdateGeneralSettingCommand>());
            },
            deleteFunc: async id => await _client.DeleteGeneralSettingEndpointAsync("1", id));

    //// Advanced Search

    //private Guid _searchBrandId;
    //private Guid SearchBrandId
    //{
    //    get => _searchBrandId;
    //    set
    //    {
    //        _searchBrandId = value;
    //        _ = _table.ReloadDataAsync();
    //    }
    //}

    private decimal _searchMinimumRate;
    private decimal SearchMinimumRate
    {
        get => _searchMinimumRate;
        set
        {
            _searchMinimumRate = value;
            _ = _table.ReloadDataAsync();
        }
    }

    private decimal _searchMaximumRate = 9999;
    private decimal SearchMaximumRate
    {
        get => _searchMaximumRate;
        set
        {
            _searchMaximumRate = value;
            _ = _table.ReloadDataAsync();
        }
    }
}

public class GeneralSettingViewModel : UpdateGeneralSettingCommand
{
}
