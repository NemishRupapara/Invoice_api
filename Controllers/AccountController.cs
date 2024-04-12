using InvoiceAppApi.Dto;
using InvoiceAppApi.Interffaces;
using InvoiceAppApi.Models;
using InvoiceAppApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InvoiceAppApi.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AccountController(IUserRepository userRepository,IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [Route("AddNewUser")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddNewUser([FromBody] User NewUser)
        {
            if (NewUser == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_userRepository.AddNewUser(NewUser))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }

        [AllowAnonymous]
        [Route("LoginCheck")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Logincheck([FromBody] Login User)
        {
            if (User == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_userRepository.LoginCheck(User))
            {

                return Ok("Invalid UserName Or Password");
            }
            else {
                var Userdetail = new UserDetails();
                Userdetail = _userRepository.GetUserDetails(User);
            return Ok(new JWTService(_configuration).GenerateToken(User.UserName, Userdetail));
            }
        }

    }
}
