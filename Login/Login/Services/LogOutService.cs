using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;

namespace Login.Services
{
    public class LogOutService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogOutService(SignInManager<IdentityUser<int>> signInManager) 
        {
            _signInManager = signInManager;
        }

        public Result Logout()
        {
            var deslogar = _signInManager.SignOutAsync();
            return deslogar.IsCompletedSuccessfully ? Result.Ok() : Result.Fail("Erro ao deslogar");
        }
    }
}
