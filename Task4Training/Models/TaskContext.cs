using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Task4Training.Models
{
    public class TaskContext : DbContext
    {
        #region Constructor
        public TaskContext(DbContextOptions options) : base(options)
        {
        }
        #endregion

        public DbSet<EmpSkills> Skills { get; set; }
        public DbSet<Emp> Employees { get; set; }
        public DbSet<SkillsMap> Skillmaps { get; set; }

        #region Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureModels(modelBuilder);

        }
        #endregion


        private static void ConfigureModels(ModelBuilder modelBuilder)
        {
            #region Entity: Skills
            modelBuilder.Entity<EmpSkills>().ToTable("Skills");
            modelBuilder.Entity<EmpSkills>().Property(x => x.Name).IsRequired().HasMaxLength(30);
            #endregion

            #region Entity: Employee
            modelBuilder.Entity<Emp>().ToTable("Employees");
            modelBuilder.Entity<Emp>().Property(x => x.EmpName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Emp>().Property(x => x.Status).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Emp>().Property(x => x.Manager).HasMaxLength(30);
            modelBuilder.Entity<Emp>().Property(x => x.WFMmanager).HasMaxLength(30);
            modelBuilder.Entity<Emp>().Property(x => x.Email);
            modelBuilder.Entity<Emp>().Property(x => x.Lockstatus).HasMaxLength(30);
            modelBuilder.Entity<Emp>().Property(x => x.Experience).HasColumnType("decimal(5,0)");
            modelBuilder.Entity<Emp>().Property(x => x.ProfileID).HasColumnType("decimal(5,0)");
            #endregion

            #region Entity: SkillMap
            modelBuilder.Entity<SkillsMap>().ToTable("SkillMap");
            modelBuilder.Entity<SkillsMap>().HasKey(c => new { c.EmployeeID, c.SkillID });
            modelBuilder.Entity<SkillsMap>().HasOne(a => a.employee).WithMany(b => b.skillmap).HasForeignKey(c => c.EmployeeID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SkillsMap>().HasOne(a => a.skills).WithMany(b => b.skillmap).HasForeignKey(c => c.SkillID).OnDelete(DeleteBehavior.NoAction);
            #endregion



        }

        
    }
}

    
