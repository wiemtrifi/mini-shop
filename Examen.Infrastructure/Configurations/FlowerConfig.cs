using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Examen.Infrastructure.Configurations
{
    internal class FlowerConfig : IEntityTypeConfiguration<Flower>
    {

        public void Configure(EntityTypeBuilder<Flower> builder)
        {
            builder.HasOne(f => f.Bouquet)
               .WithMany(p => p.flowers)
               .HasForeignKey(f => f.BouqFK)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
