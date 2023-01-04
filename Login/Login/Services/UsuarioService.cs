using AutoMapper;
using FluentResults;
using Login.Data.DTO;
using Login.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Login.Services
{
    public class UsuarioService
    {
        private UserManager<IdentityUser<int>> _manager;
        private IMapper _mapper;

        public UsuarioService(UserManager<IdentityUser<int>> manager, IMapper mapper)
        {
            _manager= manager;
            _mapper= mapper;
        }


        public Result CreateUsuario(CreateUsuarioDTO createDTO)
        {
            Usuario user = _mapper.Map<Usuario>(createDTO);
            IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> resultadoCriacaoConta = _manager.CreateAsync(identityUser, createDTO.Senha);
            return resultadoCriacaoConta.Result.Succeeded? Result.Ok() : Result.Fail("Falha ao Criar a Conta !");
        }
    }
}
