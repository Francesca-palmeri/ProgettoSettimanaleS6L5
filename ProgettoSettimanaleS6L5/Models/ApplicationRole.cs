using Microsoft.AspNetCore.Identity;

namespace ProgettoSettimanaleS6L5.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

    }
}
