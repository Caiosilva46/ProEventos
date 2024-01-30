namespace ProEventos.Application.Contratos
{
    public interface IGeralService
    {
        //CRUD geral para consumo
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}