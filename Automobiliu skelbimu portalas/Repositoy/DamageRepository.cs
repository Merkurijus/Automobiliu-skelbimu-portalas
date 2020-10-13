﻿using Automobiliu_skelbimu_portalas.Contracts;
using Automobiliu_skelbimu_portalas.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Repository
{
    public class DamageRepository : IDamageRepository
    {
        private readonly ApplicationDbContext _db;
        public DamageRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Damage entity)
        {
            await _db.Damages.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Damage entity)
        {
            _db.Damages.Remove(entity);
            return await Save();
        }

        public async Task<bool> Edit(Damage entity)
        {
            _db.Damages.Update(entity);
            return await Save();
        }

        public async Task<List<Damage>> FindAll()
        {
            var data = await _db.Damages.ToListAsync();
            return data;
        }

        public async Task<Damage> FindById(int id)
        {
            var data = await _db.Damages.FindAsync(id);
            return data;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Damage entity)
        {
            _db.Damages.Update(entity);
            return await Save();
        }
    }
}
