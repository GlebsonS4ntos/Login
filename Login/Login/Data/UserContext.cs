using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Login.Data
{
    public class UserContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
    }
}
