using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProducts.Data.Repository.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ProductDBContext _productContext;

        public GenericRepository(ProductDBContext productContext)
        {
            this._productContext = productContext;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            _productContext.Set<TEntity>().Remove(entity);
            await _productContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _productContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _productContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            _productContext.Set<TEntity>().Add(entity);
            await _productContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _productContext.Entry(entity).State = EntityState.Modified;
            //universityContext.Set<TEntity>().AddOrUpdate(entity);
            await _productContext.SaveChangesAsync();
            return entity;
        }
    }
}
