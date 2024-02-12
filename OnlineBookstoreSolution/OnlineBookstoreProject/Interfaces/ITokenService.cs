using OnlineBookstoreProject.Models;
using OnlineBookstoreProject.Models.DTOs;

namespace OnlineBookstoreProject.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
