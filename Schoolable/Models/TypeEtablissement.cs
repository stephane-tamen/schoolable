using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolable.Models
{
    public class TypeEtablissement
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public string  Code { get; set; }
        [Required]
        public string Libelle { get; set; }

        public DateTime CreatedTimestamp { get; set; }

        public DateTime UpdateTimestamp { get; set; }
        public ICollection<Etablissement> Etablissements { get; set; } = new List<Etablissement>();

       
    }
}
