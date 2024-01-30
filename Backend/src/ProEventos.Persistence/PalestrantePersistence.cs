using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contrato;

namespace ProEventos.Persistence
{
    public class PalestrantePersistence : IPalestrantePersistence
    {
        public ProEventosContext _context { get; }

        public PalestrantePersistence(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(pe => pe.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteByNameAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id)
                    .Where(p => p.Nome.ToLower()
                    .Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                .Include(p => p.Id == PalestranteId);

            }

            query = query.OrderBy(p => p.Id)
                    .Where(p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}