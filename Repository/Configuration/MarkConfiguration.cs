using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;

namespace Repository.Configuration
{
    internal class MarkConfiguration : IEntityTypeConfiguration<Mark>
    {
        //public DateAndTime date = new DateAndTime.
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.HasData
                (new Mark
                {
                    Id = new Guid("aca90b78-fea9-4679-a600-e047765d1c65"),
                    SubjectId = new Guid("22ec677b-2a66-4cc0-8590-0ae600f587cc"),
                    MarkValue = 80,
                    CreatedDate = DateTime.Now,
                    StudentId = new Guid("9121c45f-aab8-4041-a582-51e3c5454cde")

                },
                new Mark
                {
                    Id = new Guid("8e68496b-d691-4162-82a9-41cc2a4d89aa"),
                    SubjectId = new Guid("21dc68ab-72e4-41c0-b27f-9e3631c3da88"),
                    MarkValue = 90,
                    CreatedDate = DateTime.Now,
                    StudentId = new Guid("caa44bf4-b109-4fe8-84cd-dbf87b8906c4")

                }
                );




    }
    } }
