using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Data.Services;
using ProyectoFinal.Data.ViewModel;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        public ActividadService _actividadService;

        public ActividadController(ActividadService actividadService)
        {
            _actividadService = actividadService;
        }

        [HttpPost("add-actividad")]
        public IActionResult AddActividad([FromBody] ActividadVM actividad)
        {
            _actividadService.AddActividad(actividad);
            return Ok();
        }

        [HttpGet("get-all-actividad")]
        public IActionResult GetAllAns()
        {
            var allactividad = _actividadService.GetAllAns();
            return Ok(allactividad);
        }

        [HttpGet("get-actividad-with-alumno-by-id/{id}")]
        public IActionResult GetActividadWithAlumno(int id)
        {
            var response = _actividadService.GetActividadWithAlumno(id);
            if (response == null)
            {
                return NotFound(new { message = $"No hay ninguna actividad con el ID {id}" });
            }
            return Ok(response);
        }

        [HttpPut("update-actividad-by-id/{id}")]
        public IActionResult UpdateActividadById(int id, [FromBody] ActividadVM actividad)
        {
            var updateActividad = _actividadService.UpdateActivivdadByID(id, actividad);
            return Ok(updateActividad);
        }

        [HttpDelete("delete-actividad-by-id/{id}")]
        public IActionResult DeleteActividadById(int id)
        {
            _actividadService.DeleteActividadById(id);
            return Ok();
        }
    }
}
