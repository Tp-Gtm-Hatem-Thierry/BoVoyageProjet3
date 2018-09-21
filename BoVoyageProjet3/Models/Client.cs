using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace BoVoyageProjet3.Models
{
    /// Model et attributs de la table Client pour la base de données
    public class Client : Personne
    {

        [StringLength(50)]
        public string Email { get; set; }

    }
}