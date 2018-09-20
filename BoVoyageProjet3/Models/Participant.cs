﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageProjet3.Models
{
    public class Participant : Personne
    {
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

        public int DossierReservationId { get; set; }

        //[ForeignKey("DossierReservationId")]
        public virtual DossierReservation DossierReservation { get; set; }
        public string NomComplet
        {
            get
            {
                return Civilite + " " + Nom + " " + Prenom;
            }
        }


    }
}