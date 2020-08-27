using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OralHealthManagement.Models;

namespace OralHealthManagement.Data
{
    public class OralHealthManagementContext : DbContext
    {
        public OralHealthManagementContext(DbContextOptions<OralHealthManagementContext> options)
            : base(options)
        {
        }

        public DbSet<OralHealthManagement.Models.Demography> Demography { get; set; }
        public DbSet<OralHealthManagement.Models.Routine> Routine { get; set; }
        public DbSet<OralHealthManagement.Models.Routine_IdNo> Routine_IdNo { get; set; }
        public DbSet<OralHealthManagement.Models.Lung> Lung { get; set; }
        public DbSet<OralHealthManagement.Models.Lung_IdNo> Lung_IdNo { get; set; }
        public DbSet<OralHealthManagement.Models.Exhaust> Exhaust { get; set; }
        public DbSet<OralHealthManagement.Models.Exhaust_IdNo> Exhaust_IdNo { get; set; }
        public DbSet<OralHealthManagement.Models.OHAT> OHAT { get; set; }
        public DbSet<OralHealthManagement.Models.OHAT_IdNo> OHAT_IdNo { get; set; }
        public DbSet<OralHealthManagement.Models.Oral6> Oral6 { get; set; }
        public DbSet<OralHealthManagement.Models.Oral6_IdNo> Oral6_IdNo { get; set; }
        public DbSet<OralHealthManagement.Models.Nutrition> Nutrition { get; set; }
        public DbSet<OralHealthManagement.Models.Nutrition_IdNo> Nutrition_IdNo { get; set; }
    }
}
