using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contexto
{
    public class ProEventosContext : DbContext
    {
        // conexão de contexto com o banco de dados
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options)
        {

        }

        //Migrations das tabelas pelo Entity framework
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
            .HasKey(PE => new { PE.EventoId, PE.PalestranteId });
        }
    }
}