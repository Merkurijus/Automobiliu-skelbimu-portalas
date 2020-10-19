using Automobiliu_skelbimu_portalas.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Models
{
    public class ImageVM
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public Ad Ad { get; set; }
        [ForeignKey("AdId")]
        public int AdId { get; set; }
    }
}
