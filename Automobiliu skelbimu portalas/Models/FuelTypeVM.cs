using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Models
{
    public class FuelTypeVM
    {
        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; }
    }
    public class CreateFuelTypeVM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
