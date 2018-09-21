﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageProjet3.Models
{
    //Model et attributs de la table DossierReservation pour la base de donnée
    public class DossierReservation
    {
        public int Id { get; set; }

        [Required]
        public int NumeroUnique { get; set; }

        [Required]
        public string NumeroCarteBancaire { get; set; }

        //^^prix par perszonne a calculer
        [Required]
        public decimal PrixParPersonne { get; set; }

        [Required]
        public decimal PrixTotal { get; set; }

        //{
        //    get
        //    {
        //        decimal prixTotal = 0;
        //        foreach (var participant in this.Participants)
        //        {
        //            prixTotal += (1 - (decimal)participant.Reduction) * PrixParPersonne;
        //        }

        //        foreach (var assurance in this.Assurances)
        //        {
        //            if (assurance.TypeAssurance == TypeAssurance.Annulation)
        //            {
        //                prixTotal += (decimal)assurance.Montant;
        //            }
        //        }
        //        return prixTotal;
        //    }
        //}
        public EtatDossierReservation EtatDossierReservation { get; set; }

        public RaisonAnnulationDossier RaisonAnnulationDossier { get; set; }

        public int VoyageId { get; set; }

        public int ClientId { get; set; }

        public int ParticipantId { get; set; }


        [ForeignKey("VoyageId")]
        public Voyage Voyage { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        //Liste des participants et assurances (pour futur offres)
        [ForeignKey ("ParticipantId")] //^^ en attente validation apres test
        public List<Participant> Participants { get; set; }
        public List<Assurance> Assurances { get; set; }

    }

    public enum EtatDossierReservation { EnAttente, EnCours, Refuse, Accepte, Clos, Annule }
    public enum RaisonAnnulationDossier { Client = 1, PlacesInsuffisantes = 2, SoldeInsuffisant = 3 }
}