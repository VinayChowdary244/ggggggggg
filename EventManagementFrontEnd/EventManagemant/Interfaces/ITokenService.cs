using EventManagement.Models;
using EventManagement.Models.DTOs;

namespace EventManagement.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
