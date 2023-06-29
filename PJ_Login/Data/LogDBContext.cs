using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PJ_Login.Models;

#nullable disable

namespace PJ_Login.Data
{
    public partial class LogDBContext : DbContext
    {
        public LogDBContext()
        {
        }

        public LogDBContext(DbContextOptions<LogDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chart> Charts { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Chart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("chart");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DestinationIp).HasColumnName("Destination_IP");

                entity.Property(e => e.DistinationPort).HasColumnName("Distination_Port");

                entity.Property(e => e.SourceIp).HasColumnName("Source_IP");

                entity.Property(e => e.SourcePort).HasColumnName("Source_Port");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
