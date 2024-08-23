using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Service.Common;
using PIS.Model;
using AutoMapper;
using System.Linq;
using System;

namespace PIS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisniciAktivnostiController : ControllerBase
    {
        private readonly IKorisniciAktivnostiService _service;
        private readonly IMapper _mapper;

        public KorisniciAktivnostiController(IKorisniciAktivnostiService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKorisniciAktivnosti()
        {
            var korisniciAktivnosti = await _service.GetAllKorisniciAktivnostiAsync();
            if (korisniciAktivnosti == null || !korisniciAktivnosti.Any())
            {
                return NotFound("No activities found for any user.");
            }
            return Ok(korisniciAktivnosti);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKorisniciAktivnostiById(int id)
        {
            var korisniciAktivnosti = await _service.GetKorisniciAktivnostiByIdAsync(id);
            if (korisniciAktivnosti == null)
            {
                return NotFound($"Activity with ID {id} not found.");
            }
            return Ok(korisniciAktivnosti);
        }

        [HttpPost]
        public async Task<IActionResult> AddKorisniciAktivnosti([FromBody] KorisniciAktivnostiDomain korisniciAktivnosti)
        {
            if (korisniciAktivnosti == null || !korisniciAktivnosti.KorisnikId.HasValue || !korisniciAktivnosti.EventId.HasValue || !korisniciAktivnosti.AktivnostId.HasValue)
            {
                return BadRequest("Invalid activity data provided.");
            }

            try
            {
                var result = await _service.AddKorisniciAktivnostiAsync(korisniciAktivnosti);
                return CreatedAtAction(nameof(GetKorisniciAktivnostiById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKorisniciAktivnosti(int id, [FromBody] KorisniciAktivnostiDomain korisniciAktivnosti)
        {
            if (id != korisniciAktivnosti.Id)
            {
                return BadRequest("ID mismatch.");
            }

            var existingActivity = await _service.GetKorisniciAktivnostiByIdAsync(id);
            if (existingActivity == null)
            {
                return NotFound($"Activity with ID {id} not found.");
            }

            try
            {
                await _service.UpdateKorisniciAktivnostiAsync(korisniciAktivnosti);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKorisniciAktivnosti(int id)
        {
            var existingActivity = await _service.GetKorisniciAktivnostiByIdAsync(id);
            if (existingActivity == null)
            {
                return NotFound($"Activity with ID {id} not found.");
            }

            try
            {
                await _service.DeleteKorisniciAktivnostiAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/event/{eventId}")]
        public async Task<IActionResult> GetUserActivities(int userId, int eventId)
        {
            if (userId <= 0 || eventId <= 0)
            {
                return BadRequest("Invalid userId or eventId.");
            }

            var korisniciAktivnosti = await _service.GetUserActivitiesByEvent(userId, eventId);
            if (korisniciAktivnosti == null || !korisniciAktivnosti.Any())
            {
                return NotFound("No activities found for this user in the specified event.");
            }
            return Ok(korisniciAktivnosti);
        }

        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetUsersByEvent(int eventId)
        {
            var korisniciAktivnosti = await _service.GetUsersByEventAsync(eventId);
            if (korisniciAktivnosti == null || !korisniciAktivnosti.Any())
            {
                return NotFound("No users found for this event.");
            }
            return Ok(korisniciAktivnosti);
        }

        [HttpPut("{userId}/{eventId}/qrcode")]
        public async Task<IActionResult> UpdateQrCode(int userId, int eventId, [FromBody] string qrCodeUrl)
        {
            var activities = await _service.GetUserActivitiesByEvent(userId, eventId);
            if (activities == null || !activities.Any())
            {
                return NotFound("No activities found for the specified user and event.");
            }

            foreach (var activity in activities)
            {
                activity.QrKod = qrCodeUrl;
                await _service.UpdateKorisniciAktivnostiAsync(activity);
            }

            return NoContent();
        }

        [HttpGet("user/{userId}/registeredEvents")]
        public async Task<IActionResult> GetRegisteredEvents(int userId)
        {
            var activities = await _service.GetUserActivitiesAsync(userId);
            var events = activities.GroupBy(a => a.EventId)
                                   .Select(g => new {
                                       Event = g.First().Event,
                                       QrCodeUrl = g.First().QrKod // Assuming all activities have the same QR code for the event
                                   }).ToList();

            return Ok(events);
        }

        [HttpDelete("user/{userId}/event/{eventId}")]
        public async Task<IActionResult> DeleteUserRegistration(int userId, int eventId)
        {
            var activities = await _service.GetUserActivitiesByEvent(userId, eventId);
            if (activities == null || !activities.Any())
            {
                return NotFound("No registrations found for the specified user and event.");
            }

            foreach (var activity in activities)
            {
                await _service.DeleteKorisniciAktivnostiAsync(activity.Id);
            }

            return NoContent();
        }

        [HttpPut("{userId}/{eventId}/attendance")]
        public async Task<IActionResult> UpdateUserAttendance(int userId, int eventId)
        {
            try
            {
                await _service.UpdateUserAttendanceAsync(userId, eventId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("multiple")]
        public async Task<IActionResult> AddMultipleKorisniciAktivnosti([FromBody] List<KorisniciAktivnostiDomain> korisniciAktivnostiList)
        {
            if (korisniciAktivnostiList == null || !korisniciAktivnostiList.Any())
            {
                return BadRequest("No activities to sign up.");
            }

            try
            {
                foreach (var korisniciAktivnosti in korisniciAktivnostiList)
                {
                    if (korisniciAktivnosti == null || !korisniciAktivnosti.KorisnikId.HasValue || !korisniciAktivnosti.EventId.HasValue || !korisniciAktivnosti.AktivnostId.HasValue)
                    {
                        return BadRequest("Invalid activity data provided.");
                    }

                    await _service.AddKorisniciAktivnostiAsync(korisniciAktivnosti);
                }

                return Ok("Activities signed up successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
