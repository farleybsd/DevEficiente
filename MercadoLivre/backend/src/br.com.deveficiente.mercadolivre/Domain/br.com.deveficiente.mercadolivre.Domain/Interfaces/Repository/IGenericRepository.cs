﻿namespace br.com.deveficiente.mercadolivre.Domain.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);

        Task<T> GetByIdAsync(int id);

        Task<T> FirstAsync(Expression<Func<T, bool>> expression);

        Task<int> CountAsync(Expression<Func<T, bool>> expression);

        Task<List<T>> GetDataAsync(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int? skip = null,
            int? take = null);

         Task<List<T>> GetAllAsync();
    }
}