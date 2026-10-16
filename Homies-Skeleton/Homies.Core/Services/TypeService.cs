using Homies.Data;
using Homies.DTO.Type;
using Homies.Services.Core.Contracts;

namespace Homies.Services.Core.Services
{
    public class TypeService(HomiesDbContext dbContext) : ITypeService
    {
        public IEnumerable<TypeViewModel> GetTypes()
        {
            return dbContext.Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                });
        }
    }
}
