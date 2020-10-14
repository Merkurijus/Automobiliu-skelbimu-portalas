using Automobiliu_skelbimu_portalas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Contracts
{
    public interface IAdRepository : IRepositoryBase<Ad>
    {
        public Task<List<Ad>> GetSearchResults(Ad enitity);
    }
}
