using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibMS.Repository.Irepositories
{
    public interface IRepository<T, T2> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIDAsync(T2 id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> where);

        T GetById(T2 Id);
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        void Save(T entity);
        Task SaveAsync();
        void Save();
        void Delete(T entity);
        void Delete(T2 Id);
        Task DeleteAsync(T2 Id);
        Task DeleteAsync(Expression<Func<T, bool>> match);
        Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindByIdAsync(Expression<Func<T, bool>> where);
        IQueryable<T> TableAsNoTracking { get; }
        IQueryable<T> Table { get; }



    }
}
