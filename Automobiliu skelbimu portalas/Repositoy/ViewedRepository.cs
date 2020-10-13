using Automobiliu_skelbimu_portalas.Contracts;
using Automobiliu_skelbimu_portalas.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Repository
{
    public class ViewedRepository : IViewedRepository
    {
        private readonly ApplicationDbContext _db;
        public ViewedRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Viewed entity)
        {
            await _db.ViewedList.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Viewed entity)
        {
            _db.ViewedList.Remove(entity);
            return await Save();
        }

        public async Task<bool> Edit(Viewed entity)
        {
            _db.ViewedList.Update(entity);
            return await Save();
        }

        public async Task<List<Viewed>> FindAll()
        {
            var damages = await _db.ViewedList.ToListAsync();
            return damages;
        }

        public async Task<Viewed> FindById(int id)
        {
            var damage = await _db.ViewedList.FindAsync(id);
            return damage;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Viewed entity)
        {
            _db.ViewedList.Update(entity);
            return await Save();
        }
    }
}
