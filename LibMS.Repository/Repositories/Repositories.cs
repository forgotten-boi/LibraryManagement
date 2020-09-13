using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using LibMS.DataAccess;
using LibMS.Repository.Irepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using System.Reflection;
using System.Threading.Tasks;

using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace LibMS.Repository.Repositories
{
    public abstract class Repository<T, T2> : IRepository<T, T2> where T : class
    {
        private ProjectDbContext _dataContext;
        private DbSet<T> _dbset;
        public Repository(ProjectDbContext DataContext)
        {
            _dataContext = DataContext;
            _dbset = DataContext.Set<T>();

        }
        public virtual IQueryable<T> GetAll()
        {
            return _dbset.AsQueryable<T>();
        }
      

        public virtual async Task<T> GetByIDAsync(T2 id)
        {
            return await _dbset.FindAsync(id);
        }
        public virtual async Task AddAsync(T entity)
        {
            try
            {
                dynamic model = entity;
                model.CreatedDate = DateTime.Now;
                await _dbset.AddAsync(model).ConfigureAwait(false);
                await SaveAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
          

        }

        public virtual T GetById(T2 id)
        {
            return _dbset.Find(id);
        }
        public virtual IQueryable<T> GetAllWithNavigation(string[] children)
        {
            if (children != null)
            {
                foreach (var child in children)
                {
                    _dbset.Include(child);
                }
            }
            return _dbset;
        }
        public IQueryable<T> GetAllWithNavigation(string[] children, Expression<Func<T, bool>> where)
        {
            if (children != null)
            {
                foreach (var child in children)
                {
                    _dbset.Include(child);
                }
            }
            return _dbset.Where(where);
        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).AsQueryable<T>();
        }

        public virtual void Add(T entity)
        {
            dynamic model = entity;
            model.CreatedDate = DateTime.Now;
            
            _dbset.Add(model);
            Save();
            
        }
        public virtual void Delete(T entity)
        {

            _dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Deleted;
            Save();
        }
        public virtual void Update(T entity)
        {
            dynamic model = entity;
            model.ModifiedDate = DateTime.Now;
            _dbset.Attach(model);
            _dataContext.Entry(model).State = EntityState.Modified;
            Save();

        }

        public virtual void Save(T entity)
        {
            _dbset.Add(entity);
            //_dataContext.SaveChanges();

        }
        public virtual async Task SaveAsync()
        {
            //_dbset.Add(entity);
            await _dataContext.SaveChangesAsync();

        }
        public virtual void Save()
        {
            //_dbset.Add(entity);
            _dataContext.SaveChanges();

        }

        
        public async Task DeleteAsync(T2 Id)
        {
            var entity = await _dbset.FindAsync(Id);
            _dbset.Remove(entity);
            await SaveAsync();

        }
        public async Task DeleteAsync(System.Linq.Expressions.Expression<Func<T, bool>> match)
        {
            var entities = await _dbset.Where(match).ToListAsync();
            foreach (var entity in entities)
            {
                _dbset.Remove(entity);
            }

            await SaveAsync();

        }
        
        public virtual async Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> where)
        {
            return await _dbset.Where(where).ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }
        public virtual async Task<T> FindByIdAsync(Expression<Func<T, bool>> where)
        {
            return await Task.FromResult<T>(_dbset.Where(where).SingleOrDefault());
        }


        public void Delete(T2 id)
        {
            var entity = _dbset.Find(id);
            _dbset.Remove(entity);
            Save();
        }

        public virtual IQueryable<T> TableAsNoTracking
        {
            get
            {
                return _dbset.AsNoTracking();
            }
        }
        public virtual IQueryable<T> Table
        {
            get
            {
                return _dbset.AsTracking();
            }
        }

        public static void SetItemFromRow<T1>(T1 item, DataRow row) where T1 : new()
        {
            // go through each column
            foreach (DataColumn c in row.Table.Columns)
            {

                // find the property for the column
                PropertyInfo p = item.GetType().GetProperty(c.ColumnName);

                // if exists, set the value
                if (p != null && row[c] != DBNull.Value)
                {
                    if (p.PropertyType == typeof(int))
                    {
                        p.SetValue(item, Convert.ToInt32(row[c]), null);
                    }
                    else
                    {
                        p.SetValue(item, row[c], null);
                    }
                }
            }
        }
     
    }

    
}
