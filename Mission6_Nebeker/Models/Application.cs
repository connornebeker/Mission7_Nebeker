using System.ComponentModel.DataAnnotations;

namespace Mission6_Nebeker.Models;

public class Application
{
    public int Id { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string Rating { get; set; }
    public bool Edited { get; set; }
    public string LentTo { get; set; }
    [MaxLength(25)]
    public string Notes { get; set; }
    
}