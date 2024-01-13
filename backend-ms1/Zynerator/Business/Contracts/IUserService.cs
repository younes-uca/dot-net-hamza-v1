using Project_Spring_to_.net.Zynerator.Models.Dtos;

namespace Project_Spring_to_.net.Zynerator.Business.Contracts
{
    public interface IUserService
    {
        UserDto Register(UserDto user);
        string Login(UserDto user);
    }
}
