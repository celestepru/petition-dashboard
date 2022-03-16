using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace cw1.Models
{
    public class MembersDB : DbContext
    {
        public MembersDB() : base("DefaultConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MembersDB>());
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Petition> Petitions { get; set; }
    }
}