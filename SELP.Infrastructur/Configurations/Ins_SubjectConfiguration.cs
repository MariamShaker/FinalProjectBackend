using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SELP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Infrastructur.Configurations
{
    public class Ins_SubjectConfiguration : IEntityTypeConfiguration<Ins_Subject>
    {
        public void Configure(EntityTypeBuilder<Ins_Subject> builder)
        {

            builder.HasKey(x => new { x.SubId, x.InsId });

            builder.HasOne(IS => IS.instructor)
                        .WithMany(d => d.In_subjects)
                        .HasForeignKey(IS => IS.InsId);

            builder.HasOne(IS => IS.subject)
                .WithMany(s => s.Ins_Subjects)
                .HasForeignKey(IS => IS.SubId);
            
        }
    }
}
