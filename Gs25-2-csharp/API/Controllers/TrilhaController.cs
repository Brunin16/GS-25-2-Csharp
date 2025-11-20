using Business;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/trilhas")]
    public class TrilhaController : ControllerBase
    {
        private readonly ITrilhaService _service;

        public TrilhaController(ITrilhaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Trilha trilha)
        {
            var created = await _service.CreateAsync(trilha);
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
            var trilha = await _service.GetByIdAsync(id);
            if (trilha == null) return NotFound();
            return Ok(trilha);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Trilha trilha)
        {
            var updated = await _service.UpdateAsync(id, trilha);
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
