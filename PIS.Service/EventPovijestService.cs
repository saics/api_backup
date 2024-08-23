using PIS.Model;
using PIS.Repository.Common;
using PIS.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.Service
{
    public class EventPovijestService : IEventPovijestService
    {
        private readonly IEventPovijestRepository _repository;

        public EventPovijestService(IEventPovijestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EventPovijestDomain>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<EventPovijestDomain> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<EventPovijestDomain> AddAsync(EventPovijestDomain eventPovijest)
            => await _repository.AddAsync(eventPovijest);

        public async Task UpdateAsync(EventPovijestDomain eventPovijest)
            => await _repository.UpdateAsync(eventPovijest);

        public async Task DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}
