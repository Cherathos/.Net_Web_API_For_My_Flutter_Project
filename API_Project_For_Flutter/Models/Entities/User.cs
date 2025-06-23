using Microsoft.AspNetCore.Identity;

namespace API_Project_For_Flutter.Models.Entities
{
    public class User : IdentityUser
    {
        public string? Initials { get; set; }

        public ICollection<Furniture> Furnitures { get; set; }
    }
}
