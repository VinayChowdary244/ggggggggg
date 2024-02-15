using EventManagement.Models;
using EventManagement.Models.DTOs;

namespace EventManagement.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
        List<User> GetAllUsers();
        UserDataDTO UpdateUser(UserDataDTO userDataDTO);


    }
}
