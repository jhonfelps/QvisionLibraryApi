using ApiTravelLib.Dtos;
using AutoMapper;
using Core.Models;
using System.Linq;

namespace ApiTravelLib.Profiles
{
    public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Libro, LibroDto>()
				.ReverseMap();

            CreateMap<Autor, AutorDto>()
                .ReverseMap();

            CreateMap<Editorial, EditorialDto>()
                .ReverseMap();

            CreateMap<Libro, LibroListDto>()
            .ForMember(dto => dto.NombreAutor, opt => opt.MapFrom(x => x.Autores.Select(y => y.nombre).FirstOrDefault()))
            .ForMember(dto => dto.ApellidosAutor, opt => opt.MapFrom(x => x.Autores.Select(y => y.apellidos).FirstOrDefault()));

        }
	}
}
