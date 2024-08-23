using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.Repository
{
    public class InteresZaEventRepository : IInteresZaEventRepository
    {
        private readonly PIS_DbContext2 _context;
        private readonly IMapper _mapper;

        public InteresZaEventRepository(PIS_DbContext2 context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InteresZaEventDomain>> GetAllAsync()
        {
            var entities = await _context.InteresZaEvent.ToListAsync();
            return _mapper.Map<IEnumerable<InteresZaEventDomain>>(entities);
        }

        public async Task<InteresZaEventDomain> GetByIdAsync(int id)
        {
            var entity = await _context.InteresZaEvent.FindAsync(id);
            return _mapper.Map<InteresZaEventDomain>(entity);
        }

        public async Task<InteresZaEventDomain> AddAsync(InteresZaEventDomain interesZaEvent)
        {
            var entity = _mapper.Map<InteresZaEvent>(interesZaEvent);
            _context.InteresZaEvent.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<InteresZaEventDomain>(entity);
        }

        public async Task UpdateAsync(InteresZaEventDomain interesZaEvent)
        {
            var entity = await _context.InteresZaEvent.FindAsync(interesZaEvent.Id);
            if (entity != null)
            {
                _mapper.Map(interesZaEvent, entity);
                _context.InteresZaEvent.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.InteresZaEvent.FindAsync(id);
            if (entity != null)
            {
                _context.InteresZaEvent.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
