using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Persistance.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
	public class Repository : IRepository
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

		public async Task Delete<TEntity>(long id) where TEntity : class
		{
			var entity = await _ctx.Set<TEntity>().FindAsync(id);
			if(entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
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
			return await _ctx.FindAsync<TEntity>(id);
		}

		public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
		{
			_ctx.Entry(entity).State = EntityState.Modified;
			await _ctx.SaveChangesAsync();
		}
	}
}
