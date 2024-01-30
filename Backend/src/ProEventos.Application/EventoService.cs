using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contrato;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IEventoPersistence _eventoPersistence;

        public EventoService(IGeralPersistence geralPersistence, IEventoPersistence eventoPersistence)
        {
            _eventoPersistence = eventoPersistence;
            _geralPersistence = geralPersistence;

        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersistence.Add<Evento>(model);

                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventoPersistence.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, false);
                if (evento == null)
                    return null;

                model.Id = evento.Id;

                _geralPersistence.Update(model);

                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventoPersistence.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, false);
                if (evento == null)
                    throw new Exception("Evento para delete não foi encontrado");

                _geralPersistence.Delete<Evento>(evento);

                return await _geralPersistence.SaveChangesAsync();

            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Evento[]> GetAllEventoAsync(bool includePalestrantes)
        {
            throw new NotImplementedException();
        }

        public Task<Evento[]> GetAllEventoByTemaAsync(string tema, bool includePalestrantes)
        {
            throw new NotImplementedException();
        }

        public Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes)
        {
            throw new NotImplementedException();
        }


    }
}