using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Models
{
    public class BodyTypeVM
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
