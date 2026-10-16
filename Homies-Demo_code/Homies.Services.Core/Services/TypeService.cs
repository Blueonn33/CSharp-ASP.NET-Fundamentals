using Homies.Data;
using Homies.DataTransferObjects.Type;
using Homies.Services.Core.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services.Core.Services
{
    public class TypeService : ITypeService
    {
        private readonly HomiesDbContext dbContext;

        public TypeService(HomiesDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<IEnumerable<TypeViewModel>> GetTypesAsync()
        {
            return await dbContext
                .Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }
    }
}
