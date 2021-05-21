using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolable.Models
{
    public class Role
    {
        public long Id { get; set; }
        public string RoleName { get; set; }
        public string Designation { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdateTimestamp { get; set; }
        public ICollection<Compte> Comptes { get; set; } = new List<Compte>();

    }
}
