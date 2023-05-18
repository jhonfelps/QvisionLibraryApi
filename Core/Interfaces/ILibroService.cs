using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ILibroService
	{
		Task<(int totalRegistros, IEnumerable<Libro> registros)> GetLibrosAsync(int pageIndex, int pageSize, string? search, bool noTracking = true);
    }
}
