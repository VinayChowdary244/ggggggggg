using OnlineBookStore.Models.DTOs;
using OnlineBookstoreProject.Models;
using OnlineBookstoreProject.Models.DTOs;

namespace OnlineBookstoreProject.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
        List<User> GetAllUsers();
        UserDataDTO UpdateUser(UserDataDTO userDataDTO);


    }
}
