using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolable.Models
{

    public class Etablissement
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public string Num_reference { get; set; }
        [Required]
        public string Nom_etablissement { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdateTimestamp { get; set; }
        public long TypeEtablissementId { get; set; }
        [Required]
        public TypeEtablissement TypeEtablissement { get; set; }
        public ICollection<Departement> Departements { get; set; } = new List<Departement>();
        public ICollection<Salle> Salles { get; set; } = new List<Salle>();

    }
}
