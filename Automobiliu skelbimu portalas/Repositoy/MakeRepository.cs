using Automobiliu_skelbimu_portalas.Contracts;
using Automobiliu_skelbimu_portalas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var data = await _db.Makes.ToListAsync();
            return data;
        }

        public async Task<Make> FindById(int id)
        {
            var data = await _db.Makes.FindAsync(id);
            return data;
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
        public async Task<IEnumerable<SelectListItem>> GetSelectListItem()
        {
            var data = await _db.Makes.ToListAsync();
            var selectItems = data.Select(q => new SelectListItem
            {
                Text = q.Title,
                Value = q.Id.ToString()
            });
            return selectItems;
        }
    }
}
