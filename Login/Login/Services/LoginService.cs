using FluentResults;
using Login.Data.Request;
using Microsoft.AspNetCore.Identity;
using System;

namespace Login.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager { get; set; }

        public LoginService(SignInManager<IdentityUser<int>> signInManager) 
        {
            _signInManager= signInManager;
        }

        public Result Login(LoginRequest request)
        {
            var resultado = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false).Result;
            if(resultado.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha a Efetuar o Login");
        }
    }
}
