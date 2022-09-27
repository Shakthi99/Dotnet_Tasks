using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WFM_Models.Models
{
    public class WFMContext:DbContext
    {
        #region Constructor
        public WFMContext(DbContextOptions options) : base(options)
        {
        }
        #endregion



        #region Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureModels(modelBuilder);



        }
        #endregion



        #region Models Configuration
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<decimal>().HavePrecision(5, 0);
            configurationBuilder.Properties<string>().HaveColumnType("varchar");
        }



        private static void ConfigureModels(ModelBuilder modelBuilder)
        {
            #region Entity: Skills
            modelBuilder.Entity<Skills>().ToTable("Skills");
            modelBuilder.Entity<Skills>().Property(x => x.name).IsRequired().HasMaxLength(30);
            #endregion



            #region Entity: Employee
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Employee>().Property(x => x.name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.status).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.manager).HasMaxLength(30);
            modelBuilder.Entity<Employee>().Property(x => x.wfm_manager).HasMaxLength(30);
            modelBuilder.Entity<Employee>().Property(x => x.email);
            modelBuilder.Entity<Employee>().Property(x => x.lockstatus).HasMaxLength(30);
            modelBuilder.Entity<Employee>().Property(x => x.experience).HasColumnType("decimal(5,0)");
            modelBuilder.Entity<Employee>().Property(x => x.profile_id).HasColumnType("decimal(5,0)");
            #endregion



            #region Entity: User
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Users>().Property(x => x.username).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Users>().Property(x => x.password).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Users>().Property(x => x.name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Users>().Property(x => x.role).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Users>().Property(x => x.email);
            #endregion



            #region Entity: Softlock
            modelBuilder.Entity<Softlock>().ToTable("Softlocks");
            modelBuilder.Entity<Softlock>().Property(x => x.manager).HasMaxLength(30);
            modelBuilder.Entity<Softlock>().Property(x => x.reqdate);
            modelBuilder.Entity<Softlock>().Property(x => x.status).HasMaxLength(30);
            modelBuilder.Entity<Softlock>().Property(x => x.lastupdated);
            modelBuilder.Entity<Softlock>().Property(x => x.requestmessage);
            modelBuilder.Entity<Softlock>().Property(x => x.wfmremark);
            modelBuilder.Entity<Softlock>().Property(x => x.managerstatus).HasMaxLength(30).HasDefaultValue("awaiting_approval");
            modelBuilder.Entity<Softlock>().Property(x => x.mgrstatuscomment);
            modelBuilder.Entity<Softlock>().Property(x => x.mgrlastupdate);
            modelBuilder.Entity<Softlock>().HasOne(e => e.Employee).WithMany(b => b.softlocks).HasForeignKey(c => c.employee_id).OnDelete(DeleteBehavior.NoAction);
            #endregion



            #region Entity: SkillMap
            modelBuilder.Entity<Skillmap>().ToTable("SkillMaps");
            modelBuilder.Entity<Skillmap>().HasOne(a => a.employee).WithMany(b => b.skillMaps).HasForeignKey(c => c.employee_id).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Skillmap>().HasOne(a => a.skills).WithMany(b => b.skillMaps).HasForeignKey(c => c.skillid).OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
        #endregion
    }
}
