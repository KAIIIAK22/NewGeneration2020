using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Configuration
{
    public class MediaTypeConfiguration : EntityTypeConfiguration<MediaType>
    {
        public MediaTypeConfiguration()
        {
            ToTable("MediaType").
                HasKey(p => p.Id).
                Property(p => p.Type).HasMaxLength(25).
                HasColumnType("varchar");
            HasMany(p => p.Media)
                .WithRequired(p => p.MediaType);
        }
    }
}
