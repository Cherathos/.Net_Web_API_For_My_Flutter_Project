using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Project_For_Flutter.Models.Entities
{
    public class Furniture
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage ="Price must be over than 0.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be over than 0.")]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
