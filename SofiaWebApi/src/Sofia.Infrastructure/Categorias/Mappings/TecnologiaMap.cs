using Sofia.Domain.Categorias.Entities;
using Sofia.SharedKernel.ValueObjects;
using System.Data.Entity.ModelConfiguration;

namespace Sofia.Infrastructure.Categorias.Mappings
{
    internal class TecnologiaMap : EntityTypeConfiguration<Tecnologia>
    {
        public TecnologiaMap()
        {
            ToTable("Tecnologia", "sofia");

            HasKey(x => x.Id);

            Property(x => x.Nome);

            Property(x => x.Icone.Url)
                .HasColumnName("Icone");

            HasRequired(x => x.Categoria);
        }
    }
}
