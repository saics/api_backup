using PIS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.Service.Common
{
    public interface IInteresZaEventService
    {
        Task<IEnumerable<InteresZaEventDomain>> GetAllAsync();
        Task<InteresZaEventDomain> GetByIdAsync(int id);
        Task<InteresZaEventDomain> AddAsync(InteresZaEventDomain interesZaEvent);
        Task UpdateAsync(InteresZaEventDomain interesZaEvent);
        Task DeleteAsync(int id);
    }
}
