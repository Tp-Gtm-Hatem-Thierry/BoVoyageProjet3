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
        [StringLength(60)] //¤ taille raisonnable pour le nom d'un pays je pense
        public string Pays { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
    }
}