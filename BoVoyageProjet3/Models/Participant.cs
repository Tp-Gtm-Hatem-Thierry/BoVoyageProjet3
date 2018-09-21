using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageProjet3.Models
{
    /// Model et attributs de la table Participant pour la base de données
    public class Participant : Personne
    {
        [Required]
        public int NumeroUnique { get; set; }

        /// Le diagramme requière un type float, sur demande instructeur, un type int sera utilisé
        [Required]
        public double Reduction
        {
            get
            {
                if (Age < 12)
                    return 0.6d;
                else
                    return 0d;
            }
        }
        public int DossierReservationId { get; set; }

        public DossierReservation DossierReservation { get; set; }

        /// <summary>
        /// Récupération Civilité, Nom, Prenom
        /// </summary>
        public string NomComplet
        {
            get
            {
                return Civilite + " " + Nom + " " + Prenom + " ";
            }
        }
    }
}