using Stocky.Models.Dtos;

namespace Stocky.Models.DTO
{
    public class AchatItemDto
    {
        public int Id { get; set; }
        public Decimal? PrixUnitaire { get; set; }
        public Decimal? PrixVente { get; set; }
        public Decimal? Quantite { get; set; }
        public Decimal? QuantiteAvoir { get; set; }
        public Decimal? Remise { get; set; }

        public ProduitDto? Produit { get; set; }
        public AchatDto? Achat { get; set; }
    }
}
