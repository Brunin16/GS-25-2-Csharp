using Business;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/matriculas")]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _service;

        public MatriculaController(IMatriculaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Matricula matricula)
        {
            var created = await _service.CreateAsync(matricula);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var matricula = await _service.GetByIdAsync(id);
            if (matricula == null) return NotFound();
            return Ok(matricula);
        }

        [HttpGet("usuario/{usuarioId:guid}")]
        public async Task<IActionResult> GetByUsuario(Guid usuarioId)
        {
            return Ok(await _service.GetByUsuarioAsync(usuarioId));
        }

        [HttpGet("trilha/{trilhaId:guid}")]
        public async Task<IActionResult> GetByTrilha(Guid trilhaId)
        {
            return Ok(await _service.GetByTrilhaAsync(trilhaId));
        }

        [HttpPatch("{id:guid}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromQuery] string status)
        {
            var updated = await _service.UpdateStatusAsync(id, status);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var removed = await _service.DeleteAsync(id);
            return removed ? NoContent() : NotFound();
        }
    }
}
