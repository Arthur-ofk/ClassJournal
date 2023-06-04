using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
   public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder )
        {
            builder.HasData
                (
                new Subject
                {
                    Id = new Guid("22ec677b-2a66-4cc0-8590-0ae600f587cc"),
                    SubjectName = "Math"
                }
                , new Subject
                {
                    Id = new Guid("21dc68ab-72e4-41c0-b27f-9e3631c3da88"),
                    SubjectName ="Programming"
                });

        } 
    }
}
