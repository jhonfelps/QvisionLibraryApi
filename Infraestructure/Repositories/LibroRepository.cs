using Core.Interfaces;
using Core.Models;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class LibroRepository : ILibroRepository
	{
        private readonly QVisionLibraryContext _context;

        public LibroRepository(QVisionLibraryContext context)
        {
            _context = context;
        }

        public async Task<(int totalRegistros, IEnumerable<Libro> registros)> GetAllAsync(int pageIndex, int pageSize, string? search, bool noTracking = true)
        {
            var queryRecaudo = noTracking ? _context.Libros.AsNoTracking()
                                        : _context.Libros;


            if (!String.IsNullOrEmpty(search))
            {
                queryRecaudo = queryRecaudo
                    .Where(p => p.titulo.ToLower().Contains(search));
            }


            var totalRegistros = await queryRecaudo
                                        .CountAsync();

            var registros = await queryRecaudo
                                    .Skip((pageIndex - 1) * pageSize)
                                    .Take(pageSize)
                                    .Include(u => u.Autores)
                                    .Include(u => u.Editorial)
                                    .ToListAsync();

            return (totalRegistros, registros);
        }

        public Task<IEnumerable<Libro>> GetProductosMasCaros(int cantidad)
        {
            throw new NotImplementedException();
        }
    }
}
