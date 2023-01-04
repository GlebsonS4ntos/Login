using AutoMapper;
using Login.Data.DTO;
using Login.Models;
using Microsoft.AspNetCore.Identity;

namespace Login.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<CreateUsuarioDTO, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }
    }
}
