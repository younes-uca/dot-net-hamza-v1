using Stocky.Models.DTO;

namespace Stocky.Business.Contracts
{
    public interface AchatAdminService
    {
        IEnumerable<AchatDto> GetAchats();
        AchatDto GetAchat(int id);
        void PutAchat(int id, AchatDto achat);
        void PostAchat(AchatDto achat);
        void DeleteAchat(int id);
    }
}
