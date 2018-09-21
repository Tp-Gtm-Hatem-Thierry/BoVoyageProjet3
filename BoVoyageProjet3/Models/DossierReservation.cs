using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageProjet3.Models
{
    /// Model et attributs de la table DossierReservation pour la base de données
    public class DossierReservation
    {
        public int Id { get; set; }

        [Required]
        public int NumeroUnique { get; set; }

        [Required]
        public string NumeroCarteBancaire { get; set; }

        [Required]
        public decimal PrixParPersonne { get; set; }

        [Required]
        public decimal PrixTotal { get; set; }

        public EtatDossierReservation EtatDossierReservation { get; set; }

        public RaisonAnnulationDossier RaisonAnnulationDossier { get; set; }

        public int VoyageId { get; set; }

        public int ClientId { get; set; }

        public int ParticipantId { get; set; }

        [ForeignKey("VoyageId")]
        public Voyage Voyage { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        
        public List<Participant> Participants { get; set; }

        public List<Assurance> Assurances { get; set; }

    }

    public enum EtatDossierReservation { EnAttente, EnCours, Refuse, Accepte, Clos, Annule }

    /// Le diagramme représente une interface par le use mais enum sera utilisé
    public enum RaisonAnnulationDossier { Client = 1, PlacesInsuffisantes = 2, SoldeInsuffisant = 3 }
}