using Stocky.Models.DTO;

namespace Stocky.Business.Contracts
{
    public interface ClientAdminService
    {
        IEnumerable<ClientDto> GetClients();
        ClientDto GetClient(int id);
        void PutClient(int id, ClientDto client);
        void PostClient(ClientDto client);
        void DeleteClient(int id);
    }
}
