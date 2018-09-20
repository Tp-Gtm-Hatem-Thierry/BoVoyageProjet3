using BoVoyageProjet3.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BoVoyageProjet3
{
    public class Configuration : DbMigrationsConfiguration<BoVoyageDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
/* Affichage>Autre fentre> add-migration "le nom de la migration" va creer une classe :

  add-migration >> Init << nom de la migration que l'on a donné
  update-database << creation de la base de donnee*/
