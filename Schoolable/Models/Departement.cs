using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolable.Models
{
    public class Departement
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public string Nom_departement { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdateTimestamp { get; set; }
        public long EtablissementId { get; set; }
        [Required]
        public Etablissement Etablissement { get; set; }

    }
}
