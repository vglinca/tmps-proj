using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Core.Utils.Resolver;

namespace Core.Services
{
	public class RentCarService : IRepositoryService
	{
		private readonly IRepositoryService _repository;
		public RentCarService(ServiceResolver resolver)
		{
			_repository = resolver(Utils.ServiceType.Repository);
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class
		{
			return await _repository.GetAllAsync<TEntity>();
		}

		public async Task<TEntity> GetByIdAsync<TEntity>(long id) where TEntity : class
		{
			return await _repository.GetByIdAsync<TEntity>(id);
		}
		public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class
		{
			return await _repository.AddAsync<TEntity>(entity);
		}

		public Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
		{
			throw new NotImplementedException();
		}

		public Task Delete<TEntity>(long id) where TEntity : class
		{
			throw new NotImplementedException();
		}
	}
}
