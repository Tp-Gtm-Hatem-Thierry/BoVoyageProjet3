using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageProjet3.Models
{
    public class AgenceVoyage
    {

        public int Id { get; set; }
        public string Nom { get; set; }
        public ICollection<Voyage> Voyages { get; set; }
        
    }
}