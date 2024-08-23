using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.Repository
{
    public class EventPovijestRepository : IEventPovijestRepository
    {
        private readonly PIS_DbContext2 _context;
        private readonly IMapper _mapper;

        public EventPovijestRepository(PIS_DbContext2 context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventPovijestDomain>> GetAllAsync()
        {
            var entities = await _context.EventPovijest.ToListAsync();
            return _mapper.Map<IEnumerable<EventPovijestDomain>>(entities);
        }

        public async Task<EventPovijestDomain> GetByIdAsync(int id)
        {
            var entity = await _context.EventPovijest.FindAsync(id);
            return _mapper.Map<EventPovijestDomain>(entity);
        }

        public async Task<EventPovijestDomain> AddAsync(EventPovijestDomain eventPovijest)
        {
            var entity = _mapper.Map<EventPovijest>(eventPovijest);
            _context.EventPovijest.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<EventPovijestDomain>(entity);
        }

        public async Task UpdateAsync(EventPovijestDomain eventPovijest)
        {
            var entity = await _context.EventPovijest.FindAsync(eventPovijest.Id);
            if (entity != null)
            {
                _mapper.Map(eventPovijest, entity);
                _context.EventPovijest.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.EventPovijest.FindAsync(id);
            if (entity != null)
            {
                _context.EventPovijest.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
