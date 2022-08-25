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
    internal class VoyageStationConfiguration : IEntityTypeConfiguration<VoyageStations>
    {
        public void Configure(EntityTypeBuilder<VoyageStations> builder)
        {
            builder.HasKey(x => x.VoyageStationId);

            builder.Property(x => x.VoyageStationId).UseIdentityAlwaysColumn();

            builder.HasOne(x => x.Voyage).WithMany(x => x.VoyageStations).HasForeignKey(x => x.VoyageId);

            builder.HasOne(x => x.Station).WithMany(x => x.VoyageStations).HasForeignKey(x => x.StationId);
        }
    }
}
