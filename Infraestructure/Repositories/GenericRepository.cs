using Core.Interfaces;
using Core.Models;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
	{
		protected readonly QVisionLibraryContext _context;

		public GenericRepository(QVisionLibraryContext context)
		{
			_context = context;
		}
		public virtual void Add(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public virtual void AddRange(IEnumerable<T> entities)
		{
			_context.Set<T>().AddRange(entities);
		}

		public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
		{
			return _context.Set<T>().Where(expression);
		}

		public virtual async Task<IEnumerable<T>> GetAllAsync()
		{
			return  await _context.Set<T>().ToListAsync();
		}

		public virtual async Task<T> GetByIdAsync(Guid id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public Task<T> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public virtual void Remove(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public virtual void RemoveRange(IEnumerable<T> entities)
		{
			_context.Set<T>().RemoveRange(entities);
		}

		public virtual void Update(T entity)
		{
			_context.Set<T>()
				.Update(entity);
		}
		public virtual async Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(
        int pageIndex, int pageSize,string search, bool noTracking = true)
		{

			var query = noTracking ? _context.Set<T>().AsNoTracking().AsQueryable()
									: _context.Set<T>().AsQueryable();

			var totalRegistros = await query
								.CountAsync();

			var registros = await query
									.Skip((pageIndex - 1) * pageSize)
									.Take(pageSize)
									.ToListAsync();

			return (totalRegistros, registros);

		}
	}
}
