using Automobiliu_skelbimu_portalas.Contracts;
using Automobiliu_skelbimu_portalas.Data;
using Automobiliu_skelbimu_portalas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            if (searches.CarMakeId > 0)
            {
                searchResults = searchResults.Where(x => x.CarMakeId == searches.CarMakeId).ToList();
            }
            if (searches.CarModelId > 0)
            {
                searchResults = searchResults.Where(x => x.CarModelId == searches.CarModelId).ToList();
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
            if (searches.BodyTypeId > 0)
            {
                searchResults = searchResults.Where(x => x.BodyTypeId == searches.BodyTypeId).ToList();
            }

            if (searches.ColorId > 0)
            {
                searchResults = searchResults.Where(x => x.ColorId == searches.ColorId).ToList();
            }
            if (searches.DamageId > 0)
            {
                searchResults = searchResults.Where(x => x.DamageId == searches.DamageId).ToList();
            }
            if (searches.FuelTypeId > 0)
            {
                searchResults = searchResults.Where(x => x.FuelTypeId == searches.FuelTypeId).ToList();
            }
            if (searches.GearBoxId > 0)
            {
                searchResults = searchResults.Where(x => x.GearBoxId == searches.GearBoxId).ToList();
            }
            return searchResults;
        }
     
    }
        
}
