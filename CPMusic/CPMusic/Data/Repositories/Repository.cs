using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPMusic.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public Task<IEnumerable<TEntity>> All()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public Task<TEntity> Update(TEntity id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<(int, double)> GrowthRate()
        {
            double growth = 0;
            int month = DateTime.Now.Month;
            var record = await Context.Set<TEntity>().Select(_ => new
            {
                prevMonth = Context.Set<TEntity>().Count(col => col.CreatedAt.Month == month - 1),
                thisMonth = Context.Set<TEntity>().Count(col => col.CreatedAt.Month == month),
                total = Context.Set<TEntity>().Select(col => col.Id).Count(),
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

        /// <summary>
        /// Lấy số lượng bản ghi của từng tháng, tính từ tháng 1 đến tháng hiện tại, năm hiện tại
        /// </summary>
        /// <example>
        /// Tháng hiện tại: 5
        /// Kết quả [0, 1, 2, 3, 4]
        /// Nghĩa là tháng 1 có 0 bản ghi, tháng 2 có 1 bản ghi, tháng 3 có 2 bản ghi và tháng 4 có 4 bản ghi
        /// </example>
        /// <returns>Một mảng số nguyên có độ dài là n (n là tháng hiện tại)</returns>
        public IEnumerable<int> StatisticsPerMonth(int? month = null)
        {
            return Enumerable.Range(1, month ?? DateTime.Now.Month)
                             .GroupJoin(
                                 Context.Set<TEntity>().Where(song => song.CreatedAt.Year == DateTime.Now.Year)
                                        .Select(song => song.CreatedAt.Month),
                                 month => month,
                                 createdAtMonth => createdAtMonth,
                                 (month, monthGroup) => monthGroup.Count())
                             .ToArray();
        }
    }
}
