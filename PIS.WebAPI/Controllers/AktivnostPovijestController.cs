using Microsoft.AspNetCore.Mvc;
using PIS.Service.Common;
using PIS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AktivnostPovijestController : ControllerBase
    {
        private readonly IAktivnostPovijestService _service;

        public AktivnostPovijestController(IAktivnostPovijestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var aktivnostPovijest = await _service.GetAllAsync();
            return Ok(aktivnostPovijest);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var aktivnostPovijest = await _service.GetByIdAsync(id);
            if (aktivnostPovijest == null)
                return NotFound();
            return Ok(aktivnostPovijest);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AktivnostPovijestDomain aktivnostPovijest)
        {
            if (aktivnostPovijest == null)
                return BadRequest("Invalid data.");

            var createdAktivnostPovijest = await _service.AddAsync(aktivnostPovijest);
            return CreatedAtAction(nameof(GetById), new { id = createdAktivnostPovijest.Id }, createdAktivnostPovijest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AktivnostPovijestDomain aktivnostPovijest)
        {
            if (aktivnostPovijest == null || aktivnostPovijest.Id != id)
                return BadRequest("Invalid data or ID mismatch.");

            await _service.UpdateAsync(aktivnostPovijest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var aktivnostPovijest = await _service.GetByIdAsync(id);
            if (aktivnostPovijest == null)
                return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
