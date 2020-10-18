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
    public class BodyTypeRepository : IBodyTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public BodyTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<bool> Create(BodyType entity)
        {
            _db.BodyTypes.Add(entity);
            return Save();
        }

        public Task<bool> Delete(BodyType entity)
        {
            _db.BodyTypes.Remove(entity);
            return Save();
        }

        public async Task<bool> Edit(BodyType entity)
        {
            _db.BodyTypes.Update(entity);
            return await Save();
        }

        public async Task<List<BodyType>> FindAll()
        {
            var data =  await _db.BodyTypes.ToListAsync();
            return data;
        }

        public async Task<BodyType> FindById(int id)
        {
            var data = await _db.BodyTypes.FindAsync(id);
            return data;
        }

        public async Task<bool> Save()
        {
            var isSuccess = await _db.SaveChangesAsync();
            return isSuccess > 0;
        }

        public async Task<bool> Update(BodyType entity)
        {
            _db.BodyTypes.Update(entity);
            return await Save();
        }
        public async Task<IEnumerable<SelectListItem>> GetSelectListItem()
        {
            var data = await _db.BodyTypes.ToListAsync();
            var selectItems = data.Select(q => new SelectListItem
            {
                Text = q.Title,
                Value = q.Id.ToString()
            });
            return selectItems;
        }
    }
}
