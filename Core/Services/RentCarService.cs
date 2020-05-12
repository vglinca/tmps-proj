using Core.Services.Interfaces;
using Persistance.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
	public class RentCarService : IRentCarService
	{
		private readonly RentCarHeadService _headService;

		public RentCarService(IRepository repository)
		{
			_headService = new RentCarHeadService(repository);
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class
		{
			return await _headService.GetAllAsync<TEntity>();
		}

		public async Task<TEntity> GetByIdAsync<TEntity>(long id) where TEntity : class
		{
			return await _headService.GetByIdAsync<TEntity>(id);
		}
		public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class
		{
			return await _headService.AddAsync<TEntity>(entity);
		}
	}
}
