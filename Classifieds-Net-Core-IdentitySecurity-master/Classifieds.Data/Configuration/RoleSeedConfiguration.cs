using Classifieds.Data.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classifieds.Data.Configuration
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                 new IdentityRole
                 {
                     Id = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                     Name = Roles.Customer,
                     NormalizedName = Roles.Customer.ToUpper(),
                 },
                 new IdentityRole
                 {
                     Id = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                     Name = Roles.Administrator,
                     NormalizedName = Roles.Administrator.ToUpper()
                 }
            );
        }
    }
}
