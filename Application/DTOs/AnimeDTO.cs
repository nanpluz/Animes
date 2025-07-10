using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;
public class AnimeDTO
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Summary { get; set; } = "";
    public required string Director { get; set; }
}