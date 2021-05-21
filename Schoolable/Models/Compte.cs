using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolable.Models
{
    public class Compte
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdateTimestamp { get; set; }
        public ICollection<Role> Roles { get; set; } = new List<Role>();






    }
}
