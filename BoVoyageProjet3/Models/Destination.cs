using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageProjet3.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Continent { get; set; }
        public string Pays { get; set; }
        public  string  description { get; set; }
    }
}