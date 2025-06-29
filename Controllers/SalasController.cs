using AutoMapper;
using CineCartelera.API.DTOs;
using CineCartelera.API.Interfaces;
using CineCartelera.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineCartelera.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalasController : ControllerBase
    {
        private readonly ISalaRepository _salaRepository;
        private readonly IMapper _mapper;

        public SalasController(ISalaRepository salaRepository, IMapper mapper)
        {
            _salaRepository = salaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            var salas = await _salaRepository.ObtenerTodasAsync();
            var dto = _mapper.Map<IEnumerable<SalaDto>>(salas);
            return Ok(dto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var sala = await _salaRepository.ObtenerPorIdAsync(id);
            if (sala == null)
                return NotFound();

            var dto = _mapper.Map<SalaDto>(sala);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CrearSalaDto dto)
        {
            var sala = _mapper.Map<Sala>(dto);

            await _salaRepository.AgregarAsync(sala);
            var guardado = await _salaRepository.GuardarCambiosAsync();

            if (!guardado)
                return StatusCode(500, "Error al guardar la sala.");

            var result = _mapper.Map<SalaDto>(sala);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = sala.Id }, result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, Sala sala)
        {
            if (id != sala.Id)
                return BadRequest();

            await _salaRepository.ActualizarAsync(sala);
            var guardado = await _salaRepository.GuardarCambiosAsync();

            if (!guardado)
                return StatusCode(500, "Error al actualizar la sala.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _salaRepository.EliminarAsync(id);
            var guardado = await _salaRepository.GuardarCambiosAsync();

            if (!guardado)
                return StatusCode(500, "Error al eliminar la sala.");

            return NoContent();
        }
    }
}
