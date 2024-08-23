using Microsoft.AspNetCore.Mvc;
using PIS.Service.Common;
using PIS.Model;
using System.Threading.Tasks;

namespace PIS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _service;
        private readonly IKorisniciAktivnostiService _aktivnostiService;

        public KorisniciController(IKorisniciService service, IKorisniciAktivnostiService aktivnostiService)
        {
            _service = service;
            _aktivnostiService = aktivnostiService;
        }

        // Endpoint to get all users
        [HttpGet]
        public async Task<IActionResult> GetAllKorisnici()
        {
            var korisnici = await _service.GetAllKorisniciAsync();
            return Ok(korisnici);
        }

        // Endpoint to get user by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKorisnici(int id)
        {
            var korisnici = await _service.GetKorisniciByIdAsync(id);
            if (korisnici == null)
                return NotFound();
            return Ok(korisnici);
        }

        // Endpoint to add a new user
        [HttpPost]
        public async Task<IActionResult> PostKorisnici([FromBody] KorisniciDomain korisnici)
        {
            if (korisnici == null)
                return BadRequest("Invalid user data.");

            var createdKorisnici = await _service.AddKorisniciAsync(korisnici);
            return CreatedAtAction(nameof(GetKorisnici), new { id = createdKorisnici.Id }, createdKorisnici);
        }

        // Endpoint to update user by ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKorisnici(int id, [FromBody] KorisniciDomain korisnici)
        {
            if (korisnici == null || korisnici.Id != id)
                return BadRequest("Invalid user data or ID mismatch.");

            var korisniciToUpdate = await _service.GetKorisniciByIdAsync(id);
            if (korisniciToUpdate == null)
                return NotFound($"User with ID {id} not found.");

            await _service.UpdateKorisniciAsync(korisnici);
            return NoContent();
        }

        // Endpoint to delete user by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKorisnici(int id)
        {
            var korisniciToDelete = await _service.GetKorisniciByIdAsync(id);
            if (korisniciToDelete == null)
                return NotFound($"User with ID {id} not found.");

            await _service.DeleteKorisniciAsync(id);
            return NoContent();
        }

        // Endpoint for user login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Lozinka))
                return BadRequest("Invalid login request.");

            var korisnik = await _service.AuthenticateAsync(loginRequest.Email, loginRequest.Lozinka);
            if (korisnik == null)
                return Unauthorized("Invalid email or password.");

            return Ok(korisnik);
        }

        // Endpoint for user registration
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] KorisniciDomain korisnici)
        {
            if (korisnici == null)
                return BadRequest("Invalid user data.");

            // Assign role ID 2 for new users
            korisnici.UlogaId = 2;

            var createdKorisnici = await _service.AddKorisniciAsync(korisnici);
            return CreatedAtAction(nameof(GetKorisnici), new { id = createdKorisnici.Id }, createdKorisnici);
        }

        // Get user details and activities
        [HttpGet("user/{userId}/details")]
        public async Task<IActionResult> GetUserDetailsWithActivities(int userId)
        {
            var user = await _service.GetKorisniciByIdAsync(userId);
            if (user == null)
                return NotFound("User not found");

            var activities = await _aktivnostiService.GetUserActivitiesAsync(userId);
            return Ok(new
            {
                User = user,
                Activities = activities
            });
        }
    }

    // Request model for login
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Lozinka { get; set; }
    }
}
