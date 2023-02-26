using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entity_Type_Configurations
{
    public class Domain_Example_Configuration : IEntityTypeConfiguration<Domain_Example>
    {
        public void Configure(EntityTypeBuilder<Domain_Example> builder)
        {
            builder.Property(person => person.Name).HasMaxLength(20);
        }
    }
}
