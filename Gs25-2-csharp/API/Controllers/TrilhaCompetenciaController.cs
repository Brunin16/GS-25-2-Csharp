using Business;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/trilhas/{trilhaId:guid}/competencias")]
    public class TrilhaCompetenciaController : ControllerBase
    {
        private readonly ITrilhaCompetenciaService _service;

        public TrilhaCompetenciaController(ITrilhaCompetenciaService service)
        {
            _service = service;
        }

        [HttpPost("{competenciaId:guid}")]
        public async Task<IActionResult> AddCompetencia(Guid trilhaId, Guid competenciaId)
        {
            var result = await _service.AddCompetenciaAsync(trilhaId, competenciaId);
            if (result == null) return BadRequest("Competência já adicionada ou dados inválidos.");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCompetencias(Guid trilhaId)
        {
            var competencias = await _service.GetCompetenciasByTrilhaAsync(trilhaId);
            return Ok(competencias);
        }

        [HttpDelete("{competenciaId:guid}")]
        public async Task<IActionResult> RemoveCompetencia(Guid trilhaId, Guid competenciaId)
        {
            var removed = await _service.RemoveCompetenciaAsync(trilhaId, competenciaId);
            return removed ? NoContent() : NotFound();
        }
    }
}
