using System.ComponentModel.DataAnnotations;

namespace API_Project_For_Flutter.Models.Entities
{
    public class Furniture
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public required string FurnitureName { get; set; }
        public IFormFile ? Image { get; set; }
        public string ? FurnitureType { get; set; }
        public string ? Description { get; set; }
        [Required]
        public required decimal FurniturePrice { get; set; }
    }
}
