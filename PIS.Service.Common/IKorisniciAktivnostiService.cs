using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Model;

namespace PIS.Service.Common
{
    public interface IKorisniciAktivnostiService
    {
        Task<IEnumerable<KorisniciAktivnostiDomain>> GetAllKorisniciAktivnostiAsync();
        Task<KorisniciAktivnostiDomain> GetKorisniciAktivnostiByIdAsync(int id);
        Task<KorisniciAktivnostiDomain> AddKorisniciAktivnostiAsync(KorisniciAktivnostiDomain korisniciAktivnosti);
        Task UpdateKorisniciAktivnostiAsync(KorisniciAktivnostiDomain korisniciAktivnosti);
        Task DeleteKorisniciAktivnostiAsync(int id);
        Task<IEnumerable<KorisniciAktivnostiDomain>> GetUserActivitiesByEvent(int userId, int eventId);
        Task<IEnumerable<KorisniciAktivnostiDomain>> GetUsersByEventAsync(int eventId);
        Task<IEnumerable<KorisniciAktivnostiDomain>> GetUserActivitiesAsync(int userId);
        Task UpdateUserAttendanceAsync(int userId, int eventId);
    }
}
