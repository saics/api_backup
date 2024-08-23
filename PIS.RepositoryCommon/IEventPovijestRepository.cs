using PIS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.Repository.Common
{
    public interface IEventPovijestRepository
    {
        Task<IEnumerable<EventPovijestDomain>> GetAllAsync();
        Task<EventPovijestDomain> GetByIdAsync(int id);
        Task<EventPovijestDomain> AddAsync(EventPovijestDomain eventPovijest);
        Task UpdateAsync(EventPovijestDomain eventPovijest);
        Task DeleteAsync(int id);
    }
}
