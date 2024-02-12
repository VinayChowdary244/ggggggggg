using OnlineBookStore.Models.DTOs;
using OnlineBookstoreProject.Exceptions;
using OnlineBookstoreProject.Interfaces;
using OnlineBookstoreProject.Models;
using OnlineBookstoreProject.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace OnlineBookstoreProject.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userrepository;
        private readonly ITokenService _tokenService;



        public UserService(IUserRepository userrepository)
        {
            _userrepository = userrepository;
        }

        public UserService(IUserRepository userrepository, ITokenService tokenService)
        {
            _userrepository = userrepository;
            _tokenService = tokenService;
        }

        public List<User> GetAllUsers()
        {
            var users = _userrepository.GetAll();
            if (users != null)
            {
                return users.ToList();
            }
            throw new NoUsersAvailableException();  
        }

        public UserDataDTO UpdateUser(UserDataDTO userDataDTO)
        {
            var userData = _userrepository.GetById(userDataDTO.UserName);

            userData.Email = userDataDTO.Email;
            userData.Password = userDataDTO.Password;
            

            if (userData != null)
            {
                var res = _userrepository.Update(userData);
                if (res != null)
                {
                    return userDataDTO;
                }
            }
            throw new NoUsersAvailableException(); 
        }

        public UserDTO Login(UserDTO userDTO)
        {
            var user = _userrepository.GetById(userDTO.UserName);

            if (user != null)
            {
                HMACSHA512 hmac = new HMACSHA512(user.Key);
                var userpass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userpass.Length; i++)
                {
                    if (user.Password[i] != userpass[i])
                        return null;
                }

                userDTO.Token = _tokenService.GetToken(userDTO);
                userDTO.Password = "";
                userDTO.Email = user.Email;
                return userDTO;
            }

            return null; 
        }

        public UserDTO Register(UserDTO userDTO)
        {
            HMACSHA512 hmac = new HMACSHA512();

            User user = new User()
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password)),
                Key = hmac.Key,
                Role = userDTO.Role
            };

            var result = _userrepository.Add(user);
            if (result != null)
            {
                userDTO.Password = "";
                return userDTO;
            }

            return null; 
        }
    }
}
