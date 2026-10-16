using Homies.DataTransferObjects.Type;

namespace Homies.Services.Core.Contracts
{
    public interface ITypeService
    {
        Task<IEnumerable<TypeViewModel>> GetTypesAsync();
    }
}
