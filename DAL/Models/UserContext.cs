using DAL.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("DefaultConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<TemporaryMedia> TemporaryMedia { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Attempt> Attempts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new MediaConfiguration());
            modelBuilder.Configurations.Add(new TemporaryMediaConfiguration());
            modelBuilder.Configurations.Add(new MediaTypeConfiguration());
            modelBuilder.Configurations.Add(new AttemptConfiguration());
            base.OnModelCreating(modelBuilder);
        }



    }
}
