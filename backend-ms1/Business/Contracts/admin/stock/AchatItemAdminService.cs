using Stocky.Models.DTO;

namespace Stocky.Business.Contracts
{
    public interface AchatItemAdminService
    {
        IEnumerable<AchatItemDto> GetAchatItems();
        AchatItemDto GetAchatItem(int id);
        void PutAchatItem(int id, AchatItemDto achatItem);
        void PostAchatItem(AchatItemDto achatItem);
        void DeleteAchatItem(int id);
    }
}
