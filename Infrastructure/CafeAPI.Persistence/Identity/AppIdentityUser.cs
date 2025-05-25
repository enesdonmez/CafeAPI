using Microsoft.AspNetCore.Identity;

namespace CafeAPI.Persistence.Identity
{
    public class AppIdentityUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
