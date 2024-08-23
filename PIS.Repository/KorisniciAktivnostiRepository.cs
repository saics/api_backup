using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Common;

namespace PIS.Repository
{
    public class KorisniciAktivnostiRepository : IKorisniciAktivnostiRepository
    {
        private readonly PIS_DbContext2 _context;
        private readonly IMapper _mapper;

        public KorisniciAktivnostiRepository(PIS_DbContext2 context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<KorisniciAktivnostiDomain>> GetAllKorisniciAktivnostiAsync()
        {
            var korisniciAktivnosti = await _context.KorisniciAktivnosti.ToListAsync();
            return _mapper.Map<IEnumerable<KorisniciAktivnostiDomain>>(korisniciAktivnosti);
        }

        public async Task<KorisniciAktivnostiDomain> GetKorisniciAktivnostiByIdAsync(int id)
        {
            var korisniciAktivnosti = await _context.KorisniciAktivnosti.FindAsync(id);
            return _mapper.Map<KorisniciAktivnostiDomain>(korisniciAktivnosti);
        }

        public async Task<KorisniciAktivnostiDomain> AddKorisniciAktivnostiAsync(KorisniciAktivnostiDomain korisniciAktivnostiDomain)
        {
            var entity = _mapper.Map<KorisniciAktivnosti>(korisniciAktivnostiDomain);
            _context.KorisniciAktivnosti.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<KorisniciAktivnostiDomain>(entity);
        }

        public async Task UpdateKorisniciAktivnostiAsync(KorisniciAktivnostiDomain korisniciAktivnostiDomain)
        {
            var entity = await _context.KorisniciAktivnosti.FindAsync(korisniciAktivnostiDomain.Id);
            if (entity != null)
            {
                _mapper.Map(korisniciAktivnostiDomain, entity);
                _context.KorisniciAktivnosti.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteKorisniciAktivnostiAsync(int id)
        {
            var entity = await _context.KorisniciAktivnosti.FindAsync(id);
            if (entity != null)
            {
                _context.KorisniciAktivnosti.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<KorisniciAktivnostiDomain>> GetUserActivitiesByEvent(int userId, int eventId)
        {
            var korisniciAktivnosti = await _context.KorisniciAktivnosti
                .Where(k => k.KorisnikId == userId && k.EventId == eventId)
                .Include(k => k.Event)
                .ToListAsync();

            return _mapper.Map<IEnumerable<KorisniciAktivnostiDomain>>(korisniciAktivnosti);
        }

        public async Task<IEnumerable<KorisniciAktivnostiDomain>> GetUserActivitiesAsync(int userId)
        {
            var korisniciAktivnosti = await _context.KorisniciAktivnosti
                .Where(k => k.KorisnikId == userId)
                .Include(k => k.Event)
                .ToListAsync();

            return _mapper.Map<IEnumerable<KorisniciAktivnostiDomain>>(korisniciAktivnosti);
        }

        public async Task UpdateUserAttendanceAsync(int userId, int eventId)
        {
            var activities = await _context.KorisniciAktivnosti
                .Where(k => k.KorisnikId == userId && k.EventId == eventId)
                .ToListAsync();

            foreach (var activity in activities)
            {
                activity.HasAttended = true; // Mark as attended
                _context.KorisniciAktivnosti.Update(activity);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<KorisniciAktivnostiDomain>> GetUsersByEventAsync(int eventId)
        {
            var korisniciAktivnosti = await _context.KorisniciAktivnosti
                .Where(k => k.EventId == eventId)
                .Include(k => k.Korisnik)
                .ToListAsync();

            return _mapper.Map<IEnumerable<KorisniciAktivnostiDomain>>(korisniciAktivnosti);
        }
    }
}
