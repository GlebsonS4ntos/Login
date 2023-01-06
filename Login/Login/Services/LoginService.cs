using FluentResults;
using Login.Data.Request;
using Login.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace Login.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager { get; set; }
        private TokenService _tokenService { get; set; }

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService) 
        {
            _signInManager= signInManager;
            _tokenService= tokenService;
        }

        public Result Login(LoginRequest request)
        {
            var resultado = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false).Result;
            if(resultado.Succeeded)
            {
                IdentityUser<int> user = _signInManager.UserManager.Users.FirstOrDefault(x => x.UserName.ToUpper() == request.UserName.ToUpper());
                Token token = _tokenService.CreateToken(user);

                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Falha a Efetuar o Login");
        }
    }
}
