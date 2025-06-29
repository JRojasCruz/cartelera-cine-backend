using AutoMapper;
using CineCartelera.API.DTOs;
using CineCartelera.API.Interfaces;
using CineCartelera.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineCartelera.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaRepository _peliculaRepository;
        private readonly IMapper _mapper;
        public PeliculasController(IPeliculaRepository peliculaRepository, IMapper mapper)
        {
            _peliculaRepository = peliculaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            var peliculas = await _peliculaRepository.ObtenerTodasAsync();
            var peliculasDto = _mapper.Map<IEnumerable<PeliculaDto>>(peliculas);
            return Ok(peliculasDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var pelicula = await _peliculaRepository.ObtenerPorIdAsync(id);
            if (pelicula == null)
                return NotFound();

            var peliculaDto = _mapper.Map<PeliculaDto>(pelicula);
            return Ok(peliculaDto);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearPeliculaDto dto)
        {
            var pelicula = _mapper.Map<Pelicula>(dto);

            await _peliculaRepository.AgregarAsync(pelicula);
            var guardado = await _peliculaRepository.GuardarCambiosAsync();

            if (!guardado)
                return StatusCode(500, "Error al guardar la película.");

            var result = _mapper.Map<PeliculaDto>(pelicula);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = pelicula.Id }, result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, Pelicula pelicula)
        {
            if (id != pelicula.Id)
                return BadRequest();

            await _peliculaRepository.ActualizarAsync(pelicula);
            var guardado = await _peliculaRepository.GuardarCambiosAsync();

            if (!guardado)
                return StatusCode(500, "Error al actualizar la película.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _peliculaRepository.EliminarAsync(id);
            var guardado = await _peliculaRepository.GuardarCambiosAsync();

            if (!guardado)
                return StatusCode(500, "Error al eliminar la película.");

            return NoContent();
        }
    }
}
