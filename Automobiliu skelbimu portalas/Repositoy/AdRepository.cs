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
        public async Task<List<Ad>> GetSearchResults(Ad entity)
        {
            var allData = await FindAll();
            var searchResults = allData.Where(x => x.IsApproved == true).ToList();
            if (!String.IsNullOrEmpty(entity.CarMake.Title))
            {
                searchResults = searchResults.Where(x => x.CarMake.Title.Equals(entity.CarMake.Title)).ToList();
            }
            if (!String.IsNullOrEmpty(entity.CarModel.Title))
            {
                searchResults = searchResults.Where(x => x.CarModel.Title.Equals(entity.CarModel.Title)).ToList();
            }
            if (!String.IsNullOrEmpty(entity.BodyType.Title))
            {
                searchResults = searchResults.Where(x => x.BodyType.Title.Equals(entity.BodyType.Title)).ToList();
            }
            if (!String.IsNullOrEmpty(entity.Color.Title))
            {
                searchResults = searchResults.Where(x => x.Color.Title.Equals(entity.Color.Title)).ToList();
            }
            if (!String.IsNullOrEmpty(entity.Damage.Title))
            {
                searchResults = searchResults.Where(x => x.Damage.Title.Equals(entity.Damage.Title)).ToList();
            }
            if (!String.IsNullOrEmpty(entity.FuelType.Title))
            {
                searchResults = searchResults.Where(x => x.FuelType.Title.Equals(entity.FuelType.Title)).ToList();
            }
            if (!String.IsNullOrEmpty(entity.GearBox.Title))
            {
                searchResults = searchResults.Where(x => x.GearBox.Title.Equals(entity.GearBox.Title)).ToList();
            }
            return searchResults;
        }
    }
        
}
