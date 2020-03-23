using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//using MySql.Data.Entity;

namespace html.Models
{
    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class UserContext : DbContext
    {
        public UserContext() :
            base("DefaultConnection")
        { }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().Property(t => t.Email).HasColumnName("Email");
            modelBuilder.Entity<User>().Property(t => t.Password).HasColumnName("Password");
            modelBuilder.Entity<User>().HasRequired(e => e.Email).WithMany().HasForeignKey(e => e.Email);
            modelBuilder.Entity<User>().HasRequired(e => e.Password).WithMany().HasForeignKey(e => e.Password);*/
            //map other properties too    
        }
    }
    
}