using Entities;

namespace Persistence.Repository.Interfaces
{
    public interface IFangerRepository
    {
        Task<Fange> HentFangerAvId(int id);
        Task<List<Fange>> HentFangerList();
        Fange OpprettNyFanger(Fange fanger);
        Fange OppdatertFanger(Fange fanger);
        Task<bool> SlettFange(int id);
    }
}
