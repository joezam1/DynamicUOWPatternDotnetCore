 
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using project.Data.Interfaces;
using project.Data.Context;

namespace project.Data.UnitOfWork
{
    public class UnitOfWorkRepository:  IUnitOfWorkRepository
    {
        public DataContext _context{get;}
        public UnitOfWorkRepository(DataContext context)
        {
            _context = context;
        }

        private List<UnitOfWorkEntity> insertEntities = new List<UnitOfWorkEntity>();
        private List<UnitOfWorkEntity> updateEntities = new List<UnitOfWorkEntity>();
        private List<UnitOfWorkEntity> deleteEntities = new List<UnitOfWorkEntity>();

        public async Task<T> GetBySelectedIdAsync<T>(int id) where T : class, new()
        {
            var result = await _context.Set<T>().FindAsync(id);
            if(result !=null)
            {
                _context.Entry(result).State = EntityState.Detached;
            }
            
            return result;
        }

        public void SetEntitiesToInsert(UnitOfWorkEntity entity)
        {
            insertEntities.Add(entity);
        }
        public void SetEntitiesToUpdate(UnitOfWorkEntity entity)
        {
            updateEntities.Add(entity);
        }
        public void SetEntitiesToDelete(UnitOfWorkEntity entity)
        {
            deleteEntities.Add(entity);
        }
        public async Task<int> Commit()
        {
            try
            {
                foreach(var entity in insertEntities)
                {
                    await _context.AddAsync(entity);
                }

                foreach(var entity in updateEntities)
                {
                    _context.Set<UnitOfWorkEntity>().Attach(entity);   
                    var result = _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                foreach(var entity in deleteEntities)
                {
                    // detach
                    _context.Entry(entity).State = EntityState.Detached;
                    var result = _context.Set<UnitOfWorkEntity>().Remove(entity);
                   
                }
                 var saved = await _context.SaveChangesAsync();
                 return saved;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}