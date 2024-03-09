namespace Entities
{
    public class Celle
    {
        public int Id { get; set; }
        public int CelleNumber { get; set; }
        public bool Opptatt { get; set; }

        public virtual Fange? Fange { get; set; }
        public int FangeId { get; set; }
    }
}
