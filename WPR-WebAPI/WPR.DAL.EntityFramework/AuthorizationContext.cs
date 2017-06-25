using PartnerView.DAL.EntityFramework.Mapping;
using PartnerView.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerView.DAL.EntityFramework
{
    public class AuthorizationContext : DbContext
    {
        public AuthorizationContext() : base("Name=AuthContext") { }

        static AuthorizationContext()
        {
            Database.SetInitializer<AuthorizationContext>(null);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


        }
    }
}
