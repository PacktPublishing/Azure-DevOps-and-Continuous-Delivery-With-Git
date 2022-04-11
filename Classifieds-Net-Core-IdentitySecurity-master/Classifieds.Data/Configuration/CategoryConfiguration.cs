using Classifieds.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classifieds.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Motor Car",
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "House",
                    }
                );
        }
    }

}
