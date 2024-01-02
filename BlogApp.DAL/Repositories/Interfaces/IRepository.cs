﻿using BlogApp.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<IQueryable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>>? expression = null,
            Expression<Func<TEntity, object>>? orderByExpression = null,
            bool isDescending = false,
            params string[] includes);

        DbSet<TEntity> Table {  get; }

        Task CreateAsync(TEntity entity);

        Task<TEntity> FindById(int id);
        Task<bool> IExisted(int  id);
        Task<int> SavaChangesAsync();
        Task Remove(int id);

    }
}
