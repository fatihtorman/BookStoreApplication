using Pomelo.EntityFrameworkCore.MySql.Design;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Configuration
{
    public class IsbnConfiguration : IEntityTypeConfiguration<Isbn>
    {
        public void Configure(EntityTypeBuilder<Isbn> builder)
        {
            builder
                .HasKey(a => a.Id);


            builder.Property(c => c.Id).UseMySqlIdentityColumn();


        }
    }
}
