using Login.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Login.Services
{
    public class TokenService
    {
        public Token CreateToken(IdentityUser<int> user)
        {
            Claim[] dadosUsuario = new Claim[]{ // As claims são os dados que serão repassados pelo token
                new Claim("userName", user.UserName),
                new Claim("Id", user.Id.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("489afdgafd89374asdf834adsfasdfasdfas723")); //uma chave pra criptografia dos dados

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256); //credemciais do token que é a chave e um algoritimo de criptografia 

            var token = new JwtSecurityToken(claims: dadosUsuario, signingCredentials: credenciais, expires: DateTime.UtcNow.AddHours(2)); //criação do token

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token); //transformação do token em string
            return new Token(tokenString);
        }
    }
}
