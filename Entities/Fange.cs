using System.ComponentModel.DataAnnotations;
using Entities.Typer;

namespace Entities
{
    public class Fange
    {
        public int Id { get; set; }
        public string? Navn { get; set; }
        public int Alder { get; set; } = 0;
        public Kjonn Kjonn  { get; set; }
        public DateOnly FengslingsDatoFra { get; set; }
        public DateOnly FengslingsDatoTil { get; set; }

        public virtual Celle? Celle { get; set; }
        public int CelleId { get; set; }
    }
}
