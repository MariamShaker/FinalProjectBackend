using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SELP.Data.Entites.Identity;
using SELP.Data.Entities;
using SELP.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Infrastructur.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
        //,IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        private readonly IEncryptionProvider _encryptionProvider;
        public ApplicationDBContext()
        {
            
        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options) 
        {
            _encryptionProvider = new GenerateEncryptionProvider("075761d5-737b42c8-8df4d50b61b2bb");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRefreshToken> userRefreshToken { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Subject> subjects { get; set; }
       // public DbSet<Instructor> instructors { get; set; }
        // public DbSet<Ins_Subject> Ins_Subjects { get; set; }
       // public DbSet<Content> Contents { get; set; }
        public DbSet<SubjectStudent> SubjectStudent { get; set;}



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            


            //modelBuilder.Entity<SubjectStudent>()
            //    .HasKey(x => new { x.StudID, x.SubID });
            //modelBuilder.Entity<Ins_Subject>()
            //    .HasKey(x => new { x.SubId, x.InsId });

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.UseEncryption(_encryptionProvider);
        }

    }
}
