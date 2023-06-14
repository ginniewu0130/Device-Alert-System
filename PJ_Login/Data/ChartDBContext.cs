using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PJ_Login.Models;

#nullable disable

namespace PJ_Login.Data
{
    public partial class ChartDBContext : DbContext
    {
        public ChartDBContext()
        {
        }

        public ChartDBContext(DbContextOptions<ChartDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Output> Outputs { get; set; }
        public virtual DbSet<Output3> Output3s { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Output>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("output");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.ApplicationCategory)
                    .HasMaxLength(50)
                    .HasColumnName("Application_Category");

                entity.Property(e => e.ApplicationList)
                    .HasMaxLength(50)
                    .HasColumnName("Application_List");

                entity.Property(e => e.Attack).HasMaxLength(50);

                entity.Property(e => e.AttackId)
                    .HasMaxLength(50)
                    .HasColumnName("Attack_ID");

                entity.Property(e => e.CoreRuleAction).HasColumnName("Core_Rule_Action");

                entity.Property(e => e.CoreRuleLevel)
                    .HasMaxLength(50)
                    .HasColumnName("Core_Rule_Level");

                entity.Property(e => e.CoreRuleSetScore).HasColumnName("Core_Rule_Set_score");

                entity.Property(e => e.Date2).HasColumnType("date");

                entity.Property(e => e.DevId)
                    .HasMaxLength(50)
                    .HasColumnName("Dev_ID");

                entity.Property(e => e.DevName)
                    .HasMaxLength(50)
                    .HasColumnName("Dev_Name");

                entity.Property(e => e.Device).HasMaxLength(50);

                entity.Property(e => e.Direction).HasMaxLength(50);

                entity.Property(e => e.DstCountry)
                    .HasMaxLength(50)
                    .HasColumnName("Dst_Country");

                entity.Property(e => e.DstInterface)
                    .HasMaxLength(50)
                    .HasColumnName("Dst_Interface");

                entity.Property(e => e.DstInterfaceRole)
                    .HasMaxLength(50)
                    .HasColumnName("Dst_Interface_Role");

                entity.Property(e => e.DstIp)
                    .HasMaxLength(50)
                    .HasColumnName("Dst_IP");

                entity.Property(e => e.DstPort).HasColumnName("Dst_Port");

                entity.Property(e => e.Error).HasMaxLength(50);

                entity.Property(e => e.EventTime).HasColumnName("Event_Time");

                entity.Property(e => e.EventType)
                    .HasMaxLength(1)
                    .HasColumnName("Event_Type");

                entity.Property(e => e.Incidentserialno).HasMaxLength(50);

                entity.Property(e => e.LogDescription)
                    .HasMaxLength(1)
                    .HasColumnName("Log_description");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.Message).HasMaxLength(50);

                entity.Property(e => e.Month).HasMaxLength(50);

                entity.Property(e => e.PolicyId).HasColumnName("Policy_ID");

                entity.Property(e => e.PolicyType)
                    .HasMaxLength(50)
                    .HasColumnName("Policy_type");

                entity.Property(e => e.PolicyUuid)
                    .HasMaxLength(50)
                    .HasColumnName("Policy_UUID");

                entity.Property(e => e.Profile).HasMaxLength(50);

                entity.Property(e => e.QueryClass)
                    .HasMaxLength(50)
                    .HasColumnName("Query_Class");

                entity.Property(e => e.QueryName)
                    .HasMaxLength(50)
                    .HasColumnName("Query_Name");

                entity.Property(e => e.QueryType)
                    .HasMaxLength(50)
                    .HasColumnName("Query_Type");

                entity.Property(e => e.QueryTypeValue)
                    .HasMaxLength(50)
                    .HasColumnName("Query_Type_Value");

                entity.Property(e => e.RecoveredByte).HasColumnName("Recovered_Byte");

                entity.Property(e => e.RecoveredPkt).HasColumnName("Recovered_PKT");

                entity.Property(e => e.Reference).HasMaxLength(50);

                entity.Property(e => e.ResponseCode)
                    .HasMaxLength(50)
                    .HasColumnName("Response_Code");

                entity.Property(e => e.SentByte).HasColumnName("Sent_Byte");

                entity.Property(e => e.SentPkt).HasColumnName("Sent_PKT");

                entity.Property(e => e.Service).HasMaxLength(50);

                entity.Property(e => e.SessionId).HasColumnName("Session_ID");

                entity.Property(e => e.Severity).HasMaxLength(50);

                entity.Property(e => e.SrcCountry)
                    .HasMaxLength(50)
                    .HasColumnName("Src_Country");

                entity.Property(e => e.SrcInterface)
                    .HasMaxLength(50)
                    .HasColumnName("Src_Interface");

                entity.Property(e => e.SrcInterfaceRole)
                    .HasMaxLength(50)
                    .HasColumnName("Src_Interface_Role");

                entity.Property(e => e.SrcIp)
                    .HasMaxLength(50)
                    .HasColumnName("Src_IP");

                entity.Property(e => e.SrcPort).HasColumnName("Src_Port");

                entity.Property(e => e.Subtype).HasMaxLength(50);

                entity.Property(e => e.TimeZone)
                    .HasMaxLength(50)
                    .HasColumnName("Time_Zone");

                entity.Property(e => e.Trandisp).HasMaxLength(50);

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(50)
                    .HasColumnName("Transaction_ID");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.VirtualDomain)
                    .HasMaxLength(50)
                    .HasColumnName("Virtual_Domain");
            });

            modelBuilder.Entity<Output3>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("output_3");

                entity.Property(e => e.SubType).HasColumnName("Sub_Type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
