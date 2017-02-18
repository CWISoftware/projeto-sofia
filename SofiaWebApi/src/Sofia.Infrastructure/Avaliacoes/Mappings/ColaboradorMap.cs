using Sofia.Domain.Avaliacoes.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Sofia.Infrastructure.Avaliacoes.Mappings
{
    internal class ColaboradorMap : EntityTypeConfiguration<Colaborador>
    {
        public ColaboradorMap()
        {
            ToTable("Colaborador", "sofia");
            HasKey(x => x.Id);
        }
    }
}
