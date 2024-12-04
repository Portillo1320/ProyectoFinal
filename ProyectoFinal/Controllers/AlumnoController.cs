using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Data.Services;
using ProyectoFinal.Data.ViewModel;

namespace ProyectoFinal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        public AlumnoService _alumnoService;

        public AlumnoController(AlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }
        [HttpGet("get-all-alumnos")]
        public IActionResult GetAllAlumno()
        {
            var allalumno = _alumnoService.GetAllAns();
            return Ok(allalumno);
        }

        [HttpGet("get-alumnos-by-id/{id}")]
        public IActionResult GetAlumnoById(int id)
        {
            var alumno = _alumnoService.GetAlumnoById(id);
            if (alumno == null)
            {
                return NotFound(new { message = $"No hay ningún alumno con el ID {id}" });
            }
            return Ok(alumno);
        }

        [HttpPost("add-alumno-whit-class")]
        public IActionResult AddAlumno([FromBody] AlumnoVM alumno)
        {
            _alumnoService.AddAlumnoWithClass(alumno);
            return Ok();
        }

        [HttpPut("update-alumno-by-id/{id}")]
        public IActionResult UpdateAlumnoById(int id, [FromBody] AlumnoVM alumno)
        {
            var updateAlumno = _alumnoService.UpdateAlumnoByID(id, alumno);
            return Ok(updateAlumno);
        }
        [HttpDelete("delete-alumno-by-id/{id}")]
        public IActionResult DeleteAlumnoById(int id)
        {
            _alumnoService.DeleteAlumnoById(id);
            return Ok();
        }
    }
}
