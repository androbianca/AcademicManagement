using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ProfConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Prof>
    {
        public void Configure(EntityTypeBuilder<Prof> builder)
        {
           

        }
    }
    
  
}
