using ProEventos.Domain;

namespace ProEventos.Persistence.Contrato
{
    public interface IPalestrantePersistence
    {
        //Palestrantes
        Task<Palestrante[]> GetAllPalestranteByNameAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos);
    }
}