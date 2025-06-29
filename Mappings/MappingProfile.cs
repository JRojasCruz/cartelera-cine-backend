using AutoMapper;
using CineCartelera.API.DTOs;
using CineCartelera.API.Models;

namespace CineCartelera.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Película
            CreateMap<Pelicula, PeliculaDto>();
            CreateMap<CrearPeliculaDto, Pelicula>();

            // Sala
            CreateMap<Sala, SalaDto>();
            CreateMap<CrearSalaDto, Sala>();

            // Funcion
            CreateMap<Funcion, FuncionDto>()
                .ForMember(dest => dest.PeliculaTitulo, opt => opt.MapFrom(src => src.Pelicula.Titulo))
                .ForMember(dest => dest.SalaNombre, opt => opt.MapFrom(src => src.Sala.Nombre));

            CreateMap<CrearFuncionDto, Funcion>();

            // Reserva
            CreateMap<Reserva, ReservaDto>()
                .ForMember(dest => dest.PeliculaTitulo, opt => opt.MapFrom(src => src.Funcion.Pelicula.Titulo))
                .ForMember(dest => dest.SalaNombre, opt => opt.MapFrom(src => src.Funcion.Sala.Nombre))
                .ForMember(dest => dest.HoraInicio, opt => opt.MapFrom(src => src.Funcion.HoraInicio));

            CreateMap<CrearReservaDto, Reserva>();

        }
    }
}
