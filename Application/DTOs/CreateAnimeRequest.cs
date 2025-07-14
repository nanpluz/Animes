using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.DTOs
{
    public class CreateAnimeRequest
    {
        [Required]
        [MinLength(2, ErrorMessage = "At least two characters per anime name.")]
        public string Name { get; set; } = "";

        [Required]
        [MinLength(2, ErrorMessage = "At least two characters per anime director.")]
        public string Director { get; set; } = "";

        public string Summary { get; set; } = "";
    }
}
