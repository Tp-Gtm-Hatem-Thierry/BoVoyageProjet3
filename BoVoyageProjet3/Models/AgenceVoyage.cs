using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace BoVoyageProjet3.Models
{
    //Model et attributs de la table AgenceVoyage pour la base de donnée
    public class AgenceVoyage
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        //^^[ForeignKey("VoyageId")] //a tester
        public int VoyageId { get; set; }//^^ regle de nommage VoyageID>VoyageId

        public ICollection<Voyage> Voyages { get; set; }

    }
}