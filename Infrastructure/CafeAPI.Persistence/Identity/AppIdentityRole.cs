using Microsoft.AspNetCore.Identity;

namespace CafeAPI.Persistence.Identity
{
    public class AppIdentityRole : IdentityRole
    {
        public string Name { get; set; }

        public AppIdentityRole(string name) : base(name)
        {
            Name = name;
        }
    }
}
