using Core.Exceptions;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
	public class Repository : IRepositoryService
	{
		private readonly RentCarDbContext _ctx;
		public Repository(RentCarDbContext ctx)
		{
			_ctx = ctx;
		}
		public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class
		{
			await _ctx.Set<TEntity>().AddAsync(entity);
			await _ctx.SaveChangesAsync();
			return entity;
		}

		public async Task DeleteAsync<TEntity>(long id) where TEntity : class
		{
			var entity = await _ctx.Set<TEntity>().FindAsync(id);
			if(entity == null)
			{
				throw new EntityNotFoundException($"{typeof(TEntity).ToString().Split('.').Last()} with id {id} not found.");
			}
			_ctx.Set<TEntity>().Remove(entity);
			await _ctx.SaveChangesAsync();
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class
		{
			return await _ctx.Set<TEntity>().ToListAsync();
		}

		public async Task<TEntity> GetByIdAsync<TEntity>(long id) where TEntity : class
		{
			var entity = await _ctx.FindAsync<TEntity>(id);
			if(entity == null)
			{
				throw new EntityNotFoundException($"{typeof(TEntity).ToString().Split('.').Last()} with id {id} not found.");
			}
			return entity;
		}

		public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
		{
			_ctx.Entry(entity).State = EntityState.Modified;
			await _ctx.SaveChangesAsync();
		}
	}
}
