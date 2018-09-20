using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageProjet3.Models
{
    //Model de table Assurance
    public class Assurance
    {
        public int Id { get; set; }

        [Required]
        public decimal Montant { get; set; }

        public int DossierReservationId { get; set; }

        [ForeignKey("DossierReservationId")]
        public List<DossierReservation> DossierReservations { get; set; } //suppression collection

        public TypeAssurance TypeAssurance { get; set; }
        //public virtual ICollection<DossierReservation> DossierReservations { get; set; }
    }
    public enum TypeAssurance { Annulation = 1 }

}