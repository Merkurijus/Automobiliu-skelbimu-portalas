using Automobiliu_skelbimu_portalas.Contracts;
using Automobiliu_skelbimu_portalas.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Repository
{
    public class MakeRepository : IMakeRepository
    {
        private readonly ApplicationDbContext _db;
        public MakeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Make entity)
        {
            await _db.Makes.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Make entity)
        {
            _db.Makes.Remove(entity);
            return await Save();
        }

        public async Task<bool> Edit(Make entity)
        {
            _db.Makes.Update(entity);
            return await Save();
        }

        public async Task<List<Make>> FindAll()
        {
            var damages = await _db.Makes.ToListAsync();
            return damages;
        }

        public async Task<Make> FindById(int id)
        {
            var damage = await _db.Makes.FindAsync(id);
            return damage;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Make entity)
        {
            _db.Makes.Update(entity);
            return await Save();
        }
    }
}
