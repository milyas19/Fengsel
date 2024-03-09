

using Entities;
using Entities.Typer;
using Microsoft.EntityFrameworkCore;
using Persistence.DBContextConfig;
using System.Reflection.Metadata;

namespace Persistence;
public class FengselContext : DbContext
{
    public DbSet<Fange> Fangers { get; set; }
    public DbSet<Celle> Celles { get; set; }

    public FengselContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new FangeConfig());
        builder.ApplyConfiguration(new CelleConfig());


        builder.Entity<Celle>()
        .HasOne(c => c.Fange)
        .WithOne(f => f.Celle)
        .HasForeignKey<Fange>(f => f.CelleId);

        builder.Entity<Celle>().HasData(
            new Celle
            {
                Id = 1,
                CelleNumber = 101,
                Opptatt = true,
                FangeId = 1
            }
        );

        builder.Entity<Fange>().HasData(
            new Fange
            {
                Id = 1,
                CelleId = 1,
                Alder = 34,
                Kjonn = Kjonn.Mann,
                Navn = "Olaf",
                FengslingsDatoFra = DateOnly.Parse("12-02-2007"),
                FengslingsDatoTil = DateOnly.Parse("12-02-2037"),
            }
        ); ;
    }
}

