using Sofia.Domain.Avaliacoes.Entities;
using Sofia.Infrastructure.Avaliacoes.Mappings;
using System.Data.Entity;

namespace Sofia.Infrastructure.Avaliacoes
{
    public class AvaliacoesContext : DbContextBase<AvaliacoesContext>
    {
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AvaliacaoMap());
            modelBuilder.Configurations.Add(new TecnologiaMap());
            modelBuilder.Configurations.Add(new ColaboradorMap());
        }
    }
}
