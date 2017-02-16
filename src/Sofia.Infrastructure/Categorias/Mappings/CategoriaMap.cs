using Sofia.Domain.Categorias.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Sofia.Infrastructure.Categorias.Mappings
{
    internal class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria", "sofia");

            HasKey(x => x.Id);

            Property(x => x.Nome);
        }
    }
}
