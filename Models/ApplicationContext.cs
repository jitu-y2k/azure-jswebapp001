using System;
using Microsoft.EntityFrameworkCore;

namespace WebApp1.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>().ToTable("Students");

            modelBuilder.Entity<Student>().Property(s => s.Id).HasColumnName("StudentId");

            modelBuilder.Entity<Student>().HasKey(s => s.Id);

            //modelBuilder.Entity<Student>().HasKey(s => new { s.Id, s.Name });

            modelBuilder.Entity<Student>().Property(s => s.Name).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Student>().Property(s => s.Age).IsRequired(true);
            modelBuilder.Entity<Student>().Ignore(s => s.LocalCalculation);

            modelBuilder.Entity<Student>().Property(s => s.IsRegularStudent).HasDefaultValue(false);

            //modelBuilder.Entity<Student>()
            //   .HasData(
            //       new Student
            //       {
            //           Id = 1,
            //           Name = "John Doe",
            //           Age = 30
            //       },
            //       new Student
            //       {
            //           Id = 2,
            //           Name = "Jane Doe",
            //           Age = 25
            //       }
            //   );

            //modelBuilder.ApplyConfiguration(new StudentConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
    }
}

