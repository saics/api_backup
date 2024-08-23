using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Model;
using PIS.Repository.Common;
using AutoMapper;
using PIS.Service.Common;
using PIS.Repository;

namespace PIS.Service
{
    public class KorisniciAktivnostiService : IKorisniciAktivnostiService
    {
        private readonly IKorisniciAktivnostiRepository _repository;
        private readonly IMapper _mapper;

        public KorisniciAktivnostiService(IKorisniciAktivnostiRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<KorisniciAktivnostiDomain>> GetAllKorisniciAktivnostiAsync()
        {
            return await _repository.GetAllKorisniciAktivnostiAsync();
        }

        public async Task<KorisniciAktivnostiDomain> GetKorisniciAktivnostiByIdAsync(int id)
        {
            return await _repository.GetKorisniciAktivnostiByIdAsync(id);
        }

        public async Task<KorisniciAktivnostiDomain> AddKorisniciAktivnostiAsync(KorisniciAktivnostiDomain korisniciAktivnostiDomain)
        {
            return await _repository.AddKorisniciAktivnostiAsync(korisniciAktivnostiDomain);
        }

        public async Task UpdateKorisniciAktivnostiAsync(KorisniciAktivnostiDomain korisniciAktivnostiDomain)
        {
            await _repository.UpdateKorisniciAktivnostiAsync(korisniciAktivnostiDomain);
        }

        public async Task DeleteKorisniciAktivnostiAsync(int id)
        {
            await _repository.DeleteKorisniciAktivnostiAsync(id);
        }

        public async Task<IEnumerable<KorisniciAktivnostiDomain>> GetUserActivitiesByEvent(int userId, int eventId)
        {
            return await _repository.GetUserActivitiesByEvent(userId, eventId);
        }

        public async Task<IEnumerable<KorisniciAktivnostiDomain>> GetUserActivitiesAsync(int userId)
        {
            return await _repository.GetUserActivitiesAsync(userId);
        }

        public async Task UpdateUserAttendanceAsync(int userId, int eventId)
        {
            await _repository.UpdateUserAttendanceAsync(userId, eventId);
        }

        public async Task<IEnumerable<KorisniciAktivnostiDomain>> GetUsersByEventAsync(int eventId)
        {
            return await _repository.GetUsersByEventAsync(eventId);
        }
    }
}
