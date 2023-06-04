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
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
     
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasData
               (new Group
               {
                   Id = new Guid("339cc24f-5d1e-48e3-a0a2-f03baa93c2eb"),
                   GroupName = "144b",
                   GroupCourse = 4


               },
               new Group
               {
                   Id = new Guid("5e5d5c0e-1b88-45e4-96c4-059f2db0de95"),
                   GroupName = "143b",
                   GroupCourse = 1
               }

               );
        }
    }
}
