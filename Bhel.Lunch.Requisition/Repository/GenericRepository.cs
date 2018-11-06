﻿using Bhel.Lunch.Requisition.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Bhel.Lunch.Requisition.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal RequisitionEntities context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(RequisitionEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                         string includeProperties = "")
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (filter == null)
            {
                query = query.Where(filter);
            }
            foreach (string includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public IEnumerable<TEntity> Get()
        {
            return dbSet;
        }
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

    }
}