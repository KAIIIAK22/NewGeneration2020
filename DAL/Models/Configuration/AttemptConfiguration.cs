using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Configuration
{
    public class AttemptConfiguration : EntityTypeConfiguration<Attempt>
    {
        public AttemptConfiguration()
        {
            ToTable("Attempt").
                Property(a => a.TimeStamp).
                IsRequired().
                HasColumnType("datetime");

        }
    }
}
