using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageProjet3.Models
{
    public class Voyage
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateAller { get; set; }

        [Required]
        public DateTime DateRetour { get; set; }

        [Required]
        public int PlacesDisponibles { get; set; }

        [Required]
        public decimal PrixParPersonne { get; set; }

        [Required]
        public int DestinationId { get; set; }

        [Required]
        public int AgenceVoyageId { get; set; }


        [ForeignKey("DestinationId")]
        public Destination Destination { get; set; }

        [ForeignKey("AgenceVoyageId")]
        public AgenceVoyage AgenceVoyage { get; set; }
    }
}