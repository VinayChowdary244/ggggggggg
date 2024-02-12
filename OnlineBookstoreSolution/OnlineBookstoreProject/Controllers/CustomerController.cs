using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Models.DTOs;
using OnlineBookstoreProject.Interfaces;
using OnlineBookstoreProject.Models.DTOs;

namespace OnlineBookStore.Controllers
{
    [Route("api/[controller]")]  
    [ApiController] 
    [EnableCors("reactApp")] 
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userService;  

        public CustomerController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult Register(UserDTO userDTO)
        {
            string message = "";
            try
            {
                var user = _userService.Register(userDTO); 
                if (user != null)
                {
                    return Ok(user); 
                }
            }
            catch (DbUpdateException exp)
            {
                message = "Duplicate username";
            }
            

            return BadRequest(message); 
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(UserDTO userDTO)
        {
            var result = _userService.Login(userDTO); 
            if (result != null)
            {
                return Ok(result); 
            }
            return Unauthorized("Invalid username or password");  
        }

        [Authorize(Roles = "Admin")] [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult GetAllUsers()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _userService.GetAllUsers();  
                return Ok(result);  
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);  
        }

        [HttpPut]
        [Route("Update User")]
        public ActionResult UserProfiles(UserDataDTO userDataDTO)
        {
            string msg = "";
            try
            {
                var res = _userService.UpdateUser(userDataDTO); 
                return Ok(res); 
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return BadRequest(msg); 
        }


    }
}