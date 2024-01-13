using Stocky.Data;

namespace Stocky.Models
{
    public class AchatItem
    {
        public int Id { get; set; }
        public Decimal PrixUnitaire { get; set; }
        public Decimal PrixVente { get; set; }
        public Decimal Quantite { get; set; }
        public Decimal QuantiteAvoir { get; set; }
        public Decimal Remise { get; set; }
        public int ProduitId { get; set; }
        public Produit Produit { get; set; }
        public int AchatId { get; set; }
        public Achat Achat { get; set; }
    }
}
