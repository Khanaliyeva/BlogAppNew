using BlogApp.Core.Entities.Common;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories.Implimentations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();


        public async Task<IQueryable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>>? expression = null,
            Expression<Func<TEntity, object>>? orderByExpression = null,
            bool isDescending = false,
            params string[] includes)
        {
            IQueryable<TEntity> query = Table.Where(e => !e.IsDeleted);


            if(expression != null)
            {
                query= query.Where(expression);
            }

            if(orderByExpression != null)
            {
                query=isDescending? query.OrderByDescending(orderByExpression):
                    query.OrderBy(orderByExpression);
            }

            if(includes != null)
            {
                for(int i=0;i<includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }

            return query;
        }
        public async Task CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task<TEntity> FindById(int id)
        {
            return await Table.FirstOrDefaultAsync(e => e.Id == id);

        }
                  
        public async Task<bool> IExisted(int id)
        {
            return await Table.AnyAsync(e => e.Id == id && !e.IsDeleted);
        }

        public async Task<int> SavaChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            (await FindById(id)).IsDeleted = true;
        }
    }
}
