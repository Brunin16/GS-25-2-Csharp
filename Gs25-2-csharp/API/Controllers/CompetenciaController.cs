using Business;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/competencias")]
    public class CompetenciaController : ControllerBase
    {
        private readonly ICompetenciaService _service;

        public CompetenciaController(ICompetenciaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Competencia competencia)
        {
            var created = await _service.CreateAsync(competencia);
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
            var competencia = await _service.GetByIdAsync(id);
            if (competencia == null) return NotFound();
            return Ok(competencia);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Competencia competencia)
        {
            var updated = await _service.UpdateAsync(id, competencia);
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
