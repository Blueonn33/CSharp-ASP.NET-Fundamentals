using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homies.DTO.Type;

namespace Homies.Services.Core.Contracts
{
    public interface ITypeService
    {
        IEnumerable<TypeViewModel> GetTypes();
    }
}
