using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BoVoyageProjet3.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Continent { get; set; }
        public string Pays { get; set; }
        public string Description { get; set; }
    }
}