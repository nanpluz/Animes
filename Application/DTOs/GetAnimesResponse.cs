using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.DTOs;
public class GetAnimesResponse
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = "";
    public string Director { get; set; } = "";
    public string Summary { get; set; } = "";
}