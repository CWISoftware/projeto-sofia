using Sofia.Domain.Avaliacoes.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Sofia.Infrastructure.Avaliacoes.Mappings
{
    internal class TecnologiaMap : EntityTypeConfiguration<Tecnologia>
    {
        public TecnologiaMap()
        {
            ToTable("Tecnologia", "sofia");
            HasKey(x => x.Id);
        }
    }
}
