using Stocky.Data;

namespace Stocky.Models
{
    public class Achat
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public DateTime DateAchat { get; set; }
        public Decimal Total { get; set; }
        public Decimal TotalPaye { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
