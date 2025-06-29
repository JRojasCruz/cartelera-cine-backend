using AutoMapper;
using CineCartelera.API.DTOs;
using CineCartelera.API.Interfaces;
using CineCartelera.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CineCartelera.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionesController : ControllerBase
    {
        private readonly IFuncionRepository _funcionRepository;
        private readonly IPeliculaRepository _peliculaRepository;
        private readonly ISalaRepository _salaRepository;
        private readonly IMapper _mapper;

        public FuncionesController(IFuncionRepository funcionRepository,  IMapper mapper, IPeliculaRepository peliculaRepository, ISalaRepository salaRepository)
        {
            _funcionRepository = funcionRepository;
            _mapper = mapper;
            _peliculaRepository = peliculaRepository;
            _salaRepository = salaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            var funciones = await _funcionRepository.ObtenerTodasAsync();
            var dto = _mapper.Map<IEnumerable<FuncionDto>>(funciones);
            return Ok(dto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var funcion = await _funcionRepository.ObtenerPorIdAsync(id);
            if (funcion == null)
                return NotFound();

            var dto = _mapper.Map<FuncionDto>(funcion);
            return Ok(dto);
        }

        [HttpGet("pelicula/{peliculaId}")]
        public async Task<IActionResult> ObtenerPorPelicula(int peliculaId)
        {
            var funciones = await _funcionRepository.ObtenerPorPeliculaIdAsync(peliculaId);
            return Ok(funciones);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CrearFuncionDto dto)
        {
            var peliculaExiste = await _peliculaRepository.ObtenerPorIdAsync(dto.PeliculaId);
            if (peliculaExiste == null)
                return BadRequest($"La película seleccionada no existe.");

            var salaExiste = await _salaRepository.ObtenerPorIdAsync(dto.SalaId);
            if (salaExiste == null)
                return BadRequest($"La sala seleccionada no existe.");

            var funcion = _mapper.Map<Funcion>(dto);

            await _funcionRepository.AgregarAsync(funcion);
            var guardado = await _funcionRepository.GuardarCambiosAsync();

            if (!guardado)
                return StatusCode(500, "Error al guardar la función.");

            var result = _mapper.Map<FuncionDto>(funcion);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = funcion.Id }, result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, Funcion funcion)
        {
            if (id != funcion.Id)
                return BadRequest();

            await _funcionRepository.ActualizarAsync(funcion);
            var guardado = await _funcionRepository.GuardarCambiosAsync();

            if (!guardado)
                return StatusCode(500, "Error al actualizar la función.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _funcionRepository.EliminarAsync(id);
            var guardado = await _funcionRepository.GuardarCambiosAsync();

            if (!guardado)
                return StatusCode(500, "Error al eliminar la función.");

            return NoContent();
        }
    }
}
