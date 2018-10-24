using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ImmigrationNewSetup.Models
{
    public class dbcontext:DbContext
    {
        public dbcontext():base("dbcontext")
        {
            //Database.SetInitializer<dbcontext>(new CreateDatabaseIfNotExists<dbcontext>());
            Database.SetInitializer<dbcontext>(new MigrateDatabaseToLatestVersion<dbcontext, ImmigrationNewSetup.Migrations.Configuration>("dbcontext"));

        }

        public System.Data.Entity.DbSet<ImmigrationNewSetup.Models.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<ImmigrationNewSetup.Models.studentdetail> studentdetails { get; set; }

        public System.Data.Entity.DbSet<ImmigrationNewSetup.Models.Studentdocs> Studentdocs { get; set; }

        public System.Data.Entity.DbSet<ImmigrationNewSetup.Models.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<ImmigrationNewSetup.Models.AssignedFiles> AssignedFiles { get; set; }
    }
}