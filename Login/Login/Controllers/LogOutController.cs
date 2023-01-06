using FluentResults;
using Login.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Login.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LogOutController : ControllerBase
    {
        private LogOutService _service;

        public LogOutController(LogOutService service)
        {
            _service= service;
        }

        [HttpPost]
        public IActionResult LogOut()
        {
            Result resultado = _service.Logout();
            return resultado.IsSuccess ? Ok() : Unauthorized(resultado.Errors.FirstOrDefault());
        }
    }
}
