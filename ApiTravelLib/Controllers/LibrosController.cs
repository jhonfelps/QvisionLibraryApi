using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ApiTravelLib.Helpers;
using ApiTravelLib.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTravelLib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _libroService;
        private readonly IMapper _mapper;

        public LibrosController(ILibroService libroService, IMapper mapper)
        {
            _libroService = libroService;
            _mapper = mapper;
        }

        // GET: api/Libros
        /// <summary>
        /// Método encargado de regresar el listado de libros paginados.
        /// Recibe los parámetros de paginación y de busqueda.
        /// </summary>
        /// <param name="libroParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Pager<LibroListDto>>> GetLibros([FromQuery] Params libroParams)
        {
            var resultado = await _libroService
                                .GetLibrosAsync(libroParams.PageIndex, libroParams.PageSize,
                                libroParams.Search);

            var listaLibrosDto = _mapper.Map<List<LibroListDto>>(resultado.registros);

            Response.Headers.Add("X-InlineCount", resultado.totalRegistros.ToString());

            return new Pager<LibroListDto>(listaLibrosDto, resultado.totalRegistros,
                libroParams.PageIndex, libroParams.PageSize, libroParams.Search);
        }
    }
}
