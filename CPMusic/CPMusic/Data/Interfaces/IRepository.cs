using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPMusic.Data.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> All();
        Task<T> Get(Guid id);
        Task<T> Add(T id);
        Task<T> Update(T id);
        Task<T> Delete(Guid id);
        Task<(int, double)> GrowthRate();
        IEnumerable<int> StatisticsPerMonth(int? month = null);
    }
}
