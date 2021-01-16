using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using project.Data.Context;
using project.Data.Interfaces;


namespace project.Data.Repositories
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : class, new()
    {
        protected readonly DataContext _dataContext;

        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _dataContext.Set<TEntity>();
            }
            catch(Exception ex)
            {
                throw new Exception($"couln't retrieve entities {ex.Message}. Errpr: {ex}");
            }
        }

        public async Task<TEntity> GetBySelectedIdAsync(int id)
        {
            var result = await _dataContext.Set<TEntity>().FindAsync(id);
            return result;
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
           var result = _dataContext.Set<TEntity>().Where(predicate).AsEnumerable<TEntity>();
           return result;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }
            try
            {
                await _dataContext.AddAsync(entity);
                await _dataContext.SaveChangesAsync();
                return entity;
            
            }
            catch(Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {            
                _dataContext.Set<TEntity>().Attach(entity);   
                var result = _dataContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                
                await _dataContext.SaveChangesAsync();
                
                
                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
        public async Task<TEntity> DeleteAsync(int id)
        {
            TEntity existing =await _dataContext.Set<TEntity>().FindAsync(id);
            if(existing !=null)
            {
                _dataContext.Set<TEntity>().Remove(existing);
                await _dataContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException($"{nameof(existing)} entity is null");
            }
            return existing;
        }

    }
}