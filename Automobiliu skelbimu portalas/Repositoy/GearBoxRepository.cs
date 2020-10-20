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
    public class GearBoxRepository : IGearBoxRepository
    {
        private readonly ApplicationDbContext _db;
        public GearBoxRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(GearBox entity)
        {
            await _db.GearBoxes.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(GearBox entity)
        {
            _db.GearBoxes.Remove(entity);
            return await Save();
        }

       
        public async Task<List<GearBox>> FindAll()
        {
            var data = await _db.GearBoxes.ToListAsync();
            return data;
        }

        public async Task<GearBox> FindById(int id)
        {
            var data = await _db.GearBoxes.FindAsync(id);
            return data;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(GearBox entity)
        {
            _db.GearBoxes.Update(entity);
            return await Save();
        }
        public async Task<IEnumerable<SelectListItem>> GetSelectListItem()
        {
            var data = await _db.GearBoxes.ToListAsync();
            var selectItems = data.Select(q => new SelectListItem
            {
                Text = q.Title,
                Value = q.Id.ToString()
            });
            return selectItems;
        }
        public async Task<bool> isExist(string title)
        {
            var exists = await _db.GearBoxes.AnyAsync(q => q.Title.Equals(title));
            return exists;
        }
    }
}
