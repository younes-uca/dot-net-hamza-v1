using Stocky.Data;

namespace Stocky.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Cin { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public Decimal Creance { get; set; }
    }
}
