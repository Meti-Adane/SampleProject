
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sitesampleproject.Models;
using sitesampleproject.Services;

namespace sitesampleproject.Controllers;

[ApiController]
[Route("[Controller]/")]
public class AuthController :  ControllerBase{
    AuthService _service;
        ProductService _productService;

        public AuthController (AuthService service){
            _service = service;
        }


        // Plan routes 
        [HttpPost("/signupRegularuser")]
        public  async Task<ActionResult> SignupRegularUser([FromBody] User userinfo)
        {
            User newuser =userinfo;
            newuser.Id = Guid.NewGuid();
            newuser.isActive = true;
            if (userinfo.Password is null || userinfo.EmailAddress is null){
                return StatusCode(500);
            }

            var token = _service.SignupRegularUser(newuser);
            if (token is not null){
                return Ok(token);
            }
            return StatusCode(500);

        }

        [HttpPut]
        public async Task<ActionResult> Login([FromBody] User userinfo){
            var token = _service.Login(userinfo);
            if (token is null){
                return NotFound();
            }
            return Ok(token) ;
        }
    
}