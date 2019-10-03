using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrowSeeds.Web.Data.Entities
{
    public class User : IdentityUser
    {
        public ICollection<PlantData> Plants { get; set; }
    }
}
