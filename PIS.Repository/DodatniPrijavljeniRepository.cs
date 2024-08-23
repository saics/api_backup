using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.Repository
{
    public class DodatniPrijavljeniRepository : IDodatniPrijavljeniRepository
    {
        private readonly PIS_DbContext2 _context;
        private readonly IMapper _mapper;

        public DodatniPrijavljeniRepository(PIS_DbContext2 context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DodatniPrijavljeniDomain>> GetAllAsync()
        {
            var entities = await _context.DodatniPrijavljeni.ToListAsync();
            return _mapper.Map<IEnumerable<DodatniPrijavljeniDomain>>(entities);
        }

        public async Task<DodatniPrijavljeniDomain> GetByIdAsync(int id)
        {
            var entity = await _context.DodatniPrijavljeni.FindAsync(id);
            return _mapper.Map<DodatniPrijavljeniDomain>(entity);
        }

        public async Task<DodatniPrijavljeniDomain> AddAsync(DodatniPrijavljeniDomain dodatniPrijavljeni)
        {
            var entity = _mapper.Map<DodatniPrijavljeni>(dodatniPrijavljeni);
            _context.DodatniPrijavljeni.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<DodatniPrijavljeniDomain>(entity);
        }

        public async Task UpdateAsync(DodatniPrijavljeniDomain dodatniPrijavljeni)
        {
            var entity = await _context.DodatniPrijavljeni.FindAsync(dodatniPrijavljeni.Id);
            if (entity != null)
            {
                _mapper.Map(dodatniPrijavljeni, entity);
                _context.DodatniPrijavljeni.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.DodatniPrijavljeni.FindAsync(id);
            if (entity != null)
            {
                _context.DodatniPrijavljeni.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
