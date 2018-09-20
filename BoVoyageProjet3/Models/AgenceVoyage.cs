using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageProjet3.Models
{
    public class AgenceVoyage
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        public int VoyageID { get; set; }

        [ForeignKey("VoyageID")]
        public ICollection<Voyage> Voyages { get; set; }
        
    }
}