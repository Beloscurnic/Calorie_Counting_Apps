using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entity_Type_Configurations
{
    public class CalorieIntakeConfiguration : IEntityTypeConfiguration<CalorieIntake>
    {
        public void Configure(EntityTypeBuilder<CalorieIntake> builder)
        {
            //builder.Property(person => person.Name).HasMaxLength(20);
            builder.HasKey(c => c.Id);
        }
    }
}
