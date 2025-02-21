using System.ComponentModel.DataAnnotations;

namespace Mission6_Nebeker.Models;

public class Category
{
    [Required][Key]
    public int CategoryId { get; set; }
    [Required]
    public string CategoryName { get; set; }
}