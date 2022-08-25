using MapegServisGuzergah.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Dal.Concrete.EntityFramework.Configuration
{
    internal class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(x => x.StationId);

            builder.Property(x => x.StationId).UseIdentityAlwaysColumn();

            builder.HasOne(x => x.Location).WithOne(x => x.Station).HasForeignKey<Location>(x => x.LocationId);
        }
    }
}
