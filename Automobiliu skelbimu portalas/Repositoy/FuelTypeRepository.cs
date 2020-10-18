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
    public class FuelTypeRepository : IFuelTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public FuelTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(FuelType entity)
        {
            await _db.FuelTypes.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(FuelType entity)
        {
            _db.FuelTypes.Remove(entity);
            return await Save();
        }

        public async Task<bool> Edit(FuelType entity)
        {
            _db.FuelTypes.Update(entity);
            return await Save();
        }

        public async Task<List<FuelType>> FindAll()
        {
            var data = await _db.FuelTypes.ToListAsync();
            return data;
        }

        public async Task<FuelType> FindById(int id)
        {
            var data = await _db.FuelTypes.FindAsync(id);
            return data;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(FuelType entity)
        {
            _db.FuelTypes.Update(entity);
            return await Save();
        }
        public async Task<IEnumerable<SelectListItem>> GetSelectListItem()
        {
            var data = await _db.FuelTypes.ToListAsync();
            var selectItems = data.Select(q => new SelectListItem
            {
                Text = q.Title,
                Value = q.Id.ToString()
            });
            return selectItems;
        }
    }
}
