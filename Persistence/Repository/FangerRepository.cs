using Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository.Interfaces;

namespace Persistence.Repository
{
    public class FangerRepository : IFangerRepository
    {
        private readonly FengselContext _context;

        public FangerRepository(FengselContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Fange> HentFangerAvId(int id) => await _context.Fangers.FindAsync(id);
        public async Task<List<Fange>> HentFangerList() => await _context.Fangers.ToListAsync();
        public Fange OpprettNyFanger(Fange fanger)
        {
            _context.Fangers.Add(fanger);
            var saveChanges = _context.SaveChanges();
            if (saveChanges <= 0)
            {
                throw new ArgumentException("Error while creating new record");
            }
            return fanger;
        }

        public Fange OppdatertFanger(Fange fanger)
        {
            _context.Fangers.Update(fanger);
            var saveChanges = _context.SaveChanges();
            if (saveChanges <= 0)
            {
                throw new ArgumentException("Error while creating new record");
            }
            return fanger;
        }

        public async Task<bool> SlettFange(int id)
        {
            var fangeObj = await _context.Fangers.FindAsync(id);
            _context.Remove(fangeObj);
            var removed = _context.SaveChanges();
            return removed <= 0 ? throw new ArgumentException("Record does not deleted") : true;
        }
    }
}
