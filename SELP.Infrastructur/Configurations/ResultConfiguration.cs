using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SELP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Infrastructur.Configurations
{
    public class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)

        {

            builder.HasKey(x => new { x.ResultID });

            builder.HasOne(SS => SS.student)
               .WithMany(S => S.Results)
               .HasForeignKey(SS => SS.StudentID)
               .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.subject)
                .WithMany() // Assuming there's no navigation property on Subject referring to Results
                .HasForeignKey(e => e.SubjectID)
                .OnDelete(DeleteBehavior.Restrict);



        }


    }
}
