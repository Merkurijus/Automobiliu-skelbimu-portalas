using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobiliu_skelbimu_portalas.Data
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public int LastName { get; set; }
       
        
    }
}
