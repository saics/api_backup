using Microsoft.AspNetCore.Mvc;
using PIS.Service.Common;
using PIS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DodatniPrijavljeniController : ControllerBase
    {
        private readonly IDodatniPrijavljeniService _service;

        public DodatniPrijavljeniController(IDodatniPrijavljeniService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dodatniPrijavljeni = await _service.GetAllAsync();
            return Ok(dodatniPrijavljeni);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dodatniPrijavljeni = await _service.GetByIdAsync(id);
            if (dodatniPrijavljeni == null)
                return NotFound();
            return Ok(dodatniPrijavljeni);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DodatniPrijavljeniDomain dodatniPrijavljeni)
        {
            if (dodatniPrijavljeni == null)
                return BadRequest("Invalid data.");

            var createdDodatniPrijavljeni = await _service.AddAsync(dodatniPrijavljeni);
            return CreatedAtAction(nameof(GetById), new { id = createdDodatniPrijavljeni.Id }, createdDodatniPrijavljeni);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DodatniPrijavljeniDomain dodatniPrijavljeni)
        {
            if (dodatniPrijavljeni == null || dodatniPrijavljeni.Id != id)
                return BadRequest("Invalid data or ID mismatch.");

            await _service.UpdateAsync(dodatniPrijavljeni);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dodatniPrijavljeni = await _service.GetByIdAsync(id);
            if (dodatniPrijavljeni == null)
                return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
