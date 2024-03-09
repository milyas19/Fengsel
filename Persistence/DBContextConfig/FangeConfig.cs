using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.DBContextConfig
{
    public class FangeConfig : IEntityTypeConfiguration<Fange>
    {
        public void Configure(EntityTypeBuilder<Fange> builder)
        {
            builder.ToTable(nameof(Fange));
        }
    }
}



