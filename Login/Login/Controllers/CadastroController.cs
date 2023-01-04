using FluentResults;
using Login.Data.DTO;
using Login.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Login.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase
    {
        private UsuarioService _service;

        public CadastroController(UsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CadastroUsuario([FromBody]CreateUsuarioDTO createDTO)
        {
            Result resultado = _service.CreateUsuario(createDTO);
            return resultado.IsSuccess ? Ok(resultado.Successes.FirstOrDefault()) : StatusCode(500, resultado.Errors.FirstOrDefault());
        }

    }
}
