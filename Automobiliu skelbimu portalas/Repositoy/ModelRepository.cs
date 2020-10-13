using Automobiliu_skelbimu_portalas.Contracts;
using Automobiliu_skelbimu_portalas.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Repository
{
    public class ModelRepository : IModelRepository
    {
        private readonly ApplicationDbContext _db;
        public ModelRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Model entity)
        {
            await _db.Models.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Model entity)
        {
            _db.Models.Remove(entity);
            return await Save();
        }

        public async Task<bool> Edit(Model entity)
        {
            _db.Models.Update(entity);
            return await Save();
        }

        public async Task<List<Model>> FindAll()
        {
            var damages = await _db.Models.ToListAsync();
            return damages;
        }

        public async Task<Model> FindById(int id)
        {
            var damage = await _db.Models.FindAsync(id);
            return damage;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Model entity)
        {
            _db.Models.Update(entity);
            return await Save();
        }
    }
}
