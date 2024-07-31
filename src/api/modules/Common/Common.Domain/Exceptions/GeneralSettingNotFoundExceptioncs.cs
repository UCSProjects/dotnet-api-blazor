using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Common.Domain.Exceptions;
public sealed class GeneralSettingNotFoundException : NotFoundException
{
    public GeneralSettingNotFoundException(Guid id)
        : base($"generalsetting with id {id} not found")
    {
    }
}
