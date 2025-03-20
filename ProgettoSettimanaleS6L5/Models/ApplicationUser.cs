using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProgettoSettimanaleS6L5.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [Required]
        public DateOnly? BirthDate { get; set; }

        public ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }

        //inserire Icollection del modello che si vuole collegare
    }
}
