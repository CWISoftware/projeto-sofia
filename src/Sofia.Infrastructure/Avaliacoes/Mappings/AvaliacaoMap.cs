using Sofia.Domain.Avaliacoes.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Sofia.Infrastructure.Avaliacoes.Mappings
{
    internal class AvaliacaoMap : EntityTypeConfiguration<Avaliacao>
    {
        public AvaliacaoMap()
        {
            ToTable("Avaliacao", "sofia");

            HasKey(x => x.Id);

            HasRequired(x => x.Colaborador)
                .WithMany()
                .Map(x => x.MapKey("IdColaborador"));

            HasRequired(x => x.Tecnologia)
                .WithMany()
                .Map(x => x.MapKey("IdTecnologia"));

            Property(x => x.AvaliadoEm);

            Property(x => x.Nivel);
        }
    }
}
