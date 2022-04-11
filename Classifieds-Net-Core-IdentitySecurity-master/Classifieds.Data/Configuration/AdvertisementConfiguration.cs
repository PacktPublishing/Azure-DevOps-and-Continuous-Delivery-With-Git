using Classifieds.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classifieds.Data.Configuration
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasData(
                    new Advertisement
                    {
                        Id = 1,
                        Title = "BMW M3",
                        Description = "This is a high powered sports car.",
                        Price = 10000,
                        CategoryId = 1
                    },
                    new Advertisement
                    {
                         Id = 2,
                         Title = "Audi A5 - Sportsback",
                         Description = "This is a high powered sports car. Limited Edition",
                         Price = 12000,
                        CategoryId = 2
                    }
                );
        }
    }

}
