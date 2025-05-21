using Microsoft.AspNetCore.Identity;

namespace CentraliaStore.Areas.Identity
{
    public class AppRole : IdentityRole
    {
        public string PrettyRoleName { get; set; }
    }
}
