using Microsoft.AspNetCore.Mvc;
using PIS.Service.Common;
using PIS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InteresZaEventController : ControllerBase
    {
        private readonly IInteresZaEventService _service;

        public InteresZaEventController(IInteresZaEventService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var interesZaEvent = await _service.GetAllAsync();
            return Ok(interesZaEvent);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var interesZaEvent = await _service.GetByIdAsync(id);
            if (interesZaEvent == null)
                return NotFound();
            return Ok(interesZaEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InteresZaEventDomain interesZaEvent)
        {
            if (interesZaEvent == null)
                return BadRequest("Invalid data.");

            var createdInteresZaEvent = await _service.AddAsync(interesZaEvent);
            return CreatedAtAction(nameof(GetById), new { id = createdInteresZaEvent.Id }, createdInteresZaEvent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InteresZaEventDomain interesZaEvent)
        {
            if (interesZaEvent == null || interesZaEvent.Id != id)
                return BadRequest("Invalid data or ID mismatch.");

            await _service.UpdateAsync(interesZaEvent);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var interesZaEvent = await _service.GetByIdAsync(id);
            if (interesZaEvent == null)
                return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
