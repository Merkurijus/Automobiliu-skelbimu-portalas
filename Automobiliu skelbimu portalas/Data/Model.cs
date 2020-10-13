using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Data
{
    public class Model
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [ForeignKey("MakeId")]
        public int? MakeId { get; set; }
        public Make Make { get; set; }
    }
}
