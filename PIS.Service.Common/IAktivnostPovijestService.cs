using PIS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.Service.Common
{
    public interface IAktivnostPovijestService
    {
        Task<IEnumerable<AktivnostPovijestDomain>> GetAllAsync();
        Task<AktivnostPovijestDomain> GetByIdAsync(int id);
        Task<AktivnostPovijestDomain> AddAsync(AktivnostPovijestDomain aktivnostPovijest);
        Task UpdateAsync(AktivnostPovijestDomain aktivnostPovijest);
        Task DeleteAsync(int id);
    }
}
