namespace API_Project_For_Flutter.Models
{
    public class UpdateFurnitureDTO
    {
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
