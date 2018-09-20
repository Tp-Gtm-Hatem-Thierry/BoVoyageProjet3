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

        public DateTime DateAller { get; set; }
        public DateTime DateRetour { get; set; }
        public int PlacesDisponibles { get; set; }
        public decimal PrixParPersonne { get; set; }

        public int DestinationId { get; set; }
        public int AgenceVoyageId { get; set; }


        [ForeignKey("DestinationId")]
        public Destination Destination { get; set; }
        [ForeignKey("AgenceVoyageId")]
        public AgenceVoyage AgenceVoyage { get; set; }
    }
}