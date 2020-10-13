using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Models
{
    public class MarkedVM
    {
        [Key]
        public int Id { get; set; }
        public AdVM Ad { get; set; }
        public int AdId { get; set; }
        public UserVM User { get; set; }
        public int UserId { get; set; }
        public DateTime Time { get; set; }
    }
}
