using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageProjet3.Models
{
    //Model et attributs de la table Destination pour la base de donnée
    public class Destination
    {
        public int Id { get; set; }

        [Required]
        public string Continent { get; set; }

        [Required]
        [StringLength(60)]
        public string Pays { get; set; }

        [Required]
        [StringLength(120)]
        public string Region { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }
    }
}