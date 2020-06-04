using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace CPMusic.Data.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// Lấy tất cả các bản ghi
        /// </summary>
        Task<IEnumerable<T>> All();

        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <param name="selector">Các cột cần chọn</param>
        /// <param name="predicate">Điều kiện</param>
        /// <param name="orderBy">Sắp xếp</param>
        /// <param name="include">Các mối quan hệ</param>
        /// <param name="take">Số bản ghi cần lấy</param>
        /// <param name="disableTracking">Tắt theo dõi sự thay đổi của bản ghi</param>
        Task<IEnumerable<TResult>> All<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            int take = 0,
            bool disableTracking = true);

        /// <summary>
        /// Lấy bản ghi phù hợp với Id
        /// </summary>
        Task<T?> GetByIdAsync(Guid id);

        /// <summary>
        /// Lấy bản ghi phù hợp với Id cùng với dữ liệu có liên quan
        /// </summary>
        Task<T?> GetByIdAsync(Guid id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include);

        /// <summary>
        /// Là một hàm query được viết lại để dễ dàng tái sử dụng
        /// </summary>
        /// <param name="selector">Các cột cần chọn</param>
        /// <param name="predicate">Điều kiện</param>
        /// <param name="orderBy">Sắp xếp</param>
        /// <param name="include">Các mối quan hệ</param>
        /// <param name="take">Số bản ghi cần lấy</param>
        /// <param name="disableTracking">Tắt theo dõi sự thay đổi của bản ghi</param>
        IQueryable<TResult> Query<TResult>(Expression<Func<T, TResult>> selector,
                                           Expression<Func<T, bool>>? predicate = null,
                                           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                           int take = 0,
                                           bool disableTracking = true);

        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<T> Delete(Guid id);

        /// <summary>
        /// Thống kê tốc độ tăng trưởng dữ liệu giữa tháng hiện tại và tháng trước
        /// </summary>
        /// <returns>
        /// Giá trị trả về là một cặp dữ liệu, giá trị đầu là tổng số bản ghi đang có, giá trị hai là tốc độ tăng trưởng
        /// dữ liệu của tháng hiện tại
        /// </returns>
        Task<(int, double)> GrowthRate();

        /// <summary>
        /// Lấy số lượng bản ghi của từng tháng, tính từ tháng 1 đến tháng hiện tại, năm hiện tại
        /// </summary>
        /// <example>
        /// Tháng hiện tại: 5
        /// Kết quả [0, 1, 2, 3, 4]
        /// Nghĩa là tháng 1 có 0 bản ghi, tháng 2 có 1 bản ghi, tháng 3 có 2 bản ghi và tháng 4 có 4 bản ghi
        /// </example>
        /// <returns>Một mảng số nguyên có độ dài là n (n là tháng hiện tại)</returns>
        IEnumerable<int> StatisticsPerMonth();
    }
}