using PIS.Model;
using PIS.Repository.Common;
using PIS.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.Service
{
    public class DodatniPrijavljeniService : IDodatniPrijavljeniService
    {
        private readonly IDodatniPrijavljeniRepository _repository;

        public DodatniPrijavljeniService(IDodatniPrijavljeniRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DodatniPrijavljeniDomain>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<DodatniPrijavljeniDomain> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<DodatniPrijavljeniDomain> AddAsync(DodatniPrijavljeniDomain dodatniPrijavljeni)
            => await _repository.AddAsync(dodatniPrijavljeni);

        public async Task UpdateAsync(DodatniPrijavljeniDomain dodatniPrijavljeni)
            => await _repository.UpdateAsync(dodatniPrijavljeni);

        public async Task DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}
