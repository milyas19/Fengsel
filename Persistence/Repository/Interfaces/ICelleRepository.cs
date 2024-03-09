using Entities;

namespace Persistence.Repository.Interfaces
{
    public interface ICelleRepository
    {
        Celle OpprettCell(Celle cell);
        Task<List<Celle>> HentCeller();
        Task<Celle> HentCelleAvId(int id);
        Task<List<Celle>> HentLedigCeller();
    }
}
