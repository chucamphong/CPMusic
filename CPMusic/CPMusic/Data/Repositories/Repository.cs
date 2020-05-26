using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CPMusic.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CPMusic.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly ApplicationDbContext Context;

        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<TEntity>> All()
        {
            return await Query(entity => entity).ToListAsync();
        }

        public async Task<IEnumerable<TResult>> All<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes = null,
            bool disableTracking = true)
        {
            return await Query(selector, predicate, orderBy, includes, disableTracking).ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await Query(entity => entity, entity => entity.Id == id).SingleOrDefaultAsync();
        }

        public async Task<TEntity?> GetByIdAsync(
            Guid id,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            return await Query(entity => entity, entity => entity.Id == id, include: include)
                .SingleOrDefaultAsync();
        }

        public IQueryable<TResult> Query<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>().AsQueryable();
            
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null ? orderBy(query).Select(selector) : query.Select(selector);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            var entry = Context.Entry(entity);
            entry.State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public Task<TEntity> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<(int, double)> GrowthRate()
        {
            double growth = 0;
            int month = DateTime.Now.Month;
            var record = await Context.Set<TEntity>().AsNoTracking().Select(_ => new
            {
                prevMonth = Context.Set<TEntity>().AsNoTracking().Count(col => col.CreatedAt.Month == month - 1),
                thisMonth = Context.Set<TEntity>().AsNoTracking().Count(col => col.CreatedAt.Month == month),
                total = Context.Set<TEntity>().AsNoTracking().Select(col => col.Id).Count(),
            }).Distinct().SingleAsync();

            if (record.prevMonth == 0)
            {
                growth = record.thisMonth;
            }

            if (record.prevMonth != 0)
            {
                growth = (record.thisMonth - record.prevMonth) / (double) record.prevMonth;
            }

            return (record.total, growth);
        }

        public IEnumerable<int> StatisticsPerMonth(int? month = null)
        {
            return Enumerable.Range(1, month ?? DateTime.Now.Month)
                             .GroupJoin(
                                 Context.Set<TEntity>().AsNoTracking()
                                        .Where(song => song.CreatedAt.Year == DateTime.Now.Year)
                                        .Select(song => song.CreatedAt.Month),
                                 month => month,
                                 createdAtMonth => createdAtMonth,
                                 (month, monthGroup) => monthGroup.Count())
                             .ToArray();
        }
    }
}
