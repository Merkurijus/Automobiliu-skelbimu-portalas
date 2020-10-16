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
            if (searches.PriceFromInt > 0)
            {
                searchResults = searchResults.Where(x => x.Price >= searches.PriceFromInt).ToList();
            }
            if (searches.PriceToInt > 0)
            {
                searchResults = searchResults.Where(x => x.Price <= searches.PriceToInt).ToList();
            }
            if (searches.YearFromInt > 0)
            {
                searchResults = searchResults.Where(x => x.Year >= searches.YearFromInt).ToList();
            }
            if (searches.YearToInt > 0)
            {
                searchResults = searchResults.Where(x => x.Year <= searches.YearToInt).ToList();
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
        public List<int> GetPriceList(List<int> price)
        {
            for (int i = 0; i < 50000; i += 500)
            {
                if (i == 0)
                {
                    price.Add(100);
                }
                else if (i > 5000 && i <= 10000 && i % 1000 != 0)
                {
                    continue;
                }
                else if (i > 10000 && i % 5000 != 0)
                {
                    continue;
                }
                else
                {
                    price.Add(i);
                }
            }
            return price;
        }
        public IEnumerable<int> GetYearList()
        {
            var howManyYears = DateTime.Now.Year - 1979;
            var year = Enumerable.Range(1980, howManyYears);
            return year;
        }
    }
        
}
