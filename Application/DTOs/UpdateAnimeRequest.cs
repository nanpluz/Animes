using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateAnimeRequest
    {
        [Key]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0")]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Director { get; set; } = "";
        public string Summary { get; set; } = "";
    }
}
