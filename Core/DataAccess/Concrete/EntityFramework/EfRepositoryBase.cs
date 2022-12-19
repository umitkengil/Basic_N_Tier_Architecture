﻿using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using(var context = new TContext())
            {
                var addedEntity = context.Add(entity);
                addedEntity.State= EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Remove(entity);
                deletedEntity.State= EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using(var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using(var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public async Task<bool> GetById(Expression<Func<TEntity, bool>> filter)
        {
            using(var context = new TContext())
            {
                return await context.Set<TEntity>().AnyAsync(filter);
            }
        }

        public void Update(TEntity entity)
        {
            using(var context = new TContext())
            {
                var updatedEntity = context.Update(entity);
                updatedEntity.State= EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
