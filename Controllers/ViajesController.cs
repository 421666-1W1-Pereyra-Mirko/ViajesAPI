using Microsoft.AspNetCore.Mvc;
using ViajesAPI.Models;
using ViajesAPI.Services.Implementations;

namespace ViajesAPI.Controllers
{
    [ApiController]
    [Route("api/viajes")]
    public class ViajesController : ControllerBase
    {
        private IViajeService _service;

        public ViajesController(IViajeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Viaje> viajeList = _service.GetAll();
                return Ok(viajeList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido una excepción.");
            }
        }

        [HttpGet]
        [Route("{id}/a")]
        public IActionResult GetById(int id)
        {
            try
            {
                Viaje viaje = _service.GetById(id);
                return Ok(viaje);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido una excepción.");
            }
        }

        [HttpPut]
        [Route("{id}/estado")]
        public IActionResult UpdateEstado(int id, [FromBody] string estado)
        {
            try
            {
                _service.UpdateEstado(id, estado);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido una excepción.");
            }
        }

        [HttpGet]
        [Route("caros")]
        public IActionResult GetViajesCaros()
        {
            try
            {
                List<Viaje> viajesList = _service.GetViajesCaros();
                return Ok(viajesList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido una excepción.");
            }
        }

        [HttpGet]
        [Route("{estado}")]
        public IActionResult GetFirstByEstado(string estado)
        {
            try
            {
                Viaje viaje = _service.GetFirstByEstado(estado);
                return Ok(viaje);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido una excepción.");
            }
        }

        [HttpPut]
        [Route("{id}/fecha")]
        public IActionResult UpdateFecha(int id, [FromBody] DateTime nuevaFecha)
        {
            try
            {
                _service.UpdateFecha(id, nuevaFecha);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido una excepción.");
            }
        }
    }
}
