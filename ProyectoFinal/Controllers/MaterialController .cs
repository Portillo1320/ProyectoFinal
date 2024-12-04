using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Data.Services;
using ProyectoFinal.Data.ViewModel;


namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        public MaterialService _materialService;

        public MaterialController(MaterialService materialService)
        {
            _materialService = materialService;
        }
        [HttpPost("add-material")]
        public IActionResult AddMaterial([FromBody] MaterialVM material)
        {
            _materialService.AddMaterial(material);
            return Ok();
        }

        [HttpGet("get-material-with-alumno-by-id/{id}")]
        public IActionResult GetMaterialWithAlumno(int id)
        {
            var response = _materialService.GetMaterialWithAlumno(id);
            return Ok(response);
        }

        [HttpPut("update-material-by-id/{id}")]
        public IActionResult UpdateMaterialById(int id, [FromBody] MaterialVM material)
        {
            var updateMaterial = _materialService.UpdateMaterialByID(id, material);
            return Ok(updateMaterial);
        }

        [HttpDelete("delete-material-by-id/{id}")]
        public IActionResult DeleteMaterialById(int id)
        {
            _materialService.DeleteMaterialById(id);
            return Ok();
        }
    }
}
