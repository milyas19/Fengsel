using Entities.Typer;

namespace Application.Feature.Fanger.Command.Register
{
    public class OpprettetFangeDto
    {
        public int Id { get; set; }
        public string? Navn { get; set; }
        public int Alder { get; set; } = 0;
        public Kjonn Kjonn { get; set; }
        public int CelleId { get; set; }
        public DateOnly FengslingsDatoFra { get; set; }
        public DateOnly FengslingsDatoTil { get; set; }
    }
}
