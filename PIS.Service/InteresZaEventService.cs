using PIS.Model;
using PIS.Repository.Common;
using PIS.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.Service
{
    public class InteresZaEventService : IInteresZaEventService
    {
        private readonly IInteresZaEventRepository _repository;

        public InteresZaEventService(IInteresZaEventRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InteresZaEventDomain>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<InteresZaEventDomain> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<InteresZaEventDomain> AddAsync(InteresZaEventDomain interesZaEvent)
            => await _repository.AddAsync(interesZaEvent);

        public async Task UpdateAsync(InteresZaEventDomain interesZaEvent)
            => await _repository.UpdateAsync(interesZaEvent);

        public async Task DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}
