using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowSeeds.Web.Data.Entities
{
    public class Manager
    {
        public int Id { get; set; }
        public UserDatabase User { get; set; }
    }
}
