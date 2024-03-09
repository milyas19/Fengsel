using Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository.Interfaces;
using System;

namespace Persistence.Repository
{
    public class CelleRepository : ICelleRepository
    {
        private readonly FengselContext _context;

        public CelleRepository(FengselContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Celle> HentCelleAvId(int id) => await _context.Celles.Where(c => c.Id == id).FirstOrDefaultAsync();

        public async Task<List<Celle>> HentCeller()
        {
            var list = await _context.Celles.ToListAsync();
            return list;
        }
        public async Task<List<Celle>> HentLedigCeller() => await _context.Celles.Where(c => c.Opptatt == false).ToListAsync();

        public Celle OpprettCell(Celle celle)
        {
            _context.Celles.Add(celle);
            var saveChanges = _context.SaveChanges();
            if (saveChanges <= 0)
            {
                throw new ArgumentException("Error while creating new record");
            }
            return celle;
        }
    }
}
