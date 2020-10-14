using Automobiliu_skelbimu_portalas.Contracts;
using Automobiliu_skelbimu_portalas.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Repository
{

    public class AdRepository : IAdRepository
    {

        private readonly ApplicationDbContext _db;
        public AdRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<bool> Create(Ad entity)
        {
            _db.Ads.Add(entity);
            return Save();
        }

        public Task<bool> Delete(Ad entity)
        {
            _db.Ads.Remove(entity);
            return Save();
        }

        public async Task<bool> Edit(Ad entity)
        {
            _db.Ads.Update(entity);
            return await Save();
        }

        public async Task<List<Ad>> FindAll()
        {
            var data = await _db.Ads.
                Include(q => q.CarMake).
                Include(q => q.CarModel).
                Include(q => q.FuelType).
                Include(q => q.BodyType).
                Include(q => q.Damage).
                Include(q => q.Color).
                Include(q => q.GearBox).
                ToListAsync();
            return data;
        }

        public async Task<Ad> FindById(int id)
        {
            var data = await _db.Ads
                .Include(q => q.CarMake)
                .Include(q => q.CarModel)
                .Include(q => q.FuelType)
                .Include(q => q.BodyType)
                .Include(q => q.Damage)
                .Include(q => q.Color)
                .Include(q => q.GearBox)
                .FirstOrDefaultAsync(q => q.Id == id);
            return data;
        }

        public async Task<bool> Save()
        {
            var isSuccess = await _db.SaveChangesAsync();
            return isSuccess > 0;
        }

        public async Task<bool> Update(Ad entity)
        {
            _db.Ads.Update(entity);
            return await Save();
        }
    }
        
}
