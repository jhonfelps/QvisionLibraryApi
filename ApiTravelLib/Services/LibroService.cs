using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTravelLib.Services
{
    public class LibroService: ILibroService
	{
		private readonly ILibroRepository _libroRepository;
		public LibroService(ILibroRepository libroRepository)
		{
            _libroRepository = libroRepository;
        }

        public async Task<(int totalRegistros, IEnumerable<Libro> registros)> GetLibrosAsync(int pageIndex, int pageSize, string? search, bool noTracking = true)
        {
            return await _libroRepository.GetAllAsync(pageIndex, pageSize,search);
        }
    }
}
