using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageProjet3.Models
{
    //Model des dossier de Reservation assurance
    public class AssuranceDossierReservation
    {
        [Key, Column(Order = 0)]
        public int AssuranceId { get; set; }
        [Key, Column(Order = 1)]
        public int DossierReservationId { get; set; }

        [ForeignKey("AssuranceId")]
        public virtual Assurance Assurance { get; set; }

        [ForeignKey("DossierReservationId")]
        public virtual DossierReservation DossierReservation { get; set; }
    }
}