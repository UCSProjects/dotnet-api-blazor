using MediatR;

namespace FSH.Starter.WebApi.Common.Application.GeneralSettings.Get;
public class GetGeneralSettingRequest : IRequest<GeneralSettingResponse>
{
    public Guid Id { get; set; }
    public GetGeneralSettingRequest(Guid id) => Id = id;
}
