using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IPalestranteService
    {
        Task<Palestrante[]> GetAllPalestranteByNameAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos);
    }
}