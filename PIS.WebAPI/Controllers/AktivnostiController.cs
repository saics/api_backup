using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Service.Common;
using PIS.Model;
using System.Linq;

namespace PIS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AktivnostiController : ControllerBase
    {
        private readonly IAKtivnostiService _service;

        public AktivnostiController(IAKtivnostiService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAktivnosti()
        {
            var aktivnosti = await _service.GetAllAktivnostiAsync();
            return Ok(aktivnosti);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAktivnostiById(int id)
        {
            var aktivnosti = await _service.GetAktivnostiByIdAsync(id);
            if (aktivnosti == null) return NotFound();
            return Ok(aktivnosti);
        }

        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetActivitiesByEventId(int eventId)
        {
            var aktivnosti = await _service.GetActivitiesByEventIdAsync(eventId);
            if (aktivnosti == null || !aktivnosti.Any())
                return NotFound("No activities found for this event.");

            return Ok(aktivnosti);
        }

        [HttpPost]
        public async Task<IActionResult> AddAktivnosti(AktivnostiDomain aktivnosti)
        {
            var newAktivnosti = await _service.AddAktivnostiAsync(aktivnosti);
            return CreatedAtAction(nameof(GetAktivnostiById), new { id = newAktivnosti.Id }, newAktivnosti);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAktivnosti(int id, AktivnostiDomain aktivnosti)
        {
            if (id != aktivnosti.Id) return BadRequest();
            await _service.UpdateAktivnostiAsync(aktivnosti);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAktivnosti(int id)
        {
            await _service.DeleteAktivnostiAsync(id);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMultipleAktivnosti([FromBody] List<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return BadRequest("No activity IDs provided.");
            }

            await _service.DeleteMultipleAktivnostiAsync(ids);
            return NoContent();
        }
    }
}
