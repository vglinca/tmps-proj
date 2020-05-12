using Core.Services.Interfaces;
using Persistance.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
	internal class RentCarHeadService : IRentCarService
	{
		private readonly IRepository _repository;

		public RentCarHeadService(IRepository repository)
		{
			_repository = repository;
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
	}
}
