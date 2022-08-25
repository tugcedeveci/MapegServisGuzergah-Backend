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
    internal class VoyageConfiguration : IEntityTypeConfiguration<Voyage>
    {
        public void Configure(EntityTypeBuilder<Voyage> builder)
        {
            builder.HasKey(x => x.VoyageId);

            builder.Property(x => x.VoyageId).UseIdentityAlwaysColumn();

            builder.HasOne(x => x.Route).WithMany(x => x.Voyages).HasForeignKey(x => x.RouteId);


            //builder.HasMany(x => x.Vehicles);

            //builder.HasMany(x => x.Users);
        }
    }
}
