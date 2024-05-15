﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SELP.Infrastructur.Data;

#nullable disable

namespace SELP.Infrastructur.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240429030931_addTables")]
    partial class addTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SELP.Data.Entities.Content", b =>
                {
                    b.Property<int>("ContentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContentID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pdf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("subjectID")
                        .HasColumnType("int");

                    b.Property<string>("video")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContentID");

                    b.HasIndex("subjectID");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("SELP.Data.Entities.Ins_Subject", b =>
                {
                    b.Property<int>("SubId")
                        .HasColumnType("int");

                    b.Property<int>("InsId")
                        .HasColumnType("int");

                    b.HasKey("SubId", "InsId");

                    b.HasIndex("InsId");

                    b.ToTable("Ins_Subject");
                });

            modelBuilder.Entity("SELP.Data.Entities.Instructor", b =>
                {
                    b.Property<int>("InsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InsId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("phone")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("position")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("InsId");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("SELP.Data.Entities.Quiz", b =>
                {
                    b.Property<int>("QuizID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuizID"));

                    b.Property<string>("Ans1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ans2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ans3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ans4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContentID")
                        .HasColumnType("int");

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuizID");

                    b.HasIndex("ContentID");

                    b.ToTable("Quiz");
                });

            modelBuilder.Entity("SELP.Data.Entities.Result", b =>
                {
                    b.Property<int>("ResultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResultID"));

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<int?>("TotlalItem")
                        .HasColumnType("int");

                    b.HasKey("ResultID");

                    b.HasIndex("StudentID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Result");
                });

            modelBuilder.Entity("SELP.Data.Entities.Student", b =>
                {
                    b.Property<int>("StudID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("phone")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("StudID");

                    b.ToTable("students");
                });

            modelBuilder.Entity("SELP.Data.Entities.Subject", b =>
                {
                    b.Property<int>("SubID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubID"));

                    b.Property<int?>("Period")
                        .HasColumnType("int");

                    b.Property<string>("SubjectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubID");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("SELP.Data.Entities.SubjectStudent", b =>
                {
                    b.Property<int>("StudID")
                        .HasColumnType("int");

                    b.Property<int>("SubID")
                        .HasColumnType("int");

                    b.Property<decimal?>("grade")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("StudID", "SubID");

                    b.HasIndex("SubID");

                    b.ToTable("SubjectStudent");
                });

            modelBuilder.Entity("SELP.Data.Entities.Content", b =>
                {
                    b.HasOne("SELP.Data.Entities.Subject", "Subject")
                        .WithMany("Contents")
                        .HasForeignKey("subjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SELP.Data.Entities.Ins_Subject", b =>
                {
                    b.HasOne("SELP.Data.Entities.Instructor", "instructor")
                        .WithMany("In_subjects")
                        .HasForeignKey("InsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SELP.Data.Entities.Subject", "subject")
                        .WithMany("Ins_Subjects")
                        .HasForeignKey("SubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("instructor");

                    b.Navigation("subject");
                });

            modelBuilder.Entity("SELP.Data.Entities.Quiz", b =>
                {
                    b.HasOne("SELP.Data.Entities.Content", "content")
                        .WithMany("quizzes")
                        .HasForeignKey("ContentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("content");
                });

            modelBuilder.Entity("SELP.Data.Entities.Result", b =>
                {
                    b.HasOne("SELP.Data.Entities.Student", "student")
                        .WithMany("Results")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SELP.Data.Entities.Subject", "subject")
                        .WithMany()
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("student");

                    b.Navigation("subject");
                });

            modelBuilder.Entity("SELP.Data.Entities.SubjectStudent", b =>
                {
                    b.HasOne("SELP.Data.Entities.Student", "student")
                        .WithMany("SubjectStudents")
                        .HasForeignKey("StudID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SELP.Data.Entities.Subject", "subject")
                        .WithMany("SubjectStudent")
                        .HasForeignKey("SubID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");

                    b.Navigation("subject");
                });

            modelBuilder.Entity("SELP.Data.Entities.Content", b =>
                {
                    b.Navigation("quizzes");
                });

            modelBuilder.Entity("SELP.Data.Entities.Instructor", b =>
                {
                    b.Navigation("In_subjects");
                });

            modelBuilder.Entity("SELP.Data.Entities.Student", b =>
                {
                    b.Navigation("Results");

                    b.Navigation("SubjectStudents");
                });

            modelBuilder.Entity("SELP.Data.Entities.Subject", b =>
                {
                    b.Navigation("Contents");

                    b.Navigation("Ins_Subjects");

                    b.Navigation("SubjectStudent");
                });
#pragma warning restore 612, 618
        }
    }
}