using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace BoVoyageProjet3.Models
{
//Model de table Personne pour la base de donnée
    public class Client : Personne
    {
        //public int Id { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}