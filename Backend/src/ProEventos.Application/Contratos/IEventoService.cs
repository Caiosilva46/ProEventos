using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEvento(int id, Evento model);
        Task<bool> DeleteEvento(int id);

        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
        Task<Evento[]> GetAllEventoByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes);
    }
}