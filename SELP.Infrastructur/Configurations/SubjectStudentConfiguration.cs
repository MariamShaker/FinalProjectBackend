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
    
        public class SubjectStudentConfiguration : IEntityTypeConfiguration<SubjectStudent>
        {
            public void Configure(EntityTypeBuilder<SubjectStudent> builder)

            {

            builder.HasKey(x => new { x.StudID, x.SubID });

            builder.HasOne(SS => SS.student)
               .WithMany(S => S.SubjectStudents)
               .HasForeignKey(SS => SS.StudID);
            
            builder.HasOne(SS => SS.subject)
            .WithMany(S => S.SubjectStudent)
            .HasForeignKey(SS => SS.SubID);

        }
        }
    
}
