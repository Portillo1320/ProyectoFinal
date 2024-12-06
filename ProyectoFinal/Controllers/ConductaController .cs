using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Data.Services;
using ProyectoFinal.Data.ViewModel;


namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductaController : ControllerBase
    {
        public ConductaService _conductaService;

        public ConductaController(ConductaService conductaService)
        {
            _conductaService = conductaService;
        }
        [HttpPost("add-conducta")]
        public IActionResult AddConducta([FromBody] ConductaVM conducta)
        {
            _conductaService.AddConducta(conducta);
            return Ok();
        }

        [HttpGet("get-all-conducta")]
        public IActionResult GetAllAns()
        {
            var allconducta = _conductaService.GetAllAns();
            return Ok(allconducta);
        }

        [HttpGet("get-conducta-with-alumno-by-id/{id}")]
        public IActionResult GetConductaWithAlumno(int id)
        {
            var response = _conductaService.GetConductaWithAlumno(id);
            return Ok(response);
        }

        [HttpPut("update-conducta-by-id/{id}")]
        public IActionResult UpdateConductaById(int id, [FromBody] ConductaVM conducta)
        {
            var updateConducta = _conductaService.UpdateConductaByID(id, conducta);
            return Ok(updateConducta);
        }

        [HttpDelete("delete-conducta-by-id/{id}")]
        public IActionResult DeleteConductaById(int id)
        {
            _conductaService.DeleteConductaById(id);
            return Ok();
        }
    }
}
