using Core.Exceptions;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Utils.Resolver;

namespace Core.Services
{
	public class RentCarService : IRepositoryService
	{
		private readonly IRepositoryService _repository;
		private const string FilePath = @"D:\Универ\3 курс\семестр 2\курсовая\log.txt";
		private readonly string _nl = Environment.NewLine;
		private string Delimeter;
		public RentCarService(ServiceResolver resolver)
		{
			_repository = resolver(Utils.ServiceType.Repository);
			Delimeter = $"{_nl}-----------------------------------------------------{_nl}";
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class
		{
			var logMsg = new StringBuilder();
			logMsg
				.AppendLine(DateTime.UtcNow.ToString())
				.AppendLine($"Get collection of {typeof(TEntity).ToString().Split('.').Last()}s. Return to client.")
				.AppendLine(Delimeter);
			await LogToFile(logMsg.ToString());
			var cars = await _repository.GetAllAsync<TEntity>();
			return cars;
		}

		public async Task<TEntity> GetByIdAsync<TEntity>(long id) where TEntity : class
		{
			var entityName = typeof(TEntity).ToString().Split('.').Last();
			var logMsg = new StringBuilder();
			try
			{
				var entity = await _repository.GetByIdAsync<TEntity>(id);

				logMsg
					.AppendLine(DateTime.UtcNow.ToString())
					.AppendLine($"Get entity {entityName} with id {id}. Return to client.")
					.AppendLine(Delimeter);
				return entity;
			}
			catch (EntityNotFoundException ex)
			{
				logMsg
					.AppendLine(DateTime.UtcNow.ToString())
					.AppendLine($"Try to get unexisting {entityName} with id {id}.")
					.AppendLine("Return <null> to client.")
					.AppendLine(Delimeter);
				return null;
			}
			finally
			{
				await LogToFile(logMsg.ToString());
			}
		}
		public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class
		{
			var logMsg = new StringBuilder();
			logMsg
				.AppendLine(DateTime.UtcNow.ToString())
				.AppendLine($"Add new {typeof(TEntity).ToString().Split('.').Last()}.")
				.AppendLine(Delimeter);
			await LogToFile(logMsg.ToString());
			return await _repository.AddAsync<TEntity>(entity);
		}

		public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
		{
			var logMsg = new StringBuilder();
			logMsg
				.AppendLine(DateTime.UtcNow.ToString())
				.AppendLine($"Updating {typeof(TEntity).ToString().Split('.').Last()}.")
				.AppendLine(Delimeter);
			await LogToFile(logMsg.ToString());
			await _repository.UpdateAsync<TEntity>(entity);
		}

		public async Task Delete<TEntity>(long id) where TEntity : class
		{
			var entityName = typeof(TEntity).ToString().Split('.').Last();
			var logMsg = new StringBuilder()
				.AppendLine(DateTime.UtcNow.ToString());
			try
			{
				logMsg
					.AppendLine($"Try to delete {entityName} with id {id}.")
					.AppendLine(Delimeter);
				await _repository.Delete<TEntity>(id);
			}
			catch (EntityNotFoundException ex)
			{
				logMsg
					.AppendLine($"Trying to delete unexisting {entityName} with id {id}.")
					.AppendLine("Returning error message.")
					.AppendLine(Delimeter);
				throw;
			}
			finally
			{
				await LogToFile(logMsg.ToString());
			}
		}

		private async Task LogToFile(string str)
		{
			using (var inStream = new FileStream(FilePath, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write))
			{
				using (var writer = new StreamWriter(inStream))
				{
					await writer.WriteLineAsync(str);
				}
			}
		}
	}
}
