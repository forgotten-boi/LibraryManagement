﻿using Microsoft.EntityFrameworkCore;
using LibMS.Entity.BaseEntity;
using LibMS.Entity.DtoModel;
using LibMS.Entity.Entities;
using LibMS.Infrastructure.Extensions;
using LibMS.Repository.Irepositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LibMS.Services.IServices;

namespace LibMS.Services.Services
{
    public abstract class ApplicationService<T, T2> : IApplicationService<T, T2> where T : BaseEntity<T2>
    {
        public ApplicationService(IRepository<T, T2> repository)
        {
            Repository = repository;
        }


        public IRepository<T, T2> Repository { get; }

        public virtual async Task AddAsync(T entity)
        {
            await Repository.AddAsync(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await Task.Run(() => Repository.Update(entity));

        }

        public virtual async Task DeleteAsync(T2 id)
        {
            await Repository.DeleteAsync(id);

        }

        public virtual async Task<T> GetByIDAsync(T2 id)
        {
            return await Repository.GetByIDAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> where)
        {
            return await Repository.GetFilteredAsync(where);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }
        public virtual async Task<T> FindByAsync(Expression<Func<T, bool>> where)
        {
            return await Repository.FindByIdAsync(where);
        }
        public virtual async Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            await Repository.DeleteAsync(where);
        }
    }
}
