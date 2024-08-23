using Microsoft.AspNetCore.Mvc;
using PIS.Service.Common;
using PIS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventPovijestController : ControllerBase
    {
        private readonly IEventPovijestService _service;

        public EventPovijestController(IEventPovijestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var eventPovijest = await _service.GetAllAsync();
            return Ok(eventPovijest);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var eventPovijest = await _service.GetByIdAsync(id);
            if (eventPovijest == null)
                return NotFound();
            return Ok(eventPovijest);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EventPovijestDomain eventPovijest)
        {
            if (eventPovijest == null)
                return BadRequest("Invalid data.");

            var createdEventPovijest = await _service.AddAsync(eventPovijest);
            return CreatedAtAction(nameof(GetById), new { id = createdEventPovijest.Id }, createdEventPovijest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EventPovijestDomain eventPovijest)
        {
            if (eventPovijest == null || eventPovijest.Id != id)
                return BadRequest("Invalid data or ID mismatch.");

            await _service.UpdateAsync(eventPovijest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eventPovijest = await _service.GetByIdAsync(id);
            if (eventPovijest == null)
                return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
