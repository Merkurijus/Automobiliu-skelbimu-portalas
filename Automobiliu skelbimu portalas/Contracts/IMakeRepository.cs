using Automobiliu_skelbimu_portalas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Contracts
{
    public interface IMakeRepository : IRepositoryBase<Make>
    {
        public Task<IEnumerable<SelectListItem>> GetSelectListItem();
        public Task<bool> isExist(string title);
    }
}
