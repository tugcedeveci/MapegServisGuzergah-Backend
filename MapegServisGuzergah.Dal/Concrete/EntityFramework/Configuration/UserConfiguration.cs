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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.Property(x => x.UserId).UseIdentityAlwaysColumn();

            builder.HasOne(x => x.Voyage).WithMany(x => x.Users).HasForeignKey(x => x.VoyageId);

            //builder.HasMany(x => x.Vehicles);

            //builder.HasMany(x => x.Users);
        }
    }
}
