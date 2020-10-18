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
    public class ColorRepository : IColorRepository
    {
        private readonly ApplicationDbContext _db;
        public ColorRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Color entity)
        {
            await _db.Colors.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Color entity)
        {
            _db.Colors.Remove(entity);
            return await Save();
        }

        public async Task<bool> Edit(Color entity)
        {
            _db.Colors.Update(entity);
            return await Save();
        }

        public async Task<List<Color>> FindAll()
        {
            var data = await _db.Colors.ToListAsync();
            return data;
        }

        public async Task<Color> FindById(int id)
        {
            var data = await _db.Colors.FindAsync(id);
            return data;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Color entity)
        {
            _db.Colors.Update(entity);
            return await Save();
        }
        public async Task<IEnumerable<SelectListItem>> GetSelectListItem()
        {
            var data = await _db.Colors.ToListAsync();
            var selectItems = data.Select(q => new SelectListItem
            {
                Text = q.Title,
                Value = q.Id.ToString()
            });
            return selectItems;
        }
    }
}
