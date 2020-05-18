using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
	public interface IRepositoryService
	{
		Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class;
		Task<TEntity> GetByIdAsync<TEntity>(long id) where TEntity : class;
		Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class;
		Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
		Task DeleteAsync<TEntity>(long id) where TEntity : class;
	}
}
