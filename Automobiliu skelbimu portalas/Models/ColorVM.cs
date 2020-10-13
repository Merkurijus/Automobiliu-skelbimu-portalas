using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Models
{
    public class ColorVM
    {
        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; }
    }
    public class CreateColorVM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
