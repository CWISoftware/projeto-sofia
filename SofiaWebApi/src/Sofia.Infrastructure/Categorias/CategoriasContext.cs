using Sofia.Domain.Categorias.Entities;
using Sofia.Infrastructure.Categorias.Mappings;
using System.Data.Entity;

namespace Sofia.Infrastructure.Categorias
{
    public class CategoriasContext : DbContextBase<CategoriasContext>
    {

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tecnologia> Tecnologias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new TecnologiaMap());
        }
    }
}
