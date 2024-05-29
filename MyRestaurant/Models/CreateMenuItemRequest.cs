using System.ComponentModel.DataAnnotations;

namespace MyRestaurant.Api.Models;

public class CreateMenuItemRequest
{
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }
}