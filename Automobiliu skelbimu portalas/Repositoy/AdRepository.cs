using Automobiliu_skelbimu_portalas.Contracts;
using Automobiliu_skelbimu_portalas.Data;
using Automobiliu_skelbimu_portalas.Models;
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
        public async Task<List<Ad>> GetSearchResults(SearchAdVM searches)
        {
            var allData = await FindAll();
            var searchResults = allData.Where(x => x.IsApproved == true).ToList();
            if (!String.IsNullOrEmpty(searches.CarMake.Title))
            {
                searchResults = searchResults.Where(x => x.CarMake.Title.Equals(searches.CarMake.Title)).ToList();
            }
            if (!String.IsNullOrEmpty(searches.CarModel.Title))
            {
                searchResults = searchResults.Where(x => x.CarModel.Title.Equals(searches.CarModel.Title)).ToList();
            }
            if (searches.PriceFrom > 0)
            {
                searchResults = searchResults.Where(x => x.Price < searches.PriceFrom).ToList();
            }
            if (searches.PriceTo > 0)
            {
                searchResults = searchResults.Where(x => x.Price > searches.PriceTo).ToList();
            }
            if (searches.YearFrom > 0)
            {
                searchResults = searchResults.Where(x => x.Year < searches.YearTo).ToList();
            }
            if (searches.YearTo > 0)
            {
                searchResults = searchResults.Where(x => x.Year > searches.YearTo).ToList();
            }
            if (searches.EngineCapacityFrom > 0)
            {
                searchResults = searchResults.Where(x => x.EngineCapacity < searches.EngineCapacityFrom).ToList();
            }
            if (searches.EngineCapacityTo > 0)
            {
                searchResults = searchResults.Where(x => x.EngineCapacity > searches.EngineCapacityTo).ToList();
            }
            if (!String.IsNullOrEmpty(searches.BodyType.Title))
            {
                searchResults = searchResults.Where(x => x.BodyType.Title.Equals(searches.BodyType.Title)).ToList();
            }
            if (!String.IsNullOrEmpty(searches.Color.Title))
            {
                searchResults = searchResults.Where(x => x.Color.Title.Equals(searches.Color.Title)).ToList();
            }
            if (!String.IsNullOrEmpty(searches.Damage.Title))
            {
                searchResults = searchResults.Where(x => x.Damage.Title.Equals(searches.Damage.Title)).ToList();
            }
            if (!String.IsNullOrEmpty(searches.FuelType.Title))
            {
                searchResults = searchResults.Where(x => x.FuelType.Title.Equals(searches.FuelType.Title)).ToList();
            }
            if (!String.IsNullOrEmpty(searches.GearBox.Title))
            {
                searchResults = searchResults.Where(x => x.GearBox.Title.Equals(searches.GearBox.Title)).ToList();
            }
            return searchResults;
        }
      
    }
        
}
