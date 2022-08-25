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
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.VehicleId);

            builder.Property(x => x.VehicleId).UseIdentityAlwaysColumn();

            builder.HasOne(x => x.Voyage).WithMany(x => x.Vehicles).HasForeignKey(x => x.VoyageId);
        }
    }
}
