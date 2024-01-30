using ProEventos.Domain;

namespace ProEventos.Persistence.Contrato
{
    public interface IEventoPersistence
    {
        //Eventos
        Task<Evento[]> GetAllEventoByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes);
    }
}