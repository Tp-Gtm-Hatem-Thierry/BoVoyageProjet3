﻿using System;
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
        [Required] //^^
        public int NumeroUnique { get; set; }

        [Required] //^^
        public double Reduction //¤ Le diagramme indique du float et non du int pour le type mais on laisse tel quel
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

        //[ForeignKey("DossierReservationId")]
        public  DossierReservation DossierReservation { get; set; } //^^ Je pense que l'on peux enlever virtual tout simplement

        public string NomComplet
        {
            //Selon la cardinalite du diag ca va jusqu'à 9, aussi je pense qu'il nous qlq chose à connecter ensuite à la Class Voyage.places que j'ai créé. A valider bien sur.
            get
            {
                return Civilite + " " + Nom + " " + Prenom + " "; //¤ ajout de '+ " " ' suite à prénom. Est ce necessaire ?
            }
        }
    }
}