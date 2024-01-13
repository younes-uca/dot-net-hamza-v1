using Stocky.Models.Dtos;

namespace Stocky.Models.DTO
{
    public class AchatDto
    {
        public int Id { get; set; }
        public string? Reference { get; set; }
        public DateTime? DateAchat { get; set; }
        public Decimal? Total { get; set; }
        public Decimal? TotalPaye { get; set; }
        public string? Description { get; set; }

        public ClientDto? Client { get; set; }
    }
}
