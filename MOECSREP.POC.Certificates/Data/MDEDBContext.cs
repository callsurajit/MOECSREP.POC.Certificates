using Microsoft.EntityFrameworkCore;
using MOECSREP.POC.Certificates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOECSREP.POC.Certificates.Data
{
    public class MDEDBContext : DbContext
    {
        public MDEDBContext(DbContextOptions<MDEDBContext> options) : base(options)
        {
        }

        public DbSet<MOECSREP.POC.Certificates.Models.Certificate> Certificates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map entities to tables  
            modelBuilder.Entity<MOECSREP.POC.Certificates.Models.Certificate>().ToTable("EducatorCertificate");
        }
    }
}
