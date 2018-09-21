using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageProjet3.Models
{
    /// Model et attributs de la table Personne pour la base de données
    public abstract class Personne
    {
        public int Id { get; set; }

        [StringLength(12)]
        public string Civilite { get; set; }

        [Required]
        [StringLength(30)]
        public string Nom { get; set; }

        [Required]
        [StringLength(20)]
        public string Prenom { get; set; }

        [Required]
        [StringLength(150)]
        public string Adresse { get; set; }

        [Required]
        [StringLength(15)]
        public string Telephone { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        public int Age => DateTime.Today.Year - DateNaissance.Year;

    }
}