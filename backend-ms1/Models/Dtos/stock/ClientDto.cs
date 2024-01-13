using Stocky.Models.Dtos;

namespace Stocky.Models.DTO
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string? Cin { get; set; }
        public string? Nom { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public Decimal? Creance { get; set; }

    }
}
