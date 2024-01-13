using Stocky.Models.DTO;

namespace Stocky.Business.Contracts
{
    public interface ProduitAdminService
    {
        IEnumerable<ProduitDto> GetProduits();
        ProduitDto GetProduit(int id);
        void PutProduit(int id, ProduitDto produit);
        void PostProduit(ProduitDto produit);
        void DeleteProduit(int id);
    }
}
