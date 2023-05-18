using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ILibroRepository
	{
        Task<(int totalRegistros, IEnumerable<Libro> registros)> GetAllAsync(int pageIndex, int pageSize, string? search, bool noTracking = true);
        Task<IEnumerable<Libro>> GetProductosMasCaros(int cantidad);
    }
}
