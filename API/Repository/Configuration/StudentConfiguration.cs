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
    internal class StudentConfiguration  : IEntityTypeConfiguration<Student>
    {
        public void Configure( EntityTypeBuilder<Student> builder)
        {
            builder.HasData
              (new Student
              {
                   Id = new Guid("9121c45f-aab8-4041-a582-51e3c5454cde"),
                   StudentName = "Artur",
                   StudentAge = 19,
                   PhoneNumber = "380987432010",
                   Adress = "vulytsya pushkina ,dom kolotushkina",
                   IsStateLearning = false,
                   Email = "arthauz19@gmail.com",

                   Role = "leader",

                   GroupId = new Guid("339cc24f-5d1e-48e3-a0a2-f03baa93c2eb")

              },
              new   Student
              {
                  Id = new Guid("caa44bf4-b109-4fe8-84cd-dbf87b8906c4"),
                  StudentName = "Nazar",
                  StudentAge= 18,
                  PhoneNumber = "0684739285",
                  Adress= "Kobylanska 38",
                  IsStateLearning= false,
                  Email = "Bednyy@gmail.com",
                  Role = "Student",
                  GroupId = new Guid("339cc24f-5d1e-48e3-a0a2-f03baa93c2eb")

              },
              new Student
              {
                  Id = new Guid("559c7c64-1532-4780-bfc1-083f85ae6e33"),
                  StudentName = "Andrew",
                  StudentAge = 22,
                  PhoneNumber = "0680952644",
                  Adress = "Prospekt",
                  IsStateLearning=true,
                  Email = "Andre@gmail.com",

                  Role = "Student",
                  GroupId = new Guid("339cc24f-5d1e-48e3-a0a2-f03baa93c2eb")
              }
              );

        }
    }
}
