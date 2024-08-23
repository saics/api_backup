using PIS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.Repository.Common
{
    public interface IDodatniPrijavljeniRepository
    {
        Task<IEnumerable<DodatniPrijavljeniDomain>> GetAllAsync();
        Task<DodatniPrijavljeniDomain> GetByIdAsync(int id);
        Task<DodatniPrijavljeniDomain> AddAsync(DodatniPrijavljeniDomain dodatniPrijavljeni);
        Task UpdateAsync(DodatniPrijavljeniDomain dodatniPrijavljeni);
        Task DeleteAsync(int id);
    }
}
