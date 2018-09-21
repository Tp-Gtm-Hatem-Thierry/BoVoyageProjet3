using System;
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
        [Required]//^^
        public decimal PrixParPersonne { get; set; }

        [Required]//^^
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


        public RaisonAnnulationDossier RaisonAnnulationDossier { get; set; }//^^ pour rester coerent avec la l.74
        //public byte RaisonAnnulationDossier { get; set; }//^^ commentaire du dessus

        public int VoyageId { get; set; }

        public int ClientId { get; set; }

        public int ParticipantId { get; set; } //¤ FK ou pas ? car Id

        [ForeignKey("VoyageId")]
        public Voyage Voyage { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        //^^public Assurance Assurances { get; set; } //^^suppression collection

        //^^[ForeignKey("ParticipantId")]

        public List<Participant> Participants { get; set; } //suppression collection

        public List<Assurance> Assurances { get; set; } //suppression collection

    }

    public enum EtatDossierReservation { EnAttente, EnCours, Refuse, Accepte, Clos, Annule }
    public enum RaisonAnnulationDossier { Client = 1, PlacesInsuffisantes = 2, SoldeInsuffisant = 3 }//^^ Selon diag de class, cette classe fait un <<use>>, donc une interface normalement non ?
}