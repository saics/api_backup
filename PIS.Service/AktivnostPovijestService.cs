using PIS.Model;
using PIS.Repository.Common;
using PIS.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.Service
{
    public class AktivnostPovijestService : IAktivnostPovijestService
    {
        private readonly IAktivnostPovijestRepository _repository;

        public AktivnostPovijestService(IAktivnostPovijestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AktivnostPovijestDomain>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<AktivnostPovijestDomain> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<AktivnostPovijestDomain> AddAsync(AktivnostPovijestDomain aktivnostPovijest)
            => await _repository.AddAsync(aktivnostPovijest);

        public async Task UpdateAsync(AktivnostPovijestDomain aktivnostPovijest)
            => await _repository.UpdateAsync(aktivnostPovijest);

        public async Task DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}
