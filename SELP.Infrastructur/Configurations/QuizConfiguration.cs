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
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)

        {

            builder.HasKey(x => new { x.QuizID });

            builder.HasOne(SS => SS.content)
               .WithMany(S => S.quizzes)
               .HasForeignKey(SS => SS.ContentID)
               .OnDelete(DeleteBehavior.Cascade);

           

        }


    }
}
