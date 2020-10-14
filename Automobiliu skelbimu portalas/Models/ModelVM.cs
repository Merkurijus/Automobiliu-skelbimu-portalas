using Automobiliu_skelbimu_portalas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Models
{
    public class ModelVM
    {

        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; }
        public int? MakeId { get; set; }
        public Make Make { get; set; }
    }
    public class CreateModelVM
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public IEnumerable<SelectListItem> MakelList { get; set; }
        public int? MakeId { get; set; }
        public Make Make { get; set; }
    }
}
