using Automobiliu_skelbimu_portalas.Contracts;
using Automobiliu_skelbimu_portalas.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Repository
{
    public class SearchesRepository : ISearchesRepository
    {
        private readonly ApplicationDbContext _db;
        public SearchesRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Searches entity)
        {
            await _db.SearchesList.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Searches entity)
        {
            _db.SearchesList.Remove(entity);
            return await Save();
        }

        public async Task<bool> Edit(Searches entity)
        {
            _db.SearchesList.Update(entity);
            return await Save();
        }

        public async Task<List<Searches>> FindAll()
        {
            var data = await _db.SearchesList.ToListAsync();
            return data;
        }

        public async Task<Searches> FindById(int id)
        {
            var data = await _db.SearchesList.FindAsync(id);
            return data;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Searches entity)
        {
            _db.SearchesList.Update(entity);
            return await Save();
        }
    }
}
