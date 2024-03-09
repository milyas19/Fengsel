using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.DBContextConfig
{
    public class CelleConfig : IEntityTypeConfiguration<Celle>
    {
        public void Configure(EntityTypeBuilder<Celle> builder)
        {
            builder.ToTable(nameof(Celle));
        }
    }
}
