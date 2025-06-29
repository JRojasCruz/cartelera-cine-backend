using AutoMapper;
using CineCartelera.API.DTOs;
using CineCartelera.API.Interfaces;
using CineCartelera.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineCartelera.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IFuncionRepository _funcionRepository;
        private readonly IMapper _mapper;

        public ReservasController(IReservaRepository reservaRepository, IFuncionRepository funcionRepository, IMapper mapper)
        {
            _reservaRepository = reservaRepository;
            _funcionRepository = funcionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            var reservas = await _reservaRepository.ObtenerTodasAsync();
            var dto = _mapper.Map<IEnumerable<ReservaDto>>(reservas);
            return Ok(dto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var reserva = await _reservaRepository.ObtenerPorIdAsync(id);
            if (reserva == null)
                return NotFound();

            return Ok(reserva);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearReservaDto dto)
        {
            var funcion = await _funcionRepository.ObtenerPorIdAsync(dto.FuncionId);
            if (funcion == null)
                return BadRequest("La función no existe."); 
            
            var entradasExistentes = funcion.Reservas?.Count ?? 0;

            if (entradasExistentes >= funcion.Capacidad)
                return BadRequest("No hay más entradas disponibles para esta función.");

            var reserva = _mapper.Map<Reserva>(dto);

            await _reservaRepository.AgregarAsync(reserva);
            var guardado = await _reservaRepository.GuardarCambiosAsync();

            if (!guardado)
                return StatusCode(500, "Error al guardar la reserva.");

            // Obtener la reserva completa
            var reservaCompleta = await _reservaRepository.ObtenerPorIdAsync(reserva.Id);
            var result = _mapper.Map<ReservaDto>(reservaCompleta);

            return Ok(result);
        }

    }
}
