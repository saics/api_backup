using PIS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.Service.Common
{
    public interface IEventPovijestService
    {
        Task<IEnumerable<EventPovijestDomain>> GetAllAsync();
        Task<EventPovijestDomain> GetByIdAsync(int id);
        Task<EventPovijestDomain> AddAsync(EventPovijestDomain eventPovijest);
        Task UpdateAsync(EventPovijestDomain eventPovijest);
        Task DeleteAsync(int id);
    }
}
