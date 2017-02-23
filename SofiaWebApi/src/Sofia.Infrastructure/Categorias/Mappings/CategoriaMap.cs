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

            HasMany(x => x.Tecnologias)
                .WithRequired(x => x.Categoria)
                .Map(x => x.ToTable("Tecnologia", "sofia")
                .MapKey("IdCategoria"));

            Property(x => x.QtdTecnologias);

            Property(x => x.Versao.Numero)
             .HasColumnName("RowVersion")
             .IsRowVersion();
        }
    }
}
