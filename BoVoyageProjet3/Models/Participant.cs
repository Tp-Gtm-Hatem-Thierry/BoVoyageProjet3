using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageProjet3.Models
{
    //Model et attributs de la table Participant pour la base de donnée
    public class Participant : Personne
    {
        //^^public new int Id { get; set; }

        public int NumeroUnique { get; set; }

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
        //¤Voir si Reduction et NomComplet peuvent etre basculer en bas vis a vis de la BD
        public int DossierReservationId { get; set; }

        [ForeignKey("DossierReservationId")]
        public virtual DossierReservation DossierReservation { get; set; }

        public string NomComplet
        {
            get
            {
                return Civilite + " " + Nom + " " + Prenom + " "; //¤ ajout de '+ " " ' suite à prénom. Est ce necessaire ?
            }
        }

    }
}