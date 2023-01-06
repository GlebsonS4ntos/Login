using FluentResults;
using Login.Data.Request;
using Login.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Login.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase 
    {
        private LoginService _service;

        public LoginController(LoginService service)
        {
            _service= service;
        }


        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            Result resultado = _service.Login(request);
            return resultado.IsSuccess? Ok(resultado.Successes.FirstOrDefault()) : StatusCode(500, resultado.Errors.FirstOrDefault());
        }
    }
}
