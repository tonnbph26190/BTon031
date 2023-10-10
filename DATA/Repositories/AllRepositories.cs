
using Data.IRepositories;
using DATA.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AllRepositories<TEntity> : IAllRepositories<TEntity> where TEntity : class
    {
        private LapDbContext _dbContext;
        public DbSet<TEntity> Entities { get; set; }
        public AllRepositories(LapDbContext cuahangDbContext)
        {
            this._dbContext = cuahangDbContext;
            this.Entities = _dbContext.Set<TEntity>();
        }
        public async Task<TEntity> AddOneAsync(TEntity entity)
        {
            await this.Entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> AddManyAsync(IEnumerable<TEntity> entity)
        {
            Collection<TEntity> result = new Collection<TEntity>();
            foreach (var item in entity) // thêm từng cái 1
            {
                Collection<TEntity> collects = result;
                collects.Add(await this.AddOneAsync(item));
            }
            return (TEntity)(IEnumerable<TEntity>)result;
        }
        public async Task<TEntity> DeleteOneAsync(TEntity entity)
        {
            await Task.FromResult<TEntity>(this.Entities.Remove(entity).Entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> DeleteManyAsync(IEnumerable<TEntity> entity)
        {
            Collection<TEntity> result = new Collection<TEntity>();
            foreach (var item in entity) // thêm từng cái 1
            {
                Collection<TEntity> collects = result;
                collects.Add(await this.DeleteOneAsync(item));
            }
            return (TEntity)(IEnumerable<TEntity>)result;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await Entities.FindAsync(id);
        }
        public async Task<TEntity> UpdateOneAsync(TEntity entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entity)
        {
            Collection<TEntity> result = new Collection<TEntity>();
            foreach (var item in entity) // thêm từng cái 1
            {
                Collection<TEntity> collects = result;
                collects.Add(await this.UpdateOneAsync(item));
            }
            return (IEnumerable<TEntity>)result;
        }
        public async Task UpdateQuantity(TEntity entity, int newQuantity)
        {
            PropertyInfo quantityProperty = typeof(TEntity).GetProperty("Quatity");
            if (quantityProperty != null && quantityProperty.PropertyType == typeof(int?))
            {
                quantityProperty.SetValue(entity, newQuantity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
