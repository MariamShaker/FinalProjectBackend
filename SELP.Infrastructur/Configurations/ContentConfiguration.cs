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
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)

        {

            builder.HasKey(x => new { x.ContentID });

            builder.HasOne(SS => SS.Subject)
               .WithMany(S => S.Contents)
               .HasForeignKey(SS => SS.subjectID)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.quizzes)
                .WithOne(q => q.content)
                .HasForeignKey(q => q.ContentID)
                .OnDelete(DeleteBehavior.Cascade);

        }
    
    
    }
}
