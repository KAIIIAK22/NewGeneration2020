using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Models.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users").HasKey(p => p.Id).Property(p => p.Id).IsRequired();
            Property(p => p.Nick).IsRequired().HasColumnType("varchar").HasMaxLength(16);
            Property(p => p.Email).IsRequired().HasColumnType("varchar").HasMaxLength(40);
            Property(p => p.Password).IsRequired().HasMaxLength(50).HasColumnType("varchar");

            HasMany(p => p.Roles)
            .WithMany(c => c.Users);

            HasMany(p => p.Media)
            .WithRequired(p => p.User);

            HasMany(p => p.Attempts)
            .WithRequired(p => p.User);

            HasMany(p => p.TemporaryMedia)
                .WithRequired(p => p.User);
        }
    }
}
