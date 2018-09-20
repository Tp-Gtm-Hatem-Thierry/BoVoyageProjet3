namespace BoVoyageProjet3
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgenceVoyages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 100),
                        VoyageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Voyages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAller = c.DateTime(nullable: false),
                        DateRetour = c.DateTime(nullable: false),
                        PlacesDisponibles = c.Int(nullable: false),
                        PrixParPersonne = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DestinationId = c.Int(nullable: false),
                        Places = c.Int(nullable: false),
                        AgenceVoyageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgenceVoyages", t => t.AgenceVoyageId, cascadeDelete: true)
                .ForeignKey("dbo.Destinations", t => t.DestinationId, cascadeDelete: true)
                .Index(t => t.DestinationId)
                .Index(t => t.AgenceVoyageId);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Continent = c.String(nullable: false),
                        Pays = c.String(nullable: false, maxLength: 60),
                        Region = c.String(nullable: false, maxLength: 60),
                        Description = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Assurances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DossierReservationId = c.Int(nullable: false),
                        TypeAssurance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DossierReservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroUnique = c.Int(nullable: false),
                        NumeroCarteBancaire = c.String(nullable: false),
                        PrixParPersonne = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrixTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EtatDossierReservation = c.Int(nullable: false),
                        RaisonAnnulationDossier = c.Int(nullable: false),
                        VoyageId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ParticipantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personnes", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Voyages", t => t.VoyageId, cascadeDelete: true)
                .Index(t => t.VoyageId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Civilite = c.String(maxLength: 12),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Prenom = c.String(nullable: false, maxLength: 20),
                        Adresse = c.String(nullable: false, maxLength: 150),
                        Telephone = c.String(nullable: false, maxLength: 15),
                        DateNaissance = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 50),
                        NumeroUnique = c.Int(),
                        DossierReservationId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DossierReservations", t => t.DossierReservationId, cascadeDelete: true)
                .Index(t => t.DossierReservationId);
            
            CreateTable(
                "dbo.DossierReservationAssurances",
                c => new
                    {
                        DossierReservation_Id = c.Int(nullable: false),
                        Assurance_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DossierReservation_Id, t.Assurance_Id })
                .ForeignKey("dbo.DossierReservations", t => t.DossierReservation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Assurances", t => t.Assurance_Id, cascadeDelete: true)
                .Index(t => t.DossierReservation_Id)
                .Index(t => t.Assurance_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DossierReservations", "VoyageId", "dbo.Voyages");
            DropForeignKey("dbo.Personnes", "DossierReservationId", "dbo.DossierReservations");
            DropForeignKey("dbo.DossierReservations", "ClientId", "dbo.Personnes");
            DropForeignKey("dbo.DossierReservationAssurances", "Assurance_Id", "dbo.Assurances");
            DropForeignKey("dbo.DossierReservationAssurances", "DossierReservation_Id", "dbo.DossierReservations");
            DropForeignKey("dbo.Voyages", "DestinationId", "dbo.Destinations");
            DropForeignKey("dbo.Voyages", "AgenceVoyageId", "dbo.AgenceVoyages");
            DropIndex("dbo.DossierReservationAssurances", new[] { "Assurance_Id" });
            DropIndex("dbo.DossierReservationAssurances", new[] { "DossierReservation_Id" });
            DropIndex("dbo.Personnes", new[] { "DossierReservationId" });
            DropIndex("dbo.DossierReservations", new[] { "ClientId" });
            DropIndex("dbo.DossierReservations", new[] { "VoyageId" });
            DropIndex("dbo.Voyages", new[] { "AgenceVoyageId" });
            DropIndex("dbo.Voyages", new[] { "DestinationId" });
            DropTable("dbo.DossierReservationAssurances");
            DropTable("dbo.Personnes");
            DropTable("dbo.DossierReservations");
            DropTable("dbo.Assurances");
            DropTable("dbo.Destinations");
            DropTable("dbo.Voyages");
            DropTable("dbo.AgenceVoyages");
        }
    }
}
