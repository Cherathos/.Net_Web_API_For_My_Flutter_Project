using API_Project_For_Flutter.Data;
using API_Project_For_Flutter.Models;
using API_Project_For_Flutter.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Project_For_Flutter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FurnituresController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

        public FurnituresController(ApplicationDBContext dBContext) 
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult GetAllFurnitures()
        {
            var furnitures = dBContext.Furnitures.Select(f => new
            {
                f.Id,
                f.Name,
                f.Price,
                f.Quantity,
                f.Description
            }).ToList();

            if (furnitures == null || !furnitures.Any())
            {
                return NotFound("No furniture found.");
            }

            return Ok(furnitures);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        public IActionResult GetFurnitureById(Guid Id)
        {
            var furnitureEntity = dBContext.Furnitures.Find(Id);
            if (furnitureEntity == null)
            {
                return NotFound();
            }
            return Ok(furnitureEntity);
        }

        [HttpGet]
        [Route("search/{Name}")]
        public IActionResult SearchFurnitureByName(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
                return BadRequest("Name parameter is required.");

            var results = dBContext.Furnitures
                .Where(f => f.Name.ToLower().Contains(Name.ToLower()))
                .ToList();

            if (!results.Any())
                return NotFound("No furniture found with the given name.");

            return Ok(results);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateFurniture([FromBody] AddFurnitureDto addFurniture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var furnitureEntity = new Furniture()
            {
                Price = addFurniture.Price,
                Quantity = addFurniture.Quantity,
                Name = addFurniture.Name,
                Description = addFurniture.Description
            };


            dBContext.Furnitures.AddAsync(furnitureEntity);
            dBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFurnitureById), new {id = furnitureEntity.Id}, furnitureEntity);

        }

        [Authorize]
        [HttpDelete("{Id}")]
        public IActionResult DeleteFurniture(Guid Id)
        {
            var furnitureEntity = dBContext.Furnitures.Find(Id);
            if (furnitureEntity == null)
            {
                return NotFound();
            }
            dBContext.Furnitures.Remove(furnitureEntity);
            dBContext.SaveChanges();
            return Ok(furnitureEntity);
        }

        [Authorize]
        [HttpPut]
        [Route("{Id:guid}")]
        public IActionResult UpdateFurniture(Guid Id, UpdateFurnitureDTO updateFurnitureDTO)
        {
            var furnitureEntity = dBContext.Furnitures.Find(Id);

            if (furnitureEntity == null)
            {
                return NotFound();
            }

            furnitureEntity.Price = updateFurnitureDTO.Price;
            furnitureEntity.Quantity = updateFurnitureDTO.Quantity;
            furnitureEntity.Name = updateFurnitureDTO.Name;
            furnitureEntity.Description = updateFurnitureDTO.Description;

            dBContext.SaveChanges();

            return Ok(furnitureEntity);
        }
    }
}
