using Entities.Typer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Fanger.Command.Oppdatere
{
    public class OppdatereFangeDto
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
