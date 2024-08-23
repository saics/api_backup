using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.Repository
{
    public class AktivnostPovijestRepository : IAktivnostPovijestRepository
    {
        private readonly PIS_DbContext2 _context;
        private readonly IMapper _mapper;

        public AktivnostPovijestRepository(PIS_DbContext2 context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AktivnostPovijestDomain>> GetAllAsync()
        {
            var entities = await _context.AktivnostPovijest.ToListAsync();
            return _mapper.Map<IEnumerable<AktivnostPovijestDomain>>(entities);
        }

        public async Task<AktivnostPovijestDomain> GetByIdAsync(int id)
        {
            var entity = await _context.AktivnostPovijest.FindAsync(id);
            return _mapper.Map<AktivnostPovijestDomain>(entity);
        }

        public async Task<AktivnostPovijestDomain> AddAsync(AktivnostPovijestDomain aktivnostPovijest)
        {
            var entity = _mapper.Map<AktivnostPovijest>(aktivnostPovijest);
            _context.AktivnostPovijest.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<AktivnostPovijestDomain>(entity);
        }

        public async Task UpdateAsync(AktivnostPovijestDomain aktivnostPovijest)
        {
            var entity = await _context.AktivnostPovijest.FindAsync(aktivnostPovijest.Id);
            if (entity != null)
            {
                _mapper.Map(aktivnostPovijest, entity);
                _context.AktivnostPovijest.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.AktivnostPovijest.FindAsync(id);
            if (entity != null)
            {
                _context.AktivnostPovijest.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
