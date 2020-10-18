using Automobiliu_skelbimu_portalas.Data;
using Automobiliu_skelbimu_portalas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Contracts
{
    public interface IAdRepository : IRepositoryBase<Ad>
    {
        public Task<List<Ad>> GetSearchResults(SearchAdVM searches);
        public List<int> GetPriceList();
        public IEnumerable<int> GetYearList();
  
    }
}
