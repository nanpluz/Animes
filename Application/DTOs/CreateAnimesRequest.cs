using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateAnimeRequest
    {
        public string Name { get; set; } = "";
        public string Director { get; set; } = "";
        public string Summary { get; set; } = "";
    }
}
