using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Data
{
    public class Marked
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AdId")]
        public Ad Ad{ get; set; }
        public int AdId { get; set; }
        public IdentityUser User { get; set; }
        public int UserId { get; set; }
        public DateTime Time { get; set; }
    }
}
