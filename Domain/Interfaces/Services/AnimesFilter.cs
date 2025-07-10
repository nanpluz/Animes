using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public class AnimesFilter
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
    }
}
