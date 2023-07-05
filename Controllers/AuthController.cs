using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpn.Dtos.User;
using dotnet_rpn.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        public IAuthService _authService { get; }
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
            
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister userRegister)
        {
            var response = await _authService.Register(
                new User{Username = userRegister.Username}, userRegister.password
            );
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserRegister request)
        {
            var response = await _authService.Login(request.Username, request.password);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}