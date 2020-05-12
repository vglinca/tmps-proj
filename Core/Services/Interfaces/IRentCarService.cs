using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
	public interface IRentCarService
	{
		Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class;
		Task<TEntity> GetByIdAsync<TEntity>(long id) where TEntity : class;
		Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class;
	}
}
