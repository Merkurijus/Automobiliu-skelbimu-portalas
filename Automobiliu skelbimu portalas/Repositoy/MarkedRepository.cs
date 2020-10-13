using Automobiliu_skelbimu_portalas.Contracts;
using Automobiliu_skelbimu_portalas.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Repository
{
    public class MarkedRepository : IMarkedRepository
    {
        private readonly ApplicationDbContext _db;
        public MarkedRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Marked entity)
        {
            await _db.MarkedList.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Marked entity)
        {
            _db.MarkedList.Remove(entity);
            return await Save();
        }

        public async Task<bool> Edit(Marked entity)
        {
            _db.MarkedList.Update(entity);
            return await Save();
        }

        public async Task<List<Marked>> FindAll()
        {
            var damages = await _db.MarkedList.ToListAsync();
            return damages;
        }

        public async Task<Marked> FindById(int id)
        {
            var damage = await _db.MarkedList.FindAsync(id);
            return damage;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Marked entity)
        {
            _db.MarkedList.Update(entity);
            return await Save();
        }
    }
}
